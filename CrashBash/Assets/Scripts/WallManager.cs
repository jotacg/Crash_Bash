using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WallManager : MonoBehaviour
{
    public GameObject barreraPlayer1;
    public GameObject barreraPlayer2;    // Este objeto sirve para activar y desactivar barreras de 
    public GameObject barreraPlayer3;
    public GameObject barreraPlayer4;
    public GameObject shockPlayer1;
    public GameObject shockPlayer2;    // Este objeto sirve para activar y desactivar barreras de 
    public GameObject shockPlayer3;
    public GameObject shockPlayer4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // JUGADOR 1
        if(PlayerConfigurationManager.jugador1)         // Si el jugador 1 esta en la partida
        {
            barreraPlayer1.SetActive(false);    // Se desactiva la barrera de su lado
            //shockPlayer1.GetComponent<VisualEffect>().enabled = false;
        }
        else
        {
            shockPlayer1.GetComponent<VisualEffect>().enabled = true;
        }
        if(ScoreManager.playerCounter[0] <= 0)
        {
            barreraPlayer1.SetActive(true);
            shockPlayer1.GetComponent<VisualEffect>().enabled = true;
        }

        // JUGADOR 2
        if(PlayerConfigurationManager.jugador2)         // Si el jugador 2 esta en la partida
        {
            barreraPlayer2.SetActive(false);    // Se desactiva la barrera de su lado
            //shockPlayer2.GetComponent<VisualEffect>().enabled = false;
        }
        else
        {
            shockPlayer2.GetComponent<VisualEffect>().enabled = true;
        }
        if(ScoreManager.playerCounter[1] <= 0)
        {
            barreraPlayer2.SetActive(true);
            shockPlayer2.GetComponent<VisualEffect>().enabled = true;
        }

        // JUGADOR 3
        if(PlayerConfigurationManager.jugador3)         // Si el jugador 3 esta en la partida
        {
            barreraPlayer3.SetActive(false);    // Se desactiva la barrera de su lado
            //shockPlayer3.GetComponent<VisualEffect>().enabled = false;
        }
        else
        {
            shockPlayer3.GetComponent<VisualEffect>().enabled = true;
        }
        if(ScoreManager.playerCounter[2] <= 0)
        {
            barreraPlayer3.SetActive(true);
            shockPlayer3.GetComponent<VisualEffect>().enabled = true;
        }

        // JUGADOR 4
        if(PlayerConfigurationManager.jugador4)         // Si el jugador 4 esta en la partida
        {
            barreraPlayer4.SetActive(false);    // Se desactiva la barrera de su lado
            //shockPlayer4.GetComponent<VisualEffect>().enabled = false;
        }
        else
        {
            shockPlayer4.GetComponent<VisualEffect>().enabled = true;
        }
        if(ScoreManager.playerCounter[3] <= 0)
        {
            barreraPlayer4.SetActive(true);
            shockPlayer4.GetComponent<VisualEffect>().enabled = true;
        }
    }
}
