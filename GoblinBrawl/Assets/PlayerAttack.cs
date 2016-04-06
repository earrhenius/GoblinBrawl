using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

	public bool isDead;
	[SerializeField]
	private Animator anim;
	private bool xButton;
	[SerializeField]
	private GameObject[] Weapons;

	//IEnumerator AttackButtonAndWait(float waitTime)
	//{

		//yield return new WaitForSeconds(waitTime);
		//for(int i = 0; i < Weapons.Length; i++)
		//{
		//	Weapons[i].GetComponent<Weapon>().oneTime=false;
		//}

	//}
	// Use this for initialization
	void FixedUpdate()
	{
		if (!isDead)
		{
			if (Input.GetButtonDown("X"))
	   		{
				anim.SetTrigger("NormalAttack");
				//coroutine how often button can be pressed

				//StartCoroutine(AttackButtonAndWait(3.0F));


	   		}


		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
