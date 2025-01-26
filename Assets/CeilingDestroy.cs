using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingDestroy : MonoBehaviour
{
    [SerializeField] private PoppableLimb limb;
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Poppable"))
        {
            limb = coll.gameObject.GetComponent<PoppableLimb>();

            if (limb == null)
            {
                limb = coll.gameObject.GetComponent<PoppableArmLimb>(); 
            }

            if (limb != null)
            {
                limb.PopLimb();
            }
        }
    }
}
