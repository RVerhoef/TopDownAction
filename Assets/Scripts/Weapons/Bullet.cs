using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private float _bulletForce = 10;

    void Awake ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(transform.forward * _bulletForce);
    }
	
	void Update ()
    {
	
	}
}
