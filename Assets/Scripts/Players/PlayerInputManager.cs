using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance; 
    PlayerControls playerControls;
    
    [Header("Player 1 Input")]
    public Vector2 plr1_Movement_Input;
    public bool plr1RaiseShield;
    public bool plr1ThrustSword;
    public float plr1_Vertical_Input;
    public float plr1_Horizontal_Input;
    public float plr1_MoveAmount;

    [Header("Player 2 Input")]
    public Vector2 plr2_Movement_Input;
    public bool plr2RaiseShield;
    public bool plr2ThrustSword;
    public float plr2_Vertical_Input;
    public float plr2_Horizontal_Input;
    public float plr2_MoveAmount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad((gameObject));
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            
            playerControls.Player1.Movement.performed += i => plr1_Movement_Input = i.ReadValue<Vector2>();
            playerControls.Player2.Movement.performed += i => plr2_Movement_Input = i.ReadValue<Vector2>();

            //shield raise
            playerControls.Player1.RaiseShield.performed += i => plr1RaiseShield = true;
            playerControls.Player1.RaiseShield.canceled += i => plr1RaiseShield = false;
            playerControls.Player2.RaiseShield.performed += i => plr2RaiseShield = true;
            playerControls.Player2.RaiseShield.canceled += i => plr2RaiseShield = false;
            
            //sword thrust
            playerControls.Player1.ThrustSword.performed += i => plr1ThrustSword = true;
            playerControls.Player1.ThrustSword.canceled += i => plr1ThrustSword = false;
            playerControls.Player2.ThrustSword.performed += i => plr2ThrustSword = true;
            playerControls.Player2.ThrustSword.canceled += i => plr2ThrustSword = false;
        }

        playerControls.Enable();
    }

    private void Update()
    {
        HandleAllInputs();
    }

    private void HandleAllInputs()
    {
        HandlePlayerMovementInput();
    }

    private void HandlePlayerMovementInput()
    {
        plr1_Vertical_Input = plr1_Movement_Input.y;
        plr1_Horizontal_Input = plr1_Movement_Input.x;
        plr1_MoveAmount = Mathf.Clamp01(Mathf.Abs(plr1_Vertical_Input) + Mathf.Abs(plr1_Horizontal_Input));
        
        plr2_Vertical_Input = plr2_Movement_Input.y;
        plr2_Horizontal_Input = plr2_Movement_Input.x;
        plr2_MoveAmount = Mathf.Clamp01(Mathf.Abs(plr2_Vertical_Input) + Mathf.Abs(plr2_Horizontal_Input));
    }
    
}
