using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour
{

		// Use this for initialization
		public RaycastHit hit;
		public Camera uiCamera;
		public static string levelName;
		public GameObject BIKESelection;
		public GameObject LadingSpin;

		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Mouse0)) {
			
						MouseDown (Input.mousePosition);
				}
				if (Input.GetKeyUp (KeyCode.Mouse0)) {
			
						MouseUp (Input.mousePosition);
				}
		}

		void MouseUp (Vector3 a)
		{
		 
				Ray ray = uiCamera.ScreenPointToRay (a);
		
				if (Physics.Raycast (ray, out hit, 500)) {
			
						switch (hit.collider.name) {
						case "BACK":
								iTween.PunchScale (hit.collider.gameObject, new Vector3 (1, 1, 0), 0.3f);
								break;
			
						case "highway":
				 
			                	levelName = "highWayGameplay";
								LadingSpin.SetActive (true);
								gameObject.SetActive (false);
				 
								break;
						case "city":
				 
								levelName = "cityGameplay";
								LadingSpin.SetActive (true);
								gameObject.SetActive (false);
								break;
						case "NightCity":
				
								levelName = "NightGameplay";
								LadingSpin.SetActive (true);
								gameObject.SetActive (false);
								break;
						case "UrbanCity":
				
								levelName = "UrbanGameplay";
								LadingSpin.SetActive (true);
								gameObject.SetActive (false);
								break;
						}
			
				}
		
		}

		void MouseDown (Vector3 a)
		{
		
				Ray ray = uiCamera.ScreenPointToRay (a);
		
				if (Physics.Raycast (ray, out hit, 500)) {
						SoundController.Static.PlayClickSound ();
			 
						switch (hit.collider.name) {
						case "BACK":
								BIKESelection.SetActive (true);
								gameObject.SetActive (false);
				 
								break;
						case "dayLight":
								iTween.PunchScale (hit.collider.gameObject, new Vector3 (1, 1, 0), 0.3f);
								break;
						case "Sunny":
								iTween.PunchScale (hit.collider.gameObject, new Vector3 (1, 1, 0), 0.3f);
				
								break;
			 
				
						}
			
			
				}
		
		}
}
