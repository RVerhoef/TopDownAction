//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PistolPickup : MonoBehaviour, IShootable<int,int>
{
	
	public void Shoot(int damage, int ammo)
	{
        Debug.Log("Bang!");
	}
	
}
