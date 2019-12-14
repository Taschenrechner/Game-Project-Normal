using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {
	
	public static SaveLoadClass game;
	public string SAVE_FILE = "/SAVEGAME";
	public string FILE_EXTENSION = ".spik";
	
	public void Awake(){
		//Kreiert eine neue Klasse
		game = new SaveLoadClass();
	}
	
	
	public void SaveGameState(){
		//Speichern des Spiels und der Daten
		Stream stream = File.Open(Application.dataPath + SAVE_FILE + FILE_EXTENSION, FileMode.OpenOrCreate);
		BinaryFormatter bf = new BinaryFormatter();
		game.population = GameObject.Find("EventSystem").GetComponent<PublicVariables>().population;
		game.year = GameObject.Find("Time").GetComponent<Time>().GetYear();
		game.month = GameObject.Find("Time").GetComponent<Time>().GetMonth();
		game.day = GameObject.Find("Time").GetComponent<Time>().GetDay();
		game.hunger = GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger;
		game.thirst = GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst;
		game.mating = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating;
		game.monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster;
		game.hidden = GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden;
		game.inwater = GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater;
		game.playerx = GameObject.Find("Player").transform.position.x;
		game.playery = GameObject.Find("Player").transform.position.y;
		game.playerz = GameObject.Find("Player").transform.position.z;
		game.tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail;
		game.t_tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail;
		game.fur = GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur;
		game.t_fur = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fur;
		game.mouth = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth;
		game.t_mouth = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_mouth;
		game.foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot;
		game.t_foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot;
		game.preycount = GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount;
		game.t_preycount = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount;
		game.preycount10 = GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10;
		game.t_preycount10 = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10;
		game.fishcount = GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount;
		game.t_fishcount = GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount;
		game.season = GameObject.Find("EventSystem").GetComponent<PublicVariables>().season;
		game.last_location = GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location;
		game.E1cd = GameObject.Find("E1").GetComponent<Interactable>().GetCooldown();
		game.E2cd = GameObject.Find("E2").GetComponent<Interactable>().GetCooldown();
		game.E3cd = GameObject.Find("E3").GetComponent<Interactable>().GetCooldown();
		game.E4cd = GameObject.Find("E4").GetComponent<Interactable>().GetCooldown();
		game.E5cd = GameObject.Find("E5").GetComponent<Interactable>().GetCooldown();
		game.E8cd = GameObject.Find("E8").GetComponent<Interactable>().GetCooldown();
		game.E9cd = GameObject.Find("E9").GetComponent<Interactable>().GetCooldown();
		game.M1cd = GameObject.Find("M1").GetComponent<Interactable>().GetCooldown();
		game.M2cd = GameObject.Find("M2").GetComponent<Interactable>().GetCooldown();
		game.K1cd = GameObject.Find("K1").GetComponent<Interactable>().GetCooldown();
		game.K2cd = GameObject.Find("K2").GetComponent<Interactable>().GetCooldown();
		game.S1 = GameObject.Find("Time").GetComponent<Time>().GetS1();
		game.S2 = GameObject.Find("Time").GetComponent<Time>().GetS2();
		game.S3 = GameObject.Find("Time").GetComponent<Time>().GetS3();
		game.S4 = GameObject.Find("Time").GetComponent<Time>().GetS4();
		game.S5 = GameObject.Find("Time").GetComponent<Time>().GetS5();
		game.S6 = GameObject.Find("Time").GetComponent<Time>().GetS6();
		game.S7 = GameObject.Find("Time").GetComponent<Time>().GetS7();
		game.S8 = GameObject.Find("Time").GetComponent<Time>().GetS8();
		game.S9 = GameObject.Find("Time").GetComponent<Time>().GetS9();
		game.S10 = GameObject.Find("Time").GetComponent<Time>().GetS10();
		game.S11 = GameObject.Find("Time").GetComponent<Time>().GetS11();
		game.S12 = GameObject.Find("Time").GetComponent<Time>().GetS12();
		game.S13 = GameObject.Find("Time").GetComponent<Time>().GetS13();
		game.S14 = GameObject.Find("Time").GetComponent<Time>().GetS14();
		game.A1 = GameObject.Find("Time").GetComponent<Time>().GetA1();
		game.B1 = GameObject.Find("Time").GetComponent<Time>().GetB1();
		game.A2 = GameObject.Find("Time").GetComponent<Time>().GetA2();
		game.B2 = GameObject.Find("Time").GetComponent<Time>().GetB2();
		game.A3 = GameObject.Find("Time").GetComponent<Time>().GetA3();
		game.B3 = GameObject.Find("Time").GetComponent<Time>().GetB3();
		game.A4 = GameObject.Find("Time").GetComponent<Time>().GetA4();
		game.B4 = GameObject.Find("Time").GetComponent<Time>().GetB4();
		game.A5 = GameObject.Find("Time").GetComponent<Time>().GetA5();
		game.B5 = GameObject.Find("Time").GetComponent<Time>().GetB5();
		game.STextB2 = GameObject.Find("Time").GetComponent<Time>().STextB2.GetComponent<Text>().text;
		game.STextB3 = GameObject.Find("Time").GetComponent<Time>().STextB3.GetComponent<Text>().text;
		game.STextB4 = GameObject.Find("Time").GetComponent<Time>().STextB4.GetComponent<Text>().text;
		game.STextB5 = GameObject.Find("Time").GetComponent<Time>().STextB5.GetComponent<Text>().text;
		game.STextC2 = GameObject.Find("Time").GetComponent<Time>().STextC2.GetComponent<Text>().text;
		game.STextC3 = GameObject.Find("Time").GetComponent<Time>().STextC3.GetComponent<Text>().text;
		game.STextC4 = GameObject.Find("Time").GetComponent<Time>().STextC4.GetComponent<Text>().text;
		game.STextC5 = GameObject.Find("Time").GetComponent<Time>().STextC5.GetComponent<Text>().text;
		game.STextD2 = GameObject.Find("Time").GetComponent<Time>().STextD2.GetComponent<Text>().text;
		game.STextD3 = GameObject.Find("Time").GetComponent<Time>().STextD3.GetComponent<Text>().text;
		game.STextD4 = GameObject.Find("Time").GetComponent<Time>().STextD4.GetComponent<Text>().text;
		game.STextD5 = GameObject.Find("Time").GetComponent<Time>().STextD5.GetComponent<Text>().text;
		game.STextE2 = GameObject.Find("Time").GetComponent<Time>().STextE2.GetComponent<Text>().text;
		game.STextE3 = GameObject.Find("Time").GetComponent<Time>().STextE3.GetComponent<Text>().text;
		game.STextE4 = GameObject.Find("Time").GetComponent<Time>().STextE4.GetComponent<Text>().text;
		game.STextE5 = GameObject.Find("Time").GetComponent<Time>().STextE5.GetComponent<Text>().text;
		game.STextF2 = GameObject.Find("Time").GetComponent<Time>().STextF2.GetComponent<Text>().text;
		game.STextF3 = GameObject.Find("Time").GetComponent<Time>().STextF3.GetComponent<Text>().text;
		game.STextF4 = GameObject.Find("Time").GetComponent<Time>().STextF4.GetComponent<Text>().text;
		game.STextF5 = GameObject.Find("Time").GetComponent<Time>().STextF5.GetComponent<Text>().text;
		game.event1id = GameObject.Find("Time").GetComponent<Time>().GetEvent1ID();
		game.event1month = GameObject.Find("Time").GetComponent<Time>().GetEvent1m();
		game.event1day = GameObject.Find("Time").GetComponent<Time>().GetEvent1d();
		game.event2id = GameObject.Find("Time").GetComponent<Time>().GetEvent2ID();
		game.event2month = GameObject.Find("Time").GetComponent<Time>().GetEvent2m();
		game.event2day = GameObject.Find("Time").GetComponent<Time>().GetEvent2d();
		game.event3id = GameObject.Find("Time").GetComponent<Time>().GetEvent3ID();
		game.event3month = GameObject.Find("Time").GetComponent<Time>().GetEvent3m();
		game.event3day = GameObject.Find("Time").GetComponent<Time>().GetEvent3d();
		game.event4id = GameObject.Find("Time").GetComponent<Time>().GetEvent4ID();
		game.event4month = GameObject.Find("Time").GetComponent<Time>().GetEvent4m();
		game.event4day = GameObject.Find("Time").GetComponent<Time>().GetEvent4d();
		game.event5id = GameObject.Find("Time").GetComponent<Time>().GetEvent5ID();
		game.event5month = GameObject.Find("Time").GetComponent<Time>().GetEvent5m();
		game.event5day = GameObject.Find("Time").GetComponent<Time>().GetEvent5d();
		game.event6id = GameObject.Find("Time").GetComponent<Time>().GetEvent6ID();
		game.event6month = GameObject.Find("Time").GetComponent<Time>().GetEvent6m();
		game.event6day = GameObject.Find("Time").GetComponent<Time>().GetEvent6d();
		for (int i = 0; i < 34; i ++){
			game.R[i] = GameObject.Find("Time").GetComponent<Time>().R[i];
			game.Rtimer[i] = GameObject.Find("Time").GetComponent<Time>().GetRTimer(i);
		}
		bf.Serialize(stream, game);		
		stream.Close();
		print("Game saved");
	}
	
	
	public void LoadGameState(){
		//Laden des Spiels und der Daten
		if (GameObject.Find("LoadButton").GetComponent<LoadSceneOnClick>().loadgame == true){
			try {
			Stream stream = File.Open(Application.dataPath + SAVE_FILE + FILE_EXTENSION, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter();
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().population = game.population;
			GameObject.Find("Time").GetComponent<Time>().LoadYear(game.year);
			GameObject.Find("Time").GetComponent<Time>().LoadMonth(game.month);
			GameObject.Find("Time").GetComponent<Time>().LoadDay(game.day);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hunger = game.hunger;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().thirst = game.thirst;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = game.mating;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = game.monster;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden = game.hidden;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater = game.inwater;
			GameObject.Find("Player").transform.position = new Vector3(game.playerx, game.playery, game.playerz);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = game.tail;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail = game.t_tail;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = game.fur;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fur = game.t_fur;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = game.mouth;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_mouth = game.t_mouth;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = game.foot;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot = game.t_foot;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount = game.preycount;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount = game.t_preycount;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10 = game.preycount10;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10 = game.t_preycount10;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount = game.fishcount;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount = game.t_fishcount;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().season = game.season;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().last_location = game.last_location;
			GameObject.Find("E1").GetComponent<Interactable>().LoadCooldown(game.E1cd);
			GameObject.Find("E2").GetComponent<Interactable>().LoadCooldown(game.E2cd);
			GameObject.Find("E3").GetComponent<Interactable>().LoadCooldown(game.E3cd);
			GameObject.Find("E4").GetComponent<Interactable>().LoadCooldown(game.E4cd);
			GameObject.Find("E5").GetComponent<Interactable>().LoadCooldown(game.E5cd);
			GameObject.Find("E5").GetComponent<Interactable>().LoadCooldown(game.E8cd);
			GameObject.Find("E5").GetComponent<Interactable>().LoadCooldown(game.E9cd);
			GameObject.Find("M1").GetComponent<Interactable>().LoadCooldown(game.M1cd);
			GameObject.Find("M2").GetComponent<Interactable>().LoadCooldown(game.M2cd);
			GameObject.Find("K1").GetComponent<Interactable>().LoadCooldown(game.K1cd);
			GameObject.Find("K2").GetComponent<Interactable>().LoadCooldown(game.K2cd);
			GameObject.Find("Time").GetComponent<Time>().LoadSkills(game.S1, game.S2, game.S3, game.S4, game.S5, game.S6, game.S7, game.S8, game.S9, game.S10, game.S11, game.S12, game.S13, game.S14, game.A1, game.B1, game.A2, game.B2, game.A3, game.B3, game.A4, game.B4, game.A5, game.B5);
			GameObject.Find("Time").GetComponent<Time>().STextB2.GetComponent<Text>().text = game.STextB2;
			GameObject.Find("Time").GetComponent<Time>().STextB3.GetComponent<Text>().text = game.STextB3;
			GameObject.Find("Time").GetComponent<Time>().STextB4.GetComponent<Text>().text = game.STextB4;
			GameObject.Find("Time").GetComponent<Time>().STextB5.GetComponent<Text>().text = game.STextB5;
			GameObject.Find("Time").GetComponent<Time>().STextC2.GetComponent<Text>().text = game.STextC2;
			GameObject.Find("Time").GetComponent<Time>().STextC3.GetComponent<Text>().text = game.STextC3;
			GameObject.Find("Time").GetComponent<Time>().STextC4.GetComponent<Text>().text = game.STextC4;
			GameObject.Find("Time").GetComponent<Time>().STextC5.GetComponent<Text>().text = game.STextC5;
			GameObject.Find("Time").GetComponent<Time>().STextD2.GetComponent<Text>().text = game.STextD2;
			GameObject.Find("Time").GetComponent<Time>().STextD3.GetComponent<Text>().text = game.STextD3;
			GameObject.Find("Time").GetComponent<Time>().STextD4.GetComponent<Text>().text = game.STextD4;
			GameObject.Find("Time").GetComponent<Time>().STextD5.GetComponent<Text>().text = game.STextD5;
			GameObject.Find("Time").GetComponent<Time>().STextE2.GetComponent<Text>().text = game.STextE2;
			GameObject.Find("Time").GetComponent<Time>().STextE3.GetComponent<Text>().text = game.STextE3;
			GameObject.Find("Time").GetComponent<Time>().STextE4.GetComponent<Text>().text = game.STextE4;
			GameObject.Find("Time").GetComponent<Time>().STextE5.GetComponent<Text>().text = game.STextE5;
			GameObject.Find("Time").GetComponent<Time>().STextF2.GetComponent<Text>().text = game.STextF2;
			GameObject.Find("Time").GetComponent<Time>().STextF3.GetComponent<Text>().text = game.STextF3;
			GameObject.Find("Time").GetComponent<Time>().STextF4.GetComponent<Text>().text = game.STextF4;
			GameObject.Find("Time").GetComponent<Time>().STextF5.GetComponent<Text>().text = game.STextF5;
			GameObject.Find("Time").GetComponent<Time>().LoadEvents(game.event1id, game.event1month, game.event1day, game.event2id, game.event2month, game.event2day, game.event3id, game.	event3month, game.event3day, game.event4id, game.event4month, game.event4day, game.event5id, game.event5month, game.event5day, game.event6id, game.event6month, game.event6day);
			for (int i = 0; i < 34; i++){
				GameObject.Find("Time").GetComponent<Time>().LoadArrays(i, game.R[i], game.Rtimer[i]);
			}
			game = (SaveLoadClass)bf.Deserialize(stream);
			stream.Close();
			}
			catch (FileNotFoundException dirEx){
				SceneManager.LoadScene(0);
				PlayerPrefs.SetString("error", "Directory for save file invalid: " + dirEx.Message);
			}
		}
	}
}
