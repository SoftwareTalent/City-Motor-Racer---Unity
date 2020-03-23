using UnityEngine;
using System.Collections;

public class PurchaseItems : MonoBehaviour
{

		public Camera Cam;
		public string hitObjName;
		public int NitrousCost = 200;
		public int MagnetCost = 1000;
		//public GameObject insufficentCoins;
      	public GameObject mainmenu,Storemenu;
		public TextMesh NitrousCountTxt;
		public GameObject MagnetPower1, MagnetPower2, MagnetPower3, MagnetPower4;
	    public Renderer BuyNitrousRender,BuyMagnetRender,BackRender;
	    public Texture[] BuyNitrousTexture, BuyMagnetTexture,BackTexture;
		//MagnetCountTet;
	
		void Start ()
		{
		#if UNITY_EDITOR
	
    // PlayerPrefs.DeleteAll ();
		//TotalCoins.staticInstance.AddCoins (200000);
		#endif

		NitrousCountTxt.text = "" + PlayerPrefs.GetInt ("NitrousCount", 0);
	 
	//	print (PlayerPrefs.GetInt ("MagnetCount", 0));
		switch (PlayerPrefs.GetInt ("MagnetCount", 0)) {
		case 0:
			MagnetPower1.SetActive (false);
			MagnetPower2.SetActive (false);
			MagnetPower3.SetActive (false);
			MagnetPower4.SetActive (false);
			 
			break;
			
		case 1:
			MagnetPower1.SetActive (true);
			MagnetPower2.SetActive (false);
			MagnetPower3.SetActive (false);
			MagnetPower4.SetActive (false);
			 
			break;
		case 2:
			MagnetPower1.SetActive (true);
			MagnetPower2.SetActive (true);
			MagnetPower3.SetActive (false);
			MagnetPower4.SetActive (false);
			 
			break;
		case 3:
			MagnetPower1.SetActive (true);
			MagnetPower2.SetActive (true);
			MagnetPower3.SetActive (true);
			MagnetPower4.SetActive (false);
			 
			break;
		case 4:
			MagnetPower1.SetActive (true);
			MagnetPower2.SetActive (true);
			MagnetPower3.SetActive (true);
			MagnetPower4.SetActive (true);
			 
			break;
		}
		
	}
	
	void Update ()
	{
					if (Input.GetKeyUp (KeyCode.Mouse0)) {
			BuyNitrousRender.material.mainTexture = BuyNitrousTexture [0];
			BuyMagnetRender.material.mainTexture = BuyMagnetTexture [0];
			BackRender.material.mainTexture=BackTexture[0];

			Ray rayObj = Cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitObject;
			
			if (Physics.Raycast (rayObj, out hitObject)) {
				hitObjName = hitObject.collider.name;
			
								switch (hitObjName) {
				
				case "BuyNitrous":
					if (TotalCoins.staticInstance.getCoinCount () >= NitrousCost) {
						if(PlayerPrefs.GetInt ("NitrousCount", 0)==100)return;
					                        	PlayerPrefs.SetInt ("NitrousCount", PlayerPrefs.GetInt ("NitrousCount", 0) + 1);
					                        	NitrousCountTxt.text =  PlayerPrefs.GetInt ("NitrousCount", 0)+"";
					                        	TotalCoins.staticInstance.deductCoins (NitrousCost);
					
										} else {
												//					InGameUIController.Static.
												//					main
										}
				
										break;
				case "BackBtn":
					mainmenu.SetActive(true);
					Storemenu.SetActive(false);
					break;
				case "BuyMagnet":
					print ("hit Obj");
					if (TotalCoins.staticInstance.getCoinCount () >= MagnetCost && PlayerPrefs.GetInt ("MagnetCount", 0) <= 3) {
												print ("Magnet activated");

												PlayerPrefs.SetInt ("MagnetCount", PlayerPrefs.GetInt ("MagnetCount") + 1);
												TotalCoins.staticInstance.deductCoins (MagnetCost);
												switch (PlayerPrefs.GetInt ("MagnetCount", 0)) {
												case 0:
														MagnetPower1.SetActive (false);
														MagnetPower2.SetActive (false);
														MagnetPower3.SetActive (false);
														MagnetPower4.SetActive (false);
						//PlayerPrefs.SetInt("MagnetCount",PlayerPrefs.GetInt("MagnetCount",0)+10);
														break;
						
												case 1:
														MagnetPower1.SetActive (true);
														MagnetPower2.SetActive (false);
														MagnetPower3.SetActive (false);
														MagnetPower4.SetActive (false);
							//PlayerPrefs.SetInt("MagnetCount",PlayerPrefs.GetInt("MagnetCount",10)+10);
														break;
												case 2:
														MagnetPower1.SetActive (true);
														MagnetPower2.SetActive (true);
														MagnetPower3.SetActive (false);
														MagnetPower4.SetActive (false);
						//PlayerPrefs.SetInt("MagnetCount",PlayerPrefs.GetInt("MagnetCount",10)+10);
														break;
												case 3:
														MagnetPower1.SetActive (true);
														MagnetPower2.SetActive (true);
														MagnetPower3.SetActive (true);
														MagnetPower4.SetActive (false);
						//PlayerPrefs.SetInt("MagnetCount",PlayerPrefs.GetInt("MagnetCount",10)+10);
														break;
												case 4:
														MagnetPower1.SetActive (true);
														MagnetPower2.SetActive (true);
														MagnetPower3.SetActive (true);
														MagnetPower4.SetActive (true);
						//PlayerPrefs.SetInt("MagnetCount",PlayerPrefs.GetInt("MagnetCount",10)+10);
														break;
												}

					
										}
										break;
								case "OkayBtn":
				//insufficentCoins.SetActive(false);
										break;
								}
			}

						}
				
		
		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			Ray rayObj = Cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitObject;
			
			if (Physics.Raycast (rayObj, out hitObject)) {
				hitObjName = hitObject.collider.name;

			switch (hitObjName) {
				
				case "BuyNitrous":
				SoundController.Static.PlayClickSound ();

					BuyNitrousRender.material.mainTexture = BuyNitrousTexture [1];
				break;
				case "BackBtn":
					BackRender.material.mainTexture=BackTexture[1];
					break;
			case "BuyMagnet":
				SoundController.Static.PlayClickSound ();

				BuyMagnetRender.material.mainTexture = BuyMagnetTexture [1];
				break;
			}
			}
		}

				}


		

}
