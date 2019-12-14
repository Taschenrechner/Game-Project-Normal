using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSoundAwake : MonoBehaviour {
	
	void OnEnable(){
		//Spielt einen kurzen FeedbackSound, wenn das Hauptmenü geöffnet wird
		this.GetComponent<AudioSource>().volume = GameObject.Find("Canvas").GetComponent<MainMenuSound>().audiovol;
		this.GetComponent<AudioSource>().Play(0);
	}
}
