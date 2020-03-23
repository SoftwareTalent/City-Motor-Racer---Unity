var target : Transform;
var distance = 10.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;

@script AddComponentMenu("Camera-Control/Mouse Orbit")
var cam:Camera;
 
function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;
    
    cam  = gameObject.GetComponent(Camera);

	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
		
		Time.timeScale=1;
}
var mouseEvent:Event;

var isDrag:boolean = false;
function OnGUI()
{
 
 if(  Event.current.type == EventType.mouseDrag)
 {
     isDrag=true;
 }
 else isDrag=false;
 
 
// GUI.Label(Rect(0,10,100,90),Input.mousePosition +"" );
 }
 var rotation:Quaternion;
 var  position:Vector3;
function Update () {

 
	
		 if( isDrag){ 
			 
		 
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
         rotation= Quaternion.Euler(y, x, 0);
          position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
        }
        else{
        
         x += 0.1 * xSpeed * 0.02;
        y -= 0;//Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
          rotation = Quaternion.Euler(y, x, 0);
          position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
        
        
        }
        
     
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}