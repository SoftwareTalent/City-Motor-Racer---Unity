using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{

		// Use this for initialization

		public AudioClip Slider, clickSound, BIKECrashSound, BrakeSound;
		public AudioClip coinHitSound;
		public AudioClip pickUpSound;
		public static SoundController Static ;
		public AudioSource[]  audioSources;
		public AudioSource boostAudioControl;
		public GameObject BgSoundsObj;

		void Start ()
		{
				Static = this;
				//toStop bg music on mainMenu and Splash Screen
				if (Application.loadedLevel < 2) {

						BgSoundsObj.SetActive (false);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void PlayBIKECrashSound ()
		{
		
				swithAudioSources (BIKECrashSound);
		}

		public void playBrakeSound ()
		{

				//swithAudioSources (BrakeSound);
		}

		public void PlayClickSound ()
		{
		
				swithAudioSources (clickSound);
		}
 
		public void playCoinHit ()
		{
		 
				audio.PlayOneShot (coinHitSound);
		}

		public void PlayPowerPickUp ()
		{
		 
				swithAudioSources (pickUpSound);
		}

		public void PlaySlider ()
		{
		 
				//swithAudioSources (Slider);

		}

		void swithAudioSources (AudioClip clip)
		{
				if (audioSources [0].isPlaying) {
						audioSources [1].PlayOneShot (clip);
				} else
						audioSources [0].PlayOneShot (clip);

		}
}
