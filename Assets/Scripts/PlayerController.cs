using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float forceIntensity;
    [SerializeField] float jumpIntensity;
    [SerializeField] Text scoreTextMesh;
    [SerializeField] Text timeTextMesh;
    [SerializeField] string nextLevel;
    [SerializeField] Image[] hearts;

    static int score = 0;
    static int life = 3;

    float time = 0f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        UpdateScoreText();
        UpdateTimeText();
        UpdateLifeTracker();
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
        time += Time.deltaTime;
        UpdateTimeText();

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.AddForce(Vector3.up * jumpIntensity, ForceMode.Impulse);
        }

        if (transform.position.y <= -10f)
        {
            life--;

            if (life <= 0)
            {
                SceneManager.LoadScene("GameOver");

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            score++;

            UpdateScoreText();
        }
        else if (other.tag == "EndLevel")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    void UpdateLifeTracker()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < life);
        }


        //if (life >= 3)
        //{
        //    hearts[0].gameObject.SetActive(true);
        //    hearts[1].gameObject.SetActive(true);
        //    hearts[2].gameObject.SetActive(true);
        //}
        //else if (life == 2)
        //{
        //    hearts[0].gameObject.SetActive(true);
        //    hearts[1].gameObject.SetActive(true);
        //    hearts[2].gameObject.SetActive(false);
        //}
        //else if (life == 1)
        //{
        //    hearts[0].gameObject.SetActive(true);
        //    hearts[1].gameObject.SetActive(false);
        //    hearts[2].gameObject.SetActive(false);
        //}
    }

    void UpdateScoreText()
    {
        scoreTextMesh.text = "Punti: " + score;
    }

    void UpdateTimeText()
    {
        timeTextMesh.text = "Tempo: " + time.ToString("0:##");
        //timeTextMesh.text = "Tempo: " + Mathf.RoundToInt(time);
    }

    bool GameOver()
    {
        return life <= 0;
    }
}
