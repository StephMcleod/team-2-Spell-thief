using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<ManaBar>().Mana = collision.gameObject.GetComponent<ManaBar>().NewMax = collision.gameObject.GetComponent<ManaBar>().Max;
            Destroy(gameObject);
        }
    }
}
