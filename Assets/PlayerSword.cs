using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("1");
        if (coll.collider.CompareTag("Poppable") && coll.gameObject.layer != gameObject.layer)
        {
            Debug.Log("2");
            coll.gameObject.SetActive(false);
        }
    }
}
