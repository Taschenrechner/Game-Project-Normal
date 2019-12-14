using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thirst : MonoBehaviour {
	
	bool thirstyhint = false;
	bool thirstyhint2 = false;
	
	void Start(){
		//sorgt dafür, dass der Durstwert jeden Tag sinkt
		InvokeRepeating("Timer", 1, 0.5f);
	}
	
	
	void Update(){
		//sorgt dafür, dass der Durstwert korrekt angezeigt wird. Die Farbgebung dient dazu, dem Spieler über einen eventuellen kritischen Zustand zu informieren.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst < 40){
			this.GetComponent<Text>().text = ":<color=red>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst + "</color>";
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst < 65){
			this.GetComponent<Text>().text = ":<color=orange>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst + "</color>";
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst < 75){
			this.GetComponent<Text>().text = ":<color=yellow>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst + "</color>";
		}
		else {
			this.GetComponent<Text>().text = ":" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst;
		}
	}
	
	
	void Timer(){
		//berechnet den Durstwert jeden Tag neu. Der Wert sinkt mehr, je höher er ist. Auch eventuelle Einflüsse durch das Zufallsereignisse oder Fertigkeiten werden berücksichtigt.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			float thirst = GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst;
			float rate_thirst = 0.25f * ((25 + thirst) / 100);
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater == true){
				rate_thirst = rate_thirst * (float) (3.5f + GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot / 50);
			}
			if (GameObject.Find("Time").GetComponent<Time>().S7 == true){
				rate_thirst = rate_thirst * BalanceSheet.S7_positive_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[27] == true){
				rate_thirst = rate_thirst * BalanceSheet.event28_effect;
			}
			if (GameObject.Find("Time").GetComponent<Time>().S14 == true && GameObject.Find("EventSystem").GetComponent<PublicVariables>().PopHot.gameObject.activeSelf == true){
				rate_thirst = rate_thirst * BalanceSheet.S14_negative_effect;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst = thirst - (rate_thirst * BalanceSheet.thirst_rate);
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst < 40 && thirstyhint2 == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  You are feeling very thirsty...";
				thirstyhint2 = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst < 65 && thirstyhint == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  You are feeling thirsty...";
				thirstyhint = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst > 65){
				thirstyhint = false;
				thirstyhint2 = false;
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst < 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst = 0;
		}
	}
	
	
	void EndHint(){
		//zuständig um die Spielermeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(false);
		CancelInvoke("EndHint");
	}
}