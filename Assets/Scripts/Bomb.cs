using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float explosionRadius = 5f;
    public GameObject explosionEffect;
    void Start()
    {

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Collider bombCollider = GetComponent<Collider>();
            Collider playerCollider = player.GetComponent<Collider>();

            if (bombCollider != null && playerCollider != null)
            {
                Physics.IgnoreCollision(bombCollider, playerCollider);
            }
        }

        Invoke("Explode", delay);
    }

    public void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Destroy(nearbyObject.gameObject);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
