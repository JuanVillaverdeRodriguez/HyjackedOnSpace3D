using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float _health = 100f;
    public void hit(float damage) {
        _health -= damage;

        if (_health <= 0f) {
            Destroy(gameObject);
        }
    }

    public void setHealth(float health) {
        _health = health;
    }

    public float getHealth() {
        return _health;
    }

}
