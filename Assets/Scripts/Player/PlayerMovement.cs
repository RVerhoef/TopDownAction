//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private float _speed = 10;
	private Rigidbody2D _rigidBody;
	private Vector3 _mousePos;
    private GameObject _currentWeapon;
    private GameObject _currentWeaponOverworld;
    public GameObject[] _weapons;

	void Awake () 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
        
        //Finds all the weapons on the player and puts them in the weapon array
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.tag == "RangedWeapon" || child.tag == "MeleeWeapon")
            {
                System.Array.Resize(ref _weapons, _weapons.Length + 1);
                _weapons[i] = (child.gameObject);
                i++;
            }

        }
       
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

        //Player gets his fists out if he holds no other weapon
        if (_currentWeapon == null)
        {
            for (int i = 0; i < _weapons.Length; i++)
                if (_weapons[i].name == "Fist")
                {
                    _weapons[i].SetActive(true);
                    _currentWeapon = _weapons[i];
                }

        }

        //If the player already has a weapon, he can drop it and gain his fists back
        if (Input.GetKeyDown("g") && _currentWeapon != null && _currentWeapon.name != "Fist")
        {
            _currentWeapon.SetActive(false);
            _currentWeapon = null;
            _currentWeaponOverworld.transform.position = gameObject.transform.position;
            _currentWeaponOverworld.SetActive(true);
            _currentWeaponOverworld = null;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        //If the player is standing on a weapon and presses the spacebar, he picks it up
        if (other.tag == "RangedWeapon" && Input.GetKeyDown("space") && _currentWeapon.name == "Fist" || other.tag == "MeleeWeapon"  && Input.GetKeyDown("space") && _currentWeapon.name == "Fist")
        {
            _currentWeapon.SetActive(false);
            for (int i = 0; i < _weapons.Length; i++)
                if(_weapons[i].name == other.name)
                {
                    _weapons[i].SetActive(true);
                    _currentWeapon = _weapons[i];
                }
            _currentWeaponOverworld = other.gameObject;
            other.gameObject.SetActive(false);
        }

   }
         
}
