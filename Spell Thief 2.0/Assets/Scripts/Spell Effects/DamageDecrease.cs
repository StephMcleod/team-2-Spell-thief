using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDecrease : MonoBehaviour {

    public int DeteroationRate;
    public float WaitTime;

    // Update is called once per frame
    void Update () {
        WaitTime += Time.deltaTime;
        if (GetComponent<SpellHit>().Damage >= 10)
        {
            if (WaitTime >= 2)
            {
                GetComponent<SpellHit>().Damage -= DeteroationRate;
                WaitTime = 0;
            }
        }
	}
}
