using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour {


     

       public void StartGame(){
               SceneManager.LoadScene("Elgin_PlayerProjectile");
       }


       public void QuitGame(){
               #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
               #else
               Application.Quit();
               #endif
       }


}
