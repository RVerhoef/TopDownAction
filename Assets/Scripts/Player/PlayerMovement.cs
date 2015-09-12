//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private float _speed = 10;
	private Rigidbody2D _rigidBody;
	private Vector3 _mousePos;
    private GameObject _currentWeapon;
    public GameObject[] _weapons;

	void Awake () 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		//Player can move in 8 directions by pressing a combinations of the movement keys
		if(Input.GetAxis ("Horizontal") < 0 || Input.GetAxis ("Horizontal") > 0)
		{
			_rigidBody.velocity = new Vector2 ((Input.GetAxis ("Horizontal") * (_speed)), _rigidBody.velocity.y);
		}
		else
		{
			_rigidBody.velocity = new Vector2 (0, _rigidBody.velocity.y);
		}

		if(Input.GetAxis ("Vertical") < 0 || Input.GetAxis ("Vertical") > 0)
		{
			_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, (Input.GetAxis ("Vertical") * (_speed)));
		}
		else
		{
			_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, 0);
		}

		//Player rotates towards the mouse pointer / recticle 
		_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, _mousePos - transform.position);

		if(Input.GetMouseButton(0))
		{
			
		}

	}

    //If the player is standing on a weapon and presses the spacebar, he picks it up
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "RangedWeapon" && Input.GetKeyDown("space"))
        {
            for (int i = 0; i < _weapons.Length; i++)
                if(_weapons[i].name == other.name)
                {
                    _weapons[i].SetActive(true); 
                }
            Destroy(other.gameObject);
        }

   }
         
}
