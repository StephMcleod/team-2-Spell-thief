using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpell : MonoBehaviour {

    public float NewCost;
    public GameObject NewSpell;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<ManaBar>().Cost = NewCost;
            collision.gameObject.GetComponentInChildren<CastSpell>().Spell = NewSpell;
            Destroy(gameObject);
        }
    }
}
