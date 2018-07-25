using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject Bullet; // object to fire
    public GameObject player;
    private float Shottime = 0.0f; // when was the last shot
	
	void Update () {
        if (Input.GetButtonDown("Fire1")) // if the play clicks LMB
        {
            Debug.Log("HIT");
            if (player.GetComponent<ManaBar>().Mana >= player.GetComponent<ManaBar>().Cost) // delay has ended
            {
                Instantiate(Bullet, transform.position , transform.rotation); // create spell prefab
                Debug.Log("HIT");
                player.GetComponent<ManaBar>().Mana -= player.GetComponent<ManaBar>().Cost; // subtract cost
            }
        }
	}
}
