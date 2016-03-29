using UnityEngine;
using System.Collections;

public class DeathState : IEnemyState 
	
{
	private readonly StatePatternEnemy enemy;

	public DeathState (StatePatternEnemy statePatternEnemy)
	{
	}
	
	public void UpdateState()
	{

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
		//Debug.Log ("Can't transition to same state");
	}



	
	
}