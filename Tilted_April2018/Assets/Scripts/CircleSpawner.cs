using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour {

    [Range(1, 30)] public int circleRadius;

    [SerializeField] GameObject enemy;
    [SerializeField] int maxEnemies;
    [SerializeField] float spawnTimer;

    Coroutine CoActivateSpawn;

    List<GameObject> enemies;
    Stack<GameObject> respawnEnemies;

    public void AddToRespawnList(GameObject enem)
    {
        respawnEnemies.Push(enem);
    }

    void Spawn()
    {
        GlobalSpawnController.AddEnemy(enemy);
        enemies.Add(enemy);
        Vector3 pos = new Vector3(Random.insideUnitCircle.x * circleRadius, 0, Random.insideUnitCircle.y * circleRadius) + transform.position;
        Instantiate(enemy, pos, transform.rotation);
    }

    void Respawn()
    {
        GameObject enem = respawnEnemies.Pop();
        Vector3 pos = new Vector3(Random.insideUnitCircle.x * circleRadius, 0, Random.insideUnitCircle.x * circleRadius) + transform.position;
        enem.transform.position = pos;
        enem.SetActive(true);
    }

    IEnumerator CoActivateSpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTimer);

            if (enemies.Count != maxEnemies && GlobalSpawnController.CanAdd)
            {
                Spawn();
            }
            else if (respawnEnemies.Count != 0)
            {
                Respawn();
            }
        }
    }

    void OnEnable()
    {
        enemies = new List<GameObject>();
        respawnEnemies = new Stack<GameObject>();
        CoActivateSpawn = StartCoroutine(CoActivateSpawnEnemy());
    }

    void OnDisable()
    {
        StopCoroutine(CoActivateSpawn);
    }
}
