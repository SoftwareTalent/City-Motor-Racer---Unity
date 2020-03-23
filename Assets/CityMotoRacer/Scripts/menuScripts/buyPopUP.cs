using UnityEngine;
using System.Collections;

public class buyPopUP : MonoBehaviour {

	// Use this for initialization
	public TextMesh costText;
	public GameObject BIKESelectionMenu;
	public Camera uiCamera;
	public static int BIKECost;
	void OnEnable()
	{
		  costText.text=" "+BIKECost;
   

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			MouseUp(Input.mousePosition );
		}

	}

	void MouseUp(Vector3 a )
	{
		 Ray ray = uiCamera.ScreenPointToRay(a);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 500))
		{
			Debug.Log(gameObject.name + "    " + hit.collider.name);
			switch(hit.collider.name)
			{
			case "YES":
				 
				PlayerPrefs.SetInt("isBIKE"+BIKESelection.BIKEIndex+"Purchased",1); // to save the BIKE lock status
				Debug.Log(BIKESelection.BIKEIndex);
				TotalCoins.staticInstance.deductCoins(BIKECost);
				 
				BIKESelectionMenu.SetActive(true);
				gameObject.SetActive(false);
				break;
			case "NO":

				BIKESelectionMenu.SetActive(true);
				gameObject.SetActive(false);
				break;
			 
				
			}
			
		}
		
	}
}
