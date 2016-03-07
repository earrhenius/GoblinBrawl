using UnityEngine;
using System.Collections;


public class PlayerLocomotion : MonoBehaviour
	
{
	//annotatino:
	//should create separate class with ctrler input
	
	[SerializeField]
	private Animator anim;
	public Quaternion newrotation;
	[SerializeField]
	private float smooth = 0.1f;
	[SerializeField]
	private Transform playerCamera;
	private Vector3 movementVector;
	[SerializeField]
	private CharacterController myCharacterController;

	//[SerializeField]
	//private Rigidbody myRigidbody;
	//private float jumpPower = 15;
	//private bool temp = false;


	void Update()
	{
		
		//Debug.Log(arealState);
		
		float v = Input.GetAxis("Left Stick Y Axis");
		float h = Input.GetAxis("Left Stick X Axis");
		
		//float rightTrigger = Input.GetAxis("RightTrigger");
		//bool bButton = Input.GetButton("B");
		//bool aButton = Input.GetButton("A");
		
		float mg = new Vector3(v, h, 0).magnitude;
		

		movement(v, h, mg);
		rotate(v, h);
	}

	void OnAnimatorMove()
	{
		Vector3 velocity = anim.deltaPosition / Time.deltaTime;
		//velocity.y = myRigidbody.velocity.y;
		//myRigidbody.velocity = velocity;       
	}
	/*
	void FixedUpdate()
	{
		float vertical = Input.GetAxis("Left Stick Y Axis");
		float horizontal = Input.GetAxis("Left Stick X Axis");
		
		//rotate(vertical, horizontal);
		
		
	}*/
	void movement(float v, float h, float mg)
	{
		
		if (h != 0f || v != 0f)
		{

			//anim.SetBool("DodgeRoll", false);
			anim.SetFloat("movementSpeed", mg);

			//then move the player in that direction
		}
		else
		{
			anim.SetFloat("movementSpeed", 0);
			//Stop the player if user is not pressing any key
		}
	}

	void rotate(float v, float h)
	{
		if (v > 0)
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 45, 0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 305, 0);
			}
			else
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
			}
		}
		else if (v < 0)
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 135, 0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 225, 0);
			}
			else
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 180, 0);
			}
		}
		else
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 90, 0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0, playerCamera.eulerAngles.y + 270, 0);
			}
			else
			{
				newrotation = myCharacterController.transform.rotation;//myRigidbody.rotation;
			}
		}
		newrotation.x = 0;
		newrotation.z = 0;
		
		//We only want player to rotate in y axis 
		myCharacterController.transform.rotation = Quaternion.Slerp(myCharacterController.transform.rotation, newrotation, smooth);
		//Slerp from player's current rotation to the new intended rotaion smoothly
		
	}

	void calcSpeed()
	{
		//speed = distance/time
	}
}
