using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour {
	
	bool hungryhint = false;
	bool hungryhint2 = false;
	
	void Start(){
		//sorgt dafür, dass der Hungerwert jeden Tag sinkt
		InvokeRepeating("Timer", 1, 0.5f);
	}
	
	
	void Update(){
		//sorgt dafür, dass der Hungerwert korrekt angezeigt wird. Die Farbgebung dient dazu, dem Spieler über einen eventuellen kritischen Zustand zu informieren.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 40){
			this.GetComponent<Text>().text = ":<color=red>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger + "</color>";
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 65){
			this.GetComponent<Text>().text = ":<color=orange>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger + "</color>";
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 75){
			this.GetComponent<Text>().text = ":<color=yellow>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger + "</color>";
		}
		else {
			this.GetComponent<Text>().text = ":" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger;
		}
	}
	
	
	void Timer(){
		//berechnet den Hungerwert jeden Tag neu. Der Wert sinkt mehr, je höher er ist. Auch eventuelle Einflüsse durch das Zufallsereignisse oder Fertigkeiten werden berücksichtigt.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			float hunger = GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger;
			float rate_hunger = 0.25f * ((25 + hunger) / 100);
			rate_hunger = rate_hunger * (1 + 0.25f * (float) GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail / 100);
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater == true){
				rate_hunger = rate_hunger * (float) (3.5f + GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot / 50);
			}
			if (GameObject.Find("Time").GetComponent<Time>().S7 == true){
				rate_hunger = rate_hunger * BalanceSheet.S7_negative_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[26] == true){
				rate_hunger = rate_hunger * BalanceSheet.event27_effect;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect == true){
				rate_hunger = rate_hunger * BalanceSheet.S10_negative_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S14 == true && GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopCold.gameObject.activeSelf == true){
				rate_hunger = rate_hunger * BalanceSheet.S14_negative_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger = hunger - (rate_hunger * BalanceSheet.hunger_rate);
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 40 && hungryhint2 == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  You are feeling very hungry...";
				hungryhint2 = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 65 && hungryhint == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  You are feeling hungry...";
				hungryhint = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger > 65){
				hungryhint = false;
				hungryhint2 = false;
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger = 0;
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger < 50 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail - 0.5f;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail - (0.5f * BalanceSheet.S4_positive_effect);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail = 0;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < (-1 * BalanceSheet.S4_negative_effect)){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = -1 * BalanceSheet.S4_negative_effect;
				}
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < -100){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = -100;
			}
		}
	}
	
	
	void EndHint(){
		//zuständig um die Spielermeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(false);
		CancelInvoke("EndHint");
	}
}
