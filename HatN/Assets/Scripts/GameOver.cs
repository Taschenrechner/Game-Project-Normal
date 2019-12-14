using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	
	void Start(){
		//Startet Hintergrundprozess, der überprüft, ob das Spiel verloren wurde
		InvokeRepeating("LostGame", 0, 0.5f);
	}
	
	
	void LostGame(){
		//Wenn die Population unter 0 sinkt, ist das Spiel verloren
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().population <= 0){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused = true;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().GameOver.gameObject.SetActive(true);
			GameObject.Find("GameOverButton").GetComponent<Button>().Select();
			string gtext;
			gtext = "You have lost the game.\n\n";
			gtext = gtext + "You have survived " + GameObject.Find("Time").GetComponent<Time>().CalcTotalDays() + " days.";
			this.GetComponent<Text>().text = gtext;
		}
	}
	
	
	public void QuitToMenu(){
		//Beenden des Spiels
		SceneManager.LoadScene(0);
	}
}
