using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private PoppableLimb limb;
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Poppable") && coll.gameObject.layer != gameObject.layer)
        {
            limb = coll.gameObject.GetComponent<PoppableLimb>();

            if (limb == null)
            {
                limb = coll.gameObject.GetComponent<PoppableArmLimb>(); 
            }

            limb.PopLimb();
        }
    }
}
