using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour {


     

       public void StartGame(){
               GameHandler.Instance.StartGame();
       }


       public void QuitGame(){
               #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
               #else
               Application.Quit();
               #endif
       }


}
