using UnityEngine;
using System.Collections;

public class LoadingSpin : MonoBehaviour {

	// Use this for initialization

	public Vector3 rotationDirection ;

	IEnumerator Start () {
	
		yield return new WaitForSeconds (1);
		Application.LoadLevelAsync(levelSelection.levelName);
	}
	
	// Update is called once per frame
	void Update () {
	   
		transform.Rotate (rotationDirection * Time.deltaTime);
	}
}
