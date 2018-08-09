using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

void OnDestroy()
    {
        GameObject.Find("Spawnpoint").GetComponent<Respawn>().Invoke("Restart", 0);
    }
}
