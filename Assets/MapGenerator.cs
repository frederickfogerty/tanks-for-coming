namespace TanksPlayground
{
    public class MapGenerator //:MonoBehaviour
    {

        private int width; //generate num
        private int height; //generate num

        public Cell[,] Map;
 
        // Use this for initialization
        void Start ()
        {
            GenerateWalls();
            GenerateAreaIDs();
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void GenerateWalls()
        {
            Map = new Cell[width,height];

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i,j] = new Cell();
                }
            }
            
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        Map[i, j].LEFT_WALL = true;
                    }
                    else
                    {
                        Map[i, j].LEFT_WALL = Map[i - 1, j].RIGHT_WALL;
                    }
                    if (i == Map.GetLength(0))
                    {
                        Map[i, j].RIGHT_WALL = true;
                    }
                    else
                    {
                        Map[i, j].RIGHT_WALL = RandomBool();
                    }
                    if (j == 0)
                    {
                        Map[i, j].TOP_WALL = true;
                    }
                    else
                    {
                        Map[i, j].TOP_WALL = Map[i - 1, j].BOTTOM_WALL;
                    }
                    if (j == Map.GetLength(1))
                    {
                        Map[i, j].BOTTOM_WALL = true;
                    }
                    else
                    {
                        Map[i, j].BOTTOM_WALL = RandomBool();
                    }
                }
            }
        }

        public void GenerateAreaIDs()
        {
            int areaId = 0;
            int MaxAreaID = -1;
            int MaxSize = -1;
		
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j].AREA_ID == -1)
                    {
                        int size = exploreArea(i, j, areaId, 0);
                        
                        if (size > MaxSize)
                        {
                            MaxAreaID = areaId;
                        }
                        
                        areaId++;
                    }
				
                }
            }
        }
        

        private int exploreArea(int indexI, int indexJ, int areaId, int count)
        {
            if (Map[indexI, indexJ].AREA_ID != -1)
            {
                return 0;
            }
            
            Map[indexI, indexJ].AREA_ID = areaId;
            count++;
	
            if (indexI > 0 && Map[indexI, indexJ].LEFT_WALL == false) 
            {
			    exploreArea(indexI - 1, indexJ, areaId, count);
            }
            if (indexJ > 0 && Map[indexI, indexJ].TOP_WALL == false) 
            {
                exploreArea(indexI, indexJ - 1, areaId, count);
            }
            if (indexI < Map.GetLength(0) - 1 && Map[indexI, indexJ].RIGHT_WALL == false) 
            {
                exploreArea(indexI + 1, indexJ, areaId, count);
            }
            if (indexI < Map.GetLength(1) - 1 && Map[indexI, indexJ].BOTTOM_WALL == false) 
            {
                exploreArea(indexI, indexJ + 1, areaId, count);
            }
            return count;
        }

        // TODO
        private bool RandomBool()
        {
            return false;
        }
    }
    

    public class Cell
    {
        public bool LEFT_WALL;
        public bool TOP_WALL;
        public bool RIGHT_WALL;
        public bool BOTTOM_WALL;
        public int AREA_ID;

        public Cell()
        {
            LEFT_WALL = false;
            TOP_WALL = false;
            RIGHT_WALL = false;
            BOTTOM_WALL = false;
            AREA_ID = -1;
        }
    }
}