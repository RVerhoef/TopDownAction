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
	
	void Update ()
    {
	
	}
}
