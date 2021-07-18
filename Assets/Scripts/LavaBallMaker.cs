using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBallMaker : MonoBehaviour {
    public GameObject LavaBall;
    private float baseTime = 120f;
    //SpawnTimeDif prevents the multiple spawners to activate at the exact same time
    public float spawnTimeDif = 10f;
    public float repeatTime = 10f;
    private float x;
	// Use this for initialization
	void Start () {
        //Has the spawners initail tigger staggered but then repeat at regular intervals 
        InvokeRepeating("launchBall", baseTime + spawnTimeDif, repeatTime);
	}

    void launchBall() {
        //Launches the lava ball at a random angle on the X-axis toward the island (fixed z and y axis)
        x = Random.Range(-500f, 500f);
        GameObject lavaInstance = Instantiate(LavaBall, transform.position, transform.rotation);
        lavaInstance.GetComponent<Rigidbody>().AddForce(x, 1000, -1000);
    }
}
//Written by Ashton Westrick