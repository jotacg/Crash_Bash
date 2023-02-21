using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSetupMenucontroller : MonoBehaviour
{

    //public GameObject characterPreview;
    
    private int playerIndex;
    public GameObject readyText;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private Button characterButton;

    private float ignoreInputTime = 1.0f;
    private bool inputEnabled;
    public void setPlayerIndex(int pi)
    {
        // Fija un indice para el jugador y cambia su nombre dependiendo del jugadr que sea
        playerIndex = pi;
        titleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Inhabilita la seleccion de personaje durante un momento para no escoger un personaje sin querer
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SelectMesh(Mesh mesh)
    {
        if(!inputEnabled) { return; }

        // Selecciona la malla del personaje seleccionado
        PlayerConfigurationManager.Instance.SetPlayerMesh(playerIndex, mesh);
        // Activa los paneles ready y desactiva los de seleccion de personajes
        readyPanel.SetActive(true);
        readyButton.interactable = true;
        menuPanel.SetActive(false);
        readyButton.Select();

    }

    public void BackToSelector()
    {
        if(!inputEnabled) { return; }
        // Activa los paneles de seleccion de personajes y desactiva los de ready
        readyPanel.SetActive(false);
        menuPanel.SetActive(true);
        characterButton.Select();

    }

    public void SelectMat(Material mat)
    {
        // Selecciona el material para la malla seleccionada
        PlayerConfigurationManager.Instance.SetPlayerMat(playerIndex, mat);
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }

        // El jugador cambia al estado de listo y se desactivan los paneles de ready
        PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        readyText.gameObject.SetActive(true);
        readyButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(false);
    }

    public void SetIcon(Texture textura)
    {
        // Selecciona la textura para la malla seleccionada
        PlayerConfigurationManager.iconos[playerIndex] = textura;
    }
}
