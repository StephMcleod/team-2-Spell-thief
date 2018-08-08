using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBeam : MonoBehaviour {

    public Transform Player;
    private RaycastHit2D Hit;
    public LayerMask Layers;
    public float FreezeMod;

    void Start()
    {
        Player = GameObject.Find("PlayerCaster").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Hit = Physics2D.Raycast(Player.transform.position, Player.transform.right, 100, Layers);
        if (Hit.transform != null)
        {
            if (Hit.transform.GetComponent<HealthController>() != null) // if there is a target
            {
                    if (Hit.transform.GetComponent<Freeze>() == null) //is the object frozen
                    {
                        Hit.transform.gameObject.AddComponent<Freeze>(); // add frozen script
                    }
                    else
                    {
                        Hit.transform.GetComponent<Freeze>().Life += Time.deltaTime * FreezeMod;
                    }
                }
        }
    }

}
