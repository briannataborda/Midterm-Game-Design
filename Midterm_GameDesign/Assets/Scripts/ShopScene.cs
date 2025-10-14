using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopScene : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text healthText;
    public TMP_Text attackText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateUI();
    }

    public void BuyHealth(){
        if (GameHandler.Instance.coins >= 5){
            GameHandler.Instance.coins -= 5; 
            GameHandler.Instance.HealPlayer();
            updateUI();
        }
    }

    public void BuyAttack(){
        if (GameHandler.Instance.coins >= 5){
            GameHandler.Instance.coins -= 5; 
            GameHandler.Instance.UpgradeAttack();
            updateUI();
        }
    }

    public void NextLevel(){
        GameHandler.Instance.nextScene();
    }

    void updateUI(){
        if (coinText != null){
            coinText.text = "Coins: " + GameHandler.Instance.coins;
        }
        if (healthText != null){
            healthText.text = "Health: " + GameHandler.Instance.playerCurrentHealth + "/" + GameHandler.Instance.playerMaxHealth;
        }
        if (attackText != null){
            attackText.text = "Attack: " + GameHandler.Instance.playerAttack;
        }
    }
}