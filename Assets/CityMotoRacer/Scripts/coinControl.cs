using UnityEngine;
using System.Collections;
using System;

public class coinControl : MonoBehaviour
{

		// Use this for initialization
		float coinSpeed = 1.0f;
		Transform coinTrans ;
		public static int  turnCount;
		public BoxCollider box ;
		Vector3 originalScale;
		public static bool isONMagetPower ;
		public bool moveToPlayer = false ;
		public bool moveToCoinTarget =false;
		Transform thisTrans;

		void OnEnable ()
		{
				thisTrans = transform;
				box = GetComponent<BoxCollider> () as BoxCollider;
				originalScale = box.size;
				playerBIKEControl.switchOnMagnetPower += onMagenetPower;
				playerBIKEControl.switchOFFMagnetPower += offMagenetPower;
				playerBIKEControl.gameEnded += onGameEnd;
				if (isONMagetPower)
						onMagenetPower (null, null);
		}

		void OnDisable ()
		{
				playerBIKEControl.switchOnMagnetPower -= onMagenetPower;
				playerBIKEControl.switchOFFMagnetPower -= offMagenetPower;
				playerBIKEControl.gameEnded -= onGameEnd;
		}

		void onGameEnd (System.Object obj, EventArgs args)
		{
				Destroy (gameObject);
		}

		void onMagenetPower (System.Object obj, EventArgs args)
		{
				isONMagetPower = true;
		
				if(box != null) box.size = new Vector3 (9, 9, 9);
		}

		public void resetSize ()
		{
			if(box !=null)	box.size = originalScale;
		}

		void offMagenetPower (System.Object obj, EventArgs args)
		{
				isONMagetPower = false;
				resetSize ();
		}

		void Start ()
		{

				coinTrans = transform;
			//	coinTrans.Rotate (0, 0, turnCount);
				turnCount += 4;
		}
	
		// Update is called once per frame
	bool isAwaredNitrous = false;
	bool reduceTozero=false;
		void Update ()
		{
		if (moveToPlayer) {
			thisTrans.position = Vector3.MoveTowards (thisTrans.position, playerBIKEControl.thisPosition  , 2.0f*playerBIKEControl.isDoubleSpeed);
			if(thisTrans.position.z < playerBIKEControl.thisPosition.z ) {
				moveToPlayer=false;
				if(NitrousIndicator.NitrousCount < 100)  NitrousIndicator.NitrousCount+=0.3f;
				NitrousIndicator.Static.UpdateNitrousDisplay();

				SoundController.Static.playCoinHit();
				Destroy(gameObject);
			}
		}
//		else if ( moveToCoinTarget ) {
//
//			//Vector3 coinRelativetoPlayer = new Vector3(-10,20,playerBIKEControl.thisPosition.z+40);
//			thisTrans.position = Vector3.MoveTowards (thisTrans.position,BIKECamera.coinsStaticTarget.position ,  playerBIKEControl.isDoubleSpeed*2.0f);
//			if(reduceTozero == false)
//			{
//				iTween.ScaleTo(gameObject,Vector3.zero,1.0f);
//				reduceTozero=true;
//			}
//			if(thisTrans.position.y > 16f && !isAwaredNitrous  ) {
//				isAwaredNitrous = true;
//
//			}
//		}
			//	coinTrans.Rotate (0, 0, coinSpeed * Time.timeScale);

	
		}
}
