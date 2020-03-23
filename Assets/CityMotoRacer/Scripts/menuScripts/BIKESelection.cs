using UnityEngine;
using System.Collections;

public class BIKESelection : MonoBehaviour {

	// Use this for initialization

	public Camera uiCamera;
	public Renderer[] buttonRenders;
	public Texture[] buttonTexture;
	public RaycastHit hit;
	public GameObject buyButton,playButton;
	public GameObject buyPopUp,InAPPMenu;
	public GameObject loadingLevelObj;

	void Start () 
	{
		//Debug.Log( "BIKESelection.cs is Attached to " + gameObject.name );

#if UNITY_EDITOR || UNITY_WEBPLAYER
		TotalCoins.staticInstance.AddCoins(999999); //allot some coins to test it 
#endif

	}
	public GameObject menuObj;
	void Update () {
		if( Input.GetKeyDown(KeyCode.Mouse0) )
		{
			
			MouseDown(Input.mousePosition );
		}
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			MouseUp(Input.mousePosition );
		}

		if( Input.GetKeyUp(KeyCode.Escape) )
		{
			menuObj.SetActive(true);
			gameObject.SetActive(false);
		}

		if( Input.GetKeyUp(KeyCode.P) )
		{
			TotalCoins.staticInstance.AddCoins(999999);
		}
		if( Input.GetKeyUp(KeyCode.Q) )
		{
			TotalCoins.staticInstance.ClearCoins();
		}
	}
	
	
	
	void MouseUp(Vector3 a )
	{
		foreach(Renderer r in buttonRenders )
		{
			r.material.mainTexture = buttonTexture[0];
		}
		Ray ray = uiCamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{

			switch(hit.collider.name)
			{
			case "next":
				showNextBIKE();
				break;
			case "previous":
				showPreviousBIKE();
				break;
				
			case "play":
				 
				loadingLevelObj.SetActive(true);
				gameObject.SetActive(false);

				 
				break;
			case "buyBIKE" :

				purchaseBIKEs();
				break;
				
			}

		}
		
	}
	void MouseDown(Vector3 a )
	{
		
		Ray ray = uiCamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{
			SoundController.Static.PlayClickSound();
			Debug.Log("mouse hit on "+ hit.collider.name);
			switch(hit.collider.name)
			{
			case "next":
				buttonRenders[0].material.mainTexture  = buttonTexture[1];
				break;
			case "previous":
				buttonRenders[1].material.mainTexture  = buttonTexture[1];
				break;
				
			case "play":
				buttonRenders[2].material.mainTexture  = buttonTexture[1];
				break;
			case "buyBIKE" :
				buttonRenders[3].material.mainTexture  = buttonTexture[1];
				break;
			case "wwq":
				buttonRenders[4].material.mainTexture  = buttonTexture[1];
				break;
				
			}
			
			
		}
		
	}
    
	public static int BIKEIndex=0;
	public GameObject[] BIKEMeshObjs;
	public TextMesh BIKESpeedDisplayText,BIKEPriceDisplayText,headingText;
	void showNextBIKE()
	{
		BIKEIndex++;
		if( BIKEIndex > BIKEMeshObjs.Length-1 ) BIKEIndex=0;
		for( int BIKECount=0 ; BIKECount<= BIKEMeshObjs.Length-1; BIKECount ++ )
		{
			BIKEMeshObjs[BIKECount].SetActive(false);
			
		}
		BIKEMeshObjs[BIKEIndex].SetActive(true);
		showBIKEINFO();
	}
	void showPreviousBIKE()
	{
		BIKEIndex--;
		if( BIKEIndex < 0 ) BIKEIndex=BIKEMeshObjs.Length-1;
		for( int BIKECount=0 ; BIKECount<= BIKEMeshObjs.Length-1; BIKECount ++ )
		{
			BIKEMeshObjs[BIKECount].SetActive(false);
			
		}
		BIKEMeshObjs[BIKEIndex].SetActive(true);
		showBIKEINFO();
	}
	void OnEnable()
	{
		if(BIKEIndex ==0 ) return;
		if( PlayerPrefs.GetInt("isBIKE"+BIKEIndex+"Purchased",0) == 1 )
		{
			playButton.SetActive(true);
			buyButton.SetActive(false);
		}
		else{
			buyButton.SetActive(true);
			playButton.SetActive(false);
		}
		 
		 
	}
	void showBIKEINFO()
	{

		switch(BIKEIndex)
		{
		case 0:
			headingText.text="MODEL : Hunter ";
			BIKESpeedDisplayText.text ="Top speed : 120 kmh";
			BIKEPriceDisplayText.text = "PRice  :    FREE ";
			playButton.SetActive(true);
			buyButton.SetActive(false);
			break;
		case 1:
			headingText.text="MODEL : Eagle";
			BIKESpeedDisplayText.text ="Top speed : 130 kmh";
			BIKEPriceDisplayText.text = "PRice  :     1000 ";
			if(PlayerPrefs.GetInt("isBIKE1Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 2:
			headingText.text="MODEL : Racer ";
			BIKESpeedDisplayText.text ="Top speed : 130 kmh";
			BIKEPriceDisplayText.text = "PRice  :     3000 ";
			
			if(PlayerPrefs.GetInt("isBIKE2Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 3:
			headingText.text="MODEL : Racer-X";
			BIKESpeedDisplayText.text ="Top speed : 140 kmh";
			BIKEPriceDisplayText.text = "PRice  :     4000 ";
			
			if(PlayerPrefs.GetInt("isBIKE3Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 4:
			headingText.text="MODEL : F1-Bike";
			BIKESpeedDisplayText.text ="Top speed : 160 kmh";
			BIKEPriceDisplayText.text = "PRice  :     5000 ";
			
			if(PlayerPrefs.GetInt("isBIKE4Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 5:
			headingText.text="MODEL : Truck";
			BIKESpeedDisplayText.text ="Top speed : 180 kmh";
			BIKEPriceDisplayText.text = "PRice  :     7000 ";
			
			if(PlayerPrefs.GetInt("isBIKE5Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		}

	}

	void purchaseBIKEs()
	{

		switch(BIKEIndex)
		{
		case 1:

			if( TotalCoins.staticInstance.totalCoins >= 1000 )
			{
				buyPopUP.BIKECost=1000;//to set the cost in buyPopUpScript
				buyPopUp.SetActive(true);
				gameObject.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
					gameObject.SetActive(false);
			}
			 
			break;
		case 2:
			if( TotalCoins.staticInstance.totalCoins >= 3000 )
			{
				buyPopUP.BIKECost=3000;
				buyPopUp.SetActive(true);
				gameObject.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				gameObject.SetActive(false);
			}
			
			break;
		case 3:
			if( TotalCoins.staticInstance.totalCoins >= 4000 )
			{
				buyPopUP.BIKECost=4000;
				buyPopUp.SetActive(true);
				gameObject.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				gameObject.SetActive(false);
			}
			
			break;
		case 4:
			if( TotalCoins.staticInstance.totalCoins >= 5000 )
			{
				buyPopUP.BIKECost=5000;
				buyPopUp.SetActive(true);
				gameObject.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				gameObject.SetActive(false);
			}
			
			break;
		case 5:
			if( TotalCoins.staticInstance.totalCoins >= 6000 )
			{
				buyPopUP.BIKECost=6000;
				buyPopUp.SetActive(true);
				gameObject.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				gameObject.SetActive(false);
			}
			
			break;
		}

	}
}
