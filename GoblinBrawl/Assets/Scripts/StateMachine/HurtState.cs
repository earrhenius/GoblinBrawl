using UnityEngine;
using System.Collections;

public class HurtState : IEnemyState 
	
{
	private readonly StatePatternEnemy enemy;

	public HurtState (StatePatternEnemy statePatternEnemy)
	{
	}
	
	public void UpdateState()
	{
		Hurt();
	}
	
	public void OnTriggerEnter (Collider other)
	{

	}
	
	public void ToPatrolState()
	{
		//searchTimer = 0f;
	}
	
	public void ToAlertState()
	{
		//Debug.Log ("Can't transition to same state");
	}
	
	public void ToChaseState()
	{
		//searchTimer = 0f;
	}

	public void ToAttackState()
	{
		//Debug.Log ("Can't transition to same state");
	}

	public void ToDeathState()
	{
		enemy.currentState = enemy.deathState;
	}
	public void ToHurtState()
	{
		//Debug.Log ("Can't transition to same state");
	}
	void Hurt()
	{

	}

	
	
}