using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	
	public bool loadgame = false;
	
	public void LoadByIndex(int sceneIndex){
		//Starten eines neuen Spiels/Szenenwechsel
		PlayerPrefs.DeleteKey("error");
		GameObject.Find("MainMenuPanel").GetComponent<AudioSource>().Play(0);
		SceneManager.LoadScene(sceneIndex);
		DontDestroyOnLoad(GameObject.Find("Canvas").gameObject);
	}
	
	
	public void GameByIndex(int sceneIndex){
		//Laden eines Spielstandes/Szenenwechsel
		PlayerPrefs.DeleteKey("error");
		GameObject.Find("MainMenuPanel").GetComponent<AudioSource>().Play(0);
		loadgame = true;
		SceneManager.LoadScene(sceneIndex);
		DontDestroyOnLoad(GameObject.Find("Canvas").gameObject);
	}
	
	
	void OnEnable(){
		
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	
	void OnDisable(){
		
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	
	
	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		//Wird ausgeführt, sobald die neue Szene geladen wurde. Notwendig, um den Spielstand und die PlayerPrefs weiterzugeben. Danach wird dieses Objekt zerstört.
		if (SceneManager.GetActiveScene().buildIndex == 1){
			GameObject.Find("EventSystem").GetComponent<SaveGame>().LoadGameState();
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mastervol = GameObject.Find("Canvas").GetComponent<MainMenuSound>().mastervol;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().musicvol = GameObject.Find("Canvas").GetComponent<MainMenuSound>().musicvol;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().soundvol = GameObject.Find("Canvas").GetComponent<MainMenuSound>().soundvol;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().audiovol = GameObject.Find("Canvas").GetComponent<MainMenuSound>().mastervol * GameObject.Find("Canvas").GetComponent<MainMenuSound>().musicvol;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol = GameObject.Find("Canvas").GetComponent<MainMenuSound>().mastervol * GameObject.Find("Canvas").GetComponent<MainMenuSound>().soundvol;
			Destroy(GameObject.Find("Canvas").gameObject);
		}
	}
}
