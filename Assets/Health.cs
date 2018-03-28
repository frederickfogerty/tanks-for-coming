using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
	public void Hit()
	{
		Debug.Log("Hit");
		if (!isServer)
		{
			return;
		}

		RpcRespawn();
	}

	[ClientRpc]
	private void RpcRespawn()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		transform.position = Vector3.zero;
	}
}
