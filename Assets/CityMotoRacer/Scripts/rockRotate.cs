using UnityEngine;
using System.Collections;

public class rockRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate (0, Random.Range (0, 36)*10, 0);
		Destroy (this);
	}
	
	 
}
