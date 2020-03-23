using UnityEngine;
using System.Collections;

public class scrollUv : MonoBehaviour {


    public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );

    public string textureName = "_MainTex";

	public Material mat;
    Vector2 uvOffset = Vector2.zero;

    void Start()
	{
		if(mat == null) mat= renderer.material;

	}
    void LateUpdate() 
    {
        uvOffset += ( uvAnimationRate * Time.deltaTime );
	
        
		mat.SetTextureOffset( textureName, uvOffset );

       
    }
}



 