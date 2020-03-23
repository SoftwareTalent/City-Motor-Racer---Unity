using UnityEngine;
using System.Collections;
 
public class GamePlayController : MonoBehaviour
{


		public GameObject[] trafficCars, roadBlocks, vlcCans, sideTres, coinsParent, powerPickups, playerBIKEs;
		public static int collectedCoinsCounts, distanceTravelled;
		public static bool isGameEnded = false;
		public GameObject playerObj;
		public GameObject gameEndMenu;
		public TextMesh coinsText, distanceText, gameOverTxt;
		float startPlayerBIKEPositionZ;
		public BIKECamera bikeScript ;
		// Use this for initialization
		void OnEnable ()
		{
				isGameEnded = false;
				playerBIKEControl.gameEnded += onGameEnd;
				coinControl.isONMagetPower = false;


		 

		}

		void OnDisable ()
		{
				playerBIKEControl.gameEnded -= onGameEnd;
		}
	
		void onGameEnd (System.Object obj, System.EventArgs args)
		{
				CancelInvoke ();
				//gameEndMenu.SetActive (true);//activate it after 2Sec 
				Invoke ("gameEndMenuActive", 2);
				this.enabled = false;
		}

		void gameEndMenuActive ()
		{
				gameEndMenu.SetActive (true);
		}

		public void OnGameStart ()
		{
		 //on game start we invoking traffic ,trees 
				InvokeRepeating ("generateTrafficBIKEs", 1, 1.0f);
	        	InvokeRepeating ("generateTrafficBIKEs", 3, 3.0f);
		
				InvokeRepeating ("generatePowerups", 15, 15);
		
		 
				if (!Application.loadedLevelName.Contains ("city")) {
						InvokeRepeating("generateSideTress",0,3.0f);
				}
		
				InvokeRepeating ("generateCoins", 0, 2);

		}

		void Start ()
		{


		 

				collectedCoinsCounts = 0;

				if (bikeScript == null)
						bikeScript = Camera.main.GetComponent<BIKECamera> ();
				// ;//
				// playerObj = GameObject.FindGameObjectWithTag ("Player");//
				 playerObj = GameObject.Instantiate (playerBIKEs [BIKESelection.BIKEIndex]) as GameObject;

				UIControl.Static.playerRigidBody = playerObj.rigidbody;
				startPlayerBIKEPositionZ = playerObj.transform.position.z;
				bikeScript.targetTrans = playerObj.transform;

		 
		}

		void Update ()
		{
	
				coinsText.text = "" + collectedCoinsCounts.ToString ().PadLeft (3, '0');
				;
				distanceText.text = "" + GamePlayController.distanceTravelled + " m";
				if (isGameEnded) {
						coinsText.text = "";
						distanceText.text = "";
						gameOverTxt.text = "GAME OVER :(";
				} else {
						distanceTravelled = Mathf.RoundToInt ((playerBIKEControl.thisPosition.z + (1104.015f)) / 10);
				}



		}

		public float[] trafficPositions ;
		int lastRandom ;

		void generateTrafficBIKEs ()
		{
				int randomNumber = 3 * Random.Range (1, 11);

				if (randomNumber == lastRandom)
						randomNumber = 3 * Random.Range (1, 11);
				if (randomNumber == lastRandom)
						return;
				lastRandom = randomNumber;
				GameObject trafficObj = GameObject.Instantiate (trafficCars [randomNumber]) as GameObject;
		
				trafficObj.transform.position = new Vector3 (trafficPositions [Random.Range (0, trafficPositions.Length - 1)], 0, playerObj.transform.position.z + 200 + (Random.Range (18, 20) * 10));
		}

		void generatePowerups ()
		{
		
				GameObject pickupObj = GameObject.Instantiate (powerPickups [Random.Range (0, powerPickups.Length - 1)]) as GameObject;
		
				pickupObj.transform.position = new Vector3 (Random.Range (-5, 5), 5, playerObj.transform.position.z + 400 + (Random.Range (1, 10) * 10));
		}

		void generateSideTress ()
		{

				//left side
				GameObject treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
				treeObj.transform.position = new Vector3 (Random.Range (-80, -60), 0, playerObj.transform.position.z + 780);
				treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);

				treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
				treeObj.transform.position = new Vector3 (Random.Range (-90, -60), 0, playerObj.transform.position.z + 1230);
				treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);
				//rightside
				treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
				treeObj.transform.position = new Vector3 (Random.Range (60, 80), 0, playerObj.transform.position.z + 820);
				treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);

				treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
				treeObj.transform.position = new Vector3 (Random.Range (60, 90), 0, playerObj.transform.position.z + 1320);
				treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);
		}

		void generateCoins ()
		{
		
				//left side
				GameObject coin = GameObject.Instantiate (coinsParent [Random.Range (0, coinsParent.Length - 1)]) as GameObject;
				coin.transform.position = new Vector3 (Random.Range (-8, 6), 3, playerObj.transform.position.z + 180);
		
		
		 
		}
}
