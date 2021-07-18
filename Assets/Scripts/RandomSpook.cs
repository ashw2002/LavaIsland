using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpook : MonoBehaviour {
    // this scripts plays a selection of random noises at regular but distant intervals
    public AudioClip[] noiseArray;
    private int x;
    public GameObject player;
	
	void Start () {
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("Spook", 120, 180);
	}
	
	
    void Spook() {
        x = Random.Range(0, noiseArray.Length - 1);
        AudioSource.PlayClipAtPoint(noiseArray[x], player.transform.position, 7);
	}
}
