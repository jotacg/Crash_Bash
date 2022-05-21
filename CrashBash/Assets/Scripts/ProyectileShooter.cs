using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileShooter : MonoBehaviour
{
    // este script se usa para probar el lanzamiento de bolas con la "w"
    public Rigidbody bola; // Prefab de la bola
    public Transform extremoCanon;  // GameObject desde donde sale la bola
    private Vector3 InitialRotation;
    // Start is called before the first frame update
    void Start()
    {
        InitialRotation = new Vector3 (extremoCanon.rotation.x,extremoCanon.rotation.y,extremoCanon.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            Rigidbody projectileInstance;
            float desviacionRandom = Random.Range(1500f,2000f);
            int masMenos = Random.Range(0,2)*2-1;
            extremoCanon.Rotate(0f,0f,desviacionRandom*masMenos*Time.deltaTime);
            projectileInstance = Instantiate(bola, extremoCanon.position, extremoCanon.rotation) as Rigidbody;
            projectileInstance.AddForce(extremoCanon.up * -2000f);
            extremoCanon.Rotate(0f,0f,-desviacionRandom*masMenos*Time.deltaTime);

            Debug.Log(masMenos);
        }
    }
}
