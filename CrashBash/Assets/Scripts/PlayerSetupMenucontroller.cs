using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSetupMenucontroller : MonoBehaviour
{
    private int playerIndex;

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
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SelectMesh(Mesh mesh)
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.SetPlayerMesh(playerIndex, mesh);
        readyPanel.SetActive(true);
        readyButton.interactable = true;
        menuPanel.SetActive(false);
        readyButton.Select();
        
    }

    public void BackToSelector()
    {
        if(!inputEnabled) { return; }

        readyPanel.SetActive(false);
        menuPanel.SetActive(true);
        characterButton.Select();
    }

    public void SelectMat(Material mat)
    {
        PlayerConfigurationManager.Instance.SetPlayerMat(playerIndex, mat);
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        readyButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(false);
    }

    public void SetIcon(Texture textura)
    {
        PlayerConfigurationManager.iconos[playerIndex] = textura;
    }
}
