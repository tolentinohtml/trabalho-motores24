using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    private Rigidbody rb;
    private AudioSource source;
    public bool noChão;




    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("START");
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!noChão && collision.gameObject.CompareTag("Chão"))
        {
            noChão = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log("UPDATE");

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && noChão)
        {
            // Pulo
            source.Play();
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChão = false;
        }
        if (transform.position.y < -10)
        {

            FindObjectOfType<GameManager>().GameOver();


        }

        if (transform.position.y < -40)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
    }
}
