using System;
using System.Collections;
using UnityEngine;

public class Pistol : Gun {
    public LayerMask enemyMask;
    void Start() {
        inputControl.onShoot += shoot;
    }

    void Update() {

    }
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public virtual void shoot(object obj, EventArgs e) {
        RaycastHit hit;
        if (lastShootTime + fireRate < Time.time) {
            shooting.Play();
            if (Physics.Raycast(cam.transform.position, bulletDirection(), out hit, range)) {
                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, true));
                lastShootTime = Time.time;
                BasicEnemyAi enemy = null;
                Debug.Log(hit.collider.gameObject.layer);
                if (hit.collider.gameObject.layer == 9) {
                    Debug.Log("hit some shit ");
                    enemy = hit.collider.gameObject.GetComponent<BasicEnemyAi>();
                }
                if (enemy != null) {
                    enemy.takeDMG(dmg);
                }
            }
            else {
                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, bulletSpawnPoint.position + bulletDirection() * 100, Vector3.zero, false));
                lastShootTime = Time.time;
            }
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact) {
        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;

        while (remainingDistance > 0) {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));

            remainingDistance -= BulletSpeed * Time.deltaTime;

            yield return null;
        }
        Trail.transform.position = HitPoint;
        if (MadeImpact) {
            Instantiate(impactParticle, HitPoint, Quaternion.LookRotation(HitNormal));
        }
        Destroy(Trail.gameObject, Trail.time);
    }
    private Vector3 bulletDirection() {
        Vector3 direction = cam.transform.forward;
        if (bulletSpread) {
            direction += new Vector3(
                UnityEngine.Random.Range(-spreadVariance.x, spreadVariance.x),
                UnityEngine.Random.Range(-spreadVariance.y, spreadVariance.y),
                UnityEngine.Random.Range(-spreadVariance.z, spreadVariance.z));
            direction.Normalize();
        }
        return direction;
    }
}
