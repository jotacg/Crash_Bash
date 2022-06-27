using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPauseMenu : MonoBehaviour
{

    public GameObject MenuPanel;
    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.gamePaused)
        {
            MenuPanel.SetActive(true);
        }
        else
        {
            MenuPanel.SetActive(false);
        }
    }
}
