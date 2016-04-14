using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState 
	
{
	private readonly StatePatternEnemy enemy;
	private int nextWayPoint;
	
	public PatrolState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}
	
	public void UpdateState()
	{
		Look ();
		Patrol ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}
	
	public void ToPatrolState()
	{
		Debug.Log ("Can't transition to same state");
	}
	
	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}
	
	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}
	public void ToAttackState()
	{
		
	}
	public void ToDeathState()
	{
		//Debug.Log ("Can't transition to same state");
	}
	public void ToHurtState()
	{
		enemy.currentState = enemy.deathState;
	}
	private void Look()
	{

		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}
	
	void Patrol ()
	{

		enemy.enemyAnimator.SetFloat ("movementSpeed", 2.0f);
		//slowMg = Mathf.Lerp(slowMg, mg, (Time.deltaTime*4));
		//enemy.Move(enemy.navMeshAgent.desiredVelocity);
		//Debug.Log (enemy.navMeshAgent.desiredVelocity);
		enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;
		enemy.navMeshAgent.Resume ();
		
		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
		{
			nextWayPoint =(nextWayPoint + 1) % enemy.wayPoints.Length;
			
		}
		
		
	}
}