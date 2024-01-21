using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour
{
    public float explosionRadius = 10f;
    public float explosionForce = 2000f;
    public float delayBeforeExplode = 3f;

    void Start()
    {
       
        StartCoroutine(ExplodeAfterDelay());
    }

    IEnumerator ExplodeAfterDelay()
    {
        
        yield return new WaitForSeconds(delayBeforeExplode);

      
        Explode();
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = rb.transform.position - transform.position;
                float distance = direction.magnitude;

                float force = 1 - (distance / explosionRadius);
                force = Mathf.Clamp01(force);

                rb.AddForce(direction.normalized * explosionForce * force);
            }
        }

       
        Destroy(gameObject);
    }
}
