using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	private int currentHealth;

	[SerializeField]
	private StatePatternEnemy enemy;
	private bool oneTime = false;
	//[HideInInspector] public PlayerHealth playerHealth;
	private string currentAniState;

	IEnumerator AttackButtonAndWait(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		print("WaitAndPrint " + Time.time);
		oneTime = false;
	}

	// Use this for initialization
	void awake ()
	{
		//playerHealth = GameObject.FindGameObjectWithTag("PlayerComponents").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonUp("X"))
		{
			
			//coroutine how often button can be pressed
			oneTime = false;
			//StartCoroutine(AttackButtonAndWait(2.0F));
			
			//print();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Weapon"))
		{
			//print(enemy.playerAnim);
			if(enemy.playerAnim.GetCurrentAnimatorStateInfo(0).IsName("SlidePunch 1") || enemy.playerAnim.GetCurrentAnimatorStateInfo(0).IsName("NormalAttack2") || enemy.playerAnim.GetCurrentAnimatorStateInfo(0).IsName("NormalAttack3"))
			{

					if(!oneTime)
					{
						enemy.TakeDamage(enemy.playerHealth.playerWeaponDamage);
						oneTime = true;
						
						
						//Debug.Log ( animPercentage);
						//StartCoroutine(WaitAndTweak(1.0F));
					}

			}

		}
	}
}
