using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamageable {

    public enum State
    {
        Alive,
        Dead
    };

    public float Health
    {
        get
        {
            return health;
        }
        private set
        {
            health -= value;
            health = Mathf.Clamp(health, 0f, 10f);

            if(health == 0f)
            {
                Die();
                Debug.Log("You Died!!");
            }
        }
    }

    [HideInInspector] public State state;
    
    [SerializeField] float health;

    public void TakeDamage(float damage)
    {
        if(state == State.Alive) Health = damage;
    }

    void Start()
    {
        state = State.Alive;
    }

    void Die()
    {
        state = State.Dead;
        gameObject.SetActive(false);
    }
}
