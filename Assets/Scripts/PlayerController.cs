using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float forceIntensity;
    [SerializeField] float jumpIntensity;

    int score = 0;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * forceIntensity);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * forceIntensity);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceIntensity);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceIntensity);
        }

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.AddForce(Vector3.up * jumpIntensity, ForceMode.Impulse);
        }

        if (transform.position.y <= -10f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            score++;
        }
        else if (other.tag == "EndLevel")
        {
            Debug.Log("Fine livello");
        }
    }
}
