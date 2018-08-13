﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public float Health;
    public float MaxHealth;
    public Image HealthBar;
    public float HealthPercent;

    public void Start()
    {
        MaxHealth = Health;
        DrawHealth();// run draw health function
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.transform.tag == "Projectile")
        {
            Health -= collision.gameObject.GetComponent<SpellHit>().Damage;  //subtract damage value
            DrawHealth();  // run draw health function
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