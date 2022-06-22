using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private Scene gameScene;

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
        SceneManager.LoadScene(gameScene.name);
    }

    public void CharacterSelectionScene()
    {
        SceneManager.LoadScene("BallistixCharacterSelection");
        Destroy(GameObject.Find("PlayerConfigurationManager"));
    }
}
