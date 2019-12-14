using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
	
	int cooldown = 0;
	GameObject slider;
	bool clicked_with_mouse = false;
	bool alt_option = false;
	float advancetime;
	float percentage;
	bool split;
	bool requirement;
	public AudioClip first;
	public AudioClip second;
	public AudioClip third;
	float audiovol;
	
	void Start() {
		//Initialisieren des Sounds
		this.GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mastervol * GameObject.Find("EventSystem").GetComponent<PublicVariables>().soundvol;
		audiovol = this.GetComponent<AudioSource>().volume;
	}
	
	
	void Update() {
		//Große und Komplexe Funktion. Überprüft, ob sich der Spieler in der Nähe von einer Interaktion befindet und blendet Buttons für diese ein, wenn der Spieler in die Nähe klickt oder den "x"-Knopf betätigt. Sorgt auch dafür, dass verschiedene Eingaben (Maus/Tastatur) miteinander kompatibel sind. Der Spieler ist auch in der Lage, die Interaktionen wieder auszublenden, wenn er woanders hinklickt, oder den "c"-Knopf betätigt. Wenn mit Interaktionen temporär nicht interagiert werden kann, wird kein Button eingeblendet oder eine Meldung ausgegeben.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().OptionP.gameObject.activeSelf == true){
			this.GetComponent<AudioSource>().volume = GameObject.Find("SoundSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
			audiovol = this.GetComponent<AudioSource>().volume;
		}
		if (clicked_with_mouse == true && requirement == false && Mathf.Abs(transform.position.x - GameObject.Find("Player").transform.position.x) +  (Mathf.Abs(transform.position.y - GameObject.Find("Player").transform.position.y)) == 0){
			if (this.name == GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location && GameObject.Find("Time").GetComponent<Time>().S8 == false){
				if (Input.anyKeyDown){
					clicked_with_mouse = false;
					GameObject.Find("Player").GetComponent<PlayerController>().target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					GameObject.Find("Player").GetComponent<PlayerController>().target.z = GameObject.Find("Player").transform.position.z;
					if (GameObject.Find("Player").GetComponent<PlayerController>().target.x > GameObject.Find("Player").transform.position.x){
						GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = true;
					}
					else if (GameObject.Find("Player").GetComponent<PlayerController>().target.x < GameObject.Find("Player").transform.position.x){
						GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = false;
					}
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().ResetButtons();
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
				}
			}
			else {
				clicked_with_mouse = false;
				StartInteraction();
			}
		}
		else if (clicked_with_mouse == true && Input.anyKeyDown){
			if (Mathf.Abs(transform.position.x - 1 - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) + (Mathf.Abs(transform.position.y + 1 - Camera.main.ScreenToWorldPoint(Input.mousePosition).y)) >= 1.0){
				clicked_with_mouse = false;
				GameObject.Find("Player").GetComponent<PlayerController>().target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				GameObject.Find("Player").GetComponent<PlayerController>().target.z = GameObject.Find("Player").transform.position.z;
				if (GameObject.Find("Player").GetComponent<PlayerController>().target.x > GameObject.Find("Player").transform.position.x){
					GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = true;
				}
				else if (GameObject.Find("Player").GetComponent<PlayerController>().target.x < GameObject.Find("Player").transform.position.x){
					GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = false;
				}
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().ResetButtons();
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			}
		}
		if (Input.GetMouseButtonDown(0) && GameObject.Find("Player").GetComponent<PlayerController>().frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
			if (Mathf.Abs(transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) +  (Mathf.Abs(transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y)) <= 1.5){
				if (this.name == "E1" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E2" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E3" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E4" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E5" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E6" && GameObject.Find("Time").GetComponent<Time>().R[7] == false){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E6Canvas.gameObject.SetActive(true);
					GameObject.Find("E6Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E7"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E7Canvas.gameObject.SetActive(true);
					GameObject.Find("E7Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E8" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E9" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "E10"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().E10Canvas.gameObject.SetActive(true);
					GameObject.Find("E10Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "T1"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().T1Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "T2"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().T2Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "T3"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().T3Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "T4"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().T4Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "T5"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().T5Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "K1" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "K2" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "M1" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "M2" && cooldown == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "V1P1"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().P1Canvas.gameObject.SetActive(true);
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
						GameObject.Find("P1Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("gui_cross");
					}
					else {
						GameObject.Find("P1Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("arrowup");
					}
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "V2P3"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
						GameObject.Find("P3Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("gui_cross");
					}
					else {
						GameObject.Find("P3Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("arrowup");	
					}
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "V3P4"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3Canvas.gameObject.SetActive(true);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().P4Canvas.gameObject.SetActive(true);
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
						GameObject.Find("P4Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("gui_cross");
					}
					else {
						GameObject.Find("P4Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("arrowup");
					}
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "P2"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().P2Canvas.gameObject.SetActive(true);
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
						GameObject.Find("P2Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("gui_cross");
					}
					else {
						GameObject.Find("P2Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("arrowup");
					}
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
				else if (this.name == "P5"){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(true);
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
						GameObject.Find("P5Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("gui_cross");
					}
					else {
						GameObject.Find("P5Parrow").GetComponent<Image>().sprite = Resources.Load<Sprite>("arrowup");
					}
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
					GameObject.Find("Player").GetComponent<PlayerController>().target = GameObject.Find("Player").transform.position;
					clicked_with_mouse = true;
				}
			}
		}
		if (Mathf.Abs(transform.position.x - GameObject.Find("Player").transform.position.x) +  (Mathf.Abs(transform.position.y - GameObject.Find("Player").transform.position.y)) <= 1.5 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false || GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true)){
			if (Input.GetKeyDown("x")){
				if (this.name == "E1"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E2"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E3"){
					if (GameObject.Find("Time").GetComponent<Time>().R[2] == false){
						if (cooldown == 0){
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								StartInteraction();
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Private Garden is active";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E4"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E5"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E6" && GameObject.Find("Time").GetComponent<Time>().R[7] == false){
					if (cooldown == 0 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount > 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E6Canvas.gameObject.SetActive(true);
							GameObject.Find("E6Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount;
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  No fish left";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E6Canvas.gameObject.SetActive(true);
							GameObject.Find("E6Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount;
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E7"){
					if (cooldown == 0 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount > 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E7Canvas.gameObject.SetActive(true);
							GameObject.Find("E7Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount;
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  No prey animals left";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E7Canvas.gameObject.SetActive(true);
							GameObject.Find("E7Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount;
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E8"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E9"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "E10"){
					if (cooldown == 0 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10 > 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E10Canvas.gameObject.SetActive(true);
							GameObject.Find("E10Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10;
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  No prey animals left";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().E10Canvas.gameObject.SetActive(true);
							GameObject.Find("E10Text").GetComponent<Text>().text = "" + GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10;
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "T1"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().T1Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "T2"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().T2Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "T3"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().T3Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "T4"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().T4Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "T5"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							StartInteraction();
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().T5Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "K1"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= 50){
							if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= (50 + BalanceSheet.event29_effect)){
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										StartInteraction();
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
								else {
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
										GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + (50 + BalanceSheet.event29_effect);
										InvokeRepeating("EndHint", 3, 0.1f);
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
							}
							else {
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
									StartInteraction();
								}
								else {
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1Canvas.gameObject.SetActive(true);
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
									GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
								}
							}
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
								if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + (50 + BalanceSheet.event29_effect);
								}
								else {
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 50";
								}
								InvokeRepeating("EndHint", 3, 0.1f);
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
				}
				else if (this.name == "K2"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= 50){
							if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= (50 + BalanceSheet.event29_effect)){
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										StartInteraction();
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
								else {
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
										GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + (50 + BalanceSheet.event29_effect);
										InvokeRepeating("EndHint", 3, 0.1f);
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
							}
							else {
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
									StartInteraction();
								}
								else {
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2Canvas.gameObject.SetActive(true);
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
									GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
								}
							}
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
								if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + (50 + BalanceSheet.event29_effect);
								}
								else {
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 50";
								}
								InvokeRepeating("EndHint", 3, 0.1f);
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
				}
				else if (this.name == "M1"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= 25){
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								StartInteraction();
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
								GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 25";
								InvokeRepeating("EndHint", 3, 0.1f);
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
				}
				else if (this.name == "M2"){
					if (GameObject.Find("Time").GetComponent<Time>().R[18] == false){
						if (cooldown == 0){
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								StartInteraction();
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Holiday Time is active";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "V1P1" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
								print("same location");
							}
							else {
								StartInteraction();
							}
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().P1Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "V2P3" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[17] == false){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= 0){
							if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= BalanceSheet.event29_effect){
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
											print("same location");
										}
										else {
											StartInteraction();
										}
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
								else {
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
										GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
										InvokeRepeating("EndHint", 3, 0.1f);
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
							}
							else {
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
										print("same location");
									}
									else {
										StartInteraction();
									}
								}
								else {
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
									GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
								}
							}
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
								if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
								}
								else {
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 0";
								}
								InvokeRepeating("EndHint", 3, 0.1f);
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Great Storm is active";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "V3P4" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[3] == false){
						if (cooldown == 0){
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
									print("same location");
								}
								else {
									StartInteraction();
								}
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().P4Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  The cave is currently destroyed";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().P4Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "P2"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
							print("same location");
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								StartInteraction();
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().P2Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
				}
				else if (this.name == "P5"){
					if (GameObject.Find("Time").GetComponent<Time>().R[5] == false){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location == this.name && GameObject.Find("Time").GetComponent<Time>().S8 == false){
							print("same location");
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= 0){
								if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= BalanceSheet.event29_effect){
										if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
											StartInteraction();
										}
										else {
											GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(true);
											GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
											GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
										}
									}
									else {
										if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
											GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
											GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
											InvokeRepeating("EndHint", 3, 0.1f);
										}
										else {
											GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(true);
											GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
											GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
										}
									}
								}
								else {
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										StartInteraction();
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
							}
							else {
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
									if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
										GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
									}
									else {
										GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 0";
									}
									InvokeRepeating("EndHint", 3, 0.1f);
								}
								else {
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(true);
									GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
									GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
								}
							}
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  This tree was cut down";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
			}
			else if (Input.GetKeyDown("y")){
				if (this.name == "V1P1"){
					if (cooldown == 0){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							alt_option = true;
							StartInteraction();
						}
						else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1HCanvas.gameObject.activeSelf == true){
							ButtonClickHide();
						}
					}
				}
				else if (this.name == "V2P3"){
					if (GameObject.Find("Time").GetComponent<Time>().R[17] == false){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= 0){
							if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail >= BalanceSheet.event29_effect){
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										alt_option = true;
										StartInteraction();
									}
									else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2HCanvas.gameObject.activeSelf == true){
										ButtonClickHide();
									}
								}
								else {
									if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
										GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
										InvokeRepeating("EndHint", 3, 0.1f);
									}
									else {
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
										GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
										GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
									}
								}
							}
							else {
								if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
									alt_option = true;
									StartInteraction();
								}
								else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2HCanvas.gameObject.activeSelf == true){
									ButtonClickHide();
								}
							}
						}
						else {
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
								if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
								}
								else {
									GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 0";
								}
								InvokeRepeating("EndHint", 3, 0.1f);
							}
							else {
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
								GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
								GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
							}
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Great Storm is active";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
				else if (this.name == "V3P4"){
					if (GameObject.Find("Time").GetComponent<Time>().R[3] == false){
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							alt_option = true;
							StartInteraction();
						}
						else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3HCanvas.gameObject.activeSelf == true){
							ButtonClickHide();
						}
					}
					else {
						if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == true){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
							GameObject.Find("PlayerHints").GetComponent<Text>().text = "  The cave is currently destroyed";
							InvokeRepeating("EndHint", 3, 0.1f);
						}
						else {
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().P4Canvas.gameObject.SetActive(true);
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = true;
							GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
						}
					}
				}
			}
		}
	}
	
	
	public void StartInteraction(){
		//Berechnet die Variablen für die jeweilige Interaktion z.B. um wieviel der Hunger gesenkt oder das Monster-o-Meter gesteigert wird. Sorgt auch dafür, dass die Buttons korrekt ausgeblendet werden und sich die Spielfigur während der Interaktionen nicht bewegen kann. Die Variablen werden dann an die ausführende Funktion weitergegeben.
		if (this.name == "E1"){
			print(this.name);
			cooldown = BalanceSheet.e1_cooldown;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[13] == true){
				StartCoroutine(BlockMovement(true,0,0,0,BalanceSheet.e1_monster_increase,5));
			}
			else {
				StartCoroutine(BlockMovement(true,BalanceSheet.e1_hunger_reduction,0,0,BalanceSheet.e1_monster_increase,5));
			}
		}
		else if (this.name == "E2"){
			print(this.name);
			cooldown = BalanceSheet.e2_cooldown;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[13] == true){
				StartCoroutine(BlockMovement(true,0,0,0,BalanceSheet.e2_monster_increase,5));
			}
			else {
				StartCoroutine(BlockMovement(true,BalanceSheet.e2_hunger_reduction,0,0,BalanceSheet.e2_monster_increase,5));
			}
		}
		else if (this.name == "E3"){
			print(this.name);
			if (GameObject.Find("Time").GetComponent<Time>().R[4] == false){
				cooldown = BalanceSheet.e3_cooldown;
			}
			else {
				cooldown = (int) (BalanceSheet.e3_cooldown * BalanceSheet.event5_effect);
			}
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(true,BalanceSheet.e3_hunger_reduction,0,0,0,5));
		}
		else if (this.name == "E4"){
			print(this.name);
			if (GameObject.Find("Time").GetComponent<Time>().R[4] == false){
				cooldown = BalanceSheet.e4_cooldown;
			}
			else {
				cooldown = (int) (BalanceSheet.e4_cooldown * BalanceSheet.event5_effect);
			}
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(true,BalanceSheet.e4_hunger_reduction,0,0,0,5));
		}
		else if (this.name == "E5"){
			print(this.name);
			cooldown = BalanceSheet.e5_cooldown;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(true,BalanceSheet.e5_hunger_reduction,0,0,0,5));
		}
		else if (this.name == "E6"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E6Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(CatchFish());
		}
		else if (this.name == "E7"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E7Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(CatchPrey());
		}
		else if (this.name == "E8"){
			print(this.name);
			if (GameObject.Find("Time").GetComponent<Time>().R[4] == false){
				cooldown = BalanceSheet.e8_cooldown;
			}
			else {
				cooldown = (int) (BalanceSheet.e8_cooldown * BalanceSheet.event5_effect);
			}
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(true,BalanceSheet.e8_hunger_reduction,0,0,0,5));
		}
		else if (this.name == "E9"){
			print(this.name);
			cooldown = BalanceSheet.e9_cooldown;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9S;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(true,BalanceSheet.e9_hunger_reduction,0,0,0,5));
		}
		else if (this.name == "E10"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().E10Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(CatchPrey());
		}
		else if (this.name == "T1"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().T1Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[15] == true){
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t1_thirst_reduction,0,BalanceSheet.t1_monster_increase * BalanceSheet.event16_effect,3));
			}
			else {
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t1_thirst_reduction,0,BalanceSheet.t1_monster_increase,3));
			}
		}
		else if (this.name == "T2"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().T2Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[15] == true){
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t2_thirst_reduction,0,BalanceSheet.t2_monster_increase * BalanceSheet.event16_effect,3));
			}
			else {
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t2_thirst_reduction,0,BalanceSheet.t2_monster_increase,3));
			}
		}
		else if (this.name == "T3"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().T3Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[1] == true){
				if (GameObject.Find("Time").GetComponent<Time>().R[29] == true){
					StartCoroutine(BlockMovement(false,0,BalanceSheet.t3_thirst_reduction * BalanceSheet.event30_effect,0,BalanceSheet.t3_monster_increase * BalanceSheet.event2_effect,3));
				}
				else {
					StartCoroutine(BlockMovement(false,0,BalanceSheet.t3_thirst_reduction,0,BalanceSheet.t3_monster_increase * BalanceSheet.event2_effect,3));
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[29] == true){
					StartCoroutine(BlockMovement(false,0,BalanceSheet.t3_thirst_reduction * BalanceSheet.event30_effect,0,BalanceSheet.t3_monster_increase,3));
				}
				else {
					StartCoroutine(BlockMovement(false,0,BalanceSheet.t3_thirst_reduction,0,BalanceSheet.t3_monster_increase,3));
				}
			}
		}
		else if (this.name == "T4"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().T4Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[7] == false){
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t4_thirst_reduction,0,BalanceSheet.t4_monster_increase,3));
			}
			else {
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t4_thirst_reduction_tourism,0,BalanceSheet.t4_monster_increase_tourism,3));
			}
		}
		else if (this.name == "T5"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().T5Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[15] == true){
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t5_thirst_reduction,0,BalanceSheet.t5_monster_increase * BalanceSheet.event16_effect,3));
			}
			else {
				StartCoroutine(BlockMovement(false,0,BalanceSheet.t5_thirst_reduction,0,BalanceSheet.t5_monster_increase,3));
			}
		}
		else if (this.name == "K1"){
			print(this.name);
			cooldown = BalanceSheet.k1_cooldown;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1S;
			float skill = 100 - (float) (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail - 20);
			skill = skill * BalanceSheet.S2_positive_effect;
			if (GameObject.Find("Time").GetComponent<Time>().S2 == false){
				skill = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[6] == true){
				skill = skill - BalanceSheet.event7_effect;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail - 20 + skill > Random.Range(0.0f, 100.0f)){
				if (GameObject.Find("Time").GetComponent<Time>().R[19] == true && Random.Range(500.0f, 600.0f) < (500 + BalanceSheet.event20_effect)){
					StartCoroutine(BlockMovement(true,0,0,0,0,7));
				}
				else {
					StartCoroutine(BlockMovement(true,BalanceSheet.k1_hunger_reduction,0,0,0,7));
				}
			}
			else {
				StartCoroutine(BlockMovement(true,0,0,0,BalanceSheet.k1_monster_increase,2));
			}
		}
		else if (this.name == "K2"){
			print(this.name);
			cooldown = BalanceSheet.k2_cooldown;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2S;
			float skill = 100 - (float) (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail - 20);
			skill = skill * BalanceSheet.S2_positive_effect;
			if (GameObject.Find("Time").GetComponent<Time>().S2 == false){
				skill = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[6] == true){
				skill = skill - BalanceSheet.event7_effect;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail - 20 + skill > Random.Range(0.0f, 100.0f)){
				if (GameObject.Find("Time").GetComponent<Time>().R[19] == true && Random.Range(500.0f, 600.0f) < (500 + BalanceSheet.event20_effect)){
					StartCoroutine(BlockMovement(true,0,0,0,0,7));
				}
				else {
					StartCoroutine(BlockMovement(true,BalanceSheet.k2_hunger_reduction,0,0,0,7));
				}
			}
			else {
				StartCoroutine(BlockMovement(true,0,0,0,BalanceSheet.k2_monster_increase,2));
			}
		}
		else if (this.name == "M1"){
			print(this.name);
			cooldown = BalanceSheet.m1_cooldown;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1S;
			if (GameObject.Find("Time").GetComponent<Time>().R[21] == true && Random.Range(500.0f, 600.0f) < (500 + BalanceSheet.event22_effect)){
				StartCoroutine(BlockMovement(true,0,0,0,-1 * BalanceSheet.m1_monster_reduction,8));
			}
			else {
				StartCoroutine(BlockMovement(true,0,0,0,BalanceSheet.m1_monster_reduction,8));
			}
		}
		else if (this.name == "M2"){
			print(this.name);
			cooldown = BalanceSheet.m2_cooldown;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2S;
			if (GameObject.Find("Time").GetComponent<Time>().R[21] == true && Random.Range(500.0f, 600.0f) < (500 + BalanceSheet.event22_effect)){
				StartCoroutine(BlockMovement(true,0,0,0,-1 * BalanceSheet.m2_monster_reduction,8));
			}
			else {
				StartCoroutine(BlockMovement(true,0,0,0,BalanceSheet.m2_monster_reduction,8));
			}
		}
		else if (this.name == "V1P1"){
			if (alt_option == false){
				GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
				if (GameObject.Find("Time").GetComponent<Time>().R[16] == true){
					StartCoroutine(BlockMovement(false,0,0,100,-2,12 * BalanceSheet.event17_effect2));
				}
				else {
					StartCoroutine(BlockMovement(false,0,0,100,-2,12));
				}
			}
			else {
				alt_option = false;
				GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
				StartCoroutine(GoHide(1));
			}
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().P1Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
		}
		else if (this.name == "V2P3"){
			if (alt_option == false){
				GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
				if (GameObject.Find("Time").GetComponent<Time>().R[10] == true){
					StartCoroutine(BlockMovement(false,0,0,100,0,12 * BalanceSheet.event11_effect));
				}
				else {
					StartCoroutine(BlockMovement(false,0,0,100,0,12));
				}
			}
			else {
				alt_option = false;
				GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
				StartCoroutine(GoHide(3));
			}
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().P3Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
		}
		else if (this.name == "V3P4"){
			if (alt_option == false){
				GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
				StartCoroutine(BlockMovement(false,0,0,100,0,12));
			}
			else {
				alt_option = false;
				GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
				StartCoroutine(GoHide(1));
			}
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().P4Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
		}
		else if (this.name == "P2"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().P2Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(false,0,0,100,-7,12));
		}
		else if (this.name == "P5"){
			print(this.name);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().P5Canvas.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active = false;
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			if (GameObject.Find("Time").GetComponent<Time>().R[10] == true){
				StartCoroutine(BlockMovement(false,0,0,100,0,12 * BalanceSheet.event11_effect));
			}
			else {
				StartCoroutine(BlockMovement(false,0,0,100,0,12));
			}
		}
		requirement = true;
	}
	
	
	public void ButtonClick(){
		//falls mit der Maus gesteuert wird und die Buttons direkt mit der Maus geklickt werden, erfolgt hier nochmal eine Sicherheitsabfrage, damit Interaktionen auch wirklich nur dann ausgeführt werden, wenn alle Bedingungen dafür erfüllt sind. Ansonsten kommt eine Meldung, die erklärt, warum die Interaktion nicht möglich ist
		requirement = false;
		if (this.name == "E7" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount <= 0){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  No prey animals left";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		else if (this.name == "E10" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10 <= 0){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  No prey animals left";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		else if (this.name == "E6" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount <= 0){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  No fish left";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		else if (this.name == "K1" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < (50 + BalanceSheet.event29_effect)){
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
				requirement = true;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + (50 + BalanceSheet.event29_effect);
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else {
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 50){
					requirement = true;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
					GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 50";
					InvokeRepeating("EndHint", 3, 0.1f);
				}
			}
		}
		if (this.name == "K2" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < (50 + BalanceSheet.event29_effect)){
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
				requirement = true;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + (50 + BalanceSheet.event29_effect);
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else {
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 50){
					requirement = true;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
					GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 50";
					InvokeRepeating("EndHint", 3, 0.1f);
				}
			}
		}
		if (this.name == "M1" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 25){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 25";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		else if (this.name == "V2P3" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < BalanceSheet.event29_effect){
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
				requirement = true;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else {
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 0){
					requirement = true;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
					GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 0";
					InvokeRepeating("EndHint", 3, 0.1f);
				}
			}
		}
		if (this.name == "P5" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < BalanceSheet.event29_effect){
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
				requirement = true;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else {
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 0){
					requirement = true;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
					GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 0";
					InvokeRepeating("EndHint", 3, 0.1f);
				}
			}
		}
		if (this.name == "E3" && GameObject.Find("Time").GetComponent<Time>().R[2] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Private Garden is active";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (this.name == "M2" && GameObject.Find("Time").GetComponent<Time>().R[18] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Holiday Time is active";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (this.name == "V2P3" && GameObject.Find("Time").GetComponent<Time>().R[17] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Great Storm is active";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (this.name == "V3P4" && GameObject.Find("Time").GetComponent<Time>().R[3] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  The cave is currently destroyed";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (this.name == "P5" && GameObject.Find("Time").GetComponent<Time>().R[5] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  This tree was cut down";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (this.name == GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location && GameObject.Find("Time").GetComponent<Time>().S8 == false){
			requirement = true;
		}
		else if (cooldown > 0){
			requirement = true;
		}
		if (requirement == false){
			GameObject.Find("Player").GetComponent<PlayerController>().target = transform.position;
			GameObject.Find("Player").GetComponent<PlayerController>().target.z = GameObject.Find("Player").transform.position.z;
			if (clicked_with_mouse == false){
				StartInteraction();
			}
		}
	}
	
	
	public void ButtonClickAlt(){
		//Erweiterte Abfrage von ButtonClick, falls der Spieler versucht sich zu verstecken
		requirement = false;
		if (this.name == "V2P3" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < BalanceSheet.event29_effect){
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == true){
				requirement = true;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + " + BalanceSheet.event29_effect;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else {
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 0){
					requirement = true;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
					GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your tail needs at least a value of + 0";
					InvokeRepeating("EndHint", 3, 0.1f);
				}
			}
		}
		if (this.name == "V2P3" && GameObject.Find("Time").GetComponent<Time>().R[17] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Event Great Storm is active";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (this.name == "V3P4" && GameObject.Find("Time").GetComponent<Time>().R[3] == true){
			requirement = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
			GameObject.Find("PlayerHints").GetComponent<Text>().text = "  The cave is currently destroyed";
			InvokeRepeating("EndHint", 3, 0.1f);
		}
		if (requirement == false) {
			GameObject.Find("Player").GetComponent<PlayerController>().target = transform.position;
			GameObject.Find("Player").GetComponent<PlayerController>().target.z = GameObject.Find("Player").transform.position.z;
			alt_option = true;
			if (clicked_with_mouse == false){
				StartInteraction();
			}
		}
	}
	
	
	public void ButtonClickHide(){
		//überprüft, ob sich der Spieler eigentlich nur verstecken will
		alt_option = true;
		StartInteraction();
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1HCanvas.gameObject.SetActive(false);
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2HCanvas.gameObject.SetActive(false);
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3HCanvas.gameObject.SetActive(false);
	}
	
	
	IEnumerator CatchFish(){
		//Zuständig um das Fischen auszuführen. Hier wird berechnet, ob der Spieler den Fisch erfolgreich fängt. Auch wird dazu passend ein Sound wiedergegeben. Die Fische reduzieren sich mit jedem Fischfangversuch
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
		this.GetComponent<AudioSource>().loop = false;
		this.GetComponent<AudioSource>().clip = first;
		if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = (4 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect;
			}
			else {
				advancetime = 4 + BalanceSheet.event24_effect;
			}
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = 4 * BalanceSheet.S6_positive_effect;
			}
			else {
				advancetime = 4;
			}
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
		InvokeRepeating("Advance", 0, 0.1f);
		if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds((4 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(4 * BalanceSheet.event24_effect);
			}
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(4 * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(4);
			}
		}
		float skill = 10 + 0.1f * (float) (100 - GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot);
		if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
			skill = skill * BalanceSheet.S1_negative_effect;
		}
		if (skill > Random.Range(0.0f, 100.0f)){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - 1;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - (1 * BalanceSheet.S4_positive_effect);
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount--;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount = 0;
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot < 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot < (-1 * BalanceSheet.S4_negative_effect)){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = -1 * BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot < -100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = -100;
			}
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(false,BalanceSheet.e6_hunger_reduction,0,0,0,1));
		}
		else {
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - 2;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - (2 * BalanceSheet.S4_positive_effect);
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount--;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount = 0;
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot < 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot < (-1 * BalanceSheet.S4_negative_effect)){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = -1 * BalanceSheet.S2_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot < -100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = -100;
			}
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
		}
	}
	
	
	IEnumerator CatchPrey(){
		//Zuständig um das Beutefangen auszuführen. Hier wird berechnet, ob der Spieler die Beute erfolgreich fängt. Auch werden dazu passend verschiedene Sounds wiedergegeben. Die Beute reduziert sich mit jedem Beutefangversuch
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
		this.GetComponent<AudioSource>().loop = true;
		this.GetComponent<AudioSource>().clip = first;
		if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = (5 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect;
			}
			else {
				advancetime = 5 + BalanceSheet.event24_effect;
			}
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = 5 * BalanceSheet.S6_positive_effect;
			}
			else {
				advancetime = 5;
			}
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
		InvokeRepeating("Advance", 0, 0.1f);
		if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds((5 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(5 + BalanceSheet.event24_effect);
			}
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(5 * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(5);
			}
		}
		float skill = 10 + 0.2f * (float) (100 + GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot);
		if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
			skill = skill * BalanceSheet.S1_negative_effect;
		}
		if (skill > Random.Range(0.0f, 100.0f)){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot + 5;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot + (5 * BalanceSheet.S4_positive_effect);
			}
			if (this.name == "E7"){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount--;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount = 0;
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10--;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10 = 0;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot > 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot > BalanceSheet.S4_negative_effect){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot > 100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = 100;
			}
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
			StartCoroutine(BlockMovement(false,BalanceSheet.prey_hunger_reduction,0,0,0,1));
		}
		else {
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot + 5;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot + (5 * BalanceSheet.S4_positive_effect);
			}
			if (this.name == "E7"){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount--;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount = 0;
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10--;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10 = 0;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot > 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot > BalanceSheet.S4_negative_effect){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot > 100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = 100;
			}
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = third;
			this.GetComponent<AudioSource>().volume = audiovol;
			this.GetComponent<AudioSource>().Play(0);
			GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
		}
	}
	
	
	IEnumerator GoHide(float int_time){
		//Führt das Verstecken aus
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
		if (this.name == "V2P3" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false){
			this.GetComponent<AudioSource>().loop = true;
			this.GetComponent<AudioSource>().clip = first;
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				advancetime = 2 + BalanceSheet.event24_effect;
			}
			else {
				advancetime = 2;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = advancetime * BalanceSheet.S6_positive_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().R[23] != true){
				int_time = int_time - BalanceSheet.event24_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(int_time * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(int_time);
			}
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = second;
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				advancetime = 1 + BalanceSheet.event24_effect;
			}
			else {
				advancetime = 1;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = advancetime * BalanceSheet.S6_positive_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				int_time = 1 + BalanceSheet.event24_effect;
			}
			else {
				int_time = 1;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(int_time * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(int_time);
			}
		}
		else if (this.name == "V2P3" && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == true){
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = second;
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				advancetime = 1 + BalanceSheet.event24_effect;
			}
			else {
				advancetime = 1;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = advancetime * BalanceSheet.S6_positive_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				int_time = 1 + BalanceSheet.event24_effect;
			}
			else {
				int_time = 1;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(int_time * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(int_time);
			}
			this.GetComponent<AudioSource>().loop = true;
			this.GetComponent<AudioSource>().clip = first;
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				advancetime = 2 + BalanceSheet.event24_effect;
			}
			else {
				advancetime = 2;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = advancetime * BalanceSheet.S6_positive_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				int_time = 2 + BalanceSheet.event24_effect;
			}
			else {
				int_time = 2;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(int_time * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(int_time);
			}
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				if (int_time == (2 + BalanceSheet.event24_effect)){
					advancetime = 1 + BalanceSheet.event24_effect;
				}
				else {
					advancetime = 1;
				}
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = (advancetime + int_time) * BalanceSheet.S6_positive_effect;
			}
			else {
				advancetime = advancetime + int_time;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				if (int_time == (1 + (2 * BalanceSheet.event24_effect))){
					int_time = int_time + (2 * BalanceSheet.event24_effect);
				}
				else {
					int_time = int_time + BalanceSheet.event24_effect;
				}
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				yield return new WaitForSeconds(int_time * BalanceSheet.S6_positive_effect);
			}
			else {
				yield return new WaitForSeconds(int_time);
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden = true;
			if (this.name == "V1P1"){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1HCanvas.gameObject.SetActive(true);
			}
			else if (this.name == "V2P3"){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().V2HCanvas.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().V3HCanvas.gameObject.SetActive(true);
			}
		}
		else {
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden = false;
		}
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
	}
	
	
	void Timer(){
		//Berechnet den Cooldown von den Interaktionen und setzt den Cooldown sekündlich um eins herunter. Zeigt dies mithilfe eines Balkens an
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			if ((this.name == "M1" || this.name == "M2") && GameObject.Find("Time").GetComponent<Time>().R[12] == true){
			}
			else {
				cooldown--;
				slider.GetComponent<Slider>().value++;
				if (cooldown == 0){
					slider.gameObject.SetActive(false);
					CancelInvoke("Timer");
				}
			}
		}
	}
	
	
	void Advance(){
		//Zuständig für die Fortschrittsanzeige während Interaktionen. Teilt auch die Soundeffekte ein
		percentage = percentage + (100 * (0.1f / advancetime));
		GameObject.Find("Advance").GetComponent<Text>().text = (int) percentage + "%";
		if (this.GetComponent<AudioSource>().isPlaying == false){
			if (this.name == "E6" || (this.name == "E7" && this.GetComponent<AudioSource>().clip == second) || (this.name == "E10" && this.GetComponent<AudioSource>().clip == second) || (this.name == "K1" && this.GetComponent<AudioSource>().clip == second) || (this.name == "K2" && this.GetComponent<AudioSource>().clip == second) || (this.name == "V1P1" && this.GetComponent<AudioSource>().clip == second) || (this.name == "V2P3" && this.GetComponent<AudioSource>().clip == second) || (this.name == "V3P4" && this.GetComponent<AudioSource>().clip == second)){
				if (percentage <= 100 * (0.2f / advancetime)){
					this.GetComponent<AudioSource>().volume = audiovol;
					this.GetComponent<AudioSource>().Play(0);
				}
			}
			else {
				this.GetComponent<AudioSource>().volume = audiovol;
				this.GetComponent<AudioSource>().Play(0);
			}
			if (percentage >= 50 && percentage <= 55){
				if ((this.name == "K1" && this.GetComponent<AudioSource>().clip == second) || (this.name == "K2" && this.GetComponent<AudioSource>().clip == second)){
					this.GetComponent<AudioSource>().volume = audiovol;
					this.GetComponent<AudioSource>().Play(0);
				}
			}
		}
		if (percentage >= 99.5f && split == true){
			split = false;
			this.GetComponent<AudioSource>().Stop();
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = second;
			percentage = 0;
			advancetime = advancetime * 2.5f;
		}
		else if (percentage >= 100){
			CancelInvoke("Advance");
			if (second == null && this.name != "E6"){
				InvokeRepeating("FadeOutSound", 0, 0.1f);
			}
			else {
				this.GetComponent<AudioSource>().Stop();
				if ((this.name == "V2P3" && this.GetComponent<AudioSource>().clip == third) || (this.name == "P5" && this.GetComponent<AudioSource>().clip == third)){
					this.GetComponent<AudioSource>().loop = true;
					this.GetComponent<AudioSource>().clip = first;
				}
			}
			percentage = 0;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(false);
		}
	}
	
	
	void FadeOutSound(){
		//Bei manchen Interaktionen wird der Sound langsam ausgeklungen
		if (this.GetComponent<AudioSource>().volume > 0){
			this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - (audiovol / 20);
		}
		else {
			this.GetComponent<AudioSource>().Stop();
			CancelInvoke("FadeOutSound");
		}
	}
	
	
	IEnumerator BlockMovement(bool has_cooldown, float red_hunger, float red_thirst, int red_mating, float red_monster, float int_time) {
		//Führt die Interaktion final aus und berechnet eventuelle weitere Einflüsse wie Effekte durch ein hohes Monster-o-Meter oder aktive Fertigkeiten oder Zufallsereignisse. Passt auch gegebenenfalls die Attribute des Spielers an, falls diese durch die Interaktion verändert werden würden. Während der Interaktion kann nicht pausiert werden und der Spieler kann sich nicht bewegen. Setzt auch einen Marker für das Paaren, damit das Paaren nicht 2mal am selben Ort stattfinden kann.
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = true;
		if (this.name == "E7"){
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = second;
		}
		else if (this.name == "E10"){
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = second;
		}
		else if (this.name == "E6"){
			this.GetComponent<AudioSource>().loop = false;
			this.GetComponent<AudioSource>().clip = second;
		}
		else {
			this.GetComponent<AudioSource>().loop = true;
			this.GetComponent<AudioSource>().clip = first;
		}
		float monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster;
		if (red_mating > 0 && monster >= 25){
			if (monster >= 150){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1.5f + ((0.5f * BalanceSheet.event15_effect) - 0.5f));
					}
					else {
						int_time = int_time * 1.5f;
					}
				}
				else {
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1 + (0.5f * BalanceSheet.S10_positive_effect) + ((0.5f * BalanceSheet.event15_effect * BalanceSheet.S10_positive_effect) - (0.5f * BalanceSheet.S10_positive_effect)));
					}
					else {
						int_time = int_time * (1 + (0.5f * BalanceSheet.S10_positive_effect));
					}
				}
			}
			else if (monster >= 125){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1.4f + ((0.4f * BalanceSheet.event15_effect) - 0.4f));
					}
					else {
						int_time = int_time * 1.4f;
					}
				}
				else {
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1 + (0.4f * BalanceSheet.S10_positive_effect) + ((0.4f * BalanceSheet.event15_effect * BalanceSheet.S10_positive_effect) - (0.4f * BalanceSheet.S10_positive_effect)));
					}
					else {
						int_time = int_time * (1 + (0.4f * BalanceSheet.S10_positive_effect));
					}
				}
			}
			else if (monster >= 100){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1.3f + ((0.3f * BalanceSheet.event15_effect) - 0.3f));
					}
					else {
						int_time = int_time * 1.3f;
					}
				}
				else {
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1 + (0.3f * BalanceSheet.S10_positive_effect) + ((0.3f * BalanceSheet.event15_effect * BalanceSheet.S10_positive_effect) - (0.3f * BalanceSheet.S10_positive_effect)));
					}
					else {
						int_time = int_time * (1 + (0.3f * BalanceSheet.S10_positive_effect));
					}
				}
			}
			else if (monster >= 75){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1.2f + ((0.2f * BalanceSheet.event15_effect) - 0.2f));
					}
					else {
						int_time = int_time * 1.2f;
					}
				}
				else {
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1 + (0.2f * BalanceSheet.S10_positive_effect) + ((0.2f * BalanceSheet.event15_effect * BalanceSheet.S10_positive_effect) - (0.2f * BalanceSheet.S10_positive_effect)));
					}
					else {
						int_time = int_time * (1 + (0.2f * BalanceSheet.S10_positive_effect));
					}
				}
			}
			else if (monster >= 50){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1.1f + ((0.1f * BalanceSheet.event15_effect) - 0.1f));
					}
					else {
						int_time = int_time * 1.1f;
					}
				}
				else {
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1 + (0.1f * BalanceSheet.S10_positive_effect) + ((0.1f * BalanceSheet.event15_effect * BalanceSheet.S10_positive_effect) - (0.1f * BalanceSheet.S10_positive_effect)));
					}
					else {
						int_time = int_time * (1 + (0.1f * BalanceSheet.S10_positive_effect));
					}
				}
			}
			else if (monster >= 25){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1.05f + ((0.05f * BalanceSheet.event15_effect) - 0.05f));
					}
					else {
						int_time = int_time * 1.05f;
					}
				}
				else {
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						int_time = int_time * (1 + (0.05f * BalanceSheet.S10_positive_effect) + ((0.05f * BalanceSheet.event15_effect * BalanceSheet.S10_positive_effect) - (0.05f * BalanceSheet.S10_positive_effect)));
					}
					else {
						int_time = int_time * (1 + (0.05f * BalanceSheet.S10_positive_effect));
					}
				}
			}
		}
		if (red_mating > 0 && GameObject.Find("Time").GetComponent<Time>().S2 == true){
			int_time = int_time * BalanceSheet.S2_negative_effect;
		}
		if (red_mating > 0 && GameObject.Find("Time").GetComponent<Time>().R[20] == true){
			int_time = int_time * 0.5f;
		}
		if (this.name == "V2P3" || this.name == "P5"){
			advancetime = 2;
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				advancetime = advancetime + BalanceSheet.event24_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				advancetime = advancetime * BalanceSheet.S6_positive_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
				if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
					yield return new WaitForSeconds((2 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect);
				}
				else {
					yield return new WaitForSeconds(2 + BalanceSheet.event24_effect);
				}
				this.GetComponent<AudioSource>().loop = true;
				this.GetComponent<AudioSource>().clip = third;
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
					yield return new WaitForSeconds(2 * BalanceSheet.S6_positive_effect);
				}
				else {
					yield return new WaitForSeconds(2);
				}
				this.GetComponent<AudioSource>().loop = true;
				this.GetComponent<AudioSource>().clip = third;
			}
		}
		if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
			int_time = int_time + BalanceSheet.event24_effect;
		}
		if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
			advancetime = int_time * BalanceSheet.S6_positive_effect;
		}
		else {
			advancetime = int_time;
		}
		if ((this.name == "K1" && red_monster == 0) || (this.name == "K2" && red_monster == 0)){
			advancetime = advancetime * 2 / 7;
			split = true;
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
		InvokeRepeating("Advance", 0, 0.1f);
		if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
			yield return new WaitForSeconds(int_time * BalanceSheet.S6_positive_effect);
		}
		else {
			yield return new WaitForSeconds(int_time);
		}
		if (monster >= 150){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster150_food_drink_loss * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - BalanceSheet.monster150_food_drink_loss;
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster150_food_drink_loss * BalanceSheet.S10_positive_effect * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - (BalanceSheet.monster150_food_drink_loss * BalanceSheet.S10_positive_effect);
				}
			}
		}
		else if (monster >= 125){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster125_food_drink_loss * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - BalanceSheet.monster125_food_drink_loss;
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster125_food_drink_loss * BalanceSheet.S10_positive_effect * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - (BalanceSheet.monster125_food_drink_loss * BalanceSheet.S10_positive_effect);
				}
			}
		}
		else if (monster >= 100){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster100_food_drink_loss * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - BalanceSheet.monster100_food_drink_loss;
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster100_food_drink_loss * BalanceSheet.S10_positive_effect * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - (BalanceSheet.monster100_food_drink_loss * BalanceSheet.S10_positive_effect);
				}
			}
		}
		else if (monster >= 75){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster75_food_drink_loss * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - BalanceSheet.monster75_food_drink_loss;
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
					monster = 1 - (BalanceSheet.monster75_food_drink_loss * BalanceSheet.S10_positive_effect * BalanceSheet.event15_effect);
				}
				else {
					monster = 1 - (BalanceSheet.monster75_food_drink_loss * BalanceSheet.S10_positive_effect);
				}
			}
		}
		else {
			monster = 1;
		}
		if ((slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1S && GameObject.Find("Time").GetComponent<Time>().S9 == false) || (slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2S && GameObject.Find("Time").GetComponent<Time>().S9 == false) || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9S){
			double mouth = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth;
			red_hunger = red_hunger * (float) (1 + mouth / 100);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = mouth + (20 / (1.5f + mouth / 100));
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = (mouth + (20 / (1.5f + mouth / 100))) * (1 + BalanceSheet.S4_positive_effect);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth > 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_mouth = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth > BalanceSheet.S4_negative_effect){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth > 100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = 100;
			}
		}
		if (GameObject.Find("Time").GetComponent<Time>().S13 == true){
			if (slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9S){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population + BalanceSheet.S13_positive_effect;
			}
		}
		if (slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2S){
			double tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail;
			if (slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1S || slider == GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2S){
				red_monster = red_monster * (float) (1 + tail / 100);
				if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
					red_monster = red_monster * BalanceSheet.S1_positive_effect;
				}
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = tail + 10;
				if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = tail + (10 * BalanceSheet.S4_positive_effect);
				}
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail++;
				if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = tail + (1 * BalanceSheet.S4_positive_effect);
				}
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail > 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail > BalanceSheet.S4_negative_effect){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail > 100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = 100;
			}
		}
		else if (this.name == "V2P3" || this.name == "P5"){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail + 3;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail + (3 * BalanceSheet.S4_positive_effect);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail > 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail > BalanceSheet.S4_negative_effect){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail > 100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = 100;
			}
		}
		else if (this.name == "E7" || this.name == "E10"){
			double mouth = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth;
			red_hunger = red_hunger * (float) (1 - mouth / 100);
			if (GameObject.Find("Time").GetComponent<Time>().S3 == true){
				red_hunger = red_hunger + (25 * BalanceSheet.S3_positive_effect);
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = mouth - (20 / (1.5f - mouth / 100));
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = (mouth - (20 / (1.5f - mouth / 100))) * (1 + BalanceSheet.S4_positive_effect);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth < 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_mouth = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth < (-1 * BalanceSheet.S4_negative_effect)){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = -1 * BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth < -100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = -100;
			}
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger = GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger + red_hunger * monster;
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger > 100){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger = 100;
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst = GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst + red_thirst * monster;
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst > 100){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst = 100;
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating + red_mating;
		if (red_mating > 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location = this.name;
			if (GameObject.Find("Time").GetComponent<Time>().S10 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect = true;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingbuff = 90;
			}
		}
		if (GameObject.Find("Time").GetComponent<Time>().R[20] == false){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating > 100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = 100;
			}
		}
		else if (GameObject.Find("Time").GetComponent<Time>().R[20] == true){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating > 75){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = 75;
			}
		}
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster - red_monster;
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster < 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = 0;
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster > 160){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = 160;
		}
		if (has_cooldown == true){
			slider.gameObject.SetActive(true);
			slider.GetComponent<Slider>().value = 0;
			slider.GetComponent<Slider>().maxValue = cooldown;
			InvokeRepeating("Timer", 1, 1);
		}
		if (this.name == "V2P3" || this.name == "P5" || this.name == "K1" || this.name == "K2"){
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
					advancetime = (2 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect;
				}
				else {
					advancetime = 2 * BalanceSheet.S6_positive_effect;
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
					advancetime = 2 + BalanceSheet.event24_effect;
				}
				else {
					advancetime = 2;
				}
			}
			if (this.name == "K1" || this.name == "K2"){
				this.GetComponent<AudioSource>().Stop();
				this.GetComponent<AudioSource>().loop = true;
				this.GetComponent<AudioSource>().clip = first;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().Advance.gameObject.SetActive(true);
			InvokeRepeating("Advance", 0, 0.1f);
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
					yield return new WaitForSeconds((2 + BalanceSheet.event24_effect) * BalanceSheet.S6_positive_effect);
				}
				else {
					yield return new WaitForSeconds(2 * BalanceSheet.S6_positive_effect);
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[23] == true){
					yield return new WaitForSeconds(2 + BalanceSheet.event24_effect);
				}
				else {
					yield return new WaitForSeconds(2);
				}
			}
		}
		if (this.name == "T1" || this.name == "T2" || this.name == "T5"){
			if (GameObject.Find("Time").GetComponent<Time>().R[0] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population - BalanceSheet.event1_effect;
			}
		}
		GameObject.Find("Player").GetComponent<PlayerController>().frozen = false;
	}
	
	
	public int GetCooldown(){
		//Gibt bei Abfrage den Cooldown zurück
		return cooldown;
	}
	
	
	public void LoadCooldown(int cd){
		//übernimmt Daten, wenn Spielstand geladen wird
		cooldown = cd;
		if (this.name == "E1"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E1S;
		}
		else if (this.name == "E2"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E2S;
		}
		else if (this.name == "E3"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E3S;
		}
		else if (this.name == "E4"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E4S;
		}
		else if (this.name == "E5"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E5S;
		}
		else if (this.name == "E8"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E8S;
		}
		else if (this.name == "E9"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().E9S;
		}
		else if (this.name == "M1"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().M1S;
		}
		else if (this.name == "M2"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().M2S;
		}
		else if (this.name == "K1"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().K1S;
		}
		else if (this.name == "K2"){
			slider = GameObject.Find("EventSystem").GetComponent<PublicVariables>().K2S;
		}
		if (cooldown != 0){
			StartCoroutine(LoadDelay());
		}
	}
	
	
	IEnumerator LoadDelay(){
		//wichtig, wenn Spiel geladen wird
		yield return new WaitForSeconds(0.1f);
		slider.gameObject.SetActive(true);
		slider.GetComponent<Slider>().value = 0;
		slider.GetComponent<Slider>().maxValue = cooldown;
		InvokeRepeating("Timer", 1, 1);
	}
	
	
	void EndHint(){
		//zuständig um die Spielermeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(false);
		CancelInvoke("EndHint");
	}
}
