using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchActionMap : MonoBehaviour
{
    public GameObject thisObject;       // Referencia al objeto
    private PlayerInput controlMap;     // Referencia al componente input player para hacer el cambio de ActionMap
    private bool switchedMap = false;   // Variable de control

    private void Awake() {
        controlMap = thisObject.GetComponent<PlayerInput>();    // Inicializacion
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(controlMap.playerIndex);        // IMPORTANTE: ESTO INDICA EL INDEX DE ENTRADA EN LA SALA Y ES MUY UTIL PARA IDENTIFICAR QUE JUGADOR ES
    }

    // Update is called once per frame
    void Update()   
    {                                   // Switch case con el idex para poder identificar que jugador es y hacer el cambio de Action map
        switch (controlMap.playerIndex)             
        {
            // JUGADOR 1
            case 0:
                if(ScoreManager.player1Counter <= 0 && !switchedMap)        //  Si el score es menor o igual a 0 y no se ha hecho el cambio de Mapa 
                {
                    //Debug.Log("aaaa");
                    //controlMap.actions.FindActionMap("Player").Disable();
                    controlMap.SwitchCurrentActionMap("Menu");
                }
                break;
            
            // JUGADOR 2
            case 1:
                if(ScoreManager.player2Counter <= 0 && !switchedMap)        //  Si el score es menor o igual a 0 y no se ha hecho el cambio de Mapa 
                {
                    //Debug.Log("aaaa");
                    //controlMap.actions.FindActionMap("Player").Disable();
                    controlMap.SwitchCurrentActionMap("Menu");
                }
                break;
            
            // JUGADOR 3
            case 2:
                if(ScoreManager.player3Counter <= 0 && !switchedMap)        //  Si el score esmenor i gual a 0 y no se ha hecho el cambio de Mapa 
                {
                    //Debug.Log("aaaa");
                    //controlMap.actions.FindActionMap("Player").Disable();
                    controlMap.SwitchCurrentActionMap("Menu");
                }
                break;

            // JUGADOR 4
            case 3:
                if(ScoreManager.player4Counter <= 0 && !switchedMap)        //  Si el score esmenor i gual a 0 y no se ha hecho el cambio de Mapa 
                {
                    //Debug.Log("aaaa");
                    //controlMap.actions.FindActionMap("Player").Disable();
                    controlMap.SwitchCurrentActionMap("Menu");
                }
                break;
                
        }

    }
}
