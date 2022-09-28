using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    public static bool jugador1;    // Variable global para saber si el jugador uno esta en la partida (true) o no (false)
    public static bool jugador2;    // Variable global para saber si el jugador dos esta en la partida (true) o no (false)
    public static bool jugador3;    // Variable global para saber si el jugador tres esta en la partida (true) o no (false)
    public static bool jugador4;    // Variable global para saber si el jugador cuatro esta en la partida (true) o no (false)
    
    public static Texture[] iconos = new Texture[4];

    private Scene scene;

    public Animator transition;
    public float transitiontime = 1f;

    private List<PlayerConfiguration> playerConfigs;
    //[SerializeField]
    //private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        jugador1 = false;
        jugador2 = false;
        jugador3 = false;
        jugador4 = false;

        scene = SceneManager.GetActiveScene();

        if(Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
        
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        if(scene.name == "BallistixCharacterSelection")
        {
//            Debug.Log("player joined " + pi.playerIndex);
            pi.transform.SetParent(transform);

            if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
            {
                playerConfigs.Add(new PlayerConfiguration(pi));
            }
            switch(pi.playerIndex)
            {                               // Cuando vayan entrando los jugadores sus variables de cotrol se iran poniendo a true
                case 0:
                    jugador1 = true;
                    break;
                case 1:
                    jugador2 = true;
                    break;
                case 2:
                    jugador3 = true;
                    break;
                case 3:
                    jugador4 = true;
                    break;
            }
        }

    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerMesh(int index, Mesh mesh)
    {
        playerConfigs[index].playerMesh = mesh;
    }

    public void SetPlayerMat(int index, Material mat)
    {
        playerConfigs[index].playerMat = mat;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.All(p => p.isReady == true))
        {
            //SceneManager.LoadScene("BallistixGame");
            StartCoroutine(LoadLevel("BallistixGame"));
        }
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(sceneName);
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; private set; }
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }
    public Mesh playerMesh { get; set; }
    public Material playerMat { get; set; }
}