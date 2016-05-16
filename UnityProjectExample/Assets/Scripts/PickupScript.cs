using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	//The Player
	public PlayerScript playerScript;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerScript.playerHealth < 6) 
		{
			playerScript.playerHealth = 6;
		}
	}
}
