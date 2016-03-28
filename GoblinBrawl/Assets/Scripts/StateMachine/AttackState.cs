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
		enemy.currentState = enemy.chaseState;
		//searchTimer = 0f;
	}

	public void ToAttackState()
	{
		//Debug.Log ("Can't transition to same state");
	}


	private void Look()
	{
		enemy.navMeshAgent.Stop ();
		enemy.meshRendererFlag.material.color = Color.magenta;
		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.attackRange) && hit.collider.CompareTag ("Player"))
		{
			Debug.DrawLine (enemy.eyes.transform.position, hit.transform.position, Color.yellow);
			Attack ();
			//enemy.chaseTarget = hit.transform;
		}
		else
		{
			ToChaseState();
		}
	}
	
	private void Attack()
	{

		enemy.navMeshAgent.Stop ();
		//attackTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		//Debug.Log (attackTimer);
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(attackTimer >= enemy.attackRate && enemy.currentHealth > 0)
		{
			attackTimer = 0f;
			enemy.meshRendererFlag.material.color = Color.white;
			//Debug.Log ("attacking");

			// If the player has health to lose...
			// ... damage the player.
			enemy.playerHealth.TakeDamage(enemy.attackDamage);

		}

	}
	
	
}