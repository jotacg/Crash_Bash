using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private Scene gameScene;

    public Animator transition;
    public float transitiontime = 1f;

    private void Awake()
    {
        gameScene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainScene()
    {
        //SceneManager.LoadScene(gameScene.name);
        StartCoroutine(LoadLevel(gameScene.name));
    }

    public void CharacterSelectionScene()
    {
        if(PauseMenu.gamePaused)
        {
            Time.timeScale = 1f;
            PauseMenu.gamePaused = false;
        }
        //SceneManager.LoadScene("BallistixCharacterSelection");
        StartCoroutine(LoadLevel("BallistixCharacterSelection"));
        Destroy(GameObject.Find("PlayerConfigurationManager"));
    }

    public void MainMenuScene()
    {
        if(PauseMenu.gamePaused)
        {
            Time.timeScale = 1f;
            PauseMenu.gamePaused = false;
        }
        //SceneManager.LoadScene("BallistixCharacterSelection");
        StartCoroutine(LoadLevel("MainMenu"));
        Destroy(GameObject.Find("PlayerConfigurationManager"));
    }

    public void DisablePanel (GameObject panel)
    {
        panel.SetActive(false);
    }

    public void EnablePanel (GameObject panel)
    {
        panel.SetActive(true);
    }

    public void GoGame ()
    {
        ScoreManager.instruccionesJuego = false;
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(sceneName);
    }
}
