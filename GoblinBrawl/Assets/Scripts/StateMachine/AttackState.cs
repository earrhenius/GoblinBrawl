using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState 
	
{
	private readonly StatePatternEnemy enemy;
	private float attackTimer;
	
	public AttackState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}
	
	public void UpdateState()
	{
		Look ();

	}
	
	public void OnTriggerEnter (Collider other)
	{

	}
	
	public void ToPatrolState()
	{
		//enemy.currentState = enemy.patrolState;
		//searchTimer = 0f;
	}
	
	public void ToAlertState()
	{
		//Debug.Log ("Can't transition to same state");
	}
	
	public void ToChaseState()
	{
		//enemy.currentState = enemy.chaseState;
		//searchTimer = 0f;
	}

	public void ToAttackState()
	{

	}


	private void Look()
	{
		enemy.navMeshAgent.Stop ();
		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, 0.1f) && hit.collider.CompareTag ("Player"))
		{
			Debug.DrawLine (enemy.eyes.transform.position, hit.transform.position, Color.yellow);
			Attack ();
			//enemy.chaseTarget = hit.transform;
		}
		else
		{
			ToAlertState();
		}
	}
	
	private void Attack()
	{

		enemy.navMeshAgent.Stop ();
		//attackTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(attackTimer >= enemy.attackRate && enemy.currentHealth > 0)
		{
			attackTimer = 0f;

			Debug.Log ("attack");
			// If the player has health to lose...
			//if(playerHealth.currentHealth > 0)
			//{
				// ... damage the player.
			//	playerHealth.TakeDamage (attackDamage);
			//}
		}

	}
	
	
}