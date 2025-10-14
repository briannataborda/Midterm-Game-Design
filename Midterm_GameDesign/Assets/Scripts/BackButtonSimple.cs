using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonSimple : MonoBehaviour
{
    public void GoBack(){
        SceneManager.LoadScene("StartScene");
    }
}
