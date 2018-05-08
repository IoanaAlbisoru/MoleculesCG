using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedAtom : MonoBehaviour {

    public float charge = 1;

    public void Start()
    {
        UpdateColor();
    }

    public void UpdateColor()
    {
        Color color;
        if (charge == 1)
            color = Color.yellow;
        else if (charge == -1)
            color = Color.blue;
        else 
            color = Color.green;
        //Color color = charge > 0 ? Color.white : Color.blue;
        GetComponent<Renderer>().material.color = color;
    }
}
