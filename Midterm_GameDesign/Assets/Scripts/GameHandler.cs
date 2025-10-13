using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    private GameObject player;
    public int playerMaxHealth = 100;
    public int playerCurrentHealth = 100;
    public int playerAttack = 25;
    public int coins = 0;

    public GameObject textHealth;
    public GameObject textCoins;

    public int currentLevel = 1;
    public int totalLevels = 3;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUIReferences();
        updateStatsDisplay();
    }

    void UpdateUIReferences()
    {
        GameObject healthObj = GameObject.Find("HealthText");
        GameObject coinsObj = GameObject.Find("CandyText");

        if (healthObj != null)
        {
            textHealth = healthObj;
        }

        if (coinsObj != null)
        {
            textCoins = coinsObj;
        }
    }

    public void StartGame()
    {
        currentLevel = 1;
        playerCurrentHealth = playerMaxHealth;
        coins = 0;
        playerAttack = 25;
        SceneManager.LoadScene("Level1");
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void nextScene()
    {
        currentLevel += 1;

        if (currentLevel > totalLevels)
        {
            EndGame(true);
        }
        else
        {
            SceneManager.LoadScene("Level" + currentLevel);
        }
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void EndGame(bool win)
    {
        //GameStatus.LastWin = win; 
        SceneManager.LoadScene("EndScene");
    }

    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        if (playerCurrentHealth >= 0)
        {
            updateStatsDisplay();
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }

    }

    public void PickupCoins(int amount)
    {
        coins += amount;
        updateStatsDisplay();
    }

    public void updateStatsDisplay()
    {
        Text healthTextTemp = textHealth.GetComponent<Text>();
        if (healthTextTemp != null)
        {
            healthTextTemp.text = "HEALTH: " + playerCurrentHealth;
        }

        if (textCoins != null)
        {
            Text coinsTextTemp = textCoins.GetComponent<Text>();
            if (coinsTextTemp != null)
            {
                coinsTextTemp.text = "CANDY: " + coins;
            }
        }


    }

    public void AddCoins()
    {
        coins += 1;
        updateStatsDisplay();
    }

    public void HealPlayer()
    {
        playerCurrentHealth += 1;
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        updateStatsDisplay();
    }

    public void UpgradeAttack()
    {
        playerAttack += 1;
        updateStatsDisplay();
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void BackButton()
       {
        SceneManager.LoadScene("StartScene");
       }

}
