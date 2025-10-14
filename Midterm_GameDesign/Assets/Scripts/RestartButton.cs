using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void Restart(){
        if (GameHandler.Instance!=null){
            GameHandler.Instance.RestartGame();
        }
    }
}

