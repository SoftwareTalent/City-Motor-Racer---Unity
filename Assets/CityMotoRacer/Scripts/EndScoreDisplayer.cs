 using UnityEngine;
using System.Collections;
using System;
public class EndScoreDisplayer : MonoBehaviour {

	// Use this for initialization

	public TextMesh coinsText,distancetext,bestDistanceText;
	private float coins, distance;
	public GameObject playAgainButton,mainMenuButton,newBestDistance,FbButton,NewSticker;
	public Vector3[] originalPositions;
	public static event EventHandler showFullScreenAd;
	void OnEnable( )
	{
		originalPositions[0] = playAgainButton.transform.localPosition;
		originalPositions[1] = mainMenuButton.transform.localPosition;
		originalPositions[2] = FbButton.transform.localPosition;
		playAgainButton.transform.Translate(40,0,0);
		mainMenuButton.transform.Translate(-40,0,0);
		FbButton.transform.Translate(40,0,0);
		coinsText.text="0";
		distancetext.text="0";
		iTween.ValueTo(gameObject,iTween.Hash("from",coins,"to",GamePlayController.collectedCoinsCounts,"time",1,"easetype",iTween.EaseType.easeInOutCubic,
		                                      "onupdate","changeCoinText","delay",1.2f,"oncomplete","startDistanceCount") );


		iTween.ColorTo(coinsText.gameObject,iTween.Hash("color",Color.red,"time",1.0f,"delay",1.2f ));

		 
		PlayerPrefs.SetInt("TotalCoins",PlayerPrefs.GetInt("TotalCoins",0 ) + GamePlayController.collectedCoinsCounts) ;
		//to stop bgsounds on GameoVer
		SoundController.Static.BgSoundsObj.SetActive (false);
		//SoundController.Static.PlayBIKECrashSound ();

	}
	void BestDistance()
	{
		if (PlayerPrefs.GetFloat ("BestDistance", 0) < GamePlayController.distanceTravelled) {
			//iTween.MoveTo(newBestDistance,iTween.Hash("islocal",true,"position",new Vector3(-0.03848858f,0,-2),"time",0.5f));
			NewSticker.SetActive(true);
			iTween.ScaleTo(NewSticker,new Vector3(3,3,3),0.5f);
			//iTween.ShakePosition(Camera.main.gameObject, new Vector3 (2.3f, 2.3f,2.5f),0.8f);
			iTween.PunchRotation (Camera.main.gameObject, iTween.Hash ("amount", new Vector3 (0.3f, 0.3f, 0.3f), "time", 0.5f));

			PlayerPrefs.SetFloat("BestDistance",GamePlayController.distanceTravelled );
		}
		bestDistanceText.text= ""+Mathf.RoundToInt(PlayerPrefs.GetFloat ("BestDistance", 0))+"m";
		Invoke ("showButtons", 0.5f);
	}
	void changeCoinText(float newValue)
	{
		coinsText.text = ""+ Mathf.RoundToInt(  newValue );
		SoundController.Static.playCoinHit();
	}

	void startDistanceCount()
	{
		iTween.ValueTo(gameObject,iTween.Hash("from",0,"to", GamePlayController.distanceTravelled,"time",1,"easetype",iTween.EaseType.easeInOutCubic,
		                                      "onupdate","changeDistanceText","oncomplete","BestDistance") );


		SoundController.Static.PlayPowerPickUp();

		iTween.ColorTo(distancetext.gameObject,Color.red,1.0f);
	}

	void changeDistanceText(float newValue)
	{
		SoundController.Static.playCoinHit();
		distancetext.text = ""+ Mathf.RoundToInt(  newValue )+"m";

	}
	 
	void showButtons()
	{
		SoundController.Static.PlaySlider();

		if(showFullScreenAd != null) showFullScreenAd(null,null) ; //raise an adevent here 
		iTween.MoveTo(playAgainButton,iTween.Hash("position",originalPositions[0] ,"time",0.5f,"easetype",iTween.EaseType.easeInOutBounce,"islocal",true ) );
		iTween.MoveTo(mainMenuButton,iTween.Hash("position",originalPositions[1],"time",0.5f,"easetype",iTween.EaseType.easeInOutBounce,"islocal",true,"delay",0.6f ) );
		iTween.MoveTo(FbButton,iTween.Hash("position",originalPositions[2],"time",0.5f,"easetype",iTween.EaseType.easeInOutBounce,"islocal",true,"delay",1.3f ) );
	}
	
	 
}
