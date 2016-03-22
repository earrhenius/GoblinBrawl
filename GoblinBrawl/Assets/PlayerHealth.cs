﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {


	public int playerHealth =100;
	// Use this for initialization
	[SerializeField]
	private GUIText HealthValue;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		HealthValue.text = playerHealth.ToString();
	}

	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		//damaged = true;
		
		// Reduce the current health by the damage amount.
		//currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		//healthSlider.value = currentHealth;
		
		// Play the hurt sound effect.
		//playerAudio.Play ();
		//
		// If the player has lost all it's health and the death flag hasn't been set yet...
		//if(currentHealth <= 0 && !isDead)
		//{
			// ... it should die.
		//	Death ();
		//}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		//isDead = true;
		
		// Turn off any remaining shooting effects.
		//playerShooting.DisableEffects ();
		
		// Tell the animator that the player is dead.
		//anim.SetTrigger ("Die");
		
		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
		//playerAudio.clip = deathClip;
		//playerAudio.Play ();
		
		// Turn off the movement and shooting scripts.
		//playerMovement.enabled = false;
		//playerShooting.enabled = false;
	} 
}
