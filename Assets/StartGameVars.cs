using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameVars : MonoBehaviour
{
    public static StartGameVars instance;
    
    [SerializeField] public GameObject startButton;
    [SerializeField] public GameObject countdownObj;
    [SerializeField] public TextMeshProUGUI countdownText;
    [SerializeField] public GameObject player1Restraint;
    [SerializeField] public GameObject player2Restraint;

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
}
