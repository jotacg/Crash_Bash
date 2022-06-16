using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public static int player1Counter;   // Vidas de los jugadores
    //public static int player2Counter;
    //public static int player3Counter;
    //public static int player4Counter;

    public static int[] playerCounter;

    public GameObject fin;              // Texto al acabar la partida

    public Text lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        //player1Counter = player2Counter = player3Counter = player4Counter = 1;
        playerCounter = new int[] {10, 10, 10, 10};
    }

    // Update is called once per frame
    void Update()
    {
        /*                          AQUI HAY QUE PONER CUANDO SOLO QUEDE UN JUGADOR VIVO QUE SE ACABE EL JUEG,
        if(player1Counter <= 0)                                                          QUE NO SE LANCEN MAS BOLAS,
        {                                                                                QUE APAREZCA EL NOMBRE DEL GANADOR
            fin.SetActive(true);                                                         QUE APAREZCA UN MENU PARA VOLVER A JUGAR O IR A MENU GENERAL
        }                                                                                QUE EL QUE GANA SE LE CAMBIE EL ACTIONMAP AL DE MENU PARA SELECCIONAR QUE HACER
        */
    }
}
