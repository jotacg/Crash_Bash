using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIcon : MonoBehaviour
{
    public int indexJugador;

    private void Awake()
    {
        this.GetComponent<RawImage>().texture = PlayerConfigurationManager.iconos[indexJugador];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
