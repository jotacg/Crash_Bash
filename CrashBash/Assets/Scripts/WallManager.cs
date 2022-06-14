using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject barreraPlayer1;
    public GameObject barreraPlayer2;    // Este objeto sirve para activar y desactivar barreras de 
    public GameObject barreraPlayer3;
    public GameObject barreraPlayer4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // JUGADOR 1
        if(MultiplayerSpawner.jugador1)         // Si el jugador 1 esta en la partida
        {
            barreraPlayer1.SetActive(false);    // Se desactiva la barrera de su lado
        }
        if(ScoreManager.player1Counter <= 0)
        {
            barreraPlayer1.SetActive(true);
        }

        // JUGADOR 2
        if(MultiplayerSpawner.jugador2)         // Si el jugador 2 esta en la partida
        {
            barreraPlayer2.SetActive(false);    // Se desactiva la barrera de su lado
        }
        if(ScoreManager.player2Counter <= 0)
        {
            barreraPlayer2.SetActive(true);
        }

        // JUGADOR 3
        if(MultiplayerSpawner.jugador3)         // Si el jugador 3 esta en la partida
        {
            barreraPlayer3.SetActive(false);    // Se desactiva la barrera de su lado
        }
        if(ScoreManager.player3Counter <= 0)
        {
            barreraPlayer3.SetActive(true);
        }

        // JUGADOR 4
        if(MultiplayerSpawner.jugador4)         // Si el jugador 4 esta en la partida
        {
            barreraPlayer4.SetActive(false);    // Se desactiva la barrera de su lado
        }
        if(ScoreManager.player4Counter <= 0)
        {
            barreraPlayer4.SetActive(true);
        }
    }
}
