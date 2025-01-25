using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player1LocomotionManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float leanForce = 40f;

    [SerializeField] private float uplift = 50f;
    
    [Header("Player 1 Bodies")]
    [SerializeField] private ArticulationBody root1RB;
    [SerializeField] private ArticulationBody head1RB;
    [SerializeField] private ArticulationBody leftFoot1RB;
    [SerializeField] private ArticulationBody rightFoot1RB;
    [SerializeField] private ArticulationBody sword1Arm;
    [SerializeField] private ArticulationBody shield1Arm;
    [SerializeField] private GameObject sword1;

    [Header("Player 1 Input")]
    [SerializeField] private float move1Input = 0;

    [SerializeField] private float lean1Input = 0;
    
    [Header("Player 2 Bodies")]
    [SerializeField] private ArticulationBody root2RB;
    [SerializeField] private ArticulationBody head2RB;
    [SerializeField] private ArticulationBody leftFoot2RB;
    [SerializeField] private ArticulationBody rightFoot2RB;
    [SerializeField] private ArticulationBody sword2Arm;
    [SerializeField] private ArticulationBody shield2Arm;
    [SerializeField] private GameObject sword2;

    [Header("Player 2 Input")]
    [SerializeField] private float move2Input = 0;

    [SerializeField] private float lean2Input = 0;
    
    private void FixedUpdate()
    {
        GetMovementValues();
        HandleMovement();
        Uplift();
        RaiseShield();
        ThrustSword();
    }

    void Start()
    {
        leftFoot1RB.linearLockX = ArticulationDofLock.LockedMotion;
        leftFoot1RB.linearLockY = ArticulationDofLock.LockedMotion;
        leftFoot1RB.linearLockZ = ArticulationDofLock.LockedMotion;
        leftFoot1RB.twistLock = ArticulationDofLock.LockedMotion;
        leftFoot1RB.swingYLock = ArticulationDofLock.LockedMotion;
        leftFoot1RB.swingZLock = ArticulationDofLock.LockedMotion;
        
        rightFoot1RB.linearLockX = ArticulationDofLock.LockedMotion;
        rightFoot1RB.linearLockY = ArticulationDofLock.LockedMotion;
        rightFoot1RB.linearLockZ = ArticulationDofLock.LockedMotion;
        rightFoot1RB.twistLock = ArticulationDofLock.LockedMotion;
        rightFoot1RB.swingYLock = ArticulationDofLock.LockedMotion;
        rightFoot1RB.swingZLock = ArticulationDofLock.LockedMotion;
        
        //plr2
        
        leftFoot2RB.linearLockX = ArticulationDofLock.LockedMotion;
        leftFoot2RB.linearLockY = ArticulationDofLock.LockedMotion;
        leftFoot2RB.linearLockZ = ArticulationDofLock.LockedMotion;
        leftFoot2RB.twistLock = ArticulationDofLock.LockedMotion;
        leftFoot2RB.swingYLock = ArticulationDofLock.LockedMotion;
        leftFoot2RB.swingZLock = ArticulationDofLock.LockedMotion;
        
        rightFoot2RB.linearLockX = ArticulationDofLock.LockedMotion;
        rightFoot2RB.linearLockY = ArticulationDofLock.LockedMotion;
        rightFoot2RB.linearLockZ = ArticulationDofLock.LockedMotion;
        rightFoot2RB.twistLock = ArticulationDofLock.LockedMotion;
        rightFoot2RB.swingYLock = ArticulationDofLock.LockedMotion;
        rightFoot2RB.swingZLock = ArticulationDofLock.LockedMotion;
    }

    private void GetMovementValues()
    {
        move1Input = PlayerInputManager.instance.plr1_Vertical_Input;
        lean1Input = PlayerInputManager.instance.plr1_Horizontal_Input;
        
        move2Input = PlayerInputManager.instance.plr2_Vertical_Input;
        lean2Input = PlayerInputManager.instance.plr2_Horizontal_Input;
    }

    private void HandleMovement()
    {
        root1RB.AddForce(move1Input * transform.right * leanForce, ForceMode.Acceleration);
        root1RB.AddForce(lean1Input * -transform.forward * leanForce, ForceMode.Acceleration);
        
        root2RB.AddForce(move2Input * -transform.right * leanForce, ForceMode.Acceleration);
        root2RB.AddForce(lean2Input * transform.forward * leanForce, ForceMode.Acceleration);
    }

    private void Uplift()
    {
        root1RB.AddForce(uplift * transform.up, ForceMode.Acceleration);
        head1RB.AddForce(uplift * Vector3.up, ForceMode.Acceleration);
        root1RB.AddForce(uplift * Vector3.up, ForceMode.Acceleration);
        
        root2RB.AddForce(uplift * transform.up, ForceMode.Acceleration);
        head2RB.AddForce(uplift * Vector3.up, ForceMode.Acceleration);
        root2RB.AddForce(uplift * Vector3.up, ForceMode.Acceleration);
    }
    
    private void RaiseShield()
    {
        if (PlayerInputManager.instance.plr1RaiseShield)
        {
            //body lean back
            root1RB.AddForce(150 * -transform.right, ForceMode.Force);
            
            //shield arm forwards
            shield1Arm.AddForce(100 * transform.right, ForceMode.Acceleration);
        }

        if (PlayerInputManager.instance.plr2RaiseShield)
        {
            //body lean back
            root2RB.AddForce(150 * transform.right, ForceMode.Force);
            
            //shield arm forwards
            shield2Arm.AddForce(100 * -transform.right, ForceMode.Acceleration);
        }
    }

    private void ThrustSword()
    {
        if (PlayerInputManager.instance.plr1ThrustSword)
        {
            sword1Arm.AddForce(100 * transform.right, ForceMode.Acceleration);
        }

        if (PlayerInputManager.instance.plr2ThrustSword)
        {
            sword2Arm.AddForce(100 * -transform.right, ForceMode.Acceleration);
        }
    }


}
