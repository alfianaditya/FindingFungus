using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemdrop : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DropItem()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(transform.forward * 100);
        rb.AddForce(transform.up * 100);
        rb.AddTorque(transform.right * 100);
    }
}
