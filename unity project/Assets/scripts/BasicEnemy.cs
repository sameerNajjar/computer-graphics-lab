
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    public void takeDMG(float dmg) {
        if (health - dmg > 0) {
            health-= dmg;
        }
        else {
            health= 0;
            Die();
        }
        Debug.Log(health);
    }
    public void Die() {
        Destroy(gameObject);
    }
}
