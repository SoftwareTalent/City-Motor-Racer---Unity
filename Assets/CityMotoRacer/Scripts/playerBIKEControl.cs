 using UnityEngine;
using System.Collections;
using System;


public class playerBIKEControl : MonoBehaviour
{
	public float turnSpeed;
	public float carSpeed;
	public float tilt;
	public float[] limits;
	public Transform carBody;
	public Transform[] wheelObjs;
	public float wheelSpeed;
	public static event EventHandler gameEnded;
	public static event EventHandler switchOnMagnetPower;
	public static event EventHandler switchOFFMagnetPower;
	public float magnetPowerTime=3.0f;
	private float nextFire;
	public static float isDoubleSpeed = 1;
	Transform thisTrans ;
	public GameObject particleParent;
	public Transform frontAnchor, backAnchor ;
	//public Transform bike;
	 
	public static Vector3 thisPosition ;
	bool isbikefalldown = true ;
	public Quaternion  Back_RotationTarget;
 
	Quaternion back_currentRotation;
	 

	float brakeSpeed = 0; 
	BIKECamera bikeScript ;
	Camera mainCamera;
	public enum playerstates{
		playerLive,Playerdead
	};
	public	playerstates currentState;

	#region enum for Player Animations

 
	#endregion


	void OnEnable()
	{
		if (UnityEngine.Random.Range (-4, 4) > 0)
						rotateDir = 1;
				else
						rotateDir = -1;
	 
		//print ("Nitrou"+ PlayerPrefs.GetInt ("NitrousCount", 0));
		#if UNITY_WEBPLAYER || UNITY_EDITOR
		tilt = tilt*2; 
		#endif
		thisTrans = transform;
		mainCamera = Camera.main;
		foreach (Transform t in gameObject.GetComponentsInChildren<Transform>()) {
			if(t.name.Contains("Effect") )
			{
				particleParent = t.gameObject;
			}
				}

		isDoubleSpeed = 1;


		bikeScript = Camera.main.GetComponent<BIKECamera> ();
		bikeScript.targetTrans = thisTrans;

		
		#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8
		// even blob shadows is also taking 5 draw calls ,so we are going disable it 
//		foreach(Transform t in transform.GetComponentsInChildren<Transform>() )
//		{ if(t.name.Contains("Shadow") ) {
//				Debug.Log(t.name);
//				Destroy(t.gameObject);
//			}
//		}
		#endif

	}

	void LiveUpdate(){
		backAnchor.rotation = Quaternion.Lerp (backAnchor.rotation, back_currentRotation,   0.1f );
		
		
		if(isDoubleSpeed == 1 ) {
			hideNitrousParticle();
			UIControl.Static.neddleIndex=0;
		}
		else  showNitrousParticle ();	
		}



	public float rotateDir   ;
	void Update ()
	{

		switch (currentState) {
		case playerstates.playerLive:
			LiveUpdate();
			playerIFixedUpdate();
			break;
		case playerstates.Playerdead:
			 
				 
			 if( isbikefalldown )
			{
				  if( !isUsingNitrous){
					iTween.RotateTo( backAnchor.gameObject,new Vector3(0,50*rotateDir,70*rotateDir),1.0f) ;
					
					iTween.MoveTo(backAnchor.gameObject,thisTrans.position+new Vector3(10 * rotateDir ,0,40)  ,2.0f ) ;

				}
				else {

					iTween.RotateTo( backAnchor.gameObject,new Vector3( 180*rotateDir,0,0),1.0f) ;
					
					iTween.MoveTo(backAnchor.gameObject,thisTrans.position+new Vector3(10 * rotateDir ,15 ,40)  ,2.0f ) ;
					Invoke("bringBikeToGround",0.3f);
				}
					
			 isbikefalldown= false;
			}
		
			break;

		}
		 
	}

	void bringBikeToGround()
	{
		//iTween.RotateTo( backAnchor.gameObject,new Vector3( 270*rotateDir,0,0),1.50f) ;
		iTween.MoveTo(backAnchor.gameObject,thisTrans.position+new Vector3(0 ,90 * rotateDir,60)  ,1.5f ) ; 
		isbikefalldown = true;
		isUsingNitrous = false;
	}

 


	void OnTriggerEnter( Collider c )
	{

		  if( c.tag.Contains("coin" ) )
		{
			 
				coinControl coinScript = c.gameObject.GetComponent<coinControl>() as coinControl ;
				 coinScript.moveToPlayer = true;
		    	Destroy( c );
			  
			    GamePlayController.collectedCoinsCounts++;

		}
		else if( c.collider.name.Contains("Magnet" ) )
		{
			Destroy(c.gameObject);
			if(switchOnMagnetPower != null) switchOnMagnetPower(null,null);
			Invoke("EndMagnetPower",magnetPowerTime + PlayerPrefs.GetInt ("MagnetCount", 0));
			SoundController.Static.PlayPowerPickUp();
		}
		else if( c.collider.name.Contains("InstantNitrous" ) )
		{
			Destroy(c.gameObject);

			NitrousIndicator.NitrousCount+=30;//+ PlayerPrefs.GetInt ("NitrousCount", 0); // set to nitrous    + PlayerPrefs.GetInt ("NitrousCount", 0);
			NitrousIndicator.Static.UpdateNitrousDisplay();
			SoundController.Static.PlayPowerPickUp();
		}

	}
	void EndMagnetPower( )
	{
		if (switchOFFMagnetPower != null)
						switchOFFMagnetPower (null, null);
	 }

	void OnCollisionEnter(Collision incomingCollision)
	{
		string incTag = incomingCollision.collider.tag;

		if (incTag.Contains ("trafficCar")) {
		 
			carSpeed=0;
			wheelSpeed=0;
			isDoubleSpeed=0;
			turnSpeed=0;
			rigidbody.velocity = Vector3.zero;
			isDoubleSpeed = 1;
			GamePlayController.isGameEnded = true;
			if(gameEnded != null) gameEnded(null,null);
			iTween.ShakePosition(Camera.main.gameObject,new Vector3(1,1,1),0.6f);
		//	Debug.Log("traffic collision detected " );
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			//rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			SoundController.Static.PlayBIKECrashSound ();
			GameObject trafficCar  = incomingCollision.collider.gameObject ; 
			SoundController.Static.boostAudioControl.enabled = false;
			trafficCar.SendMessage("StopCar",SendMessageOptions.DontRequireReceiver);//to stop the car
			iTween.RotateTo(trafficCar , new Vector3(0,UnityEngine.Random.Range(-1,2)*25,0),1.0f);
			currentState=playerstates.Playerdead;
		 
			 
			collider.enabled = false ;

				}
		 

		}
	void FixedUpdate ()
	{
		switch (currentState) {
		case playerstates.playerLive:

			break;
		case playerstates.Playerdead:
			 
			break;
			
		}

	}
		
	void playerIFixedUpdate ()
	{
		thisPosition = thisTrans.position;
		 
		if (UIControl.isBrakesOn) {
			brakeSpeed = 2;
			 
			UIControl.Static.neddleIndex=1;
	         SoundController.Static.playBrakeSound ();
		  } else {
			brakeSpeed =1 ;
		 
            }

		   
       float moveHorizontal ;
	 
		#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
		 
		float smoothX = Input.acceleration.x ;
		if(smoothX < -0.5f  && smoothX < 0) smoothX = Mathf.Lerp(smoothX,-1,Time.deltaTime/6);  //smoothX = -1;
		else if(smoothX > 0.5f  ) smoothX = Mathf.Lerp(smoothX,1,Time.deltaTime/6); ;

		moveHorizontal = smoothX * 2 ;
		 
		#endif
		
		#if UNITY_EDITOR || UNITY_WEBPLAYER
		moveHorizontal =  Input.GetAxis ("Horizontal");
		 
		#endif

		foreach(Transform t in wheelObjs)
		{
			t.Rotate(-wheelSpeed * Time.deltaTime,0,0);
		}
		 
		  
		Vector3 movement = new Vector3 (moveHorizontal *2, 0.0f, ( carSpeed * isDoubleSpeed)/brakeSpeed );
		rigidbody.velocity = movement * turnSpeed;
		
		rigidbody.position = new Vector3
		(
				Mathf.Clamp (rigidbody.position.x, limits[0],limits[1]),
				0.0f, rigidbody.position.z
		);

		//carCamera.position = rigidbody.position - new Vector3(0,-10, 20 );
		rigidbody.rotation = Quaternion.Euler (0,rigidbody.velocity.x *  tilt, 0);
		 carBody.rotation = Quaternion.Euler (0,  0,  -rigidbody.velocity.x *  tilt   );
	}
 
	 
	public void switchoffmagnet()
	{
		if (switchOFFMagnetPower != null)
		{
			switchOFFMagnetPower (null, null);
		}
	}

	bool isUsingNitrous = false ;
	void showNitrousParticle()
	{
		if (particleParent != null)particleParent.SetActive (true);
		
		SoundController.Static.boostAudioControl.enabled = true;
		UIControl.Static.neddleIndex=2;
		UIControl.Static.NitrousParticle.SetActive (true);

		back_currentRotation = Back_RotationTarget; 
		isUsingNitrous = true;
	}
	
	void hideNitrousParticle()
	{
		if (particleParent != null)
			particleParent.SetActive (false);


		back_currentRotation = Quaternion.identity;
		isUsingNitrous = false;
		SoundController.Static.boostAudioControl.enabled = false;
		UIControl.Static.NitrousParticle.SetActive (false);
	}
}
