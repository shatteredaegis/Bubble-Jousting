using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoppableLimb : MonoBehaviour
{
    [SerializeField] private bool crucialLimb;
    [SerializeField] private GameObject popVFX;

    private void Start()
    {
        popVFX = VFXManager.instance.popVFX;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            PopLimb();
        }
    }

    private void PopVFX(Transform pos)
    {
        Debug.Log("pop");
        GameObject pop = Instantiate(popVFX, pos);
        pop.transform.SetParent(null);
    }
    public virtual void PopLimb()
    {
        if (crucialLimb)
        {
            //game reset
            StartCoroutine(PopCrucialLimb());
            GameManager.instance.gameOver = true;
        }
        else
        {
            PopVFX(gameObject.transform);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator PopCrucialLimb()
    {
        yield return new WaitForSeconds(0.5f);
        
        PopVFX(gameObject.transform);
        gameObject.SetActive(false);

        yield return null;
    }
}
