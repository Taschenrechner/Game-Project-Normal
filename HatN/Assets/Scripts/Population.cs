using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour {
	
	bool populationhint = false;
	bool functioncall = false;
	
	void Start(){
		//sorgt dafür, dass der Populationswert jeden Tag neu berechnet wird
		InvokeRepeating("Timer", 1, 0.5f);
	}
	
	
	void Update(){
		//sorgt dafür, dass der Populationswert korrekt angezeigt wird.
		if (GameObject.Find("Time").GetComponent<Time>().R[32] == false){
			this.GetComponent<Text>().text = "  Population: " + GameObject.Find("EventSystem").GetComponent<PublicVariables>().population;
		}
		else {
			this.GetComponent<Text>().text = "  Population: ???";
		}
	}
	
	
	void Timer(){
		//berechnet den Populationswert jeden Tag aufs Neue. Der neue Wert hängt dabei von Hunger, Durst, Paarungsbedarf und diversen Umweltvariablen ab. Gibt dem Spieler auch eine Meldung, wenn die Population zu gering wird und ruft eine Funktion auf, die einen akustischen Alarm startet.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			int old_population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population;
			float monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster;
			float hunger = GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger;
			int per_hunger = 100 - (int) hunger;
			if (per_hunger > 25){
				per_hunger = per_hunger - 10;
				if (per_hunger < 25){
					per_hunger = 25;
				}
			}
			float mod1_hunger = 1.01f - (0.0004f * per_hunger);
			float mod2_hunger = 25 - per_hunger;
			if (mod2_hunger < 0){
				mod2_hunger = mod2_hunger / 5;
			}
			if (per_hunger > 25){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopFood.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopFood.gameObject.SetActive(false);
			}
			float thirst = GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst;
			int per_thirst = 100 - (int) thirst;
			if (per_thirst > 25){
				per_thirst = per_thirst - 10;
				if (per_thirst < 25){
					per_thirst = 25;
				}
			}
			float mod1_thirst = 1.01f - (0.0004f * per_thirst);
			float mod2_thirst = 25 - per_thirst;
			if (mod2_thirst < 0){
				mod2_thirst = mod2_thirst / 5;
			}
			if (per_thirst > 25){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopThirst.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopThirst.gameObject.SetActive(false);
			}
			float mating = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating;
			int per_mating = 100 - (int) mating;
			float mod1_mating = 1;
			if (per_mating > 50){
				mod1_mating = 1 - (0.004f * (per_mating - 50));
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMating.gameObject.SetActive(true);
			}
			else {
				mod1_mating = 1;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMating.gameObject.SetActive(false);
			}
			float mod2_mating;
			if (per_mating < 25){
				mod2_mating = 1.5f - (0.02f * per_mating);
			}
			else {
				mod2_mating = 1 - (0.008f * per_mating);
			}
			if (monster >= 150){
				monster = BalanceSheet.monster150_pop_loss;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMonster.gameObject.SetActive(true);
			}
			else if (monster >= 125){
				monster = BalanceSheet.monster125_pop_loss;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMonster.gameObject.SetActive(true);
			}
			else if (monster >= 100){
				monster = BalanceSheet.monster100_pop_loss;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMonster.gameObject.SetActive(true);
			}
			else if (monster >= 75){
				monster = BalanceSheet.monster75_pop_loss;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMonster.gameObject.SetActive(true);
			}
			else if (monster >= 50){
				monster = BalanceSheet.monster50_pop_loss;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMonster.gameObject.SetActive(true);
			}
			else {
				monster = 0;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMonster.gameObject.SetActive(false);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == true){
				monster = monster * BalanceSheet.S10_positive_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
				monster = monster * BalanceSheet.event15_effect;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == true && monster > 0){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster >= 150){
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
						monster = monster * 0.5f;
					}
					else {
						monster = monster * 0.5f * BalanceSheet.S10_positive_effect;
					}
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						monster = monster * BalanceSheet.event15_effect;
					}
				}
				else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster >= 125){
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
						monster = monster * 0.3f;
					}
					else {
						monster = monster * 0.3f * BalanceSheet.S10_positive_effect;
					}
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						monster = monster * BalanceSheet.event15_effect;
					}
				}
				else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster >= 100){
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == false){
						monster = monster * 0.1f;
					}
					else {
						monster = monster * 0.1f * BalanceSheet.S10_positive_effect;
					}
					if (GameObject.Find("Time").GetComponent<Time>().R[14] == true){
						monster = monster * BalanceSheet.event15_effect;
					}
				}
			}
			int new_population = (int) (old_population * mod1_hunger * mod1_thirst * mod1_mating + mod2_hunger + mod2_thirst);
			int difference = old_population - new_population;
			float tempreduction = TemperatureCalc();
			if (GameObject.Find("Time").GetComponent<Time>().R[8] == true){
				tempreduction = tempreduction * BalanceSheet.event9_effect;
			}
			if (new_population <= old_population){
				if (GameObject.Find("Time").GetComponent<Time>().S13 == true){
					new_population = new_population - (int) ((old_population - new_population) * BalanceSheet.S13_negative_effect);
					difference = difference + (int) ((old_population - new_population) * BalanceSheet.S13_negative_effect);
				}
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = new_population - (int) monster - (int) tempreduction;
				difference = difference + (int) monster + (int) tempreduction;
				if (difference >= 40 || (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population < 1200 && difference >= 20)){
					if (functioncall == false){
						InvokeRepeating("StartBlink", 0, 0.3f);
						functioncall = true;
					}
				}
				else {
					functioncall = false;
					CancelInvoke("StartBlink");
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCritical.gameObject.SetActive(false);
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCriticalPl.gameObject.SetActive(false);
				}
			}
			else {
				functioncall = false;
				CancelInvoke("StartBlink");
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCritical.gameObject.SetActive(false);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCriticalPl.gameObject.SetActive(false);
				new_population = (int) ((new_population - old_population) * mod2_mating * ((GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation - old_population) / (GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation - Mathf.Pow(Mathf.Log10(GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation - old_population),6))));
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = old_population + new_population - (int) monster - (int) tempreduction;
				if (GameObject.Find("Time").GetComponent<Time>().S12 == true){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population + (int) (new_population * BalanceSheet.S12_positive_effect);
				}
				if (mod2_mating < 1){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopMating.gameObject.SetActive(true);
				}
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[9] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population - BalanceSheet.event10_effect;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().V1HCanvas.gameObject.activeSelf == true && GameObject.Find("Time").GetComponent<Time>().R[16] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population - BalanceSheet.event17_effect;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population < 1200 && populationhint == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  Your pack is dwindling away...";
				populationhint = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population > 1800){
				populationhint = false;
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population > GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation;
		}
	}
	
	
	float TemperatureCalc(){
		//berechnet den eventuellen Populationsverlust durch zu hohe oder niedrige Temperaturen
		float posy = GameObject.Find("Player").transform.position.y;
		float tempfactor;
		double heatres;
		double coldres;
		if (GameObject.Find("Time").GetComponent<Time>().S14 == false){
			heatres = 1 - GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur / 50;
			coldres = -1 - GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur / 50;
		}
		else {
			heatres = (1 + BalanceSheet.S14_positive_effect) - GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur / 50;
			coldres = (-1 - BalanceSheet.S14_positive_effect) - GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur / 50;
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().season == 1 || GameObject.Find("EventSystem").GetComponent<PublicVariables>().season == 3){
			if (GameObject.Find("Time").GetComponent<Time>().R[30] == true){
				tempfactor = 2.5f;
			}
			else {
				tempfactor = 2;
			}
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().season == 2){
			if (GameObject.Find("Time").GetComponent<Time>().R[30] == true){
				tempfactor = 4;
			}
			else {
				tempfactor = 3;
			}
		}
		else {
			tempfactor = 1;
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater == true){
			tempfactor = tempfactor - 1;
		}
		else if (Mathf.Abs(GameObject.Find("E6").transform.position.x - GameObject.Find("Player").transform.position.x) + (Mathf.Abs(GameObject.Find("E6").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 1.5){
			tempfactor = tempfactor - 1;
		}
		if (GameObject.Find("Time").GetComponent<Time>().R[30] == true){
			tempfactor = tempfactor - 5 * Mathf.Abs(posy) / 13;
		}
		else {
			tempfactor = tempfactor - 4 * Mathf.Abs(posy) / 13;
		}
		if (tempfactor > heatres || tempfactor < coldres){
			if (tempfactor > heatres){
				tempfactor = tempfactor - (float) heatres;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopHot.gameObject.SetActive(true);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCold.gameObject.SetActive(false);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur--;
				if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur - (1 * BalanceSheet.S4_positive_effect);
				}
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur < 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fur = 0;
				}
				if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur < (-1 * BalanceSheet.S4_negative_effect)){
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = -1 * BalanceSheet.S4_negative_effect;
					}
				}
				else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur < -100){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = -100;
				}
			}
			else {
				tempfactor = tempfactor - (float) coldres;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopHot.gameObject.SetActive(false);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCold.gameObject.SetActive(true);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur++;
				if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur + (1 * BalanceSheet.S4_positive_effect);
				}
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur > 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fur = 0;
				}
				if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
					if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur > BalanceSheet.S4_negative_effect){
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = BalanceSheet.S4_negative_effect;
					}
				}
				else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur > 100){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = 100;
				}
			}
		}
		else {
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopHot.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCold.gameObject.SetActive(false);
			tempfactor = 0;
		}
		tempfactor = tempfactor * 8;
		return(Mathf.Abs(tempfactor));
	}
	
	
	void StartBlink(){
		//wenn die Population zu stark sinkt, wird ein blinkendes, rotes Ausrufezeichen neben der Population angezeigt. Außerdem gibt es einen akustischen Alarm
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCritical.gameObject.activeSelf == false){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCritical.gameObject.SetActive(true);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCriticalPl.gameObject.SetActive(false);
			GameObject.Find("PopCritical").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
			GameObject.Find("PopCritical").GetComponent<AudioSource>().Play(0);
		}
		else {
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCritical.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCriticalPl.gameObject.SetActive(true);
		}
	}
	
	
	void EndHint(){
		//zuständig um die Spielermeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(false);
		CancelInvoke("EndHint");
	}
}