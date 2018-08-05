using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {

    public float Life;

	// Use this for initialization
	void Start ()
    {
        if (GetComponentInChildren<EnemySpellCast>() != null ) GetComponentInChildren<EnemySpellCast>().enabled = false; // disable attacking
        if (GetComponentInChildren<MeeleAttack>() != null) GetComponent<MeeleAttack>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ( Life <= 0) // when the enemy thaws out
        {
            Destroy(this);
        }
	}

    void OnDestroy()
    {
        if (GetComponentInChildren<EnemySpellCast>() != null) GetComponentInChildren<EnemySpellCast>().enabled = true; // enable attacking
        if (GetComponentInChildren<MeeleAttack>() != null) GetComponent<MeeleAttack>().enabled = true;
    }
}
