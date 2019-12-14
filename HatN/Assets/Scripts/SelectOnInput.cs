using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
	
	public EventSystem eventSystem;
	public GameObject selectedObject;
	private bool buttonSelected;
	
	void Update(){
		//Steuerung des Hauptmenüs
		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false){
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
	}
	
	
	private void OnDisable(){
		//Wenn ein Button gesperrt ist
		buttonSelected = false;
	}
	
	
	public void Returnfromhelp(){
		//Sorgt dafür, dass der Hilfebutton vorselektiert wird, wenn vom Hilfemenü zurückgekehrt wird
		GameObject.Find("MainMenuPanel").GetComponent<AudioSource>().Play(0);
		selectedObject = GameObject.Find("HelpButton");
		buttonSelected = true;
	}
	
	
	public void Returnfromaudio(){
		//Sorgt dafür, dass der Audiobutton vorselektiert wird, wenn vom Audiomenü zurückgekehrt wird
		GameObject.Find("MainMenuPanel").GetComponent<AudioSource>().Play(0);
		selectedObject = GameObject.Find("AudioButton");
		buttonSelected = true;
	}
}
