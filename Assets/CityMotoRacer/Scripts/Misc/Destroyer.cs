using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	 

	void OnBecameInvisible() {

		 	Destroy(gameObject);
	}
}
