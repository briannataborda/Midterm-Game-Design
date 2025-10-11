using UnityEngine;
using UnityEngine.UI 
using TMPro;
using UnityEngine.SceneManagement;

public class ShopScene : MonoBehaviour
{
    public TMPUGUUI coinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateUI();
    }

    public void BuyHealth(){
        if (GameHandler.Instance.coins >= 1){
            GameHandler.Instance.coins -= 1; 
            GameHandler.Instance.HealPlayer();
            updateUI();
        }
    }

    public void BuyAttack(){
        if (GameHandler.Instance.coins >= 1){
            GameHandler.Instance.coins -= 1; 
            GameHandler.Instance.UpgradeAttack();
            updateUI();
        }
    }

    public void NextLevel(){
        GameHandler.Instance.LoadNextLevel();
    }

    void updateUI(){
        coinText.txt = "Coins" + GameHandler.Instance.coins;
    }
}