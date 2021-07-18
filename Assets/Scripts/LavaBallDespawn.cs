using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBallDespawn : MonoBehaviour {
	//Despawns the lava balls, enough said
	void Awake () {
        Invoke("despawnBall", 7);
	}

    void despawnBall (){
        Destroy(gameObject);   
    }	
}
//Written By Ashton Westrick