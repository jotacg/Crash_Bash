using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerSpawner : MonoBehaviour
{
    public List<PlayerInput> playerList = new List<PlayerInput>();
    public GameObject[] spawnPoints;
    // Instances
    public static MultiplayerSpawner instance = null;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else if(instance != null){
            Destroy(gameObject);
        }
    }

    private void Start(){
        PlayerInputManager.instance.JoinPlayer(0, -1, null);
    }

    void OnPlayerJoined(PlayerInput playerInput){
        playerList.Add(playerInput);
        playerInput.transform.parent.localEulerAngles = spawnPoints[playerList.Count - 1].transform.localEulerAngles;
        Debug.Log(spawnPoints[0].transform.localEulerAngles);
    }

    void OnPlayerLeft(PlayerInput playerInput){
        
    }
}
