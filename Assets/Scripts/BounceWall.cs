using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    [SerializeField] float explosionForce = 500f;
    [SerializeField] float explosionRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            collision.rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }
}
