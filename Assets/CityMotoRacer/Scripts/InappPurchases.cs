 
using UnityEngine;
using System.Collections;

public class InappPurchases : MonoBehaviour {

	public GameObject bikeSelectionMenu;
	public Camera uiCamera;
	void OnEnable () {
		
	
		
	}
	
	void Update () {
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			MouseUp(Input.mousePosition );
		}
		
	}
	//this static bool will give coins only once  per game session.
	public static bool alreadyGiveFreeCoins=false;
	void MouseUp(Vector3 a )
	{
		Ray ray = uiCamera.ScreenPointToRay(a);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 500))
		{
			SoundController.Static.PlayClickSound();
			Debug.Log(gameObject.name + "    " + hit.collider.name);
			switch(hit.collider.name)
			{
			case "buy1":
				Debug.Log("Clicked on Buy 1" );
				//iosInappAndFacebook.staticInstance.buy1();
				break;
			case "buy2":
				//iosInappAndFacebook.staticInstance.buy2();
				Debug.Log("Clicked on Buy 2" );
				break;
			case "buy3":
			//	iosInappAndFacebook.staticInstance.buy3();
				Debug.Log("Clicked on Buy 3" );
				break;
			case "BACK":
				bikeSelectionMenu.SetActive(true);
				gameObject.SetActive(false);
				
				break;
				
				
			}
			
		}
		
	}
}
 