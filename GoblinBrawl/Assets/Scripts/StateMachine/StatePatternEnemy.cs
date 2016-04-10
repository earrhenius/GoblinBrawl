using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour 
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float attackRate = 3f;
	public float sightRange = 20f;
	public float attackRange = 5f;
	public int attackDamage  = 10;
	public float currentHealth = 20;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	public MeshRenderer meshRendererFlag;
	[HideInInspector]public float movementSpeed = 0f;
	[HideInInspector]public float turnSpeed = 0f;
	Vector3 m_GroundNormal;

	[HideInInspector]public float m_TurnAmount = 0f;
	[HideInInspector]public float m_ForwardAmount = 0f;


	private MeshCollider damageHitBox;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Animator enemyAnimator;
	[HideInInspector] public PlayerHealth playerHealth;
	[HideInInspector] public DeathState deathState;

	[HideInInspector] public Animator playerAnim;
	private void Awake()
	{
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
		attackState = new AttackState (this);
		deathState = new DeathState (this);
		navMeshAgent = GetComponentInChildren<NavMeshAgent> ();

		enemyAnimator = gameObject.GetComponentInChildren<Animator>();
		playerHealth = GameObject.FindGameObjectWithTag("PlayerComponents").GetComponent<PlayerHealth>();
		playerAnim = GameObject.FindGameObjectWithTag("PlayerComponents").GetComponentInChildren<Animator>();
	}
	
	// Use this for initialization
	void Start () 
	{
		currentState = patrolState;
	}
	
	// Update is called once per frame
	public void TakeDamage(int amount)
	{

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentState = deathState;
		}
		Debug.Log(currentHealth);
	}
	
	void Update () 
	{
		currentState.UpdateState ();
		

		
	}
	public void Move(Vector3 move)
	{



		if (move.magnitude > 1f) move.Normalize();

		move = transform.InverseTransformDirection(move);

		move = Vector3.ProjectOnPlane(move, m_GroundNormal);

		m_TurnAmount = Mathf.Atan2(move.x, move.z);

		m_ForwardAmount = move.z;

		UpdateAnimator(move);
	}
	void UpdateAnimator(Vector3 move)
	{
		//Debug.Log (m_TurnAmount);
		// update the animator parameters
		enemyAnimator.SetFloat ("movementSpeed", m_ForwardAmount*10, 0.1f, Time.deltaTime);
		enemyAnimator.SetFloat ("turnSpeed", m_TurnAmount*10, 0.1f, Time.deltaTime);


		//var desiredDistance = Vector3.Distance(navMeshAgent.desiredVelocity, Vector3(0,0,0));
		//currentVelocity = Mathf.Lerp(lastVelocity, desiredDistance, (Time.deltaTime * 2));
		//lastVelocity = currentVelocity;
		//enemyAnimator.SetFloat("movementSpeed", lastVelocity);        // Pass currentVelocity to Animator
		

	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter(other);
		//if (other.gameObject.CompareTag ("Weapon"))
		//{
		//
		//if (currentHealth <= 0)
		//{
		//	currentState = deathState;
		//	Destroy(gameObject);
		//}
		//	TakeDamage(playerHealth.playerWeaponDamage);
		//	Debug.Log(currentHealth);
		//}
	}
}