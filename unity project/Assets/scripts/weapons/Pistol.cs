using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{

    void Start()
    {
    inputControl.onShoot += shoot;
    }

    void Update()
    {
        
    }
    public virtual void shoot(object obj, EventArgs e) {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && Time.time >= nextFire) {
            nextFire = Time.time + 1f / fireRate;
            BasicEnemy enemy = hit.transform.GetComponent<BasicEnemy>();
            if (enemy != null) {
                enemy.takeDMG(dmg);
            }
        }
    }
}
