using UnityEngine;
using System.Collections;

public class JustOneHeavyVechileOnScene : MonoBehaviour {

	// Use this for initialization\
	public static bool isHeavyVechileOnScene = false ;
	void Start () {

		if (isHeavyVechileOnScene) Destroy (gameObject);

		else isHeavyVechileOnScene = true;
	}
	
	void OnBecameInvisible() {
		//when destroying traffic BIKE,make sure it is behind the player BIKE
		if (playerBIKEControl.thisPosition.z > transform.position.z) {
			Destroy (gameObject, 1.0f);
			isHeavyVechileOnScene = false;
		}
	}

}
