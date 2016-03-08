using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float smooth;

	[SerializeField]
	private Transform targetObject;

	private Transform cameraObject;
	void Awake()
	{
		cameraObject = gameObject.transform;
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position,targetObject.position,smooth);
	}
}
