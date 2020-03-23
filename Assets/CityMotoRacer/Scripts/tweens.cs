using UnityEngine;
using System.Collections;

public class tweens : MonoBehaviour {

	// Use this for initialization

	public enum Tweenbuttons{
	 
		inGameEndScroller,
		slideToLeftSide,
		slideToRightSide,
		bringToTop,
		bringToDown

	}
	public  Tweenbuttons buttonTween;
	Vector3 startPos   ;
	void OnEnable () {


		startPos  = transform.localPosition;
		switch(buttonTween)
		{

		case Tweenbuttons.slideToRightSide:

			transform.Translate(20,0,0);
			iTween.MoveTo(gameObject,iTween.Hash("position",startPos,"time",1.0,"isLocal",true,"easetype",iTween.EaseType.easeInOutBack,"oncomplete","tweenComplete"));

			break;

		case Tweenbuttons.slideToLeftSide:
			 
			transform.Translate(-20,0,0);
			iTween.MoveTo(gameObject,iTween.Hash("position",startPos,"time",1.0,"isLocal",true,"easetype",iTween.EaseType.easeInOutBack,"oncomplete","tweenComplete"));


			break;


		case Tweenbuttons.bringToTop:
			transform.Translate(0,40,0);
			iTween.MoveTo(gameObject,iTween.Hash("position",startPos,"time",1.0,"isLocal",true,"easetype",iTween.EaseType.easeInOutBack,"oncomplete","tweenComplete"));
			


			break;
		case Tweenbuttons.bringToDown:
			transform.Translate(0,-40,0);
			iTween.MoveTo(gameObject,iTween.Hash("position",startPos,"time",1.0,"isLocal",true,"easetype",iTween.EaseType.easeInOutBack,"oncomplete","tweenComplete"));
			
			
			
			break;

		case Tweenbuttons.inGameEndScroller:

			iTween.MoveTo(gameObject,iTween.Hash("position",Vector3.zero,"time",1.0,"isLocal",true,"easetype",iTween.EaseType.easeInOutBack,"oncomplete","tweenComplete"));
			

			break;

		}
		if (SoundController.Static != null) {
						SoundController.Static.PlaySlider ();
				}
	
	}
	void OnDisable()
	{
		transform.localPosition = startPos;
	}
	public bool canDisableOnComplete = false ;
	public void tweenComplete()
	{
		if (canDisableOnComplete) {
			Invoke("lateDisable",1.5f);
				}
	}

	void lateDisable()
	{
		transform.localPosition = startPos;
		gameObject.SetActive (false);
	}
	
	 
}
