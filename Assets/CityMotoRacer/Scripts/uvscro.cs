using UnityEngine;
using System.Collections;

public class uvscro : MonoBehaviour {

	public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public Vector2 uvAnimationRate2 = new Vector2( 1.0f, 0.0f );
    public string textureName = "_MainTex";
	 public string textureName2 = "_MainTex";
 
    Vector2 uvOffset = Vector2.zero;
	 Vector2 uvOffset2 = Vector2.zero;
     public Color depthColor;
    void LateUpdate() 
    {
        uvOffset += ( uvAnimationRate * Time.deltaTime );
		uvOffset2 += ( uvAnimationRate2 * Time.deltaTime );
        if( renderer.enabled )
        {
            renderer.materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
			renderer.materials[ materialIndex ].SetTextureOffset( textureName2, uvOffset2 );
			  
        }
    }
}
