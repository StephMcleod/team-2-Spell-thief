using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpell : MonoBehaviour {

    public float NewCost;
    public GameObject NewSpell;
    public AudioClip NewSound;
    public AudioClip sound; // sound not specified yet
    private AudioSource SoundPlayer;

    void Start()
    {
        SoundPlayer = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<ManaBar>().Cost = NewCost;
            collision.gameObject.GetComponentInChildren<CastSpell>().Spell = NewSpell;
            collision.gameObject.GetComponentInChildren<CastSpell>().sound = NewSound;
            SoundPlayer.PlayOneShot(sound, 1f);
            Destroy(gameObject);
        }
    }
}
