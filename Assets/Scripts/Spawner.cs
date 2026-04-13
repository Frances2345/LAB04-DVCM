using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public int maxEnemies = 5;
    public float SpawnRange = 10f;
    public float checkDelay = 2f;

    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("CheckAndSpawn", 1f, checkDelay);
    }

    private void CheckAndSpawn()
    {
        activeEnemies.RemoveAll(item => item == null);

        if (activeEnemies.Count < maxEnemies)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 randomPos = transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 0, Random.Range(-SpawnRange, SpawnRange));
        GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        enemy.GetComponent<EnemyIA>().target = player;

        activeEnemies.Add(enemy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(SpawnRange * 2, 1, SpawnRange * 2));
    }
}
