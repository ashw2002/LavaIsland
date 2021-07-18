using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//A simple script that sends the player to the lose screen when they collide with a "Deadly" object
public class Death : MonoBehaviour
{
    public GameObject ScoreKeeper;
    Collider impacter;
    void Start()
    {
        impacter = gameObject.GetComponent<Collider>();
        ScoreKeeper = GameObject.FindWithTag("Score");
         
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deadly"))
        {
            //winning still requires death as you test your 'immortality'
            if (ScoreKeeper.GetComponent<ScoreKeeper>().win)
            {
                //Loads the win scene
                SceneManager.LoadScene(3);
            }
            else
            {
                //Loads the lose scene

                SceneManager.LoadScene(2);
            }
        }
    }
}
//Written By Ashton Westrick