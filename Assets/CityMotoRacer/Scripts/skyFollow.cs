using UnityEngine;
using System.Collections;

public class skyFollow : MonoBehaviour {

	
	public Transform targetTrans,thisTransform ;
 
	public Vector3 offset;
	
	// Update is called once per frame
	bool justOnce = false;
	float speed = 0.2f;
	
	void Start()
	{
		thisTransform = transform;
		 
		
	}
	 
	
	 
	void LateUpdate () {
		
		
	 
	 
		
		
		if (!GamePlayController.isGameEnded && targetTrans != null) {
			thisTransform.position = new Vector3 (offset.x+ targetTrans.position.x , offset.y, targetTrans.position.z + offset.z);
		} 
		
	}
	 
}
