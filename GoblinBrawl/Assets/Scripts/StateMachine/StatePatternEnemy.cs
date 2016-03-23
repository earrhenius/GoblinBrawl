using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour 
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float attackRate = 10f;
	public float sightRange = 20f;
	public float currentHealth = 20;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	public MeshRenderer meshRendererFlag;
	
	private MeshCollider damageHitBox;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	
	private void Awake()
	{
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
		attackState = new AttackState (this);

		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Use this for initialization
	void Start () 
	{
		currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentState.UpdateState ();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}