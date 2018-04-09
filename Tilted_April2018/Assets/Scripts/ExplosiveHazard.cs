using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveHazard : MonoBehaviour
{
    // Time before explosion
    public float maxExplosionTic;
    public float timeBeforeTic;
    // Damage caused by explosion
    public float explosionDamage;
    // Current counter
    private float currentTic;

    private bool inRadius;

    Coroutine exploCo;

    private void Start()
    {
        currentTic = 0;
    }

    // When within the radius, start countdown for explosion
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().CompareTag("Player"))
        {
            inRadius = true;
            exploCo = StartCoroutine(StartTimer(other.gameObject));
        }
    }

    // When outside of the radius, stop the countdown
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            inRadius = false;
        }
    }

    private IEnumerator StartTimer(GameObject player)
    {
        while (true)
        {
            if (inRadius)
            {
                //print("currentTic = " + currentTic);
                currentTic++;
            }
            else
                currentTic--;

            if (!inRadius && currentTic <= 0)
            {
                //print("exit Radius");
                StopCoroutine(exploCo);
            }
            if (inRadius && currentTic >= maxExplosionTic)
            {
                //print("explode");
                Explode(player);       

                StopCoroutine(exploCo);
            }

            yield return new WaitForSeconds(timeBeforeTic);
        }
    }

    private void Explode(GameObject player)
    {
        player.GetComponent<HealthManager>().TakeDamage(explosionDamage);

        // Destroys gameobject after explosion
        Destroy(gameObject.transform.parent.gameObject);
    }
}

