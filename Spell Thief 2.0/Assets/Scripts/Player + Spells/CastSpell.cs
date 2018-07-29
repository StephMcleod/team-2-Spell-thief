using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

    public GameObject Spell; // object to fire
    public GameObject player;
    private float Shottime = 0.0f; // when was the last shot
	
	void Update () {
        if (Input.GetButtonDown("Fire1")) // if the play clicks LMB
        {
            if (player.GetComponent<ManaBar>().Mana >= player.GetComponent<ManaBar>().Cost) // delay has ended
            {
                Instantiate(Spell, transform.position , transform.rotation); // create spell prefab
                player.GetComponent<ManaBar>().Mana -= player.GetComponent<ManaBar>().Cost; // subtract cost
            }
        }
	}
}
