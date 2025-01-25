using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoppableLimb : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

    public virtual void PopLimb()
    {
        this.GameObject().SetActive(false);
    }
}
