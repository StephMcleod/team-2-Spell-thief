using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFlame : MonoBehaviour
{

    public GameObject Fire;
    public Transform Burningobject;
    public Transform Player;
    public Vector3 Hitpoint;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("PlayerCaster").transform;
    }

    // Update is called once per frame
    void CreateFire()
    {
       Instantiate(Fire,(Hitpoint), new Quaternion(0,0,0,0),Burningobject);
    }
}
