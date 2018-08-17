using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallSpawner : MonoBehaviour {

    public float timeLeft;
    public float resetTime;
    public GameObject pitfallEnemy;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is ca
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Instantiate(pitfallEnemy, gameObject.transform);
            timeLeft = resetTime;
        }
    }


}
