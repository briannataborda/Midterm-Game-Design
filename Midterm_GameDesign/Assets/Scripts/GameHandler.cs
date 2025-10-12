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
    public int playerAttack = 1;
    public int coins = 0;

    public GameObject textHealth;
    public GameObject textCoins;

    public int currentLevel = 1;
    public int totalLevels = 3;


    void Start() {
        player = GameObject.FindWithTag("Player");
        // sceneName = SceneManager.GetActiveScene().name;
        // //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
        //         playerHealth = StartPlayerHealth;
        // //}
        // updateStatsDisplay();
        StartGame();
    }

    void Awake(){
        if (Instance == null){
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void StartGame(){
        currentLevel = 1;
        playerCurrentHealth = playerMaxHealth;
        coins = 0;
        playerAttack = 1;
        SceneManager.LoadScene("Level1");
        updateStatsDisplay();
    }

    public void GoToShop(){
        SceneManager.LoadScene("ShopScene");
    }

    public void nextScene(){
        currentLevel += 1;

        if (currentLevel > totalLevels){
            EndGame(true);
        } else {
            SceneManager.LoadScene("Level" + currentLevel);
        }
    }

    public void RestartGame(){
        StartGame();
    }

    public void EndGame(bool win){
        //GameStatus.LastWin = win; 
        SceneManager.LoadScene("EndScene");
    }

    public void TakeDamage(int damage){
        playerCurrentHealth -= damage;
        if (playerCurrentHealth >= 0) {
            updateStatsDisplay();
        }
        
        if (playerCurrentHealth <= 0){
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void PickupCoins(int amount) {
        coins += amount;
        updateStatsDisplay();
    }

    public void updateStatsDisplay(){
        Text healthTextTemp = textHealth.GetComponent<Text>();
        healthTextTemp.text = "HEALTH: " + playerCurrentHealth;

        Text coinsTextTemp = textCoins.GetComponent<Text>();
        coinsTextTemp.text = "CANDY: " + coins;
    }

    public void AddCoins(){
        coins += 1;
    }

    public void HealPlayer(){
        playerCurrentHealth += 1;
    }
    
    public void UpgradeAttack(){
        playerAttack += 1;
    }
  


}
