using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public float Cost;
    public AudioClip sound; // sound not specified yet
    private AudioSource SoundPlayer;

    void Start()
    {
        SoundPlayer = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (GetComponent<ManaBar>().Mana >= Cost)
                {
                    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    GetComponent<ManaBar>().Mana -= Cost;
                    SoundPlayer.PlayOneShot(sound, 1f);
                }
            }
        }
    }
