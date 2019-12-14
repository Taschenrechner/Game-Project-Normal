using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		//wenn der Spieler auf der einen Seite der Karte hinausgeht, kommt er auf der anderen Seite wieder heraus. Die Weltkarte soll einen Globus implizieren
		if (other.transform.position.x < 0){
			other.transform.position = new Vector2(76.0f, other.transform.position.y);
			GameObject.Find("Player").GetComponent<PlayerController>().target.x = GameObject.Find("Player").GetComponent<PlayerController>().target.x + 95.5f;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - 5;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - (5 * BalanceSheet.S4_positive_effect);
			}
		}
		else {
			other.transform.position = new Vector2(-12.0f, other.transform.position.y);
			GameObject.Find("Player").GetComponent<PlayerController>().target.x = GameObject.Find("Player").GetComponent<PlayerController>().target.x - 95.5f;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - 5;
			if (GameObject.Find("Time").GetComponent<Time>().S4 == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot - (5 * BalanceSheet.S4_positive_effect);
			}
		}
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
	}
	
	
	void Update(){
		//überprüft, ob sich der Spieler im Ozean befindet
		if (GameObject.Find("Player").transform.position.x < -12 || GameObject.Find("Player").transform.position.x > 76){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater = true;
		}
		else {
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater = false;
		}
	}
}
