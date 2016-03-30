using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


	public int playerHealthValue =100;
	// Use this for initialization
	[SerializeField]
	private Text HealthValue;
	[HideInInspector] public bool isDead;

	void Awake ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
	
		HealthValue.text = playerHealthValue.ToString();
	}

	public void TakeDamage (int amount)
	{


		// Set the damaged flag so the screen will flash.
		//damaged = true;

		// Reduce the current health by the damage amount.
		playerHealthValue -= amount;

		// Set the health bar's value to the current health.
		//healthSlider.value = currentHealth;
		
		// Play the hurt sound effect.
		//playerAudio.Play ();
		//
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(playerHealthValue <= 0 && !isDead)
		{

			Death ();
		}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		gameObject.GetComponent<PlayerLocomotion> ().isDead = true;
		gameObject.GetComponent<PlayerAttack> ().isDead = true;
		// Turn off any remaining shooting effects.
		//playerShooting.DisableEffects ();
		gameObject.GetComponent<Ragdoll>().activateRagdoll = true;
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
