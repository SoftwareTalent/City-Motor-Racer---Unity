using UnityEngine;
using System.Collections;
using System;

public class NitrousIndicator : MonoBehaviour
{

		// Use this for initialization

		public Material progress;
		public TextMesh   countDown, tittleText;
		public static NitrousIndicator Static;
		public Color startColor, endColor;
		public GameObject scaler;
		public static float  NitrousCount ;
		public float nitrousDecrementSpeed ;
		public   bool isNitrousOn = false ;
		public Transform barScaler ;
		void OnEnable ()
		{
	          	NitrousCount = 0 +PlayerPrefs.GetInt ("NitrousCount", 0);
				Static = this;
				UpdateNitrousDisplay ();
				
	 
		}

		void OnDisable ()
		{
	 

		}

		void destroyTimer (System.Object obj, EventArgs args)
		{
				Destroy (gameObject);
		}
 
	
		// Update is called once per frame
 
		public void UpdateNitrousDisplay ()
 		{
//				float power = 1 - (float)(((float)1.0f + (float)NitrousCount) / (float)100.0f);
//
//				power = Mathf.Clamp (power, 0.01f, 0.99f);
//		        progress.SetFloat ("_Cutoff", power); 
//				barScaler.localScale = new Vector3 (1-power,1,1);
//					 
				if (NitrousCount <= 1) {
			        isNitrousOn = false;
					playerBIKEControl.isDoubleSpeed = 1;
				}


		countDown.text = "" + Mathf.RoundToInt( NitrousCount).ToString().PadLeft (3, '0');

		}
 
		public void Update ()
		{
		       if (isNitrousOn) {
					playerBIKEControl.isDoubleSpeed = 1.8f;
//			            Debug.Log (""+nitrousDecrementSpeed * Time.deltaTime);
		             	NitrousCount -= nitrousDecrementSpeed * Time.deltaTime;
						NitrousCount = Mathf.Clamp (NitrousCount, 0, 100); //to avoid minus 
						UpdateNitrousDisplay ();
				}
		}

		void ChangeTextValue (float countNumber)
		{
				countDown.text = "" + Mathf.RoundToInt (countNumber);
		}

		void timerDone ()
		{
				iTween.RotateTo (scaler, new Vector3 (0, 0, 180), 0.3f);
				iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (-20, 0, 0), "time", 1.0f, "easetype", iTween.EaseType.easeInOutBack, "delay", 0.0f));
		}
}
