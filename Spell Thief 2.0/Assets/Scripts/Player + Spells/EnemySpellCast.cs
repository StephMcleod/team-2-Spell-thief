using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellCast : MonoBehaviour
{

    public GameObject Spell; // object to fire
    public float Delay; // minmum time between shots
    float LastShot = 0.0f; // when was the last shot
    public float Range = 10;
    public AudioClip sound; // sound not specified yet
    private AudioSource SoundPlayer;
    public LayerMask LayerFilter;
    GameObject Target;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        SoundPlayer = Target.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Target != null)
        {
            Vector3 dir = Target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // geta ngle to face the object using trig
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);// rotates specified number of degrees around upwards vector

            if (Physics2D.Raycast(transform.position, Vector2.left, Range, LayerFilter)) // if the enemy finds an object with specified distance
            {
                if (Time.time >= LastShot + Delay) // delay has ended
                {
                    GameObject Projectile = Instantiate(Spell, transform.position, transform.rotation); // create spell
                    Projectile.layer = 9; // set as enemy shot
                    SoundPlayer.PlayOneShot(sound, .5f); // play specified sound at 50% volume
                    LastShot = Time.time; // register time of shot
                }
            }
        }
        else
        {
            Target = GameObject.FindGameObjectWithTag("Player"); //retarget player on respawn
            SoundPlayer = Target.GetComponent<AudioSource>();
        }
    }
}