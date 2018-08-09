using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {

    public float Max; // maximum energy
    public float NewMax;
    public float RegenRate; // regen per second
    public Image Bar; // bar top represent
    public float Cost; // cost per shot
    public float[] segments; // array of segments from high to low

    public float Mana = 0;

    private void Start()
    {
        Mana = Max;
        Bar = GameObject.Find("Mana").GetComponent<Image>();
    }


    // Update is called once per frame
    void Update () {
        float ManaPercent;

        if (Mana <= NewMax) // if energy is not full
        {
            Mana += RegenRate* Time.deltaTime; //add energy per second
        }

        if(Mana > NewMax) Mana = NewMax;

        ManaPercent = Mana / Max; // get energy as percent
        Bar.fillAmount = ManaPercent; // show bar as x % full
        
        foreach (float i in segments)
        {
            if (Mana <= i) NewMax = i; // if falls below then set as new max
        }
    }
}
        