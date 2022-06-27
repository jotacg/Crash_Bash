using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UImanager : MonoBehaviour
{
    public GameObject profilePlayer2;    // Este objeto sirve para activar y desactivar el perfil de los jugadores
    public GameObject profilePlayer3;
    public GameObject profilePlayer4;

    public GameObject iconPlayer2;
    public GameObject iconPlayer3;
    public GameObject iconPlayer4;

    // Start is called before the first frame update
    void Start()
    {
        profilePlayer2.SetActive(false);
        profilePlayer3.SetActive(false);
        profilePlayer4.SetActive(false);

        iconPlayer2.SetActive(false);
        iconPlayer3.SetActive(false);
        iconPlayer4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerConfigurationManager.jugador2)         // Si el jugador 2 esta en la partida
        {
            iconPlayer2.SetActive(true);
            profilePlayer2.SetActive(true);    // Se desactiva la barrera de su lado
        }
        if(PlayerConfigurationManager.jugador3)         // Si el jugador 3 esta en la partida
        {
            iconPlayer3.SetActive(true);
            profilePlayer3.SetActive(true);    // Se desactiva la barrera de su lado
        }
        if(PlayerConfigurationManager.jugador4)         // Si el jugador 4 esta en la partida
        {
            iconPlayer4.SetActive(true);
            profilePlayer4.SetActive(true);    // Se desactiva la barrera de su lado
        }
    }
}
