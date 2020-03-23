using UnityEngine;
using System.Collections;

public class rigidSpeed : MonoBehaviour {

	// Use this for initialization

	public Transform needle ;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//needle.rotation= Quaternion.Euler (rigidbody.velocity);
		  
		needle.rotation= Quaternion.Euler (new Vector3(0,0,  rigidbody.velocity.y  ) );
		//Mathf.Clamp(startRotation, endRotation, curSpeed/maxSpeed);

		//Debug.Log (rigidbody.velocity);
	
	}
}
