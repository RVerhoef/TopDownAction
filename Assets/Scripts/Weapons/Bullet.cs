//Written By Rob Verhoef
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private float _bulletForce = 800;

    void Awake ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(transform.up * _bulletForce);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //Bullet is destroyed when it hits a static object
        if(other.tag == "StaticObject")
        {
            Destroy(gameObject);
        }
    }
}
