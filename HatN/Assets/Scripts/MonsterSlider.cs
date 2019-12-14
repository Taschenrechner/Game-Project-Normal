using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlider : MonoBehaviour {
	
	void Start() {
		//sorgt dafür, dass der Monster-o-Meter-Wert jeden Tag sinkt
		InvokeRepeating("Timer", 1, 0.5f);
	}
	
	
	void Update() {
		//sorgt dafür, dass der Monster-o-Meter-Wert korrekt angezeigt wird.
		this.GetComponent<Slider>().value = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster;
	}
	
	
	void Timer() {
		//berechnet den Monster-o-Meter-Wert jeden Tag aufs Neue. Dabei wird auch einbezogen, ob sich der Spieler gerade versteckt oder ob andere Faktoren den Monster-o-Meter-Wert beeinflussen.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			float dec_monster = 0.1f;
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == true){
				if (GameObject.Find("Time").GetComponent<Time>().S8 == true){
					dec_monster = dec_monster * (1 + (BalanceSheet.hiding_monster_bonus_reduction * BalanceSheet.S8_negative_effect));
				}
				else {
					dec_monster = dec_monster * (1 + BalanceSheet.hiding_monster_bonus_reduction);
				}
			}
			if (GameObject.Find("Time").GetComponent<Time>().S3 == true){
				dec_monster = dec_monster * BalanceSheet.S3_negative_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S12 == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster - (dec_monster * BalanceSheet.monster_reduction_rate);
			}
			else {
				if (Mathf.Abs(GameObject.Find("DesertCity").transform.position.x - GameObject.Find("Player").transform.position.x) +  (Mathf.Abs(GameObject.Find("DesertCity").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 3){
				}
				else if (Mathf.Abs(GameObject.Find("GrasslandsCity").transform.position.x - GameObject.Find("Player").transform.position.x) +  (Mathf.Abs(GameObject.Find("GrasslandsCity").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 3){
				}
				else if (Mathf.Abs(GameObject.Find("SouthCity").transform.position.x - GameObject.Find("Player").transform.position.x) +  (Mathf.Abs(GameObject.Find("SouthCity").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 3){
				}
				else if (Mathf.Abs(GameObject.Find("NorthCity").transform.position.x - GameObject.Find("Player").transform.position.x) +  (Mathf.Abs(GameObject.Find("NorthCity").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 3){
				}
				else {
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster - (dec_monster * BalanceSheet.monster_reduction_rate);
				}
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster < 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = 0;
		}
	}
}
