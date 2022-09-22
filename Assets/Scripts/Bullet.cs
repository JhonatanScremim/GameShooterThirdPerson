using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; //Aplicar velocidade para frente
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Ao colidir com algo, destrua
        Destroy(gameObject);
    }
}
