using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeText : MonoBehaviour {

	public void UpdateText(){
		//Generieren des Textes und der korrekten Werte für die Attributsübersicht im Pausemenü
		double t;
		double f;
		double m;
		double b;
		double temp;
		double percent;
		t = (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail;
		f = (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur;
		m = (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth;
		b = (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot;
		string fulltext;
		fulltext = "<size=22><b>Tail: </b>" + t + "</size>\n\n";
		if (t >= 65 && GameObject.Find("Time").GetComponent<Time>().R[28] == true){
			fulltext = fulltext + "<color=green>Can climb the towers (needs at least a value of +" + (BalanceSheet.event29_effect + 50) + ")</color>\n";
		}
		else if (t >= 50 && GameObject.Find("Time").GetComponent<Time>().R[28] == false){
			fulltext = fulltext + "<color=green>Can climb the towers (needs at least a value of +50)</color>\n";
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == false){
				fulltext = fulltext + "<color=red>Can not climb the towers (needs at least a value of +50)</color>\n";
			}
			else {
				fulltext = fulltext + "<color=red>Can not climb the towers (needs at least a value of +" + (BalanceSheet.event29_effect + 50) + ")</color>\n";
			}
		}
		if (t >= 25){
			fulltext = fulltext + "<color=green>Can interact with the human group in the forest town (needs at least a value of +25)</color>\n";
		}
		else {
			fulltext = fulltext + "<color=red>Can not interact with the human group in the forest town (needs at least a value of +25)</color>\n";
		}
		if (t >= 0){
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == false){
				fulltext = fulltext + "<color=green>Can climb on trees to hide or mate (needs at least a value of +0)</color>\n";
			}
			else {
				if (t >= 15){
					fulltext = fulltext + "<color=green>Can climb on trees to hide or mate (needs at least a value of +" + BalanceSheet.event29_effect + ")</color>\n";
				}
				else {
					fulltext = fulltext + "<color=red>Can not climb on trees to hide or mate (needs at least a value of +" + BalanceSheet.event29_effect + ")</color>\n";
				}
			}
			if (t > 0){
				t = 100 + t;
				temp = t;
				percent = 1;
				if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
					temp = temp * BalanceSheet.S1_positive_effect;
					percent = percent * BalanceSheet.S1_positive_effect;
				}
				fulltext = fulltext + "<color=green>Effect from interaction with humans = " + temp + "% (+" + percent + "% per point)</color>\n";
				t = t - 100;
				t = 1 + 0.25f * t / 100;
				temp = t * 100;
				percent = 0.25;
				fulltext = fulltext + "<color=red>Food demand = " + temp + "% (+" + percent + "% per point)</color>\n";
			}
			else {
				t = 100 + t;
				temp = t;
				percent = 1;
				if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
					temp = temp * BalanceSheet.S1_positive_effect;
					percent = percent * BalanceSheet.S1_positive_effect;
				}
				fulltext = fulltext + "Effect from interaction with humans = " + temp + "% (+" + percent + "% per point)\n";
				t = t - 100;
				t = 1 + 0.25f * t / 100;
				temp = t * 100;
				percent = 0.25;
				fulltext = fulltext + "Food demand = " + temp + "% (+" + percent + "% per point)\n";
			}
		}
		else {
			if (GameObject.Find("Time").GetComponent<Time>().R[28] == false){
				fulltext = fulltext + "<color=red>Can not climb on trees to hide or mate (needs at least a value of +0)</color>\n";
			}
			else {
				fulltext = fulltext + "<color=red>Can not climb on trees to hide or mate (needs at least a value of +" + BalanceSheet.event29_effect + ")</color>\n";
			}
			t = 100 + t;
			temp = t;
			percent = 1;
			if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
				temp = temp * BalanceSheet.S1_positive_effect;
				percent = percent * BalanceSheet.S1_positive_effect;
			}
			fulltext = fulltext + "<color=red>Effect from interaction with humans = " + temp + "% (+" + percent + "% per point)</color>\n";
			t = t - 100;
			t = 1 + 0.25f * t / 100;
			temp = t * 100;
			percent = 0.25;
			fulltext = fulltext + "<color=green>Food demand = " + temp + "% (+" + percent + "% per point)</color>\n";
		}
		fulltext = fulltext + "\n";
		fulltext = fulltext + "<size=22><b>Fur: </b>" + f + "</size>\n\n";
		if (f == 0){
			if (GameObject.Find("Time").GetComponent<Time>().S14 == false){
				fulltext = fulltext + "Cold resistance = 1 (+0.02 per point)\n";
				fulltext = fulltext + "Heat resistance = 1 (-0.02 per point)\n";
			}
			else {
				fulltext = fulltext + "Cold resistance = " + (1 + BalanceSheet.S14_positive_effect) + " (+0.02 per point)\n";
				fulltext = fulltext + "Heat resistance = " + (1 + BalanceSheet.S14_positive_effect) + " (-0.02 per point)\n";
			}
		}
		else if (f > 0){
			f = 1 + f / 50;
			if (GameObject.Find("Time").GetComponent<Time>().S14 == true){
				f = f + BalanceSheet.S14_positive_effect;
			}
			fulltext = fulltext + "<color=green>Cold resistance = " + f + " (+0.02 per point)</color>\n";
			f = 1 - (f - 1);
			if (GameObject.Find("Time").GetComponent<Time>().S14 == true){
				f = f + BalanceSheet.S14_positive_effect;
			}
			fulltext = fulltext + "<color=red>Heat resistance = " + f + " (-0.02 per point)</color>\n";
		}
		else {
			f = 1 + f / 50;
			if (GameObject.Find("Time").GetComponent<Time>().S14 == true){
				f = f + BalanceSheet.S14_positive_effect;
			}
			fulltext = fulltext + "<color=red>Cold resistance = " + f + " (+0.02 per point)</color>\n";
			f = 1 - (f - 1);
			if (GameObject.Find("Time").GetComponent<Time>().S14 == true){
				f = f + BalanceSheet.S14_positive_effect;
			}
			fulltext = fulltext + "<color=green>Heat resistance = " + f + " (-0.02 per point)</color>\n";
		}
		fulltext = fulltext + "\n";
		fulltext = fulltext + "<size=22><b>Mouth: </b>" + m + "</size>\n\n";
		if (m == 0){
			fulltext = fulltext + "Plant food gain = 100% (+1% per point)\n";
			if (GameObject.Find("Time").GetComponent<Time>().S3 == false){
				fulltext = fulltext + "Meat food gain = 100% (-1% per point)\n";
			}
			else {
				fulltext = fulltext + "Meat food gain = " + (100 + (BalanceSheet.S3_positive_effect * 100)) + "% (-1% per point)\n";
			}
		}
		else if (m > 0){
			m = 100 + m;
			fulltext = fulltext + "<color=green>Plant food gain = " + m + "% (+1% per point)</color>\n";
			m = 100 - (m - 100);
			if (GameObject.Find("Time").GetComponent<Time>().S3 == false){
				fulltext = fulltext + "<color=red>Meat food gain = " + m + "% (-1% per point)</color>\n";
			}
			else {
				fulltext = fulltext + "<color=red>Meat food gain = " + (m + (BalanceSheet.S3_positive_effect * 100)) + "% (-1% per point)</color>\n";
			}
		}
		else {
			m = 100 + m;
			fulltext = fulltext + "<color=red>Plant food gain = " + m + "% (+1% per point)</color>\n";
			m = 100 - (m - 100);
			if (GameObject.Find("Time").GetComponent<Time>().S3 == false){
				fulltext = fulltext + "<color=green>Meat food gain = " + m + "% (-1% per point)</color>\n";
			}
			else {
				fulltext = fulltext + "<color=green>Meat food gain = " + (m + (BalanceSheet.S3_positive_effect * 100)) + "% (-1% per point)</color>\n";
			}
		}
		fulltext = fulltext + "\n";
		fulltext = fulltext + "<size=22><b>Feet: </b>" + b + "</size>\n\n";
		if (b == 0){
			if (GameObject.Find("Time").GetComponent<Time>().S1 == false){
				fulltext = fulltext + "Fish catch probability: 20% (-0.1% per point)\n";
				fulltext = fulltext + "Prey catch probability: 30% (+0.2% per point)\n";
			}
			else {
				fulltext = fulltext + "Fish catch probability: " + (20 * BalanceSheet.S1_negative_effect) + "% (-" + (0.1f * BalanceSheet.S1_negative_effect) + "% per point)\n";
				fulltext = fulltext + "Prey catch probability: " + (30 * BalanceSheet.S1_negative_effect) + "% (+" + (0.2f * BalanceSheet.S1_negative_effect) + "% per point)\n";
			}
			if (GameObject.Find("Time").GetComponent<Time>().S6 == false){
				if (GameObject.Find("Time").GetComponent<Time>().R[24] == false){
					fulltext = fulltext + "Movement speed: 100% (+0.05% per point)\n";
				}
				else {
					fulltext = fulltext + "Movement speed: " + (100 * BalanceSheet.event25_effect) + "% (+" + (0.05f * BalanceSheet.event25_effect) + "% per point)\n";
				}
			}
			else {
				if (GameObject.Find("Time").GetComponent<Time>().R[24] == false){
					fulltext = fulltext + "Movement speed: " + (100 * BalanceSheet.S6_negative_effect) + "% (+" + (0.05f * BalanceSheet.S6_negative_effect) + "% per point)\n";
				}
				else {
					fulltext = fulltext + "Movement speed: " + (100 * BalanceSheet.S6_negative_effect * BalanceSheet.event25_effect) + "% (+" + (0.05f * BalanceSheet.S6_negative_effect * BalanceSheet.event25_effect) + "% per point)\n";
				}
			}
			fulltext = fulltext + "Swimming speed: 30% (-0.1% per point)\n";
			fulltext = fulltext + "Swimming food and drink consumption: 350% (-2% per point)";
		}
		else if (b > 0){
			double b1;
			b1 = 20 - 0.1 * (float) b;
			temp = b1;
			percent = 0.1;
			if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
				temp = temp * BalanceSheet.S1_negative_effect;
				percent = percent * BalanceSheet.S1_negative_effect;
			}
			fulltext = fulltext + "<color=red>Fish catch probability: " + temp + "% (-" + percent + "% per point)</color>\n";
			b1 = 30 + 0.2 * (float) b;
			temp = b1;
			percent = 0.2;
			if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
				temp = temp * BalanceSheet.S1_negative_effect;
				percent = percent * BalanceSheet.S1_negative_effect;
			}
			fulltext = fulltext + "<color=green>Prey catch probability: " + temp + "% (+" + percent + "% per point)</color>\n";
			b1 = 100 + 0.05 * (float) b;
			temp = b1;
			percent = 0.05;
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				temp = temp * (int) (BalanceSheet.S6_negative_effect * 100);
				temp = temp / 100;
				percent = percent * (int) (BalanceSheet.S6_negative_effect * 100);
				percent = percent / 100;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[24] == true){
				temp = temp * (int) (BalanceSheet.event25_effect * 100);
				temp = temp / 100;
				percent = percent * (int) (BalanceSheet.event25_effect * 100);
				percent = percent / 100;
			}
			fulltext = fulltext + "<color=green>Movement speed: " + temp + "% (+" + percent + "% per point)</color>\n";
			b1 = 30 - 0.1 * (float) b;
			fulltext = fulltext + "<color=red>Swimming speed: " + b1 + "% (-0.1% per point)</color>\n";
			b1 = 350 + 2 * (float) b;
			fulltext = fulltext + "<color=red>Swimming food and drink consumption: " + b1 + "% (+2% per point)</color>";
		}
		else {
			double b1;
			b1 = 20 - 0.1 * (float) b;
			temp = b1;
			percent = 0.1;
			if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
				temp = temp * BalanceSheet.S1_negative_effect;
				percent = percent * BalanceSheet.S1_negative_effect;
			}
			fulltext = fulltext + "<color=green>Fish catch probability: " + temp + "% (-" + percent + "% per point)</color>\n";
			b1 = 30 + 0.2 * (float) b;
			temp = b1;
			percent = 0.2;
			if (GameObject.Find("Time").GetComponent<Time>().S1 == true){
				temp = temp * BalanceSheet.S1_negative_effect;
				percent = percent * BalanceSheet.S1_negative_effect;
			}
			fulltext = fulltext + "<color=red>Prey catch probability: " + temp + "% (+" + percent + "% per point)</color>\n";
			b1 = 100 + 0.05 * (float) b;
			temp = b1;
			percent = 0.05;
			if (GameObject.Find("Time").GetComponent<Time>().S6 == true){
				temp = temp * (int) (BalanceSheet.S6_negative_effect * 100);
				temp = temp / 100;
				percent = percent * (int) (BalanceSheet.S6_negative_effect * 100);
				percent = percent / 100;
			}
			if (GameObject.Find("Time").GetComponent<Time>().R[24] == true){
				temp = temp * (int) (BalanceSheet.event25_effect * 100);
				temp = temp / 100;
				percent = percent * (int) (BalanceSheet.event25_effect * 100);
				percent = percent / 100;
			}
			fulltext = fulltext + "<color=red>Movement speed: " + temp + "% (+" + percent + "% per point)</color>\n";
			b1 = 30 - 0.1 * (float) b;
			fulltext = fulltext + "<color=green>Swimming speed: " + b1 + "% (-0.1% per point)</color>\n";
			b1 = 350 + 2 * (float) b;
			fulltext = fulltext + "<color=green>Swimming food and drink consumption: " + b1 + "% (+2% per point)</color>";
		}
		this.GetComponent<Text>().text = fulltext;
	}
}
