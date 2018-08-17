using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

    public GameObject Spell; // object to fire
    public GameObject player;
    public AudioClip sound; // sound not specified yet
    private AudioSource SoundPlayer;
    private float Shottime = 0.0f; // when was the last shot
	
    void Start()
    {
        SoundPlayer = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

	void Update () {
        if (Input.GetButtonDown("Fire1")) // if the play clicks LMB
        {
            if (player.GetComponent<ManaBar>().Mana >= player.GetComponent<ManaBar>().Cost) // delay has ended
            {
                Instantiate(Spell, transform.position , transform.rotation); // create spell prefab
                player.GetComponent<ManaBar>().Mana -= player.GetComponent<ManaBar>().Cost; // subtract cost
                SoundPlayer.PlayOneShot(sound, 1f);
            }
        }
	}
}
