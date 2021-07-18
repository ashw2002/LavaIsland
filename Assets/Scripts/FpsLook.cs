using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script handles the mouse looking and obtaining obtainable objects in the game
//Written by Ashton Westrick
public class FpsLook : MonoBehaviour
{
    public AudioClip pickUp;
    public AudioClip sacrifice;
    //The two different text boxes that the FpsLook script handles
    public Text infoText;
    public Text talkText;

    //Determines if info text needs to reapear
    private bool wellSaid = false;
    private bool noRepeat = false;
    //the dialog spoken by the horse to the player. Is a variable so I can change it easier or call it later if needed
    private string horseWarning = "Be wary, O traveler from afar.  " +
        "You seeketh power, but lest you forget, I remind you: " +
        "Death himself prowels these lands.  " +
        "Maketh a sacrifice of six effigies to the volcano on the left fork and you shall be granted the power you seeketh.";
    private string warningRepeat = "Did you not listen the first time fool?  Death encroches upon your life here.  " +
        "He comes now and will not hesitate to drag you into the eternal darkness.";

    //all variable for checking what the character is seeing and can interact with.
    public Camera view;
    private Vector3 forward;
    RaycastHit hit;
    Ray ray;
    GameObject Doll;

    //interacts with the horse game object as to trigger the animation
    public GameObject Horse;
    //FpsLook shares information with the score keeper
    public GameObject ScoreKeeper;

    void Start()
    {
        ScoreKeeper = GameObject.FindWithTag("Score");
        Horse = GameObject.FindWithTag("Horse");
        view = GetComponent<Camera>();
    }


    void Update()
    {
        //sets raycast variables and debugging
        forward = transform.TransformDirection(Vector3.forward);
        ray = view.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, forward * 5, Color.white);
        //checks if the raycast is hiting a viable object
        if (Physics.Raycast(ray, out hit, 4))
        {
            if (hit.collider.tag == "Collectable")
            {
                //Triggers on the hit of a collectable object and allows the player to pick it up
                Doll = hit.collider.gameObject;
                infoText.text = "Pick Up VoodoDoll (Press E)";
                //For some reason I had to use different ways of calling get key down for it to work
                //Reason is currently unknown
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(Doll);
                    AudioSource.PlayClipAtPoint(pickUp, transform.position, 7);
                    ScoreKeeper.GetComponent<ScoreKeeper>().dollsCollected += 1;
                    Debug.Log(ScoreKeeper.GetComponent<ScoreKeeper>().dollsCollected);
                }
                //Allows the player to sacrifice their collectables to the volcano and scores accordingly
            }
            else
            if (hit.collider.tag == "Sacrifice")
            {
                infoText.color = new Color(0, 0, 230, 255);
                infoText.text = "Sacrifice a Voodoo Doll (Press E)";
                if (Input.GetKeyDown("e"))
                {
                    if (ScoreKeeper.GetComponent<ScoreKeeper>().dollsCollected > 0)
                    {
                        AudioSource.PlayClipAtPoint(sacrifice, transform.position, 7);
                        ScoreKeeper.GetComponent<ScoreKeeper>().dollsSacrificed += 1;
                        ScoreKeeper.GetComponent<ScoreKeeper>().dollsCollected -= 1;
                    }
                }
            }
            else
            //controles the Dialoug with Shadowmare
            if (hit.collider.tag == "Horse")
            {
                    //Well said make the interact prompt disapear
                if (wellSaid == false)
                {
                    infoText.text = "Speak with the horse of death. (Press E)";
                }
                if (Input.GetKeyUp("e"))
                {
                    infoText.text = "";
                    wellSaid = true;
                    Horse.GetComponent<Animator>().SetInteger("animState", 1);
                    //Shadowmare scolds the player when they spaek with her again after her initial warning
                    if (noRepeat == false)
                    {
                        talkText.text = horseWarning;
                        noRepeat = true;
                    }
                    else
                    {
                        talkText.text = warningRepeat;
                    }
                }
                
            }else{
                //Sets text on the screen to it's defaults and nullifies any variable that are only needed when
                //looking at certain colliders
                infoText.text = "";
                infoText.color = new Color(194, 0, 0, 255);
                if (ScoreKeeper.GetComponent<ScoreKeeper>().dollsSacrificed < ScoreKeeper.GetComponent<ScoreKeeper>().dollsNeeded)
                {
                    talkText.text = "";
                }
                Doll = null;
                Horse.GetComponent<Animator>().SetInteger("animState", 0);
                wellSaid = false;
            }
        }else{
            //Sets text on the screen to it's defaults and nullifies any variable that are only needed when
            //looking at certain colliders
            //called again to make sure the player is looking at either nothing or an untagged object
            infoText.text = "";
            infoText.color = new Color(194, 0, 0, 255);
            if (ScoreKeeper.GetComponent<ScoreKeeper>().dollsSacrificed < ScoreKeeper.GetComponent<ScoreKeeper>().dollsNeeded)
            {
                talkText.text = "";
            }
            Doll = null;
            Horse.GetComponent<Animator>().SetInteger("animState", 0);
            wellSaid = false;
        }
    }
}//written by Ashton Westrick