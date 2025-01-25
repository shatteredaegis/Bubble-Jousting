using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private PoppableLimb limb;
    [SerializeField] private Transform vfxPoint;
    
    public GameObject shieldHitVFX;
    public GameObject swordHitVFX;
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

        if (coll.collider.CompareTag("Sword") && coll.gameObject.layer != gameObject.layer)
        {
            GameObject swordClashVFX = Instantiate(swordHitVFX, vfxPoint);
            SoundManager.instance.PlaySwordHitSFX();
        }
        
        if (coll.collider.CompareTag("Shield") && coll.gameObject.layer != gameObject.layer)
        {
            GameObject swordClashVFX = Instantiate(shieldHitVFX, vfxPoint);
            SoundManager.instance.PlayShieldHitSFX();
        }
    }
}
