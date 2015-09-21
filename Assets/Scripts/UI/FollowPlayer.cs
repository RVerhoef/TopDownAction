//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    private Transform _player;
    //private float _followSpeed = 8;
    private Vector3 _offset;

	void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _offset = new Vector3(transform.position.x, transform.position.y, -10);
	}
	
	void Update ()
    {
        //float step = _followSpeed * Time.deltaTime;

        if (_player != null)
        {
            //transform.position = Vector3.MoveTowards (transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y, -10), step);
            transform.position = _player.position + _offset;
        }
	}
}
