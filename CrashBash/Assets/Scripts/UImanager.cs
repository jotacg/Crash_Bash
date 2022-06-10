using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject profilePlayer2;    // Este objeto sirve para activar y desactivar el perfil de los jugadores
    public GameObject profilePlayer3;
    public GameObject profilePlayer4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MultiplayerSpawner.jugador2)         // Si el jugador 2 esta en la partida
        {
            profilePlayer2.SetActive(true);    // Se desactiva la barrera de su lado
        }
        if(MultiplayerSpawner.jugador3)         // Si el jugador 3 esta en la partida
        {
            profilePlayer3.SetActive(true);    // Se desactiva la barrera de su lado
        }
        if(MultiplayerSpawner.jugador4)         // Si el jugador 4 esta en la partida
        {
            profilePlayer4.SetActive(true);    // Se desactiva la barrera de su lado
        }
    }
}
