using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int player1Counter;
    public static int player2Counter;
    public static int player3Counter;
    public static int player4Counter;
    // Start is called before the first frame update
    void Start()
    {
        player1Counter = player2Counter = player3Counter = player4Counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Counter <= 0)
        {
            MultiplayerSpawner.jugador1 = false;
        }
    }
}
