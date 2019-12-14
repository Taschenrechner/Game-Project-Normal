using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingMusic : MonoBehaviour {
	
	public AudioClip sadone;
	public AudioClip sadtwo;
	public AudioClip happyone;
	public AudioClip happytwo;
	float audiovol;
	
	void Start(){
		//Übernehmen der Einstellungen aus den PlayerPrefs
		this.GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().audiovol;
		audiovol = GameObject.Find("EventSystem").GetComponent<PublicVariables>().audiovol;
		this.GetComponent<AudioSource>().Play(0);
	}
	
	
	void Update(){
		//Erstellt einen Loop aus 2 fröhlichen/2 traurigen Musikstücken. Überprüft auch, ob der Lautstärkeregler in den Optionen verändert wurde und passt die Lautstärke an den Wert an.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().OptionP.gameObject.activeSelf == true){
			this.GetComponent<AudioSource>().volume = GameObject.Find("MusicSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
			audiovol = this.GetComponent<AudioSource>().volume;
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population < 1200 && this.GetComponent<AudioSource>().clip != sadone && this.GetComponent<AudioSource>().clip != sadtwo){
			if (audiovol == this.GetComponent<AudioSource>().volume){
				this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - (audiovol / 20);
				InvokeRepeating("FadeOutSound", 0, 0.1f);
			}
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population > 1800 && this.GetComponent<AudioSource>().clip != happyone && this.GetComponent<AudioSource>().clip != happytwo){
			if (audiovol == this.GetComponent<AudioSource>().volume){
				this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - (audiovol / 20);
				InvokeRepeating("FadeOutSound", 0, 0.1f);
			}
		}
		if (this.GetComponent<AudioSource>().isPlaying == false){
			if (this.GetComponent<AudioSource>().clip == sadone){
				this.GetComponent<AudioSource>().clip = sadtwo;
				this.GetComponent<AudioSource>().Play(0);
			}
			else if (this.GetComponent<AudioSource>().clip == sadtwo){
				this.GetComponent<AudioSource>().clip = sadone;
				this.GetComponent<AudioSource>().Play(0);
			}
			else if (this.GetComponent<AudioSource>().clip == happyone){
				this.GetComponent<AudioSource>().clip = happytwo;
				this.GetComponent<AudioSource>().Play(0);
			}
			else if (this.GetComponent<AudioSource>().clip == happytwo){
				this.GetComponent<AudioSource>().clip = happyone;
				this.GetComponent<AudioSource>().Play(0);
			}
		}
	}
	
	
	void FadeOutSound(){
		//Schafft einen schönen Übergang, wenn zwischen zwei Musikstücken gewechselt wird.
		if (this.GetComponent<AudioSource>().volume > 0){
			this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - (audiovol / 20);
		}
		else {
			this.GetComponent<AudioSource>().Stop();
			if (this.GetComponent<AudioSource>().clip == sadone){
				this.GetComponent<AudioSource>().clip = happyone;
				this.GetComponent<AudioSource>().volume = audiovol;
				this.GetComponent<AudioSource>().Play(0);
			}
			else if (this.GetComponent<AudioSource>().clip == sadtwo){
				this.GetComponent<AudioSource>().clip = happytwo;
				this.GetComponent<AudioSource>().volume = audiovol;
				this.GetComponent<AudioSource>().Play(0);
			}
			else if (this.GetComponent<AudioSource>().clip == happyone){
				this.GetComponent<AudioSource>().clip = sadone;
				this.GetComponent<AudioSource>().volume = audiovol;
				this.GetComponent<AudioSource>().Play(0);
			}
			else if (this.GetComponent<AudioSource>().clip == happytwo){
				this.GetComponent<AudioSource>().clip = sadtwo;
				this.GetComponent<AudioSource>().volume = audiovol;
				this.GetComponent<AudioSource>().Play(0);
			}
			CancelInvoke("FadeOutSound");
		}
	}
}