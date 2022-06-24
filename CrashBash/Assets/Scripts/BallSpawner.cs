using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] spawners;   // Array de los lanzadores
    public Rigidbody bola; // Prefab de la bola

    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating("SpawnBall", 3f, /*3f*/Random.Range(1.5f,3f)); //Ejecutar SpawnBall, delay de inicio 3 seg, en intervalos de 1,5 a 3 seg
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.finJuego)
        {
            GameObject other = GameObject.Find("Bola(Clone)");
            Destroy(other);
        }
    }

    void SpawnBall()
    {
        if(!ScoreManager.finJuego && !ScoreManager.instruccionesJuego)
        {
            int indexSpawner = Random.Range(0,4);   // Selecciona un spawner al azar
            Rigidbody projectileInstance;
            float desviacionRandom = Random.Range(1500f,2000f); // Desvio para el lanzamiento
            int masMenos = Random.Range(0,2)*2-1;               // random +1 -1
            Transform extremoCanon = spawners[indexSpawner].transform.GetChild(0).transform.GetChild(0);    // obtener el extremo del canion que es el hijo del hijo
            extremoCanon.transform.Rotate(0f,0f,desviacionRandom*masMenos*Time.deltaTime);                  // se gira con la desviacion calculada
            projectileInstance = Instantiate(bola, extremoCanon.position, extremoCanon.rotation) as Rigidbody;  // se instancia una bola
            projectileInstance.AddForce(extremoCanon.up * -2000f);                                              // se aplica una fuerza
            extremoCanon.Rotate(0f,0f,-desviacionRandom*masMenos*Time.deltaTime);                               // se recoloca el extremo del canion
        }

    }
}
