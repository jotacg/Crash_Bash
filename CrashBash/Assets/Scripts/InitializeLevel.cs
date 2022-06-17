using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;

    [SerializeField]
    private GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, playerSpawns[i].transform);
            //player.transform.GetChild(0).transform.position = cameraSpawns[i].position;
            //player.transform.GetChild(0).transform.rotation = cameraSpawns[i].rotation;
            player.GetComponentInChildren<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
            //Debug.Log(player.transform.GetChild(0).transform.position);
            
        }
    }

}
