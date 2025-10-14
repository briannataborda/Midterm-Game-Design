using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
        Debug.Log("gamehandler awake called");
        if (Instance == null)
        {
            Debug.Log("create new gamehandler");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("gamehandler alr exists, destroy");
            Destroy(gameObject);
        }
    }
    void Start(){
        Debug.Log("Gamehandler start called");
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
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();
        if (eventSystems.Length > 1){
            for (int i = 1; i < eventSystems.Length; i++){
                Destroy(eventSystems[i].gameObject);
            }
        }
            
        if (scene.name == "CreditsScene" || scene.name == "StartScene" || scene.name == "EndScene" || scene.name == "LoseScene"){
            return;
        }

        if (scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3" || scene.name == "ShopScene"){
            UpdateUIReferences();
            updateStatsDisplay();
        }
        
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
        if (textHealth != null){
            Text healthTextTemp = textHealth.GetComponent<Text>();
            if (healthTextTemp != null)
            {
                healthTextTemp.text = "HEALTH: " + playerCurrentHealth;
            }
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
        playerCurrentHealth += 5;
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        updateStatsDisplay();
    }

    public void UpgradeAttack()
    {
        playerAttack += 3;
        updateStatsDisplay();
    }

    public void TutorialScene() 
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void CreditsScene()
    {
        Debug.Log("credit button was clicked.");
        SceneManager.LoadScene("CreditsScene");
        GameHandler.Instance.Awake();
    }

    public void BackButton(){
        Debug.Log("backbutton clicked");
        SceneManager.LoadScene("StartScene");
        GameHandler.Instance.Awake();
    }

}
