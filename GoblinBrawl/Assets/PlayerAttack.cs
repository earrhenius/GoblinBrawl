using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

	public bool isDead;
	[SerializeField]
	private Animator anim;
	private bool xButton;
	void Awake()

	{

	}
	// Use this for initialization
	void FixedUpdate()
	{
		if (!isDead)
		{
			if (Input.GetButtonDown("X"))
	   		{
				anim.SetTrigger("NormalAttack");

	   		}


		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
