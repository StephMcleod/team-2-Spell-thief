using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retarget : MonoBehaviour {

    public Rigidbody2D RB;
    public GameObject Target;
    public float magnitude;

    // Use this for initialization
    void Start () {
        GameObject[] TargetList = GameObject.FindGameObjectsWithTag("Enemy");
        Target = TargetList[0];
        RB = GetComponent<Rigidbody2D>();
        foreach(GameObject Targets in TargetList)
        {
            if((Targets.transform.position - transform.position).magnitude < (Target.transform.position - transform.position).magnitude)
            {
                Target = Targets;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null)
        {
            RB.velocity = new Vector2(0, 0);
            RB.AddForce((Target.transform.position - transform.position).normalized * magnitude);
        }
	}
}
