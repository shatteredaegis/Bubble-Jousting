using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoppableLimb : MonoBehaviour
{
    [SerializeField] private bool crucialLimb;
    [SerializeField] private GameObject popVFX;
    [SerializeField] private int whichPlayer;
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
            DecideScoreChanges();
        }
        else
        {
            PopVFX(gameObject.transform);
            SoundManager.instance.playPopSFX();
            gameObject.SetActive(false);
        }
    }

    private void DecideScoreChanges()
    {
        if (whichPlayer == 2)
        {
            GameManager.instance.plr2Score += 1;
        }
        else
        {
            GameManager.instance.plr1Score += 1;
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
