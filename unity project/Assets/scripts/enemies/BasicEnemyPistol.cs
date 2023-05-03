using System;
using System.Collections;
using UnityEngine;

public class BasicEnemyPistol : Gun {
    public LayerMask enemyMask;
    void Start() {
    }

    void Update() {

    }
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private Vector3 bulletDirection(Vector3 playPosition) {
        Vector3 direction = playPosition;
        if (bulletSpread) {
            direction += new Vector3(
                UnityEngine.Random.Range(-spreadVariance.x, spreadVariance.x),
                UnityEngine.Random.Range(-spreadVariance.y, spreadVariance.y),
                UnityEngine.Random.Range(-spreadVariance.z, spreadVariance.z));
            direction.Normalize();
        }
        return direction;
    }
    public virtual void shoot(Vector3 playPosition) {
        RaycastHit hit;
        if (lastShootTime + fireRate < Time.time) {
            shooting.Play();
            if (Physics.Raycast(transform.position, bulletDirection(playPosition), out hit, range)) {
                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, true));
                lastShootTime = Time.time;
                Debug.Log(hit.collider.gameObject.layer);
                if (hit.collider.gameObject.layer == 8) {
                    Debug.Log("hit the shit ");
                    Player player=hit.collider.gameObject.GetComponent<Player>();
                    player.takeDMG(dmg);
                }
            }
            else {
                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, bulletSpawnPoint.position + bulletDirection(playPosition) * 100, Vector3.zero, false));
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

}
