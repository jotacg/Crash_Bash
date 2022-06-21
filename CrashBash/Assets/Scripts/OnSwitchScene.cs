using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OnSwitchScene : MonoBehaviour
{
    public GameObject canvas;
    public GameObject mainCamera;

    [SerializeField]
    private Transform[] cameraSpawns;
    
    void OnEnable()
    {
    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
    //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Num jugador: " + this.GetComponent<PlayerInput>().playerIndex);

        Debug.Log(scene.name);
        Debug.Log(mode);

        if(scene.name == "BallistixGame")
        {
            mainCamera.SetActive(true);
            canvas.SetActive(true);     // Activar las puntuaciones
            transform.GetChild(0).transform.position = cameraSpawns[this.GetComponent<PlayerInput>().playerIndex].position;
            transform.GetChild(0).transform.rotation = cameraSpawns[this.GetComponent<PlayerInput>().playerIndex].rotation;
            this.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player"); // Cambiar el Action Map al de player
            //Debug.Log(this.GetComponent<PlayerInput>().currentActionMap);
        }
    }
}
