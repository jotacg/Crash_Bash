using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public static int player1Counter;   // Vidas de los jugadores
    //public static int player2Counter;
    //public static int player3Counter;
    //public static int player4Counter;

    public static int[] playerCounter;
    public static int[] activePlayer;

    private int playersLeft;
    public static bool finJuego;
    public static bool instruccionesJuego;

    public GameObject fin;              // Texto al acabar la partida
    public GameObject rules;     // Texto unicial con las reglas

    public TextMeshProUGUI winnerPlayer;

    private void Awake()
    {
        finJuego = false;
        instruccionesJuego = true;
        playerCounter = new int[] {10, 10, 10, 10};
        activePlayer = new int[]  {1, 1, 1, 1};
        playersLeft = PlayerConfigurationManager.Instance.GetPlayerConfigs().Count; // Numero de jagadores qeu quedan -> Se inicializa con el count de la lista
    }
    // Start is called before the first frame update
    void Start()
    {
        //player1Counter = player2Counter = player3Counter = player4Counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*                          AQUI HAY QUE PONER CUANDO SOLO QUEDE UN JUGADOR VIVO QUE SE ACABE EL JUEG,
        if(player1Counter <= 0)                                                          QUE NO SE LANCEN MAS BOLAS,
        {                                                                                QUE APAREZCA EL NOMBRE DEL GANADOR
            fin.SetActive(true);                                                         QUE APAREZCA UN MENU PARA VOLVER A JUGAR O IR A MENU GENERAL
        */

        if(playersLeft == 1 && !finJuego){
            for(int i = 0; i < PlayerConfigurationManager.Instance.GetPlayerConfigs().Count; i++)
            {
                if(playerCounter[i] > 0)
                {
                    //Debug.Log("Gano el jugador " + (i+1));
                    winnerPlayer.SetText("Player " + (i+1) + " wins!");
                    finJuego = true;
                    rules.SetActive(false);
                    fin.SetActive(true);
                }
            }
        }

        if(playerCounter[0] <= 0 && activePlayer[0] > 0)
        {
            playersLeft--;
            activePlayer[0]--;
        }
        if(playerCounter[1] <= 0 && activePlayer[1] > 0)
        {
            playersLeft--;
            activePlayer[1]--;
        }
        if(playerCounter[2] <= 0 && activePlayer[2] > 0)
        {
            playersLeft--;
            activePlayer[2]--;
        }
        if(playerCounter[3] <= 0 && activePlayer[3] > 0)
        {
            playersLeft--;
            activePlayer[3]--;
        }
    }
}
