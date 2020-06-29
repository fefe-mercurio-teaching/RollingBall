using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    int score = 0;

    private void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement.z += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1f;
        }

        transform.Translate(movement * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        score++;
    }
}
