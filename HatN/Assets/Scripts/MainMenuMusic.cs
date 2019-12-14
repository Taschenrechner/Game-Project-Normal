using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusic : MonoBehaviour {
	
	void Update(){
		//Bestimmt die Lautstärke der Musik im Hauptmenü
		if (this.name == "MusicSlider"){
			GameObject.Find("MusicPlayer").GetComponent<AudioSource>().volume = this.GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
		}
		if (this.name == "MasterSlider"){
			GameObject.Find("MusicPlayer").GetComponent<AudioSource>().volume = this.GetComponent<Slider>().value * GameObject.Find("MusicSlider").GetComponent<Slider>().value;
		}
	}
}
