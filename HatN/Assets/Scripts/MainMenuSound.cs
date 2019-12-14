using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSound : MonoBehaviour {
	
	public float mastervol = 0.8f;
	public float musicvol = 0.8f;
	public float soundvol = 0.8f;
	public float audiovol = 0.64f;
	public GameObject AudioP;
	public GameObject ErrorP;
	
	void Start(){
		//wirft eine Fehlermeldung aus, wenn es einen korrupten Spielstand gibt
		if (PlayerPrefs.HasKey("error") == true){
			ErrorP.gameObject.SetActive(true);
			GameObject.Find("ErrorText").GetComponent<Text>().text = PlayerPrefs.GetString("error");
		}
	}
	
	void Update(){
		//wenn die Lautstärke verändert wird, werden die Variablen neu gesetzt
		if (AudioP.gameObject.activeSelf == true){
			mastervol = GameObject.Find("MasterSlider").GetComponent<Slider>().value;
			musicvol = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
			soundvol = GameObject.Find("SoundSlider").GetComponent<Slider>().value;
			audiovol = GameObject.Find("SoundSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
		}
	}
	
	
	public void GetOldSettings(){
		//notwendig, wenn die Lautstärkeeinstellungen zurückgesetzt werden müssen
		audiovol = mastervol * musicvol;
		GameObject.Find("MusicPlayer").GetComponent<AudioSource>().volume = audiovol;
		AudioP.gameObject.SetActive(true);
		GameObject.Find("MasterSlider").GetComponent<Slider>().value = mastervol;
		GameObject.Find("MusicSlider").GetComponent<Slider>().value = musicvol;
		GameObject.Find("SoundSlider").GetComponent<Slider>().value = soundvol;
		AudioP.gameObject.SetActive(false);
	}
}
