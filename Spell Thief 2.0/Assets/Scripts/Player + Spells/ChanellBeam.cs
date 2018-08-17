using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanellBeam : MonoBehaviour {

    public GameObject Player;
    public LineRenderer lineDraw;
    private RaycastHit2D Hit;
    public LayerMask Layers;
    public float Damage;
    public float cost;

    // Use this for initialization
    void Start () {
        lineDraw = GetComponent<LineRenderer>(); // line render component
        Player = GameObject.FindGameObjectWithTag("Caster");
    }
	
	// Update is called once per frame
	void Update () {
        
        Hit = Physics2D.Raycast(Player.transform.position, Player.transform.right,100,Layers);
        
        if (Hit.transform != null)
        {
            Debug.Log(Player.transform.position);
            if (Hit.transform.GetComponent<HealthController>() != null) // if there is a target
            {
                Hit.transform.gameObject.GetComponent<HealthController>().Health -= Damage; // sybtract 1 health each frame
                Hit.transform.gameObject.GetComponent<HealthController>().Invoke("DrawHealth", 0); // redraw health
            }
            if (GetComponent<CreateFlame>() != null)
            {
                GetComponent<CreateFlame>().Hitpoint = Hit.point;
                GetComponent<CreateFlame>().Invoke("CreateFire", 0);
            }
        }
        lineDraw.SetPosition(0, Player.transform.position); // set line start at player
        lineDraw.SetPosition(1, Player.transform.right * 100); //draw line 100 units
        
        if (Hit.transform != null)
        {
            lineDraw.SetPosition(1, Hit.point); // stop line if something is hit
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(gameObject);
        }
        else if (GameObject.Find("Player").GetComponent<ManaBar>().Mana >= cost)
        {
            GameObject.Find("Player").GetComponent<ManaBar>().Mana -= cost;
        }
    }
}
