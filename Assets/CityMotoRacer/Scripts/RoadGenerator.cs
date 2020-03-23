using UnityEngine;
using System.Collections;
using System;
public class RoadGenerator : MonoBehaviour {

	// Use this for initialization
 
	bool justOnce =false;
	static  int roadBlockCount=1;
	public GameObject otherRoadBlock;
//	public static GameObject OtherStaticBlock;
	void OnEnable()
	{
		playerBIKEControl.gameEnded += cancelDestroy;
	}
	void OnDisable()
	{
		playerBIKEControl.gameEnded -= cancelDestroy;
	}
	void cancelDestroy(System.Object obj,EventArgs args)
	{
    		CancelInvoke ("SwitchRoadBlocks");
	}
	              
	public float BlockDistance;
	void  Start()
	{
	 

	 
	 
	}

	//once the player triggers ,we are translating this otherblock to infront of current block   
	void OnTriggerEnter(Collider inc )
	{
		 
		if( inc.tag.Contains("Player") && justOnce==false)
		{
			//print ("NEW road  Generated "+gameObject.name);
			GameObject newBlock =   otherRoadBlock ;//GameObject.Instantiate(this.gameObject) as GameObject;
			newBlock.name="road" + roadBlockCount;
			roadBlockCount++;
			//229
			otherRoadBlock.transform.Translate( 0,0,BlockDistance); //road tile width//1104.015f*2
			justOnce=true;
			//Destroy(this.gameObject,20);
			Invoke("SwitchRoadBlocks",0.5f );
		}

	}

	void SwitchRoadBlocks()
	{
		justOnce = false;
	}
}
