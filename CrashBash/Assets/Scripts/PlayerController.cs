using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform pivot;
    public float inercia_base = 2f;   // Inercia base
    public float inercia_maxima  = 3f;   // Inercia maxima
    private float inercia_izq;   // Medicion momentum hacia la izquierda
    private float inercia_der;  // Medicion momentum hacia la derecha
    private Vector3 initialVector = Vector3.forward;
    public float angleMax = 30.0f;

    private float inputValue;

    // Start is called before the first frame update
    void Start()
    {
        initialVector = transform.localPosition - pivot.transform.localPosition;
        initialVector.y = 0;

        inercia_izq = inercia_base;    // De primeras la velocidad hacia la izuierda y derecha
        inercia_der = inercia_base;   // son las velocidad base
    }

    public void MoveExec(InputAction.CallbackContext context){
        inputValue = context.ReadValue<float>();
    }

    // Update is called once per frame

    void Update () {
        //float inputValue =  playerInputActions.Player.Movement.ReadValue<float>();
        //Debug.Log(inputValue);
        if(pivot != null){
            float rotateDegrees = 0f;

            if(inputValue < 0.0f){
                if(inercia_izq < inercia_maxima){        // Si es menor que la inercia maxima
                    inercia_izq += 1f * Time.deltaTime;  // se aumenta el momentum 
                }
//                rotateDegrees += 70f * Time.deltaTime;
                inercia_der = inercia_base;
            }

            if(inputValue > 0.0f){
                if(inercia_der < inercia_maxima){            // Si es menor que la velocidad maxima
                    inercia_der += 1f * Time.deltaTime; // se aumenta el momentum
                }
//                rotateDegrees -= 70f * Time.deltaTime;
                inercia_izq = inercia_base;
            }

            rotateDegrees -= 70f * inputValue * Time.deltaTime;

            Vector3 currentVector = transform.localPosition - pivot.localPosition;
            currentVector.y = 0;
            float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).y > 0 ? 1 : -1);            
            float newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -angleMax, angleMax);            // Hay que ajustar el angulo para que no choque con las turbinas
            rotateDegrees = newAngle - angleBetween;

            if(inercia_izq > inercia_base && /*!Input.GetKey("a")*/ inputValue == 0.0f && newAngle < 30f){ // Si se deja de pulsar la a  (IMPORTANTE: IGUAL HAY QUE MODIFICAR EL 30 PARA AJUSTAR BIEN)
                transform.RotateAround(pivot.localPosition, pivot.up, 70f * Time.deltaTime / inercia_izq); // Se sigue avanzando hacia la izq simulando la inercia
                inercia_izq -= 1f * Time.deltaTime;   // y se va reduciendo la inercia

            }
            else if(inercia_der > inercia_base && /*!Input.GetKey("d")*/ inputValue == 0.0f && newAngle > -30f){ // Si se deja de pulsar la d (IMPORTANTE: IGUAL HAY QUE MODIFICAR EL 30 PARA AJUSTAR BIEN)
                transform.RotateAround(pivot.localPosition, pivot.up, -70f * Time.deltaTime / inercia_izq); // Se sigue avanzando hacia la der simulando la inercia
                inercia_der -= 1f * Time.deltaTime;   // y se va reduciendo la inercia

            }
            else{
                transform.RotateAround(pivot.localPosition, pivot.up, rotateDegrees);
            }
            
            //Debug.Log(angleBetween);
            //Debug.Log(rotateDegrees);
        }
    
    }
}

