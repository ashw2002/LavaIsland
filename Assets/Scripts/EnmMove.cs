// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnmMove: MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float initialSpeed;
    private float currentSpeed;
    public GameObject ScoreKeeper;
    public AudioClip deathScream;


    void Start()
    {
        ScoreKeeper = GameObject.FindWithTag("Score");
        agent = GetComponent<NavMeshAgent>();
        initialSpeed = agent.speed;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();

    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0){
            return;
        }

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        //Stops death once the player wins
        if (ScoreKeeper.GetComponent<ScoreKeeper>().dollsSacrificed >= ScoreKeeper.GetComponent<ScoreKeeper>().dollsNeeded){
            agent.speed = 0;
            AudioSource.PlayClipAtPoint(deathScream, transform.position);
            Destroy(gameObject);
        }else{
            //Death will speed up as the player progresses though he will never be as fast as the player's max speed
            currentSpeed = initialSpeed + ScoreKeeper.GetComponent<ScoreKeeper>().dollsCollected + ScoreKeeper.GetComponent<ScoreKeeper>().dollsSacrificed;
            agent.speed = currentSpeed;
        }
    }


    void Update()
    {
        GotoNextPoint();
    }
} //Copied from Unity API with modifications made by Ashton Westrick