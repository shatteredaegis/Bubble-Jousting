using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoppableLimb : MonoBehaviour
{
    [SerializeField] private bool crucialLimb;
    [SerializeField] private GameObject popVFX;
    [SerializeField] private GameObject smallPopVFX;
    [SerializeField] private int whichPlayer;

    private bool scoreHasBeenGainedForRound;
    private void Start()
    {
        popVFX = VFXManager.instance.popVFX;
        smallPopVFX = VFXManager.instance.smallPopVFX;
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

    private void SmallPopVFX(Transform pos)
    {
        GameObject pop = Instantiate(popVFX, pos);
        pop.transform.SetParent(null);
    }
    public virtual void PopLimb()
    {
        if (crucialLimb)
        {
            //game resets if a crucial limb is hit
            DecideScoreChanges();
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

    private void DecideScoreChanges()
    {
        if (scoreHasBeenGainedForRound)
            return;

        if (whichPlayer == 2)
        {
            GameManager.instance.plr2Score += 1;
        }
        else
        {
            GameManager.instance.plr1Score += 1;
        }

        scoreHasBeenGainedForRound = true;
    }
    private IEnumerator PopCrucialLimb()
    {
        SoundManager.instance.fadingMusic = true;

        SmallPopVFX(gameObject.transform);

        yield return new WaitForSeconds(1);
        
        PopVFX(gameObject.transform);
        SoundManager.instance.playPopSFX();
        gameObject.SetActive(false);

        yield return null;
    }
}
