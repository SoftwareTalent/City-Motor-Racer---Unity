using UnityEngine;
using System.Collections;

public class moveTopoint : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public Transform target;
	public float smooth = 5.0F;
	bool canUpdate = false;

	public Vector3 startPosition,startRotation;
	void Start() {
		canUpdate = false;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

		startPosition = transform.position;
		startRotation = transform.eulerAngles;
	}
	Vector3 hitPos;
	void OnBecameInvisible()
	{
		Debug.Log(" destroyed BALLLLLLL  ");

		lateCreateNewBall();
		Debug.Log("Created for time "+ i);
		i++;
		Destroy(gameObject);
	}
	void lateCreateNewBall()
	{
		GameObject.Instantiate(gameObject,startPosition,Quaternion.identity);
	}
	void Update() {

		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Debug.DrawLine(ray.origin, hit.point);

			hitPos= hit.point;
			canUpdate=true;
		}
	  	
	    }
	 

	if( canUpdate ) {


		
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
   	transform.position = Vector3.Lerp(startMarker.position,hitPos, fracJourney);
	}
	}
	public GameObject effect;
	int i=0;
	void OnCollisionEnter( Collision c)
	{
		if(canUpdate && i==0)
		{


		 Debug.Log( "Collision name " + c.collider.name );

		if( c.collider.rigidbody != null )
		{
		c.collider.rigidbody.AddForce( transform.forward * 900);
		}

		GameObject efc = GameObject.Instantiate(effect,c.contacts[0].point,Quaternion.identity) as GameObject;
			Destroy(efc,0.3f);
		}
		canUpdate = false;
	}
}
