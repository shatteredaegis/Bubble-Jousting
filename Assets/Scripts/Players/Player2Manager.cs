using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    private Player1LocomotionManager player2LocomotionManager;
    private void Start()
    {
        Player2Camera.instance.player = this;
    }
}
