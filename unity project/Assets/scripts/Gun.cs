using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float dmg = 5f;
    [SerializeField] private float range = 75f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextFire = 0f;

    [SerializeField] private InputControl inputControl;
    public Camera cam;
    void Start() {
        inputControl.onShoot += shoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot(object obj, EventArgs e) {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, range)&& Time.time>=nextFire) {
            nextFire= Time.time+1f/fireRate;
            BasicEnemy enemy= hit.transform.GetComponent<BasicEnemy>();
            if(enemy != null) {
                enemy.takeDMG(dmg);
            }
        }

    }
}
