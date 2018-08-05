using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBeam : MonoBehaviour {

    public Transform Player;
    public LineRenderer lineDraw;
    private RaycastHit2D Hit;
    public LayerMask Layers;
    public float Damage;
    public float cost;
    public float ArcRange;

    // Use this for initialization
    void Start () {
        lineDraw = GetComponent<LineRenderer>(); // line render component
        Player = GameObject.Find("PlayerCaster").transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        Hit = Physics2D.Raycast(Player.transform.position, Player.transform.right,100,Layers);
        if (Hit.transform != null)
        {
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
        lineDraw.SetPosition(0, Player.position); // set line start at player
        lineDraw.SetPosition(1, Player.right * 100); //draw line 100 units
        
        if (Hit.transform != null)
        {
            lineDraw.SetPosition(1, Hit.point); // stop line if something is hit
            RaycastHit2D ArcTarget = Physics2D.CircleCast(Hit.point, ArcRange, transform.forward, ArcRange, Layers);
            if (Physics2D.CircleCast(Hit.point,ArcRange,transform.forward, ArcRange,Layers))
            {
                lineDraw.SetPosition(2, ArcTarget.transform.position);
            }
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
