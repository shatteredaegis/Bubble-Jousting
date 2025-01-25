using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private float repelForce = 20;
    [SerializeField] private PoppableLimb limb;
    [SerializeField] private Transform vfxPoint;
    [SerializeField] private Rigidbody swordRB;
    
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

            if (limb != null)
            {
                limb.PopLimb();
            }
        }

        if (coll.collider.CompareTag("Sword") && coll.gameObject.layer != gameObject.layer)
        {
            GameObject swordClashVFX = Instantiate(swordHitVFX, vfxPoint);
            SoundManager.instance.PlaySwordHitSFX();
            swordRB.AddForce(transform.right * repelForce, ForceMode.Impulse);
        }
        
        if (coll.collider.CompareTag("Shield") && coll.gameObject.layer != gameObject.layer)
        {
            GameObject swordClashVFX = Instantiate(shieldHitVFX, vfxPoint);
            SoundManager.instance.PlayShieldHitSFX();
            swordRB.AddForce(transform.right * repelForce, ForceMode.Impulse);
        }
    }
}
