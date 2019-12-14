using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PublicVariables : MonoBehaviour {
	
	public float speedmod = 1.0f;
	public float monster = 0;
	public int population = 4000;
	public int maxpopulation = 10000;
	public float mating = 100;
	public float thirst = 100;
	public float hunger = 100;
	public double mouth = 0;
	public int t_mouth = 0;
	public double foot = 0;
	public int t_foot = 0;
	public double tail = 0;
	public int t_tail = 0;
	public double fur = 0;
	public int t_fur = 0;
	public int preycount = 3;
	public int t_preycount = 0;
	public int preycount10 = 3;
	public int t_preycount10 = 0;
	public int fishcount = 5;
	public int t_fishcount = 0;
	public bool paused = false;
	public bool clickbreak = false;
	public bool button_active = false;
	public bool hidden = false;
	public bool inwater = false;
	public bool pairingeffect = false;
	public int pairingbuff = 0;
	public int season = 1;
	public string last_location = "";
	public GameObject E1S;
	public GameObject E2S;
	public GameObject E3S;
	public GameObject E4S;
	public GameObject E5S;
	public GameObject E8S;
	public GameObject E9S;
	public GameObject M1S;
	public GameObject M2S;
	public GameObject K1S;
	public GameObject K2S;
	public GameObject E1Canvas;
	public GameObject E2Canvas;
	public GameObject E3Canvas;
	public GameObject E4Canvas;
	public GameObject E5Canvas;
	public GameObject E6Canvas;
	public GameObject E7Canvas;
	public GameObject E8Canvas;
	public GameObject E9Canvas;
	public GameObject E10Canvas;
	public GameObject T1Canvas;
	public GameObject T2Canvas;
	public GameObject T3Canvas;
	public GameObject T4Canvas;
	public GameObject T5Canvas;
	public GameObject K1Canvas;
	public GameObject K2Canvas;
	public GameObject M1Canvas;
	public GameObject M2Canvas;
	public GameObject V1Canvas;
	public GameObject V2Canvas;
	public GameObject V3Canvas;
	public GameObject P1Canvas;
	public GameObject P2Canvas;
	public GameObject P3Canvas;
	public GameObject P4Canvas;
	public GameObject P5Canvas;
	public GameObject V1HCanvas;
	public GameObject V2HCanvas;
	public GameObject V3HCanvas;
	public GameObject Advance;
	public GameObject PopCritical;
	public GameObject PopCriticalPl;
	public GameObject PopFood;
	public GameObject PopThirst;
	public GameObject PopMating;
	public GameObject PopMonster;
	public GameObject PopCold;
	public GameObject PopHot;
	public GameObject Popup;
	public GameObject OptionP;
	public GameObject HelpP;
	public GameObject AttributeP;
	public GameObject SkillP;
	public GameObject EventP;
	public GameObject QuitP;
	public GameObject GameOver;
	public GameObject SelectionP;
	public GameObject RandomP;
	public GameObject HintP;
	public GameObject EventHintP;
	public GameObject DisableK1;
	public GameObject DisableK2;
	public GameObject DisableE3;
	public GameObject DisableM1;
	public GameObject DisableM2;
	public GameObject DisableV2P3;
	public GameObject DisableV3P4;
	public GameObject DisableP5;
	public GameObject TCanvas;
	public float audiovol = 0.64f;
	public float mastervol = 0.8f;
	public float musicvol = 0.8f;
	public float soundvol = 0.8f;
	public float effectvol = 0.64f;
	
	void Start() {
		//Initialisieren des Spiels und Sicherstellen, dass keine Buttons oder Fenster am Anfang geöffnet sind
		E1S.gameObject.SetActive(false);
		E2S.gameObject.SetActive(false);
		E3S.gameObject.SetActive(false);
		E4S.gameObject.SetActive(false);
		E5S.gameObject.SetActive(false);
		E8S.gameObject.SetActive(false);
		E9S.gameObject.SetActive(false);
		M1S.gameObject.SetActive(false);
		M2S.gameObject.SetActive(false);
		K1S.gameObject.SetActive(false);
		K2S.gameObject.SetActive(false);
		E1Canvas.gameObject.SetActive(false);
		E2Canvas.gameObject.SetActive(false);
		E3Canvas.gameObject.SetActive(false);
		E4Canvas.gameObject.SetActive(false);
		E5Canvas.gameObject.SetActive(false);
		E6Canvas.gameObject.SetActive(false);
		E7Canvas.gameObject.SetActive(false);
		E8Canvas.gameObject.SetActive(false);
		E9Canvas.gameObject.SetActive(false);
		E10Canvas.gameObject.SetActive(false);
		T1Canvas.gameObject.SetActive(false);
		T2Canvas.gameObject.SetActive(false);
		T3Canvas.gameObject.SetActive(false);
		T4Canvas.gameObject.SetActive(false);
		T5Canvas.gameObject.SetActive(false);
		K1Canvas.gameObject.SetActive(false);
		K2Canvas.gameObject.SetActive(false);
		M1Canvas.gameObject.SetActive(false);
		M2Canvas.gameObject.SetActive(false);
		V1Canvas.gameObject.SetActive(false);
		V2Canvas.gameObject.SetActive(false);
		V3Canvas.gameObject.SetActive(false);
		P1Canvas.gameObject.SetActive(false);
		P2Canvas.gameObject.SetActive(false);
		P3Canvas.gameObject.SetActive(false);
		P4Canvas.gameObject.SetActive(false);
		P5Canvas.gameObject.SetActive(false);
		V1HCanvas.gameObject.SetActive(false);
		V2HCanvas.gameObject.SetActive(false);
		V3HCanvas.gameObject.SetActive(false);
		Advance.gameObject.SetActive(false);
		PopCritical.gameObject.SetActive(false);
		PopCriticalPl.gameObject.SetActive(false);
		PopFood.gameObject.SetActive(false);
		PopThirst.gameObject.SetActive(false);
		PopMating.gameObject.SetActive(false);
		PopMonster.gameObject.SetActive(false);
		PopCold.gameObject.SetActive(false);
		PopHot.gameObject.SetActive(false);
		Popup.gameObject.SetActive(false);
		OptionP.gameObject.SetActive(true);
		GameObject.Find("MasterSlider").GetComponent<Slider>().value = mastervol;
		GameObject.Find("MusicSlider").GetComponent<Slider>().value = musicvol;
		GameObject.Find("SoundSlider").GetComponent<Slider>().value = soundvol;
		OptionP.gameObject.SetActive(false);
		HelpP.gameObject.SetActive(false);
		AttributeP.gameObject.SetActive(false);
		SkillP.gameObject.SetActive(false);
		EventP.gameObject.SetActive(false);
		QuitP.gameObject.SetActive(false);
		GameOver.gameObject.SetActive(false);
		SelectionP.gameObject.SetActive(false);
		RandomP.gameObject.SetActive(false);
		HintP.gameObject.SetActive(false);
		EventHintP.gameObject.SetActive(false);
		if (GameObject.Find("Time").GetComponent<Time>().GetDay() == 1 && GameObject.Find("Time").GetComponent<Time>().GetMonth() == 3 && GameObject.Find("Time").GetComponent<Time>().GetYear() == 1){
			population = BalanceSheet.population_start;
			maxpopulation = BalanceSheet.population_max;
			TCanvas.gameObject.SetActive(true);
			GameObject.Find("StartButton").GetComponent<Button>().Select();
			paused = true;
		}
		else {
			TCanvas.gameObject.SetActive(false);
			if (GameObject.Find("Time").GetComponent<Time>().S5 == true){
				maxpopulation = BalanceSheet.S5_negative_effect;
			}
		}
	}
	
	
	void Update(){
		//Berechnung der Bewegungs- und Schwimmgeschwindigkeit. Außerdem teilweise Steuerung des Pausemenüs, beim Drücken von c gelangt man in das vorherige Menü
		if (Input.GetKeyDown("c") && paused == false && button_active == true){
			ResetButtons();
		}
		else if ((Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape)) && paused == false && GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
			Popup.gameObject.SetActive(true);
			Popup.GetComponent<AudioSource>().volume = effectvol;
			Popup.GetComponent<AudioSource>().Play(0);
			paused = true;
			GameObject.Find("InfoPanelText").GetComponent<Text>().text = "The game is paused";
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && Popup.gameObject.activeSelf == true){
			ButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && OptionP.gameObject.activeSelf == true){
			OptionButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && HelpP.gameObject.activeSelf == true){
			HelpButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && AttributeP.gameObject.activeSelf == true){
			AttributeButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && SkillP.gameObject.activeSelf == true){
			SkillButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && EventP.gameObject.activeSelf == true){
			EventButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		else if (Input.GetKeyDown("c") && paused == true && QuitP.gameObject.activeSelf == true){
			QuitButtonClick();
			GameObject.Find("Continue").GetComponent<Button>().Select();
		}
		speedmod = 1.0f + (float) (0.05f * foot / 100);
		if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
			speedmod = speedmod * BalanceSheet.S6_negative_effect;
		}
		if (GameObject.Find("Time").GetComponent<Time>().R[24] == true){
			speedmod = speedmod * BalanceSheet.event25_effect;
		}
		if (inwater == true){
			speedmod = 0.3f - (float) (foot / 1000);
			speedmod = speedmod * BalanceSheet.swimming_speed;
		}
		else {
			speedmod = speedmod * BalanceSheet.movement_speed;
		}
	}
	
	
	public void ButtonClick(){
		//Fortsetzen des Spiels
		Popup.gameObject.SetActive(false);
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		paused = false;
	}
	
	
	public void SaveButtonClick(){
		//Speichern des Spiels
		this.GetComponent<SaveGame>().SaveGameState();
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
	}
	
	
	public void OptionButtonClick(){
		//Öffnen der Optionen
		if (OptionP.gameObject.activeSelf == false){
			Popup.gameObject.SetActive(false);
			OptionP.gameObject.SetActive(true);
			OptionP.GetComponent<AudioSource>().volume = effectvol;
		}
		else {
			audiovol = GameObject.Find("MusicSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
			effectvol = GameObject.Find("SoundSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
			GameObject.Find("MainCamera").GetComponent<PlayerSettingsGame>().UpdatePrefs();
			OptionP.gameObject.SetActive(false);
			Popup.gameObject.SetActive(true);
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void HelpButtonClick(){
		//Öffnen des Hilfemenüs
		if (HelpP.gameObject.activeSelf == false){
			Popup.gameObject.SetActive(false);
			HelpP.gameObject.SetActive(true);
			HelpP.GetComponent<AudioSource>().volume = effectvol;
		}
		else {
			HelpP.gameObject.SetActive(false);
			Popup.gameObject.SetActive(true);
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void AttributeButtonClick(){
		//Öffnen der Attributübersicht
		if (AttributeP.gameObject.activeSelf == false){
			Popup.gameObject.SetActive(false);
			AttributeP.gameObject.SetActive(true);
			AttributeP.GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("AttributeText").GetComponent<AttributeText>().UpdateText();
		}
		else {
			AttributeP.gameObject.SetActive(false);
			Popup.gameObject.SetActive(true);
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void SkillButtonClick(){
		//Öffnen der Fertigkeitenübersicht
		if (SkillP.gameObject.activeSelf == false){
			Popup.gameObject.SetActive(false);
			SkillP.gameObject.SetActive(true);
			SkillP.GetComponent<AudioSource>().volume = effectvol;
		}
		else {
			SkillP.gameObject.SetActive(false);
			Popup.gameObject.SetActive(true);
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void EventButtonClick(){
		//Öffnen der Eventübersicht
		if (EventP.gameObject.activeSelf == false){
			Popup.gameObject.SetActive(false);
			EventP.gameObject.SetActive(true);
			EventP.GetComponent<AudioSource>().volume = effectvol;
		}
		else {
			EventP.gameObject.SetActive(false);
			Popup.gameObject.SetActive(true);
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void QuitButtonClick(){
		//Beenden des Spiels
		if (QuitP.gameObject.activeSelf == false){
			Popup.gameObject.SetActive(false);
			QuitP.gameObject.SetActive(true);
			QuitP.GetComponent<AudioSource>().volume = effectvol;
		}
		else {
			QuitP.gameObject.SetActive(false);
			Popup.gameObject.SetActive(true);
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void QuitToMenu(){
		//Zurückkehren zum Hauptmenü
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		SceneManager.LoadScene(0);
	}
	
	
	public void StartButtonClick(){
		//Für das Popup beim Starten eines neuen Spiels
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().volume = effectvol;
		GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		paused = false;
	}
	
	public void ResetButtons(){
		//Schließt alle offenen Buttons/Panels
		E1Canvas.gameObject.SetActive(false);
		E2Canvas.gameObject.SetActive(false);
		E3Canvas.gameObject.SetActive(false);
		E4Canvas.gameObject.SetActive(false);
		E5Canvas.gameObject.SetActive(false);
		E6Canvas.gameObject.SetActive(false);
		E7Canvas.gameObject.SetActive(false);
		E8Canvas.gameObject.SetActive(false);
		E9Canvas.gameObject.SetActive(false);
		E10Canvas.gameObject.SetActive(false);
		T1Canvas.gameObject.SetActive(false);
		T2Canvas.gameObject.SetActive(false);
		T3Canvas.gameObject.SetActive(false);
		T4Canvas.gameObject.SetActive(false);
		T5Canvas.gameObject.SetActive(false);
		K1Canvas.gameObject.SetActive(false);
		K2Canvas.gameObject.SetActive(false);
		M1Canvas.gameObject.SetActive(false);
		M2Canvas.gameObject.SetActive(false);
		V1Canvas.gameObject.SetActive(false);
		V2Canvas.gameObject.SetActive(false);
		V3Canvas.gameObject.SetActive(false);
		P1Canvas.gameObject.SetActive(false);
		P2Canvas.gameObject.SetActive(false);
		P3Canvas.gameObject.SetActive(false);
		P4Canvas.gameObject.SetActive(false);
		P5Canvas.gameObject.SetActive(false);
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
		button_active = false;
	}
	
	
	IEnumerator ClickBreak(){
		//Sicherheitsabfrage für Interaktionen, wenn mit Maus gespielt wird
		clickbreak = true;
		yield return new WaitForSeconds(0.1f);
		clickbreak = false;
	}
}