using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamageable {

    public float Health
    {
        get
        {
            return health;
        }
        private set
        {
            health -= value;
            Mathf.Clamp(health, 0f, 10f);

            if(health == 0f)
            {
                Die();
            }
        }
    }
    
    [SerializeField] float health;

    public void TakeDamage(float damage)
    {
        Health = damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
