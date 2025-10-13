using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            if (GameHandler.Instance != null){
                GameHandler.Instance.GoToShop();
            } 
        }
    }
}
