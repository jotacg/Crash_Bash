using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneLoader()
    {
        if(sceneIndex == 1)
        {
            Destroy(GameObject.Find("PlayerConfigurationManager"));
        }
        
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    
}
