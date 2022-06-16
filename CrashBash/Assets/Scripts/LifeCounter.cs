using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Text lifeCounter;
    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        switch(this.name)
        {
            case "Jugador 1":                                                   // Si es el jugador 1 se actualiza el score con su variable estatica
                lifeCounter.text = ScoreManager.playerCounter[0].ToString();
                break;
            case "Jugador 2":                                                   // Si es el jugador 2 se actualiza el score con su variable estatica
                lifeCounter.text = ScoreManager.playerCounter[1].ToString();
                break;
            case "Jugador 3":                                                   // Si es el jugador 3 se actualiza el score con su variable estatica
                lifeCounter.text = ScoreManager.playerCounter[2].ToString();
                break;
            case "Jugador 4":                                                   // Si es el jugador 4 se actualiza el score con su variable estatica
                lifeCounter.text = ScoreManager.playerCounter[3].ToString();
                break;
        }
    }
}
