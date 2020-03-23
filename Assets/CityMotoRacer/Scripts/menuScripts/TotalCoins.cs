using UnityEngine;
using System.Collections;

public class TotalCoins : MonoBehaviour {

	// Use this for initialization
	void Start () {
		staticInstance = this ;
		UpdateCoins();
	}
	
	// Update is called once per frame
	public   int totalCoins=0;
	public TextMesh coinsTxt;
	public static TotalCoins staticInstance ;
	void UpdateCoins () {
	 
		totalCoins = PlayerPrefs.GetInt("TotalCoins",0 );
		coinsTxt.text = ""+ totalCoins;
	}

	public void AddCoins (int coins) {

		PlayerPrefs.SetInt("TotalCoins",PlayerPrefs.GetInt("TotalCoins",0 ) + coins) ;
		UpdateCoins();
	}

	public void deductCoins (int coins) {
		PlayerPrefs.SetInt("TotalCoins",PlayerPrefs.GetInt("TotalCoins",0 ) - coins) ;
		UpdateCoins();
	 }

	public int getCoinCount()
	{
		return PlayerPrefs.GetInt ("TotalCoins", 0);
	}
	


	public void ClearCoins()
	{
		PlayerPrefs.DeleteAll();
		UpdateCoins();
	}
	void Update () {
				if(Input.GetKeyDown(KeyCode.G))
				{
					int vol=1000;
					AddCoins(vol);
				}
		
				if (Input.GetKeyDown (KeyCode.D))
				{
					PlayerPrefs.DeleteAll();
				}
		
	}

}
