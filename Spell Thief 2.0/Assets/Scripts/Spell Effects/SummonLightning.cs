using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonLightning : MonoBehaviour {

    public GameObject Bolt;
    GameObject PostSummon;
    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("PlayerCaster");
    }

    void OnDestroy()
    {
        PostSummon = Instantiate(Bolt,(Player.transform.position + new Vector3(0,5,0)), new Quaternion(0,0,0,0));
        Vector3 dir = (transform.position - PostSummon.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //get angle of the triangle created by screen coords using tan (player to mouse is hypotonuse)
        PostSummon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);// rotates specified number of degrees around upwards vector offset by 90 and inverted
    }
}
