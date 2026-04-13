using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;
    public GameObject ExplosionEffect;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.destination = target.position;
        }
    }

    public void ExplodeEnemy()
    {
        if(ExplosionEffect != null)
        {
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
