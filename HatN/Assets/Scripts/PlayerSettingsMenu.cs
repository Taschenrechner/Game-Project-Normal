using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingsMenu : MonoBehaviour {
	
	void Start(){
		//überprüft, ob es bereits eine PlayerPrefs-Datei gibt und setzt die Keys neu, wenn nicht. 
		if (PlayerPrefs.HasKey("master") == false || PlayerPrefs.HasKey("music") == false || PlayerPrefs.HasKey("sound") == false){
			PlayerPrefs.SetFloat("master", GameObject.Find("Canvas").GetComponent<MainMenuSound>().mastervol);
			PlayerPrefs.SetFloat("music", GameObject.Find("Canvas").GetComponent<MainMenuSound>().musicvol);
			PlayerPrefs.SetFloat("sound", GameObject.Find("Canvas").GetComponent<MainMenuSound>().soundvol);
			PlayerPrefs.Save();
			GameObject.Find("Canvas").GetComponent<MainMenuSound>().GetOldSettings();
		}
		else {
			GameObject.Find("Canvas").GetComponent<MainMenuSound>().mastervol = PlayerPrefs.GetFloat("master");
			GameObject.Find("Canvas").GetComponent<MainMenuSound>().musicvol = PlayerPrefs.GetFloat("music");
			GameObject.Find("Canvas").GetComponent<MainMenuSound>().soundvol = PlayerPrefs.GetFloat("sound");
			GameObject.Find("Canvas").GetComponent<MainMenuSound>().GetOldSettings();
		}
	}
	
	
	public void UpdatePrefs(){
		//Wenn die Audioeinstellungen verändert werden, wird dies in den PlayerPrefs gespeichert.
		PlayerPrefs.SetFloat("master", GameObject.Find("Canvas").GetComponent<MainMenuSound>().mastervol);
		PlayerPrefs.SetFloat("music", GameObject.Find("Canvas").GetComponent<MainMenuSound>().musicvol);
		PlayerPrefs.SetFloat("sound", GameObject.Find("Canvas").GetComponent<MainMenuSound>().soundvol);
		PlayerPrefs.Save();
	}
}
