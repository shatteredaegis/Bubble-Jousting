using System;
using System.Collections;
using System.Collections.Generic;
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
}
