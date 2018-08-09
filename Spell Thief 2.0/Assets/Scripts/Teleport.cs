using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public float Cost;

    void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (GetComponent<ManaBar>().Mana >= Cost)
                {
                    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    GetComponent<ManaBar>().Mana -= Cost;
                }
            }
        }
    }
