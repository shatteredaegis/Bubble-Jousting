using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2LocomotionManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float leanForce = 40f;
    
    [Header("Bodies")]
    [SerializeField] private ArticulationBody rootRB;
    [SerializeField] private ArticulationBody headRB;
    [SerializeField] private ArticulationBody leftFootRB;
    [SerializeField] private ArticulationBody rightFootRB;
    [SerializeField] private ArticulationBody swordArm;
    [SerializeField] private ArticulationBody shieldArm;

    [Header("Input")]
    [SerializeField] private float moveInput = 0;

    [SerializeField] private float leanInput = 0;

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
        leftFootRB.linearLockX = ArticulationDofLock.LockedMotion;
        leftFootRB.linearLockY = ArticulationDofLock.LockedMotion;
        leftFootRB.linearLockZ = ArticulationDofLock.LockedMotion;
        leftFootRB.twistLock = ArticulationDofLock.LockedMotion;
        leftFootRB.swingYLock = ArticulationDofLock.LockedMotion;
        leftFootRB.swingZLock = ArticulationDofLock.LockedMotion;
        
        rightFootRB.linearLockX = ArticulationDofLock.LockedMotion;
        rightFootRB.linearLockY = ArticulationDofLock.LockedMotion;
        rightFootRB.linearLockZ = ArticulationDofLock.LockedMotion;
        rightFootRB.twistLock = ArticulationDofLock.LockedMotion;
        rightFootRB.swingYLock = ArticulationDofLock.LockedMotion;
        rightFootRB.swingZLock = ArticulationDofLock.LockedMotion;
    }

    private void GetMovementValues()
    {
        moveInput = PlayerInputManager.instance.plr2_Vertical_Input;
        leanInput = PlayerInputManager.instance.plr2_Horizontal_Input;
    }

    private void HandleMovement()
    {
        rootRB.AddForce(moveInput * transform.right * leanForce, ForceMode.Acceleration);
        rootRB.AddForce(leanInput * -transform.forward * leanForce, ForceMode.Acceleration);
    }

    private void Uplift()
    {
        rootRB.AddForce(50 * transform.up, ForceMode.Acceleration);
        headRB.AddForce(50 * new Vector3(0,1,0), ForceMode.Acceleration);
        rootRB.AddForce(50 * new Vector3(0,1,0), ForceMode.Acceleration);
    }

    private void RaiseShield()
    {
        if (PlayerInputManager.instance.plr2RaiseShield)
        {
            shieldArm.AddForce(100 * transform.right, ForceMode.Acceleration);
        }
    }

    private void ThrustSword()
    {
        if (PlayerInputManager.instance.plr2ThrustSword)
        {
            swordArm.AddForce(100 * transform.right, ForceMode.Acceleration);
        }
    }


}
