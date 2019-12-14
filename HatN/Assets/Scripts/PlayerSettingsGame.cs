using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettingsGame : MonoBehaviour {
	
	public void UpdatePrefs(){
		//Wenn die Audioeinstellungen verändert werden, wird dies in den PlayerPrefs gespeichert. Gilt für die Game-Szene.
		PlayerPrefs.SetFloat("master", GameObject.Find("MasterSlider").GetComponent<Slider>().value);
		PlayerPrefs.SetFloat("music", GameObject.Find("MusicSlider").GetComponent<Slider>().value);
		PlayerPrefs.SetFloat("sound", GameObject.Find("SoundSlider").GetComponent<Slider>().value);
		PlayerPrefs.Save();
	}
}
