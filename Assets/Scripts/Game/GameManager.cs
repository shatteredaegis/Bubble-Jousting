using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] GameObject startButton;
    [SerializeField] private GameObject countdownObj;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] double countdownTimer;
    [SerializeField] private double elapsedTime;
    [SerializeField] private GameObject shield;

    [Header("Player Restraints")]
    public GameObject player1Restraint;

    public GameObject player2Restraint;
    
    public void StartGame()
    {
        startButton.SetActive(false);
        StartCoroutine(GameCountdown());
    }

    private IEnumerator GameCountdown()
    {
        elapsedTime = countdownTimer;
        
        countdownObj.SetActive(true);

        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            countdownText.text = elapsedTime.ToString("F1");
            yield return null;
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        countdownObj.SetActive(false);
        player1Restraint.SetActive(false);
        player2Restraint.SetActive(false);
        
        yield return null;
    }

    public void InstantiateShieldWhenArmPopped(Transform weaponTransform)
    {
        Instantiate(shield, weaponTransform);
    }
}
