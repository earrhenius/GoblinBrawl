using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public PlayerHealth playerHealth;
	public int weaponDamage = 5;
	[SerializeField]
	private Animator anim;
	public bool enemyHit =false;
	public bool oneTime =false;
	private void OnTriggerEnter(Collider other)
	{
		/*
		if (other.gameObject.CompareTag ("EnemyHealthCollider"))
			{
				if(anim.GetCurrentAnimatorStateInfo(0).IsName("SlidePunch 1") || anim.GetCurrentAnimatorStateInfo(0).IsName("NormalAttack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("NormalAttack3"))
            	{
					if(!oneTime)
					{
						Debug.Log (other.name);
						enemyHit=true;
						enemyHit=false;
						oneTime=true;
						//other.gameObject.GetComponent<StatePatternEnemy>().takeDamage(1);
					}
				}	//TakeDamage(playerHealth.playerWeaponDamage);
				//Debug.Log(currentHealth);

				//test statr of animsation
			}
		*/
	}

	void Start()
	{

		playerHealth.playerWeaponDamage = weaponDamage;

	}


}
