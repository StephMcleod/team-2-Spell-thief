using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public GameObject Player;

	// Update is called once per frame
	public void Restart ()
    {
        Instantiate(Player, transform.position, new Quaternion(0, 0, 0, 0));
        Player.GetComponent<HealthController>().HealthBar = GameObject.Find("Health").GetComponent<Image>();
    }
}
