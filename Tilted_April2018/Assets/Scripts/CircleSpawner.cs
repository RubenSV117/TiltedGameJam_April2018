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
        Vector3 pos = new Vector3(Random.insideUnitCircle.x * circleRadius, 0, Random.insideUnitCircle.y * circleRadius) + transform.position;
        GameObject enem = Instantiate(enemy, pos, transform.rotation).gameObject;

        GlobalSpawnController.AddEnemy(enem);
        enemies.Add(enem);
        enem.GetComponent<JalepenoEntity>().spawner = gameObject;
    }

    void Respawn()
    {
        GameObject enem = respawnEnemies.Pop();
        Vector3 pos = new Vector3(Random.insideUnitCircle.x * circleRadius, 0, Random.insideUnitCircle.x * circleRadius) + transform.position;
        enem.transform.position = pos;
        enem.GetComponent<JalepenoEntity>().JalState = JalepenoEntity.State.Alive;
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
