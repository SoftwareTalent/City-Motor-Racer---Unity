using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public GameObject gb;
	void Start () {
	//	Brake_rotation ();
	}
	
	void Brake_rotation()
	{
		iTween.RotateTo(gb,iTween.Hash("rotation",new Vector3(-30,0,0),"time",0.5f,"oncomplete","normalPosition","oncompletetarget",gameObject));//,"onstarttarget",gameObject,"oncompletetarget",gameObjects
	}
	void normalPosition()
	{
		iTween.RotateTo(gb,iTween.Hash("rotation",new Vector3(0,0,0),"time",0.5f,"oncomplete","StateChange"));
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Brake_rotation();
				}
	}
}
