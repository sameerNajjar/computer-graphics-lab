using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected float dmg;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float nextFire;
    [SerializeField] protected InputControl inputControl;
    public Camera cam;
    void Start() {
    }

    void Update()
    {
        
    }
    public virtual void shoot(object obj, EventArgs e) {
    }
}
