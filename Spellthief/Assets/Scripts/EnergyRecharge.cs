using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyRecharge : MonoBehaviour {

    public float MaxEnergy; // maximum energy
    public float EnergyRegen; // regen per second
    public Image EnergyBar; // bar top represent
    public float Cost; // cost per shot

    private float Energy = 0;


    // Update is called once per frame
    void Update () {
        float EnergyPercent;

        if (Energy < MaxEnergy) // if energy is not full
        {
            Energy += EnergyRegen* Time.deltaTime; //add energy per second
        }
        if (Input.GetButtonDown("Fire1")) // when the player uses ability
        {
           Energy -= Cost; // subtract cost
        }

        EnergyPercent = Energy / MaxEnergy; // get energy as percent
        EnergyBar.fillAmount = EnergyPercent; // show bar as x % full
    }
}
        