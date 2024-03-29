using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SwitchActionMap : MonoBehaviour
{
    //public GameObject thisObject;       // Referencia al objeto
    private PlayerInput controlMap;     // Referencia al componente input player para hacer el cambio de ActionMap
    private bool switchedMap = false;   // Variable de control

    private void Awake() {
        controlMap = GetComponent<PlayerInput>();    // Inicializacion
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(controlMap.playerIndex);        // IMPORTANTE: ESTO INDICA EL INDEX DE ENTRADA EN LA SALA Y ES MUY UTIL PARA IDENTIFICAR QUE JUGADOR ES
    }

    // Update is called once per frame
    void Update()   
    {                                   // Switch case con el idex para poder identificar que jugador es y hacer el cambio de Action map
        if(SceneManager.GetActiveScene().name == "BallistixGame")
        {
            //Debug.Log(controlMap.currentActionMap);
            if(!ScoreManager.instruccionesJuego && controlMap.currentActionMap.name == "Menu")       // Si ya se han leido las instrucciones y el action map es el menu
            {
                controlMap.SwitchCurrentActionMap("Player");                                    // Se cambia el action map al del player para jugar
            }

            if(PauseMenu.gamePaused && controlMap.currentActionMap.name == "Player")            // Si el juego se para y el action map es Player 
            {
                controlMap.SwitchCurrentActionMap("Menu");                                      // Se cambia al de menu
            }

            if(!PauseMenu.gamePaused && !ScoreManager.instruccionesJuego && controlMap.currentActionMap.name == "Menu")   // Si el juego no esta parado
            {                                                                                                             // no estamos en las instrucciones
                controlMap.SwitchCurrentActionMap("Player");                                                              // y el action map es el menu
            }                                                                                                             // se cambia el action map al de player

            switch (controlMap.playerIndex)             
            {
                // JUGADOR 1
                case 0:
                    if((ScoreManager.playerCounter[0] <= 0 || ScoreManager.finJuego) && !switchedMap)        //  Si el score es menor o igual a 0 y no se ha hecho el cambio de Mapa 
                    {
                        //controlMap.actions.FindActionMap("Player").Disable();
                        controlMap.SwitchCurrentActionMap("Menu");
                    }
                    break;
                
                // JUGADOR 2
                case 1:
                    if((ScoreManager.playerCounter[1] <= 0 || ScoreManager.finJuego) && !switchedMap)        //  Si el score es menor o igual a 0 y no se ha hecho el cambio de Mapa 
                    {
                        //controlMap.actions.FindActionMap("Player").Disable();
                        controlMap.SwitchCurrentActionMap("Menu");
                    }
                    break;
                
                // JUGADOR 3
                case 2:
                    if((ScoreManager.playerCounter[2] <= 0 || ScoreManager.finJuego) && !switchedMap)        //  Si el score esmenor i gual a 0 y no se ha hecho el cambio de Mapa 
                    {
                        //controlMap.actions.FindActionMap("Player").Disable();
                        controlMap.SwitchCurrentActionMap("Menu");
                    }
                    break;

                // JUGADOR 4
                case 3:
                    if((ScoreManager.playerCounter[3] <= 0 || ScoreManager.finJuego) && !switchedMap)        //  Si el score esmenor i gual a 0 y no se ha hecho el cambio de Mapa 
                    {
                        //controlMap.actions.FindActionMap("Player").Disable();
                        controlMap.SwitchCurrentActionMap("Menu");
                    }
                    break;     
            }
        }
    }
}
