using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPageSound : MonoBehaviour {
	
	void OnEnable(){
		//Spielt einen kurzen FeedbackSound, wenn die Hilfeseite geöffnet wird
		this.GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().audiovol;
		this.GetComponent<AudioSource>().Play(0);
	}
}
