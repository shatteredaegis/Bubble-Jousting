using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Coroutine countdownCoroutine;

    [SerializeField] GameObject startButton;
    [SerializeField] private GameObject countdownObj;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI scoreText;
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

    [Header("Score")] 
    [SerializeField] public int plr1Score = 0;
    [SerializeField] public int plr2Score = 0;

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
        DontDestroyOnLoad(gameObject);
    }

    public void FetchStartGameVars()
    {
        startButton = StartGameVars.instance.startButton;
        countdownObj = StartGameVars.instance.countdownObj;
        countdownText = StartGameVars.instance.countdownText;
        scoreText = StartGameVars.instance.scoreText;
        player1Restraint = StartGameVars.instance.player1Restraint;
        player2Restraint = StartGameVars.instance.player2Restraint;

        SetScoreboard();
    }

    private void SetScoreboard()
    {
        Debug.Log("a");
        scoreText.text = plr2Score + " - " + plr1Score;
    }
    private void Update()
    {
        GameEnd();
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        countdownCoroutine = StartCoroutine(GameCountdown());
    }

    private IEnumerator GameCountdown()
    {
        SoundManager.instance.playCDSFX();
        
        elapsedTime = countdownTimer;
        
        countdownObj.SetActive(true);

        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            countdownText.text = elapsedTime.ToString("F1");
            yield return null;
        }

        countdownText.text = "Go!";
        elapsedTime = 3;
        yield return new WaitForSeconds(0.5f);
        countdownObj.SetActive(false);
        player1Restraint.SetActive(false);
        player2Restraint.SetActive(false);
        
        SoundManager.instance.PlayMusic();
        yield break;
       
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
        gameOver = false;
        elapsedTime = 3;
        Time.timeScale = 1;
        countdownText.text = elapsedTime.ToString("F1");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void InstantiateShieldWhenArmPopped(Transform weaponTransform)
    {
        Instantiate(shield, weaponTransform);
    }
}
