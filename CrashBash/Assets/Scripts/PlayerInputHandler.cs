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
    private PauseMenu pause;

    [SerializeField]
    private MeshFilter playerMesh;
    [SerializeField]
    private MeshRenderer playerMat;

    private PlayerInputActions controls;

    private void Awake()
    {
        movement = GetComponent<PlayerController>();
        tilt = GetComponentInChildren<TiltPlayerEffect>();
        shockWave = GetComponent<ShockWaveForce>();
        pause = GetComponent<PauseMenu>();

        controls = new PlayerInputActions();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        playerMesh.mesh = config.playerMesh;
        playerMat.material = config.playerMat;

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
        if (obj.action.name == controls.Player.Pause.name)
        {
            OnPause(obj);
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

    public void OnPause(CallbackContext context)
    {
        if(pause != null)
        {
            pause.Pause(context);
        }
    }
}