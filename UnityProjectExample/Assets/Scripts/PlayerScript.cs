using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//Player Health and Ammo Count
	public int playerHealth,AmmoCount;
	//Bools to keep track of what power up effects  are active
 	public	bool isInvincible,StrBoost,DefBoost;
	//Time associated with being invincible
	float invincibiltyTime;

		


	// Use this for initialization
	void Start () 
	{
		playerHealth = 2;
		AmmoCount = 10;
		StrBoost = false;
		DefBoost = false;
		isInvincible = false;
	}

	/*void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "PickUp") 
		{
			Debug.Log ("You have hit a pickup");
		}
	}*/

	// Update is called once per frame
	void Update () 
	{
		if (isInvincible == true) 
		{
			//Set it to where the player is invincible for 10 seconds
			// Update is called once per frame
			invincibiltyTime += Time.deltaTime;
			if (invincibiltyTime == 10) 
			{
				isInvincible = false;
			}
		}
		if (playerHealth == 0) 
		{
			//Show a Game Over Screen
		}
		if (StrBoost == true) 
		{
			//Show the StrBoost UI Element
		}
		if (DefBoost == true) 
		{
			//Show the DefBoost UI Element
		}
		if (AmmoCount != 0) 
		{
			//The Player cannot shoot anymore and needs to find pick ups to refill
			//His ammo count
		}
		else 
		{
			//otherwise he doesn't need to refill ammo and can shoot :)
		}

	}
}
