using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //public static PlayerCamera instance;
    public PlayerManager player;
    public Camera cameraObject;
    [SerializeField] Transform cameraPivotTransform;

    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTarget;
    [SerializeField] float cameraSmoothSpeed = 13f;
    [SerializeField] float leftAndRightRotationSpeed = 30;
    [SerializeField] float upAndDownRotationSpeed = 30;
    [SerializeField] float minimumPivot = -15;
    [SerializeField] float maximumPivot = 15;
    
    [Header("Camera Values")]
    [SerializeField] float leftAndRightLookAngle;
    [SerializeField] float upAndDownLookAngle;
    [SerializeField] float cameraZPosition;
    [SerializeField] private Vector3 cameraVelocity;
    private void Awake()
    {
        //if (instance == null)
       // {
           // instance = this;
       // }
       // else
       // {
       //     Destroy(gameObject);
       // }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        cameraZPosition = cameraObject.transform.localPosition.z;
    }

    private void Update()
    {
        HandleAllCameraActions();
    }

    public void HandleAllCameraActions()
    {
        //HandleRotations();
        HandleFollowTarget();
    }

    private void HandleRotations()
    {
        //leftAndRightLookAngle += (PlayerInputManager.instance.cameraHorizontal_Input * leftAndRightRotationSpeed) * Time.deltaTime;
        //rotate up/down
        upAndDownLookAngle -= (PlayerInputManager.instance.plr1_Vertical_Input * upAndDownRotationSpeed) * Time.deltaTime;

        //clamp up/down min/max angle
        upAndDownLookAngle = Mathf.Clamp(upAndDownLookAngle, minimumPivot, maximumPivot);
        
        Vector3 cameraRotation = Vector3.zero;
        Quaternion targetRotation;

        //rotate this gameobject left/right
        cameraRotation.y = leftAndRightLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        transform.rotation = targetRotation;

        //rotate this gameobject up/down
        cameraRotation = Vector3.zero;
        cameraRotation.x = upAndDownLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        cameraPivotTransform.localRotation = targetRotation;
    }
    
    private void HandleFollowTarget()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, cameraTarget.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
        transform.position = targetCameraPosition;
    }
}
