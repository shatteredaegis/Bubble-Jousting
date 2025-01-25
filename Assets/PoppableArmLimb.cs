using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppableArmLimb : PoppableLimb
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private bool isShieldArm;

    public override void PopLimb()
    {
        Debug.Log(weapon.transform);
        if (isShieldArm)
        {
            GameManager.instance.InstantiateShieldWhenArmPopped(weapon.transform);
            weapon.SetActive(false);
        }
        
        base.PopLimb();
    }
}
