using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){

            if (GameObject.FindWithTag("MusicManager") != null){
                GameObject.FindWithTag("MusicManager").GetComponent<AudioManager>().SetTimeStamp();
            }

            if (GameHandler.Instance != null){
                GameHandler.Instance.GoToShop();
            } 
        }
    }
}
