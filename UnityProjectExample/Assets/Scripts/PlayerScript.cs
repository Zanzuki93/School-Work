using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//Player Health and Ammo Count
	public int playerHealth,AmmoCount;
	public int PlayerDamage, PlayerDefense;
	public float Sanity;
	//Bools to keep track of what power up effects  are active
 	public	bool isInvincible,StrBoost,DefBoost;
	//Time associated with being invincible
	public float invincibiltyTime;
	public int EnemyDamage;
		


	// Use this for initialization
	void Start () 
	{
		playerHealth = 100;
		AmmoCount = 0;
		PlayerDamage = 10;
		PlayerDefense = 100;
		Sanity = 100;
		StrBoost = false;
		DefBoost = false;
		isInvincible = false;
	}

	void OnControllerColliderHit(ControllerColliderHit player)
	{
		if (player.collider.tag == "PickUp") 
		{
			if (playerHealth < 100) 
			{
				playerHealth = 100;
				Debug.Log ("PlayerHealth is now full");
				Destroy (player.collider.gameObject);
			}
				
		}
		if (player.collider.tag == "Sword") 
		{
			StrBoost = true;
			PlayerDamage = PlayerDamage * 2;
			/*if (PlayerDamage > 20) {
				PlayerDamage = 20;
			}*/
			Debug.Log ("Damage Has Been Increased");
			Destroy (player.collider.gameObject);
		}
		if (player.collider.tag == "Shield") 
		{
			DefBoost = true;

			Debug.Log ("Defense Has Been Increased");
			Destroy (player.collider.gameObject);
		}
		if (player.collider.tag == "Invincibility") 
		{
			isInvincible = true;
			Debug.Log ("Your Invincible Go WILD!!");
			Destroy (player.collider.gameObject);
		}
		if (player.collider.tag == "Enemy") 
		{
			if (DefBoost == false) {
				playerHealth -= EnemyDamage;
			}
			else 
			{
				playerHealth -= EnemyDamage / 2;
			}
		}
		if (player.collider.tag == "Ammo") 
		{
			Debug.Log ("You have collected Ammo");

			if (AmmoCount == 10) 
			{
				//otherwise he doesn't need to refill ammo and can shoot :)
			}
			else if(AmmoCount <10)
			{
				//The Player cannot shoot anymore and needs to find pick ups to refill
				//His ammo count
				AmmoCount = 10;
				Destroy (player.collider.gameObject);

			}

		}
	}

	// Update is called once per frame
	void Update () 
	{
		Sanity -= Time.deltaTime / 8;
		if (isInvincible == true) 
		{
			//Replenish Sanity 
			Sanity += Time.deltaTime * 4;
			if (Sanity >= 100) 
			{
				Sanity = 100;
			}
			//Set it to where the player is invincible for 10 seconds
			// Update is called once per frame
			invincibiltyTime += Time.deltaTime;
			//Set Enemy Damage to 0
			EnemyDamage = 0;
			if (invincibiltyTime >= 10) 
			{
				invincibiltyTime = 10;
				isInvincible = false;
			}
		} 
		else 
		{
			isInvincible = false;
			invincibiltyTime = 0;
			EnemyDamage = 10;
		}
		if (playerHealth <= 0) 
		{
			playerHealth = 0;
			//Show a Game Over Screen
			Debug.Log("You have failed to return chivalry to the land");
		}
		if (StrBoost == true) 
		{
			//Show the StrBoost UI Element
		}
		if (DefBoost == true) 
		{
			//Show the DefBoost UI Element
			EnemyDamage = EnemyDamage / 2;
		}
		if (Sanity <= 75) 
		{
			EnemyDamage = EnemyDamage * 2;
		}
		if (Sanity <= 50) 
		{
			EnemyDamage = EnemyDamage * 4;
		}
		if (Sanity <= 25) 
		{
			EnemyDamage = EnemyDamage * 6;
			if (DefBoost == true) 
			{
				DefBoost = false;
			}
			if (StrBoost == true) 
			{
				StrBoost = false;
			}
		}
		if (Sanity == 0) 
		{
			Sanity = 0;
		}

	}
}
