using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
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
        if(MultiplayerSpawner.jugador2)         // Si el jugador 2 esta en la partida
        {
            barreraPlayer2.SetActive(false);    // Se desactiva la barrera de su lado
        }
        if(MultiplayerSpawner.jugador3)         // Si el jugador 3 esta en la partida
        {
            barreraPlayer3.SetActive(false);    // Se desactiva la barrera de su lado
        }
        if(MultiplayerSpawner.jugador4)         // Si el jugador 4 esta en la partida
        {
            barreraPlayer4.SetActive(false);    // Se desactiva la barrera de su lado
        }
    }
}
