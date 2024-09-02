using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade =  10;
    public int forcaPulo = 7;
    private Rigidbody rb;
    public bool noChão;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message:"START");
        TryGetComponent (out rb);
    }
     private void OnCollisionEnter(Collision collision){
        if(!noChão && collision.gameObject.tag == "Chão"){
            noChão=true;
        }
     }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(message:"UPDATE");
        float h = Input.GetAxis("Horizontal") ;
        float v = Input.GetAxis("Vertical");
        UnityEngine.Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime,ForceMode.Impulse);

if(Input.GetKeyDown(KeyCode.Space)&& noChão){
    rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
    noChão = false;
}





            if(transform.position.y < -10)
        {SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
    }
}
