using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
         if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<KeepMusic>().StopMusic();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<KeepMusic>().PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
