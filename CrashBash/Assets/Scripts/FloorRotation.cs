using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("e")){
            transform.Rotate(0f,0f,40f * Time.deltaTime);
        }
        if(Input.GetKey("q")){
            transform.Rotate(0f,0f,-40f * Time.deltaTime);
        }
        if(Input.GetKey("r")){
            transform.Rotate(0.2f,0f,0f * Time.deltaTime);
        }
        if(Input.GetKey("t")){
            transform.Rotate(-0.2f,0f,0f * Time.deltaTime);
        }
    }
}
