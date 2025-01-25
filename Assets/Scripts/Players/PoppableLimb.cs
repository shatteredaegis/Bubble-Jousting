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
            SoundManager.instance.playPopSFX();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator PopCrucialLimb()
    {
        SoundManager.instance.fadingMusic = true;
        
        yield return new WaitForSeconds(1);
        
        PopVFX(gameObject.transform);
        SoundManager.instance.playPopSFX();
        gameObject.SetActive(false);

        yield return null;
    }
}
