using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChargedAtom : ChargedAtom {

    public float mass = 1;
    public Rigidbody rb;

    public void Start()
    {
        UpdateColor();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.useGravity = false;
    }
}
