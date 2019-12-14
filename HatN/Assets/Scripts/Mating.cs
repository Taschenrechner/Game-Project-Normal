using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mating : MonoBehaviour {
	
	bool matinghint = false;
	bool matinghint2 = false;
	
	void Start(){
		//sorgt dafür, dass der Paarungswert jeden Tag sinkt
		InvokeRepeating("Timer", 1, 0.5f);
	}
	
	
	void Update(){
		//sorgt dafür, dass der Paarungswert korrekt angezeigt wird. Die Farbgebung dient dazu, dem Spieler über einen eventuellen kritischen Zustand zu informieren.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating < 40){
			this.GetComponent<Text>().text = ":<color=red>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating + "</color>";
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating < 65){
			this.GetComponent<Text>().text = ":<color=orange>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating + "</color>";
		}
		else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating < 75){
			this.GetComponent<Text>().text = ":<color=yellow>" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating + "</color>";
		}
		else {
			this.GetComponent<Text>().text = ":" + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating;
		}
	}
	
	
	void Timer(){
		//berechnet den Paarungswert jeden Tag neu. Der Wert sinkt mehr, je höher er ist. Auch eventuelle Einflüsse durch das Zufallsereignisse oder Fertigkeiten werden berücksichtigt.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating - (0.1f * BalanceSheet.mating_rate);
			if (GameObject.Find("Time").GetComponent<Time>().R[11] == true && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating - ((0.1f * BalanceSheet.event12_effect) * BalanceSheet.mating_rate);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating < 40 && matinghint2 == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  You are feeling very lonely...";
				matinghint2 = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating < 65 && matinghint == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
				GameObject.Find("HintPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
				GameObject.Find("HintPanel").GetComponent<AudioSource>().Play(0);
				GameObject.Find("PlayerHints").GetComponent<Text>().text = "  You are feeling lonely...";
				matinghint = true;
				InvokeRepeating("EndHint", 3, 0.1f);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating > 65){
				matinghint = false;
				matinghint2 = false;
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating < 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = 0;
		}
	}
	
	
	void EndHint(){
		//zuständig um die Spielermeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(false);
		CancelInvoke("EndHint");
	}
}