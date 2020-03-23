using UnityEngine;
using System.Collections;

public class trafficCar : MonoBehaviour {

	// Use this for initialization

	Transform thisTrans;
	public float speed;
	public Transform[] wheelObjs;
	public float wheelTurnSpeed;
	void Start () {

		thisTrans = transform;
		
		#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8
//		foreach(Transform t in transform.GetComponentsInChildren<Transform>() )
//		{ if(t.name.Contains("Shadow") ) {
//				Debug.Log(t.name);
//				Destroy(t.gameObject);
//			}
//		}
		#endif
		 
		gameObject.AddComponent<Rigidbody> ();
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Contains ("traffic"))
		{
			Destroy(gameObject);
		}

	}
	void Update () {

		thisTrans.Translate( 0,0,speed* Time.deltaTime );
		foreach (Transform  wheel in wheelObjs) {

			wheel.Rotate(wheelTurnSpeed*Time.deltaTime*2,0,0);
				}
	
	}

	void OnBecameInvisible() {
		//when destroying traffic BIKE,make sure it is behind the player BIKE
		if (playerBIKEControl.thisPosition.z > thisTrans.position.z) {
			Destroy (gameObject, 1.0f);
		}
	}

	bool justOnce=false;
	 
	public void StopCar()
	{
		speed=0;
		wheelTurnSpeed=0;
	}
}
