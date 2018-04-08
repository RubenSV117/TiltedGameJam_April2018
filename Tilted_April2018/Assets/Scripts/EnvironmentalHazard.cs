using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalHazard : MonoBehaviour
{
    // Flat damage or DoT or both
    public bool instantDamage;
    public bool damageOverTime;

    // Vals to hit
    public float flatDamage;
    public float dotValue;

    // When to trigger DoT
    public float ticInterval;

    Coroutine dotCo;

    private void OnTriggerEnter(Collider other)
    {
        if(instantDamage)
        {
            if(other.GetComponent<Collider>().CompareTag("Player"))
            {
                other.GetComponent<HealthManager>().TakeDamage(flatDamage);
            }
        }

        if (damageOverTime)
        {
            if (other.GetComponent<Collider>().CompareTag("Player"))
            {
                //Start coroutine
                dotCo = StartCoroutine(DoT(other.gameObject));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (damageOverTime)
        {
            if (other.GetComponent<Collider>().CompareTag("Player"))
            {
                StopCoroutine(dotCo);
            }
        }
    }

    private IEnumerator DoT(GameObject player)
    {
        while (true)
        {
            player.GetComponent<IDamageable>().TakeDamage(dotValue);

            yield return new WaitForSeconds(ticInterval);
        }
    }
}
