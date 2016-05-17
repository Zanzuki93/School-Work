using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//Player Health and Ammo Count
	public int playerHealth,AmmoCount;
	public int PlayerDamage, PlayerDefense;
	//Bools to keep track of what power up effects  are active
 	public	bool isInvincible,StrBoost,DefBoost;
	//Time associated with being invincible
	public float invincibiltyTime;
	public int EnemyDamage;
		


	// Use this for initialization
	void Start () 
	{
		playerHealth = 2;
		AmmoCount = 10;
		PlayerDamage = 5;
		PlayerDefense = 100;
		StrBoost = false;
		DefBoost = false;
		isInvincible = false;
	}

	void OnControllerColliderHit(ControllerColliderHit player)
	{
		if (player.collider.tag == "PickUp") 
		{
			if (playerHealth < 6) 
			{
				playerHealth = 6;
				Debug.Log ("PlayerHealth is now full");
			}
				
		}
		if (player.collider.tag == "Sword") 
		{
			StrBoost = true;
			PlayerDamage = PlayerDamage * 2;
			if (PlayerDamage > 20) {
				PlayerDamage = 20;
			}
			Debug.Log ("Damage Has Been Increased");
		}
		if (player.collider.tag == "Shield") 
		{
			DefBoost = true;

			Debug.Log ("Defense Has Been Increased");
		}
		if (player.collider.tag == "Invincibility") 
		{
			isInvincible = true;
			Debug.Log ("Your Invincible Go WILD!!");
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
	}

	// Update is called once per frame
	void Update () 
	{
		if (isInvincible == true) {
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
		if (AmmoCount == 10) 
		{
			//otherwise he doesn't need to refill ammo and can shoot :)
		}
		else if(AmmoCount <10)
		{
			//The Player cannot shoot anymore and needs to find pick ups to refill
			//His ammo count

		}

	}
}
