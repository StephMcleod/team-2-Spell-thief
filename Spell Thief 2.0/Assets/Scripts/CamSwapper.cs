using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwapper : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Main Camera").transform.position = transform.position + new Vector3(0, 0, -15);
        }
    }
}
