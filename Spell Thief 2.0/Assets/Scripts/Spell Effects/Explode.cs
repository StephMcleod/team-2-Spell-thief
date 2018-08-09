using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public float Range;
    public float Damage;
    public RaycastHit2D[] Targets;
    public ContactFilter2D filter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Targets = Physics2D.CircleCastAll(transform.position, Range, transform.up);

        foreach (RaycastHit2D Current in Targets)
        {
            Debug.LogWarning("Target hit: " + Current.transform.gameObject.name);
            if (Current.transform.gameObject.GetComponent<HealthController>() != null)
            {
                Current.transform.gameObject.GetComponent<HealthController>().Health -= Damage;
                Current.transform.gameObject.GetComponent<HealthController>().Invoke("DrawHealth", 0);
            }
        }
    }
}
