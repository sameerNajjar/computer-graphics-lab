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
    [SerializeField] protected float lastShootTime;
    [SerializeField] protected InputControl inputControl;
    [SerializeField] protected bool bulletSpread=true;
    [SerializeField] protected Vector3  spreadVariance = new Vector3(0.01f, 0.01f, 0.01f);
    [SerializeField] protected ParticleSystem shooting;
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected ParticleSystem impactParticle;
    [SerializeField] protected TrailRenderer bulletTrail;
    [SerializeField] protected Animator animator; //maybe i will use it to create reciol in the future
    [SerializeField] protected float BulletSpeed = 100;
    public Camera cam;
    void Start() {
    }

    void Update()
    {
        
    }
    public virtual void shoot(object obj, EventArgs e) {
    }
}
