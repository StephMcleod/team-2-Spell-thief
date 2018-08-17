using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBlock : MonoBehaviour {

    public float timeLeft;
    public float resetTime;

    public int breakStepsTotal;
    public int currentStep;
    public GameObject sourceBlock;
    public GameObject[] breakBlocks;

    public int currentBreakBlock;

    public int[] breakBlocksThisStep;
    public int i;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<BoxCollider2D>().enabled == false)
        {
            if (currentStep < breakStepsTotal)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    breakingPhase();
                    timeLeft = resetTime;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void breakingPhase()
    {
            for (i = 0; i < breakBlocksThisStep[currentStep]; i++)
            {
                Destroy(breakBlocks[currentBreakBlock]);
                ++currentBreakBlock;
            }
            ++currentStep;
    }


}
