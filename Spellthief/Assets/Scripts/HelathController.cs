﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelathController : MonoBehaviour {

    public float Health;
    public float MaxHealth;
    public Image HealthBar;
    public float HealthPercent;

    public void Start()
    {
        MaxHealth = Health;
        DrawHealth();// run draw health function
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health -= collision.gameObject.GetComponent<BulletForce>().Damage;  //subtract damage value
        if (Health <= 0) Destroy(gameObject); // if health is 0 or lower destroy
        DrawHealth();  // run draw health function
    }

    public void DrawHealth()
    {
        if (HealthBar != null) // if an object is specified
        {
            HealthPercent = Health/MaxHealth; // get health as percent
            HealthBar.fillAmount = HealthPercent;
        }
    }
}