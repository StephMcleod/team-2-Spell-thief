using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

    public float timeLeft;
    public float resetTime;
    public GameObject dialogueBox;
    public string dialogue;
    public Text dialogueText;
    public GameObject player;
    public bool disableMovement;
    private bool hit;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hit == true)
        {
            timeLeft -= Time.deltaTime;
            dialogueBox.SetActive(true);
            dialogueText.text = dialogue;

            if (disableMovement == true)
            {
                player.GetComponent<Movement2D>().enabled = false;
                player.GetComponent<Teleport>().enabled = false;
                player.GetComponentInChildren<CastSpell>().enabled = false;
            }

            if (timeLeft < 0)
            {
                dialogueBox.SetActive(false);
                timeLeft = resetTime;
                player.GetComponent<Movement2D>().enabled = true;
                player.GetComponent<Teleport>().enabled = true;
                player.GetComponentInChildren<CastSpell>().enabled = true;
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
    }
}
