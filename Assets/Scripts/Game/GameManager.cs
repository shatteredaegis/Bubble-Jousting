using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] GameObject startButton;
    [SerializeField] private GameObject countdownObj;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] float countdownTimer;
    [SerializeField] private float elapsedTime;
    [SerializeField] private float slowTimer;
    [SerializeField] private GameObject shield;

    [Header("Player Restraints")]
    public GameObject player1Restraint;

    public GameObject player2Restraint;

    [Header("Configuration")]
    [SerializeField] private float slowAmountOnGameOver = 0.5f;

    [Header("Flags")]
    [SerializeField] public bool gameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        GameEnd();
    }

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

    private void GameEnd()
    {
        if (!gameOver)
            return;
        
        slowTimer += Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Lerp(1, slowAmountOnGameOver, slowTimer / 2);

        if (slowTimer >= 5)
        {
            GameReset();
            slowTimer = 0;
        }
    }
    private void GameReset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartGame();
    }
    public void InstantiateShieldWhenArmPopped(Transform weaponTransform)
    {
        Instantiate(shield, weaponTransform);
    }
}
