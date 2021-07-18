using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    //this script keeps track of all the scoring variables and is called upon by a majority of other scripts
    //Score detail variables
    public int dollsCollected = 0;
    public int dollsSacrificed;
    public int dollsNeeded;
    //variables for UI Text
    public Text scoreText;
    public Text sacrificeText;
    public Text spokenText;

    public bool win = false;
	void Start () {
		
	}
	
	//Displays correct scores on the screen
	void Update () {
        scoreText.text = "Dolls Collected: " + dollsCollected;
        sacrificeText.text = "Dolls Sacrificed: " + dollsSacrificed + "/" + dollsNeeded;
        //if the player sacrifices the needed amount of dolls then some scripts will act differently and death will dissapear
        if(dollsSacrificed >= dollsNeeded){
            win = true;
            spokenText.text = "The Ritual is complete! Now throw your self into peril and revel in your newfound "
                + "immortality";
        }
	}
}
//Written by Ashton Westrick
