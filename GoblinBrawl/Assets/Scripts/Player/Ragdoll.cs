using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {
	
	
	public Component[] bones;
	public Animator anim;
	[HideInInspector]public bool activateRagdoll;
	
	
	// Use this for initialization
	void Start () {
		
		bones = gameObject.GetComponentsInChildren<Rigidbody> (); 
		//anim = GetComponent<Animator> ();
		
		
	}
	void Update ()
		
	{
		if (activateRagdoll)
			killRagdoll ();
		
	}
	
	// Update is called once per frame
	void killRagdoll () 
	{
		foreach (Rigidbody ragdoll in bones)
		{
			ragdoll.isKinematic = false;
		}
		
		anim.enabled = false;
	}
}