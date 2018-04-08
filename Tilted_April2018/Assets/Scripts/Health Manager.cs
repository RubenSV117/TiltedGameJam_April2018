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
            health = value;
        }
    }

    [SerializeField] float health;

    public void TakeDamage(float damage)
    {
        Health = damage;
    }
}
