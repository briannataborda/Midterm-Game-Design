using UnityEngine;
using UnityEnginer.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    public int playerMaxHealth = 3;
    public int playerCurrentHealth = 3;
    public int playerAttack = 1;
    public int coins = 0;

    public int currentLevel = 1;
    public int totalLevels = 3;


    public void StartGame(){
        currentLevel = 1
        playerCurrentHealth = playerMaxHealth;
        coins = 0 
        playerAttack = 1;
        SceneManager.LoadScene("Level1");
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
        GameStatus.LastWin = win; 
        SceneManager.LoadScene("EndScene");
    }

    public void TakeDamage(int amount){
        playerCurrentHealth -= amount;
        if (playerCurrentHealth <= 0){
            SceneManager.LoadGame("LoseScene");
        }
    }

    public void AddCoins(){
        coins += 1;
    }

    public void HealPlayer(){
        playerHealth += 1;
    }
    public void UpgradeAttack(){
        playerAttackDamager += 1;
    }
  


}
