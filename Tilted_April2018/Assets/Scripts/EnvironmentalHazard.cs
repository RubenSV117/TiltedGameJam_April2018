using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalHazard : MonoBehaviour
{
    // Flat damage or DoT or both
    public bool IsInstantDamage;

    // Vals to hit
    public float flatDamage;
    public float dotValue;

    // When to trigger DoT
    public float ticInterval;

    Coroutine dotCo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (IsInstantDamage) {
                other.GetComponent<HealthManager>().TakeDamage(flatDamage);
            }

            else {
                //Start coroutine
                dotCo = StartCoroutine(DoT(other.gameObject));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (!IsInstantDamage) {
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
