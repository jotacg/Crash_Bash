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

    public static bool jugador1 = false;    // Variable global para saber si el jugador uno esta en la partida (true) o no (false)
    public static bool jugador2 = false;    // Variable global para saber si el jugador dos esta en la partida (true) o no (false)
    public static bool jugador3 = false;    // Variable global para saber si el jugador tres esta en la partida (true) o no (false)
    public static bool jugador4 = false;    // Variable global para saber si el jugador cuatro esta en la partida (true) o no (false)

    public static int numJugadores = 0;     // Variable para llevar la cuenta de los jugadores en la sala
    
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
        playerList.Add(playerInput);                // Añade un jugador a la partida
        switch(playerList.Count)
        {                               // Cuando vayan entrando los jugadores sus variables de cotrol se iran poniendo a true
            case 1:
                jugador1 = true;
                break;
            case 2:
                jugador2 = true;
                break;
            case 3:
                jugador3 = true;
                break;
            case 4:
                jugador4 = true;
                break;
        }

        numJugadores++;

        playerInput.transform.parent.localEulerAngles = spawnPoints[playerList.Count - 1].transform.localEulerAngles;   // Comprueba los puntos de spawneo y pone al jugador en el primero no ocupado
        //Debug.Log(spawnPoints[0].transform.localEulerAngles);

    }

    void OnPlayerLeft(PlayerInput playerInput){

        Debug.Log("Se desconectó");

        switch(playerList.Count)
        {                               // Cuando vayan entrando los jugadores sus variables de cotrol se iran poniendo a true
            case 0:
                jugador1 = false;
                break;
            case 1:
                jugador2 = false;
                break;
            case 2:
                jugador3 = false;
                break;
            case 3:
                jugador4 = false;
                break;
        }

        numJugadores--;
    }

    private void Update()
    {
        if(ScoreManager.playerCounter[0] <= 0)
        {
            //playerList.
        }
    }
}
