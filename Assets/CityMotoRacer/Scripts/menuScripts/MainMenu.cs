using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Debug.Log( "MainMenu.cs is Attached to " + gameObject.name );

#if UNITY_IPHONE
		// Apple won't allow quit button in their app submission guides 
		menuButtonRenders[4].transform.parent.gameObject.SetActive(false);
#endif
	}
	public Camera uiCamera;
	public Renderer[] menuButtonRenders;
	public Texture[] buttonTexture;
	public RaycastHit hit;
	public GameObject storeObject;
	public GameObject BIKESelection;
	public string[] reviewUrls,MoreUrls;
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
			
			Application.Quit();
		}
	}

	bool isDrag=false;
	void OnGUI()
	{
		
		if(  Event.current.type == EventType.mouseDrag)
		{
			isDrag=true;
		}
		else isDrag=false;
		
		
		// GUI.Label(Rect(0,10,100,90),Input.mousePosition +"" );
	}

	void MouseUp(Vector3 a )
	{
		if(isDrag)return; //to avoid unwanted touches while swipine or mouse draging
		foreach(Renderer r in menuButtonRenders )
		{
			r.material.mainTexture = buttonTexture[0];
		}
		Ray ray = uiCamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{

			switch(hit.collider.name)
			{
			case "Play":
				BIKESelection.SetActive(true);
				gameObject.SetActive(false);
				break;
			case "Store":

				storeObject.SetActive(true);
				gameObject.SetActive(false);
			 
				break;
				
			case "more":
				string url="https://www.assetstore.unity3d.com/#publisher/920";
				#if UNITY_ANDROID
				
				#endif
				#if UNITY_IPHONE
				url = "https://itunes.apple.com/us/app/jet-boat-rush/id877610071?ls=1&mt=8";
				#endif
				#if UNITY_WP8
				url="http://www.windowsphone.com/en-IN/store/publishers?publisherId=Ace%2BGames&appId=b693c43c-dc64-4b03-b467-ee5821308fd3";
				#endif
				#if UNITY_WEBPLAYER
				url ="https://www.assetstore.unity3d.com/#publisher/920";
				#endif
				Application.OpenURL(url);
				break;
			case "RateUs":
				string rateurl="https://www.assetstore.unity3d.com/#publisher/920";
				#if UNITY_ANDROID

				#endif
				#if UNITY_IPHONE
				rateurl ="https://itunes.apple.com/us/app/f1-traffic-racer/id904284766?ls=1&mt=8";
				#endif
				#if UNITY_WP8
				rateurl="http://www.windowsphone.com/en-in/store/app/jet-BIKE-rush/b693c43c-dc64-4b03-b467-ee5821308fd3";
				#endif
				#if UNITY_WEBPLAYER
				url ="https://www.assetstore.unity3d.com/#publisher/920";
				#endif

				Application.OpenURL(rateurl);
				break;
			case "Quit":
				Application.Quit();
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
			//Debug.Log("mouse hit on "+ hit.collider.name);
			switch(hit.collider.name)
			{
			case "Play":
				menuButtonRenders[0].material.mainTexture  = buttonTexture[1];
				break;
			case "Store":
				menuButtonRenders[1].material.mainTexture  = buttonTexture[1];
				break;

			case "more":
				menuButtonRenders[2].material.mainTexture  = buttonTexture[1];
				break;
			case "RateUs":
				menuButtonRenders[3].material.mainTexture  = buttonTexture[1];
				break;
			case "Quit":
				menuButtonRenders[4].material.mainTexture  = buttonTexture[1];
				break;
			
				
			}

			 
		}
		
	}
}
