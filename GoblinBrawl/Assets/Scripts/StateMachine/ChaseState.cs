using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState 
	
{
	
	private readonly StatePatternEnemy enemy;
	
	
	public ChaseState (StatePatternEnemy statePatternEnemy)
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
		
	}
	
	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}
	
	public void ToChaseState()
	{
		
	}

	public void ToAttackState()
	{
		enemy.currentState = enemy.attackState;

	}
	public void ToDeathState()
	{
		enemy.currentState = enemy.deathState;
	}
	public void ToHurtState()
	{
		//Debug.Log ("Can't transition to same state");
	}
	private void Look()
	{
		RaycastHit hit;
		Vector3 enemyForward = (enemy.gameObject.transform.forward);
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;


		float angle = Vector3.Angle(enemyForward, enemyToTarget);
		Vector3 cross = Vector3.Cross(enemyForward, enemyToTarget);
		if (cross.y < 0) {
			angle = -angle;
		}
		//float clampedAngle = Mathf.Clamp (angle, 90f, -90f);
		//float evenMoreclampedAngle = Mathf.Clamp (clampedAngle, 2f, -2f);
		//float angle = Vector3.Angle(enemyToTarget, enemyForward);
		Debug.Log(angle);

		Chase ((angle*0.01f));
		if (Physics.Raycast (enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player")) {
			enemy.chaseTarget = hit.transform;
			Debug.DrawLine (enemy.eyes.transform.position, hit.transform.position, Color.red);

			if(Vector3.Distance(enemy.chaseTarget.position , enemy.transform.position)<1f)
			{
				ToAttackState();
			}
		}

		else
		{
			ToAlertState();
		}
		
	}
	
	private void Chase(float turningSpeed)
	{

		//transform.rotation = Quaternion.Lerp(turretBall.rotation, desiredRotation, Time.deltaTime * turnSpeed); 
		enemy.enemyAnimator.SetFloat("turningSpeed", turningSpeed);
		//try aiming for player

		enemy.enemyAnimator.SetFloat ("movementSpeed", 5.0f);
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		enemy.navMeshAgent.Resume ();
	}

	
}