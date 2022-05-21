using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBall : MonoBehaviour
{
    // Esto no me sirve por ahora
    public Vector3 capturePos;
    private float offsetX;
    private float offsetZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bola(Clone)" && Input.GetKey("space"))  
        {
            var playerTransform = this.transform;

            collision.rigidbody.isKinematic = true;
            collision.transform.position = playerTransform.position;

            Debug.Log("entra");
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bola(Clone)" && Input.GetKey("space"))  
        {
            //Debug.Log("Entra");
            capturePos = other.transform.position;
            other.GetComponent<Rigidbody>().isKinematic = true;
            offsetX = this.transform.localPosition.x - capturePos.x;
            offsetZ = Mathf.Abs(this.transform.localPosition.z - capturePos.z);
        }
    }

    void OnTriggerStay(Collider other)
    {
       // Debug.Log("Está");
        other.transform.position = this.transform.localPosition + new Vector3(offsetX, 0f, offsetZ);
    }

    void OnTriggerExit(Collider other)
    {
     //   Debug.Log("Sale");
    }
}
