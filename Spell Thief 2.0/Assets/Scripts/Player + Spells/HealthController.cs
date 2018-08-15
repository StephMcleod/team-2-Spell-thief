using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public float Health;
    public float MaxHealth;
    public Image HealthBar;
    public float HealthPercent;

    public AudioClip sound; // sound not specified yet
    private AudioSource SoundPlayer;

    public void Start()
    {
        MaxHealth = Health;
        SoundPlayer = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            Health -= collision.gameObject.GetComponent<SpellHit>().Damage;  //subtract damage value
            DrawHealth();  // run draw health function
            SoundPlayer.PlayOneShot(sound, 1f);
            Debug.Log("Hurt");
            Destroy(collision.gameObject);
        }
    }

    public void DrawHealth()
    {
        if (HealthBar != null) // if an object is specified
        {
            HealthPercent = Health/MaxHealth; // get health as percent
            HealthBar.fillAmount = HealthPercent;
        }
        if (Health <= 0) Destroy(gameObject); // if health is 0 or lower destroy
    }
}