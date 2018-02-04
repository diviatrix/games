using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

	public GameObject[] playerPrefab,gameMode;
	
	private void Start()
	{
		InstantiatePlayer();
		InstantiateGameMode();
	}

	private void InstantiatePlayer()
	{
		NetworkManager.Instance.PlayerNetworkObject = playerPrefab;
		NetworkManager.Instance.InstantiatePlayer(0,new Vector3(1,1,1),Quaternion.identity,true);
	}
	private void InstantiateGameMode()
	{
		if (NetworkManager.Instance.IsServer)
        {
			NetworkManager.Instance.GameModeNetworkObject = gameMode;
            NetworkManager.Instance.InstantiateGameMode(0, Vector3.zero, Quaternion.identity, true);
        }
	}
}
