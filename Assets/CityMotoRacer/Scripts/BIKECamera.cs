using UnityEngine;
using System.Collections;
using System;
public class BIKECamera : MonoBehaviour {

	// Use this for initialization

	public Transform targetTrans,thisTransform ;
	public static BIKECamera Static;
	public Vector3[] OffectTypes,camRotations    ;
	public Vector3 offset;
	 
	// Update is called once per frame
	bool justOnce = false;
	float speed = 0.2f;

	   void Start()
	   {
		speed = 0.2f;
		Static = this;

		}
	public int camIndex ; 

	public void ChangeCamera()
	{

		camIndex++;
		if (camIndex > OffectTypes.Length - 1)
						camIndex = 0;
	}
	void LateUpdate () {


		offset = OffectTypes[camIndex];
		thisTransform.rotation = Quaternion.Euler ( camRotations[camIndex]);


		if (!GamePlayController.isGameEnded && targetTrans != null) {
			thisTransform.position = new Vector3 (offset.x, offset.y, targetTrans.position.z + offset.z);
				} else {
			   
			thisTransform.Translate(Vector3.forward*speed  );
				if(!justOnce)
				{
				justOnce=true;
				Invoke("disableScript",0.4f);
				}
				}
	
		}

	void disableScript()
	{
		speed = 0;

	}
}
