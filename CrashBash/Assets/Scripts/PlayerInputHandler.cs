using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerController movement;
    private TiltPlayerEffect tilt;
    private ShockWaveForce shockWave;

    [SerializeField]
    private MeshRenderer playerMesh;

    private PlayerInputActions controls;

    private void Awake()
    {
        movement = GetComponent<PlayerController>();
        tilt = GetComponentInChildren<TiltPlayerEffect>();
        shockWave = GetComponent<ShockWaveForce>();

        controls = new PlayerInputActions();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        playerMesh.material = config.playerMaterial;
        config.Input.onActionTriggered += Input_onActionTriggered;
    }   

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Player.Movement.name)
        {
            OnMove(obj);
        }
        if (obj.action.name == controls.Player.ShockWave.name)
        {
            OnShock(obj);
        }
        
        if (obj.action.name == controls.Menu.MenuMovement.name)
        {
           // Debug.Log("hola");
        }
        
    }

    public void OnMove(CallbackContext context)
    {
        if(movement != null)
        {
            movement.MoveExec(context);
            tilt.TiltExec(context);
        }
    }
    
    public void OnShock(CallbackContext context)
    {
        if(shockWave != null)
        {
            shockWave.ExecShockWave(context);
        }
    }
}