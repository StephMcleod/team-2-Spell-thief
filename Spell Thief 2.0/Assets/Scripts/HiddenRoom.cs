using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour {

    public float alpha = 0;
    public Color spriteColor;

    // Use this for initialization
    void Start ()
    {
        spriteColor = GetComponent<SpriteRenderer>().color;
        alpha = spriteColor.a;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alpha = 0;
        spriteColor.a = alpha;

        GetComponent<SpriteRenderer>().color = spriteColor;
    }
}
