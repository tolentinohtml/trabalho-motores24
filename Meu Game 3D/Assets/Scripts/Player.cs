using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int velocidade =  10;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message:"START");
        TryGetComponent (out rb);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(message:"UPDATE");
        float h = Input.GetAxis("Horizontal") ;
        float v = Input.GetAxis("Vertical");
        UnityEngine.Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime,ForceMode.Impulse);
    }
}
