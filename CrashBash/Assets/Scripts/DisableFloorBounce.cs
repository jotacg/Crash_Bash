using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFloorBounce : MonoBehaviour
{
    private bool control = false;
    public PhysicMaterial bounce;
    public GameObject Trigger;
    public GameObject DestroyTrigger;
    public PhysicMaterial StartPhyMat;
    // Start is called before the first frame update
    void Start()
    {
        StartPhyMat = GetComponent<Collider>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)      // para que la cuando salga la bola no rebote y se vaya
    {
        if(control == false)                        // Una vez que toca el suelo se le aplica el physic material
        {
            if (collision.gameObject.name == Trigger.name)  
            {
                GetComponent<Collider>().material = bounce;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;   // Nota: Esto sirve para que no haya bugs de que las bolas boten
                                                                                                // cuando chocan entre ellas (congela el eje y)
               // GetComponent<Collider>().
                control = true;                                 // Variable de control a true para que no se cambie mas
            }
        }

        if (collision.gameObject.name == DestroyTrigger.name)
            {
                Destroy(gameObject);                            // Cuando se cae la bola que se destruya
            }

        
    }
}
