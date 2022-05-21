using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiltPlayerEffect : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private PlayerInput playerInput;
    private float zRotation;
    private float inputValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TiltExec(InputAction.CallbackContext context){
        inputValue = context.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        //float inputValue =  playerInputActions.Player.Movement.ReadValue<float>();

        zRotation = transform.localRotation.z;   // 0.1 <-> -0,1     // Controlar la rotacion maxima
        if(/*Input.GetKey("a")*/ inputValue < 0.0f && zRotation < 0.1f){              // Si se va a la izq y es menor que la rotacion maxima
            transform.Rotate(0f,0f,70f * Time.deltaTime);       // se rota hacia ese lado
        }

        if(/*Input.GetKey("d")*/ inputValue > 0.0f && zRotation > -0.1f){             // Si se va a la der y es menor que la rotacion maxima
            transform.Rotate(0f,0f,-70f * Time.deltaTime);      // se rota hacia ese lado
        }

        if(/*!Input.GetKey("a") && !Input.GetKey("d")*/ inputValue == 0.0f){           // En caso de que no se vaya ni a la izq ni a la der
            if(zRotation < 0f){                                 // si se viene de la der se rota a la izq para recuperar la pos inicial
                transform.Rotate(0f,0f,70f * Time.deltaTime);
            }
            if(zRotation > 0f){                                 // y si se viene de la izq se rota havcia la der para recuperar la pos inicial
                transform.Rotate(0f,0f,-70f * Time.deltaTime);
            }
        }
    }

}
