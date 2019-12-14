using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {
	
	public void Quit(){
		//Vollständiges Beenden der Anwendung
		GameObject.Find("MainMenuPanel").GetComponent<AudioSource>().Play(0);
		PlayerPrefs.DeleteKey("error");
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
