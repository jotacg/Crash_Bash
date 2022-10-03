using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShockWaveForce : MonoBehaviour
{
    private Collider[] hitColliders;
    private float blastRadius = 7f;      // Radio de la explsion
    public LayerMask shockLayers;   // Layers afectadas
    private float shockWavePower = 90f;   // Fuerza de la explosion
    private float timer = 2f;       // Variable para contar el tiempo entre shockwaves
    private float timerRange = 1.5f;
    [SerializeField] GameObject shockParticle;
    private PlayerInput playerInput;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

/*        
        if(timer >= timerRange && Input.GetKey("space"))    // Intervalos de 1.5 segundos para que no se utilice todo el rato
        {
            timer = 0f;                                     // resetea el timer
            ShockWave();                                    // Aplica la fuerza
            DisplayParticle();
            
        }
*/
        if(timer < timerRange)                              // Si es menor que el intervalo de tiempo
        {
            timer += Time.deltaTime;                        // Se suma un seg
        }

    }

    public void ExecShockWave(InputAction.CallbackContext context)
    {
        if(timer >= timerRange)    // Intervalos de 1.5 segundos para que no se utilice todo el rato
        {
            timer = 0f;                                     // resetea el timer
            this.GetComponent<AudioSource>().Play();
            ShockWaveVFX();                                    // Aplica la fuerza
            DisplayParticle();
            
        }
    }
    void ShockWaveVFX()
    {
        hitColliders = Physics.OverlapSphere(this.transform.position, blastRadius, shockLayers); // Se usa esto para aplicar la explosion solo a las bolas

        foreach (var item in hitColliders)      // Todas las pelotas en el radio que se les aplicara la fuerza
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;         // Reset the la fuerza de la bola para que al aplicar 
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;  // la fuerza en la direccion contraria no vaya lenta
            item.GetComponent<Rigidbody>().AddExplosionForce(shockWavePower, this.transform.position, 0, 0, ForceMode.Impulse);
        }
        
    }

    void DisplayParticle()
    {
        GameObject particle = Instantiate(shockParticle,this.transform);
    }
}
