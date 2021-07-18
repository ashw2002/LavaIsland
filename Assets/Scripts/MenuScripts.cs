using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScripts : MonoBehaviour {

	//Allows the usage of the mouse in the menu screens
	void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
	}
    //sends the player into the main game on a button click
    public void beginGame (){
        SceneManager.LoadScene(1);
    }
    //sends the player to the main menu on a button click
    public void returnToMenu (){
        SceneManager.LoadScene(0);
    }
    //Quits the game on a button click
    public void endGame (){
        Application.Quit();
    }
	
}
//written by Ashton Westick
