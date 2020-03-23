using UnityEngine;
using System.Collections;

public class TiltTuto : MonoBehaviour {

	// Use this for initialization

	public GameObject description;
	public Vector3 originalScale;
	public GamePlayController controller ;
	void OnEnable()
	{
		if (Application.isWebPlayer)
						gameObject.SetActive (false);
		//to show tutorial just three time in game lifetime.
		if (PlayerPrefs.GetInt ("tiltPlayTimes", 0) < 3) {
						transform.localScale = new Vector3 (1, 1, 1);
						PlayerPrefs.SetInt ("tiltPlayTimes", PlayerPrefs.GetInt ("tiltPlayTimes", 0) + 1);
				}
		else Destroy (gameObject);


		originalScale = description.transform.localScale;
		description.transform.localScale = Vector3.zero;
	}
	void Start () {
		Destroy( gameObject,3.0f) ;

		iTween.ScaleTo(description,iTween.Hash("scale",originalScale,"time",0.5f,"easetype",iTween.EaseType.easeOutQuad,"delay",1.0f) );

		 
	}

	void OnDisable()
	{
		controller.OnGameStart ();
	
	}
	
	 
}
