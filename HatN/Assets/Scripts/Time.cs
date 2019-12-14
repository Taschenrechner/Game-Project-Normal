using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour {
	
	int day = 1;
	int month = 3;
	int year = 1;
	string seed;
	System.Random prng;
	public bool S1 = false;
	public bool S2 = false;
	public bool S3 = false;
	public bool S4 = false;
	public bool S5 = false;
	public bool S6 = false;
	public bool S7 = false;
	public bool S8 = false;
	public bool S9 = false;
	public bool S10 = false;
	public bool S11 = false;
	public bool S12 = false;
	public bool S13 = false;
	public bool S14 = false;
	int A1;
	int B1;
	int A2;
	int B2;
	int A3;
	int B3;
	int A4;
	int B4;
	int A5;
	int B5;
	public bool[] R = new bool[34];
	int[] Rtimer = new int[34];
	public string[] Rtext = new string[34];
	public string[] Rtextshort = new string[34];
	bool prey_second = false;
	public int event1month;
	public int event1day;
	public int event1id;
	public int event2month;
	public int event2day;
	public int event2id;
	public int event3month;
	public int event3day;
	public int event3id;
	public int event4month;
	public int event4day;
	public int event4id;
	public int event5month;
	public int event5day;
	public int event5id;
	public int event6month;
	public int event6day;
	public int event6id;
	string posS1;
	string negS1;
	string posS2;
	string negS2;
	string posS3;
	string negS3;
	string posS4;
	string negS4;
	string posS5;
	string negS5;
	string posS6;
	string negS6;
	string posS7;
	string negS7;
	string posS8;
	string negS8;
	string posS9;
	string negS9;
	string posS10;
	string negS10;
	string posS11;
	string negS11;
	string posS12;
	string negS12;
	string posS13;
	string negS13;
	string posS14;
	string negS14;
	public GameObject STextB2;
	public GameObject STextB3;
	public GameObject STextB4;
	public GameObject STextB5;
	public GameObject STextC2;
	public GameObject STextC3;
	public GameObject STextC4;
	public GameObject STextC5;
	public GameObject STextD2;
	public GameObject STextD3;
	public GameObject STextD4;
	public GameObject STextD5;
	public GameObject STextE2;
	public GameObject STextE3;
	public GameObject STextE4;
	public GameObject STextE5;
	public GameObject STextF2;
	public GameObject STextF3;
	public GameObject STextF4;
	public GameObject STextF5;
	
	void Start(){
		//Initialisieren der Variablen, insbesondere des Textes für die Skills und der Zufallsereignisse
		seed = "" + System.DateTime.Now;
		prng = new System.Random(seed.GetHashCode());
		posS1 = "<color=green>Interactions with humans reduce the monster-o-meter " + ((BalanceSheet.S1_positive_effect * 100) - 100) + "% more</color>";
		negS1 = "<color=red>Probability for successfully catching fish or prey reduced by " + (100 - (BalanceSheet.S1_negative_effect * 100)) + "%</color>";
		posS2 = "<color=green>Probability for being caught while stealing food from the towers reduced by " + (BalanceSheet.S2_positive_effect * 100) + "%</color>";
		negS2 = "<color=red>Socializing time increased by " + (BalanceSheet.S2_negative_effect * 100 - 100) + "%</color>";
		posS3 = "<color=green>Meat food gain increased by + " + (BalanceSheet.S3_positive_effect * 100) + "%</color>";
		negS3 = "<color=red>Monster-o-meter decreases " + (100 - (BalanceSheet.S3_negative_effect * 100)) + "% slower</color>";
		posS4 = "<color=green>Attribute traits are gained " + (BalanceSheet.S4_positive_effect * 100) + "% faster</color>";
		negS4 = "<color=red>Maximum/Minimum of the attributes is now at " + BalanceSheet.S4_negative_effect + "/-" + BalanceSheet.S4_negative_effect + "</color>";
		posS5 = "<color=green>The ice cave cant be destroyed (will be rebuilt if already destroyed)</color>";
		negS5 = "<color=red>Population maximum is now at " + BalanceSheet.S5_negative_effect + "</color>";
		posS6 = "<color=green>Interaction times reduced by " + (100 - (BalanceSheet.S6_positive_effect * 100)) + "%</color>";
		negS6 = "<color=red>Movement speed reduced by " + (100 - (BalanceSheet.S6_negative_effect * 100)) + "%</color>";
		posS7 = "<color=green>You get thirsty " + (BalanceSheet.S7_positive_effect * 100) + "% slower</color>";
		negS7 = "<color=red>You get hungry " + ((BalanceSheet.S7_negative_effect * 100) - 100) + "% faster</color>";
		posS8 = "<color=green>Socializing can happen at the same location unlimited times in a row</color>";
		negS8 = "<color=red>Hiding reduces monster-o-meter only " + (BalanceSheet.S8_negative_effect * 50) + "% faster instead of 50% faster</color>";
		posS9 = "<color=green>Tomato bushes no longer count as plant food</color>";
		negS9 = "<color=red>Tomato bushes no longer count as plant food</color>";
		posS10 = "<color=green>After socializing, the penalties from the monster-o-meter are reduced by " + (100 - (BalanceSheet.S10_positive_effect * 100)) + "% for 90 days</color>";
		negS10 = "<color=red>After socializing, you get hungry " + ((BalanceSheet.S10_negative_effect * 100) - 100) + "% faster for 90 days</color>";
		posS11 = "<color=green>The duration of random events is decreased by " + (100 - (BalanceSheet.S11_positive_effect * 100)) + "%</color>";
		negS11 = "<color=red>Gain " + BalanceSheet.S11_negative_effect + " points for the monster-o-meter and increase social needs by " + BalanceSheet.S11_negative_effect2 + " when a random event happens</color>";
		posS12 = "<color=green>Population growth +" + (BalanceSheet.S12_positive_effect * 100) + "% (only if positive growth)</color>";
		negS12 = "<color=red>The monster-o-meter wont decrease while in a city (even if hiding)</color>";
		posS13 = "<color=green>Eating plants or tomatoes will increase population by " + BalanceSheet.S13_positive_effect + " each time</color>";
		negS13 = "<color=red>Population decline +" + (BalanceSheet.S13_negative_effect * 100) + "% (only if negative growth)</color>";
		posS14 = "<color=green>Cold and heat resistence increases by + " + BalanceSheet.S14_positive_effect + "</color>";
		negS14 = "<color=red>Get thirsty " + ((BalanceSheet.S14_negative_effect * 100) - 100) + "% faster if sweating and get hungry " + ((BalanceSheet.S14_negative_effect * 100) - 100) + "% faster if freezing</color>";
		Rtext[0] = "Dirty Water\nDrinking from the water in the desert city reduces population by " + BalanceSheet.event1_effect + " each time";
		Rtext[1] = "Valuable Crop\nDrinking at the garden sprinkler increases the monster-o-meter " + BalanceSheet.event2_effect + " times as much";
		Rtext[2] = "Private Garden\nYou cannot access the plants south of the human garden anymore";
		Rtext[3] = "Erosion\nThe cave collapses";
		Rtext[4] = "Herbalist\nPlants need " + BalanceSheet.event5_effect + " times as much to respawn";
		Rtext[5] = "Woodcutter\nThe tree near the lake is cut down and cannot be interacted with anymore";
		Rtext[6] = "Drones\nThe probability of being caught while attempting to steal food from the towers is increased by +" + BalanceSheet.event7_effect + "%";
		Rtext[7] = "Tourism\nThe lake area is converted into a tourism area. Catching fish is not possible anymore and drinking water will increase the monster-o-meter";
		Rtext[8] = "Climate Change\nPopulation loss from temperature is increased by " + ((BalanceSheet.event9_effect * 100) - 100) + "%";
		Rtext[9] = "Environmental Pollution\nPopulation is reduced by " + BalanceSheet.event10_effect + " every day";
		Rtext[10] = "Small Branches\nSocializing on trees takes " + BalanceSheet.event11_effect + " times as long";
		Rtext[11] = "Lonelyness\nSocial needs increase " + (BalanceSheet.event12_effect + 1) + " times as fast while hiding";
		Rtext[12] = "Distrust\nThe Cooldown timer for interactions with humans is frozen";
		Rtext[13] = "Foul Tomatoes\nNo food gain from tomato bushes";
		Rtext[14] = "New Animal Law\nThe effects from the monster-o-meter are increased by " + ((BalanceSheet.event15_effect * 100) - 100) + "%";
		Rtext[15] = "Drought\nDrinking in the desert city increases the monster-o-meter " + BalanceSheet.event16_effect + " times as much";
		Rtext[16] = "Protecting Dog\nHiding in the snow garden decreases population by " + BalanceSheet.event17_effect + " per second\nPairing at this location takes " + BalanceSheet.event17_effect2 + " times as long";
		Rtext[17] = "Great Storm\nThe big tree takes severe damage and cannot be interacted with";
		Rtext[18] = "Holiday Time\nCannot interact with the human group at the carriage";
		Rtext[19] = "Bait\nThere is a " + BalanceSheet.event20_effect + "% chance that no food will be found when trying to steal from the towers in the snow town";
		Rtext[20] = "Mating Needs\nThe social needs maximum is set to " + BalanceSheet.event21_effect + ". Socializing happens twice as fast";
		Rtext[21] = "Split Opinion\nThere is a " + BalanceSheet.event22_effect + "% chance that interactions with humans will increase the monster-o-meter instead of decreasing it";
		Rtext[22] = "Pesticide\nPrey animals will recover at 50% speed";
		Rtext[23] = "Calmness\nInteractions take " + BalanceSheet.event24_effect + " second longer";
		Rtext[24] = "Fatigue\nMovement speed reduced by " + (100 - (BalanceSheet.event25_effect * 100)) + "%";
		Rtext[25] = "Maladjusted\nAttributes will degenerate " + ((BalanceSheet.event26_effect * 100) - 100) + "% faster";
		Rtext[26] = "Unsaturated\nYou get hungry " + ((BalanceSheet.event27_effect * 100) - 100) + "% faster";
		Rtext[27] = "Dehydrated\nYou get thirsty " + ((BalanceSheet.event28_effect * 100) - 100) + "% faster";
		Rtext[28] = "Clumsy\nNeeds at least a value of + " + BalanceSheet.event29_effect + " for the tail for climbing trees and a value of + " + (BalanceSheet.event29_effect + 50) + " for climbing the towers";
		Rtext[29] = "Water Shortage\nThe garden sprinkler reduces thirst only " + BalanceSheet.event30_effect + " times as much";
		Rtext[30] = "Extreme Weather\nCold areas are even colder and hot areas are even hotter";
		Rtext[31] = "Misfortune\nThere will be 2 additional unlucky events next year";
		Rtext[32] = "Ignorance\nThe population size wont be displayed";
		Rtext[33] = "False Reports\nThe monster-o-meter rises by " + BalanceSheet.event34_effect + " points";
		Rtextshort[0] = "Dirty Water";
		Rtextshort[1] = "Valuable Crop";
		Rtextshort[2] = "Private Garden";
		Rtextshort[3] = "Erosion";
		Rtextshort[4] = "Herbalist";
		Rtextshort[5] = "Woodcutter";
		Rtextshort[6] = "Drones";
		Rtextshort[7] = "Tourism";
		Rtextshort[8] = "Climate Change";
		Rtextshort[9] = "Environmental Pollution";
		Rtextshort[10] = "Small Branches";
		Rtextshort[11] = "Lonelyness";
		Rtextshort[12] = "Distrust";
		Rtextshort[13] = "Foul Tomatoes";
		Rtextshort[14] = "New Animal Law";
		Rtextshort[15] = "Drought";
		Rtextshort[16] = "Protecting Dog";
		Rtextshort[17] = "Great Storm";
		Rtextshort[18] = "Holiday Time";
		Rtextshort[19] = "Bait";
		Rtextshort[20] = "Mating Needs";
		Rtextshort[21] = "Split Opinion";
		Rtextshort[22] = "Pesticide";
		Rtextshort[23] = "Calmness";
		Rtextshort[24] = "Fatigue";
		Rtextshort[25] = "Maladjusted";
		Rtextshort[26] = "Unsaturated";
		Rtextshort[27] = "Dehydrated";
		Rtextshort[28] = "Clumsy";
		Rtextshort[29] = "Water Shortage";
		Rtextshort[30] = "Extreme Weather";
		Rtextshort[31] = "Misfortune";
		Rtextshort[32] = "Ignorance";
		Rtextshort[33] = "False Reports";
		if (day == 1 && month == 3 && year == 1){
			DefineSkills();
			DefineRandomEvents();
		}
		InvokeRepeating("Timer", 1, 0.5f);
	}
	
	
	void Update(){
		//Sorgt dafür, dass die Spielzeit korrekt und ohne Verzögerung angezeigt wird
		string month_s = "";
		string day_s = "";
		switch(month) {
			case 1: month_s = "January"; break;
			case 2: month_s = "February"; break;
			case 3: month_s = "March"; break;
			case 4: month_s = "April"; break;
			case 5: month_s = "May"; break;
			case 6: month_s = "June"; break;
			case 7: month_s = "July"; break;
			case 8: month_s = "August"; break;
			case 9: month_s = "September"; break;
			case 10: month_s = "October"; break;
			case 11: month_s = "November"; break;
			case 12: month_s = "December"; break;
		}
		switch(day) {
			case 1: day_s = "st"; break;
			case 2: day_s = "nd"; break;
			case 3: day_s = "rd"; break;
			case 4: day_s = "th"; break;
			case 5: day_s = "th"; break;
			case 6: day_s = "th"; break;
			case 7: day_s = "th"; break;
			case 8: day_s = "th"; break;
			case 9: day_s = "th"; break;
			case 10: day_s = "th"; break;
			case 11: day_s = "th"; break;
			case 12: day_s = "th"; break;
			case 13: day_s = "th"; break;
			case 14: day_s = "th"; break;
			case 15: day_s = "th"; break;
			case 16: day_s = "th"; break;
			case 17: day_s = "th"; break;
			case 18: day_s = "th"; break;
			case 19: day_s = "th"; break;
			case 20: day_s = "th"; break;
			case 21: day_s = "st"; break;
			case 22: day_s = "nd"; break;
			case 23: day_s = "rd"; break;
			case 24: day_s = "th"; break;
			case 25: day_s = "th"; break;
			case 26: day_s = "th"; break;
			case 27: day_s = "th"; break;
			case 28: day_s = "th"; break;
			case 29: day_s = "th"; break;
			case 30: day_s = "th"; break;
			case 31: day_s = "st"; break;
		}
		this.GetComponent<Text>().text = month_s + ", " + day + day_s + ", Year " + year + "  ";
	}
	
	
	void Timer(){
		//sorgt dafür, dass eine halbe Sekunde gleich einem Tag entspricht. Berechnet dazu passend auch den Verfall der Attribute. Berechnet auch, wie lange Zufallsereignisse noch aktiv sind und gibt eine Meldung aus, wenn diese abgelaufen sind. Teilt außerdem die Jahreszeiten ein.
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			if ((day == 31) || (day == 28 && month == 2) || (day == 30 && month == 4) || (day == 30 && month == 6) || (day == 30 && month == 9) || (day == 30 && month == 11)){
				if (month == 12){
					day = 1;
					month = 1;
					year++;
					DefineRandomEvents();
				}
				else {
					day = 1;
					month++;
					if (month == 3){
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().season = 1;
						if (year < 6){
							RevealNewSkills();
						}
						if (year < 7){
							SelectNewSkill("null");
						}
					}
					else if (month == 6){
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().season = 2;
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
						GameObject.Find("PlayerHints").GetComponent<Text>().text = "  It is getting hotter...";
						InvokeRepeating("EndHint", 3, 0.1f);
					}
					else if (month == 9){
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().season = 3;
					}
					else if (month == 12){
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().season = 4;
						GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(true);
						GameObject.Find("PlayerHints").GetComponent<Text>().text = "  It is getting colder...";
						InvokeRepeating("EndHint", 3, 0.1f);
					}
				}
			}
			else {
				day++;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_mouth >= 30){
				if (R[25] == false){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth * 0.997f;
				}
				else {
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth * (1 - (0.003 * BalanceSheet.event26_effect));
				}
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot >= 30){
				if (R[25] == false){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot * 0.997f;
				}
				else {
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot = GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot * (1 - (0.003 * BalanceSheet.event26_effect));
				}
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail >= 30){
				if (R[25] == false){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail * 0.997f;
				}
				else {
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail = GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail * (1 - (0.003 * BalanceSheet.event26_effect));
				}
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fur >= 30){
				if (R[25] == false){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur * 0.997f;
				}
				else {
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur = GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur * (1 - (0.003 * BalanceSheet.event26_effect));
				}
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_mouth++;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_foot++;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_tail++;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fur++;
			if (R[22] == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount++;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10++;
			}
			else {
				if (prey_second == true){
					prey_second = false;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount++;
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10++;
				}
				else {
					prey_second = true;
				}
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount >= 150 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount < 3){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount++;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount = 0;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10 >= 150 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10 < 3){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().preycount10++;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_preycount10 = 0;
			}
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount++;
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount >= 100 && GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount < 5){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().fishcount++;
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().t_fishcount = 0;
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 65 && R[28] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableK1.gameObject.SetActive(true);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableK2.gameObject.SetActive(true);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 50 && R[28] == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableK1.gameObject.SetActive(true);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableK2.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableK1.gameObject.SetActive(false);
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableK2.gameObject.SetActive(false);
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 25){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableM1.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableM1.gameObject.SetActive(false);
			}
			if (R[17] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV2P3.gameObject.SetActive(true);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 15 && R[28] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV2P3.gameObject.SetActive(true);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 0 && R[28] == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV2P3.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV2P3.gameObject.SetActive(false);
			}
			if (R[5] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableP5.gameObject.SetActive(true);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 15 && R[28] == true){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableP5.gameObject.SetActive(true);
			}
			else if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail < 0 && R[28] == false){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableP5.gameObject.SetActive(true);
			}
			else {
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableP5.gameObject.SetActive(false);
			}
			GameObject.Find("TextTail").GetComponent<Text>().text = "Tail: " + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().tail;
			GameObject.Find("TextFur").GetComponent<Text>().text = "Fur: " + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().fur;
			GameObject.Find("TextMouth").GetComponent<Text>().text = "Mouth: " + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().mouth;
			GameObject.Find("TextFoot").GetComponent<Text>().text = "Feet: " + (int) GameObject.Find("EventSystem").GetComponent<PublicVariables>().foot;
			if (month == event1month && day == event1day){
				if (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
					CallRandomEvent(event1id);
				}
				else {
					if (event1day < 30){
						if (event1day == 28 && event1month == 2){
							event1day = 1;
							event1month = 3;
						}
						else {
							event1day++;
						}
					}
					else {
						if (event1month < 12){
							event1month++;
							event1day = 1;
						}
						else {
							event1month = 1;
							event1day = 1;
						}
					}
				}
			}
			else if (month == event2month && day == event2day){
				if (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
					CallRandomEvent(event2id);
				}
				else {
					if (event2day < 30){
						if (event2day == 28 && event2month == 2){
							event2day = 1;
							event2month = 3;
						}
						else {
							event2day++;
						}
					}
					else {
						if (event2month < 12){
							event2month++;
							event2day = 1;
						}
						else {
							event2month = 1;
							event2day = 1;
						}
					}
				}
			}
			else if (month == event3month && day == event3day){
				if (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
					CallRandomEvent(event3id);
				}
				else {
					if (event3day < 30){
						if (event3day == 28 && event3month == 2){
							event3day = 1;
							event3month = 3;
						}
						else {
							event3day++;
						}
					}
					else {
						if (event3month < 12){
							event3month++;
							event3day = 1;
						}
						else {
							event3month = 1;
							event3day = 1;
						}
					}
				}
			}
			else if (month == event4month && day == event4day){
				if (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
					CallRandomEvent(event4id);
				}
				else {
					if (event4day < 30){
						if (event4day == 28 && event4month == 2){
							event4day = 1;
							event4month = 3;
						}
						else {
							event4day++;
						}
					}
					else {
						if (event4month < 12){
							event4month++;
							event4day = 1;
						}
						else {
							event4month = 1;
							event4day = 1;
						}
					}
				}
			}
			else if (month == event5month && day == event5day){
				if (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
					CallRandomEvent(event5id);
					event5month = 0;
					event5day = 0;
				}
				else {
					if (event5day < 30){
						if (event5day == 28 && event5month == 2){
							event5day = 1;
							event5month = 3;
						}
						else {
							event5day++;
						}
					}
					else {
						if (event5month < 12){
							event5month++;
							event5day = 1;
						}
						else {
							event5month = 1;
							event5day = 1;
						}
					}
				}
			}
			else if (month == event6month && day == event6day){
				if (GameObject.Find("Player").GetComponent<PlayerController>().frozen == false){
					CallRandomEvent(event6id);
					event6month = 0;
					event6day = 0;
				}
				else {
					if (event6day < 30){
						if (event6day == 28 && event6month == 2){
							event6day = 1;
							event6month = 3;
						}
						else {
							event6day++;
						}
					}
					else {
						if (event6month < 12){
							event6month++;
							event6day = 1;
						}
						else {
							event6month = 1;
							event6day = 1;
						}
					}
				}
			}
			for (int i = 0; i < 34; i++){
				if (Rtimer[i] > 0){
					Rtimer[i] = Rtimer[i] - 1;
					if (Rtimer[i] == 365){
						R[i] = false;
						if (i == 18){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableM2.gameObject.SetActive(false);
						}
						if (i != 31 && i != 33){
							GameObject.Find("EventSystem").GetComponent<PublicVariables>().EventHintP.gameObject.SetActive(true);
							GameObject.Find("EventPanel").GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().effectvol;
							GameObject.Find("EventPanel").GetComponent<AudioSource>().Play(0);
							GameObject.Find("EventHints").GetComponent<Text>().text = "  Event " + Rtextshort[i] + " has run out!";
							InvokeRepeating("EndEventHint", 3, 0.1f);
						}
					}
				}
			}
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingbuff != 0){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingbuff--;
				if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingbuff == 0){
					GameObject.Find("EventSystem").GetComponent<PublicVariables>().pairingeffect = false;
				}
			}
		}
	}
	
	
	public int CalcTotalDays(){
		//berechnet, wie viele Tage insgesamt vergangen sind, notwendig um dies dem Spieler beim Gameover mitzuteilen
		int totaldays;
		totaldays = 365 * (year - 1);
		totaldays = totaldays - 59;
		if (month == 12){
			totaldays = totaldays + 334;
		}
		else if (month == 11){
			totaldays = totaldays + 304;
		}
		else if (month == 10){
			totaldays = totaldays + 273;
		}
		else if (month == 9){
			totaldays = totaldays + 243;
		}
		else if (month == 8){
			totaldays = totaldays + 212;
		}
		else if (month == 7){
			totaldays = totaldays + 181;
		}
		else if (month == 6){
			totaldays = totaldays + 151;
		}
		else if (month == 5){
			totaldays = totaldays + 120;
		}
		else if (month == 4){
			totaldays = totaldays + 90;
		}
		else if (month == 3){
			totaldays = totaldays + 59;
		}
		else if (month == 2){
			totaldays = totaldays + 31;
		}
		totaldays = totaldays + day - 1;
		return totaldays;
	}
	
	
	void DefineSkills(){
		//sorgt dafür, dass die Fertigkeiten jede Runde zufällig sind und berechnet im voraus, wann welche Fertigkeiten zur Auswahl stehen
		for (int a = 1; a < 11; a++){
			bool set = false;
			while (set == false){
				int b = (int) prng.Next(1,15);
				while (b != A1 && b != A2 && b != A3 && b != A4 && b != A5 && b != B1 && b != B2 && b != B3 && b != B4 && b != B5){
					set = true;
					if (a == 1){
						A1 = b;
					}
					else if (a == 2){
						B1 = b;
					}
					else if (a == 3){
						A2 = b;
					}
					else if (a == 4){
						B2 = b;
					}
					else if (a == 5){
						A3 = b;
					}
					else if (a == 6){
						B3 = b;
					}
					else if (a == 7){
						A4 = b;
					}
					else if (a == 8){
						B4 = b;
					}
					else if (a == 9){
						A5 = b;
					}
					else if (a == 10){
						B5 = b;
					}
				}
			}
		}
		switch(A1) {
			case 1: STextB2.GetComponent<Text>().text = posS1; STextB3.GetComponent<Text>().text = negS1; break;
			case 2: STextB2.GetComponent<Text>().text = posS2; STextB3.GetComponent<Text>().text = negS2; break;
			case 3: STextB2.GetComponent<Text>().text = posS3; STextB3.GetComponent<Text>().text = negS3; break;
			case 4: STextB2.GetComponent<Text>().text = posS4; STextB3.GetComponent<Text>().text = negS4; break;
			case 5: STextB2.GetComponent<Text>().text = posS5; STextB3.GetComponent<Text>().text = negS5; break;
			case 6: STextB2.GetComponent<Text>().text = posS6; STextB3.GetComponent<Text>().text = negS6; break;
			case 7: STextB2.GetComponent<Text>().text = posS7; STextB3.GetComponent<Text>().text = negS7; break;
			case 8: STextB2.GetComponent<Text>().text = posS8; STextB3.GetComponent<Text>().text = negS8; break;
			case 9: STextB2.GetComponent<Text>().text = posS9; STextB3.GetComponent<Text>().text = negS9; break;
			case 10: STextB2.GetComponent<Text>().text = posS10; STextB3.GetComponent<Text>().text = negS10; break;
			case 11: STextB2.GetComponent<Text>().text = posS11; STextB3.GetComponent<Text>().text = negS11; break;
			case 12: STextB2.GetComponent<Text>().text = posS12; STextB3.GetComponent<Text>().text = negS12; break;
			case 13: STextB2.GetComponent<Text>().text = posS13; STextB3.GetComponent<Text>().text = negS13; break;
			case 14: STextB2.GetComponent<Text>().text = posS14; STextB3.GetComponent<Text>().text = negS14; break;
		}
		switch(B1) {
			case 1: STextB4.GetComponent<Text>().text = posS1; STextB5.GetComponent<Text>().text = negS1; break;
			case 2: STextB4.GetComponent<Text>().text = posS2; STextB5.GetComponent<Text>().text = negS2; break;
			case 3: STextB4.GetComponent<Text>().text = posS3; STextB5.GetComponent<Text>().text = negS3; break;
			case 4: STextB4.GetComponent<Text>().text = posS4; STextB5.GetComponent<Text>().text = negS4; break;
			case 5: STextB4.GetComponent<Text>().text = posS5; STextB5.GetComponent<Text>().text = negS5; break;
			case 6: STextB4.GetComponent<Text>().text = posS6; STextB5.GetComponent<Text>().text = negS6; break;
			case 7: STextB4.GetComponent<Text>().text = posS7; STextB5.GetComponent<Text>().text = negS7; break;
			case 8: STextB4.GetComponent<Text>().text = posS8; STextB5.GetComponent<Text>().text = negS8; break;
			case 9: STextB4.GetComponent<Text>().text = posS9; STextB5.GetComponent<Text>().text = negS9; break;
			case 10: STextB4.GetComponent<Text>().text = posS10; STextB5.GetComponent<Text>().text = negS10; break;
			case 11: STextB4.GetComponent<Text>().text = posS11; STextB5.GetComponent<Text>().text = negS11; break;
			case 12: STextB4.GetComponent<Text>().text = posS12; STextB5.GetComponent<Text>().text = negS12; break;
			case 13: STextB4.GetComponent<Text>().text = posS13; STextB5.GetComponent<Text>().text = negS13; break;
			case 14: STextB4.GetComponent<Text>().text = posS14; STextB5.GetComponent<Text>().text = negS14; break;
		}
	}
	
	
	void RevealNewSkills(){
		
		if (year == 2){
			switch(A2) {
				case 1: STextC2.GetComponent<Text>().text = posS1; STextC3.GetComponent<Text>().text = negS1; break;
				case 2: STextC2.GetComponent<Text>().text = posS2; STextC3.GetComponent<Text>().text = negS2; break;
				case 3: STextC2.GetComponent<Text>().text = posS3; STextC3.GetComponent<Text>().text = negS3; break;
				case 4: STextC2.GetComponent<Text>().text = posS4; STextC3.GetComponent<Text>().text = negS4; break;
				case 5: STextC2.GetComponent<Text>().text = posS5; STextC3.GetComponent<Text>().text = negS5; break;
				case 6: STextC2.GetComponent<Text>().text = posS6; STextC3.GetComponent<Text>().text = negS6; break;
				case 7: STextC2.GetComponent<Text>().text = posS7; STextC3.GetComponent<Text>().text = negS7; break;
				case 8: STextC2.GetComponent<Text>().text = posS8; STextC3.GetComponent<Text>().text = negS8; break;
				case 9: STextC2.GetComponent<Text>().text = posS9; STextC3.GetComponent<Text>().text = negS9; break;
				case 10: STextC2.GetComponent<Text>().text = posS10; STextC3.GetComponent<Text>().text = negS10; break;
				case 11: STextC2.GetComponent<Text>().text = posS11; STextC3.GetComponent<Text>().text = negS11; break;
				case 12: STextC2.GetComponent<Text>().text = posS12; STextC3.GetComponent<Text>().text = negS12; break;
				case 13: STextC2.GetComponent<Text>().text = posS13; STextC3.GetComponent<Text>().text = negS13; break;
				case 14: STextC2.GetComponent<Text>().text = posS14; STextC3.GetComponent<Text>().text = negS14; break;
			}
			switch(B2) {
				case 1: STextC4.GetComponent<Text>().text = posS1; STextC5.GetComponent<Text>().text = negS1; break;
				case 2: STextC4.GetComponent<Text>().text = posS2; STextC5.GetComponent<Text>().text = negS2; break;
				case 3: STextC4.GetComponent<Text>().text = posS3; STextC5.GetComponent<Text>().text = negS3; break;
				case 4: STextC4.GetComponent<Text>().text = posS4; STextC5.GetComponent<Text>().text = negS4; break;
				case 5: STextC4.GetComponent<Text>().text = posS5; STextC5.GetComponent<Text>().text = negS5; break;
				case 6: STextC4.GetComponent<Text>().text = posS6; STextC5.GetComponent<Text>().text = negS6; break;
				case 7: STextC4.GetComponent<Text>().text = posS7; STextC5.GetComponent<Text>().text = negS7; break;
				case 8: STextC4.GetComponent<Text>().text = posS8; STextC5.GetComponent<Text>().text = negS8; break;
				case 9: STextC4.GetComponent<Text>().text = posS9; STextC5.GetComponent<Text>().text = negS9; break;
				case 10: STextC4.GetComponent<Text>().text = posS10; STextC5.GetComponent<Text>().text = negS10; break;
				case 11: STextC4.GetComponent<Text>().text = posS11; STextC5.GetComponent<Text>().text = negS11; break;
				case 12: STextC4.GetComponent<Text>().text = posS12; STextC5.GetComponent<Text>().text = negS12; break;
				case 13: STextC4.GetComponent<Text>().text = posS13; STextC5.GetComponent<Text>().text = negS13; break;
				case 14: STextC4.GetComponent<Text>().text = posS14; STextC5.GetComponent<Text>().text = negS14; break;
			}
		}
		else if (year == 3){
			switch(A3) {
				case 1: STextD2.GetComponent<Text>().text = posS1; STextD3.GetComponent<Text>().text = negS1; break;
				case 2: STextD2.GetComponent<Text>().text = posS2; STextD3.GetComponent<Text>().text = negS2; break;
				case 3: STextD2.GetComponent<Text>().text = posS3; STextD3.GetComponent<Text>().text = negS3; break;
				case 4: STextD2.GetComponent<Text>().text = posS4; STextD3.GetComponent<Text>().text = negS4; break;
				case 5: STextD2.GetComponent<Text>().text = posS5; STextD3.GetComponent<Text>().text = negS5; break;
				case 6: STextD2.GetComponent<Text>().text = posS6; STextD3.GetComponent<Text>().text = negS6; break;
				case 7: STextD2.GetComponent<Text>().text = posS7; STextD3.GetComponent<Text>().text = negS7; break;
				case 8: STextD2.GetComponent<Text>().text = posS8; STextD3.GetComponent<Text>().text = negS8; break;
				case 9: STextD2.GetComponent<Text>().text = posS9; STextD3.GetComponent<Text>().text = negS9; break;
				case 10: STextD2.GetComponent<Text>().text = posS10; STextD3.GetComponent<Text>().text = negS10; break;
				case 11: STextD2.GetComponent<Text>().text = posS11; STextD3.GetComponent<Text>().text = negS11; break;
				case 12: STextD2.GetComponent<Text>().text = posS12; STextD3.GetComponent<Text>().text = negS12; break;
				case 13: STextD2.GetComponent<Text>().text = posS13; STextD3.GetComponent<Text>().text = negS13; break;
				case 14: STextD2.GetComponent<Text>().text = posS14; STextD3.GetComponent<Text>().text = negS14; break;
			}
			switch(B3) {
				case 1: STextD4.GetComponent<Text>().text = posS1; STextD5.GetComponent<Text>().text = negS1; break;
				case 2: STextD4.GetComponent<Text>().text = posS2; STextD5.GetComponent<Text>().text = negS2; break;
				case 3: STextD4.GetComponent<Text>().text = posS3; STextD5.GetComponent<Text>().text = negS3; break;
				case 4: STextD4.GetComponent<Text>().text = posS4; STextD5.GetComponent<Text>().text = negS4; break;
				case 5: STextD4.GetComponent<Text>().text = posS5; STextD5.GetComponent<Text>().text = negS5; break;
				case 6: STextD4.GetComponent<Text>().text = posS6; STextD5.GetComponent<Text>().text = negS6; break;
				case 7: STextD4.GetComponent<Text>().text = posS7; STextD5.GetComponent<Text>().text = negS7; break;
				case 8: STextD4.GetComponent<Text>().text = posS8; STextD5.GetComponent<Text>().text = negS8; break;
				case 9: STextD4.GetComponent<Text>().text = posS9; STextD5.GetComponent<Text>().text = negS9; break;
				case 10: STextD4.GetComponent<Text>().text = posS10; STextD5.GetComponent<Text>().text = negS10; break;
				case 11: STextD4.GetComponent<Text>().text = posS11; STextD5.GetComponent<Text>().text = negS11; break;
				case 12: STextD4.GetComponent<Text>().text = posS12; STextD5.GetComponent<Text>().text = negS12; break;
				case 13: STextD4.GetComponent<Text>().text = posS13; STextD5.GetComponent<Text>().text = negS13; break;
				case 14: STextD4.GetComponent<Text>().text = posS14; STextD5.GetComponent<Text>().text = negS14; break;
			}
		}
		else if (year == 4){
			switch(A4) {
				case 1: STextE2.GetComponent<Text>().text = posS1; STextE3.GetComponent<Text>().text = negS1; break;
				case 2: STextE2.GetComponent<Text>().text = posS2; STextE3.GetComponent<Text>().text = negS2; break;
				case 3: STextE2.GetComponent<Text>().text = posS3; STextE3.GetComponent<Text>().text = negS3; break;
				case 4: STextE2.GetComponent<Text>().text = posS4; STextE3.GetComponent<Text>().text = negS4; break;
				case 5: STextE2.GetComponent<Text>().text = posS5; STextE3.GetComponent<Text>().text = negS5; break;
				case 6: STextE2.GetComponent<Text>().text = posS6; STextE3.GetComponent<Text>().text = negS6; break;
				case 7: STextE2.GetComponent<Text>().text = posS7; STextE3.GetComponent<Text>().text = negS7; break;
				case 8: STextE2.GetComponent<Text>().text = posS8; STextE3.GetComponent<Text>().text = negS8; break;
				case 9: STextE2.GetComponent<Text>().text = posS9; STextE3.GetComponent<Text>().text = negS9; break;
				case 10: STextE2.GetComponent<Text>().text = posS10; STextE3.GetComponent<Text>().text = negS10; break;
				case 11: STextE2.GetComponent<Text>().text = posS11; STextE3.GetComponent<Text>().text = negS11; break;
				case 12: STextE2.GetComponent<Text>().text = posS12; STextE3.GetComponent<Text>().text = negS12; break;
				case 13: STextE2.GetComponent<Text>().text = posS13; STextE3.GetComponent<Text>().text = negS13; break;
				case 14: STextE2.GetComponent<Text>().text = posS14; STextE3.GetComponent<Text>().text = negS14; break;
			}
			switch(B4) {
				case 1: STextE4.GetComponent<Text>().text = posS1; STextE5.GetComponent<Text>().text = negS1; break;
				case 2: STextE4.GetComponent<Text>().text = posS2; STextE5.GetComponent<Text>().text = negS2; break;
				case 3: STextE4.GetComponent<Text>().text = posS3; STextE5.GetComponent<Text>().text = negS3; break;
				case 4: STextE4.GetComponent<Text>().text = posS4; STextE5.GetComponent<Text>().text = negS4; break;
				case 5: STextE4.GetComponent<Text>().text = posS5; STextE5.GetComponent<Text>().text = negS5; break;
				case 6: STextE4.GetComponent<Text>().text = posS6; STextE5.GetComponent<Text>().text = negS6; break;
				case 7: STextE4.GetComponent<Text>().text = posS7; STextE5.GetComponent<Text>().text = negS7; break;
				case 8: STextE4.GetComponent<Text>().text = posS8; STextE5.GetComponent<Text>().text = negS8; break;
				case 9: STextE4.GetComponent<Text>().text = posS9; STextE5.GetComponent<Text>().text = negS9; break;
				case 10: STextE4.GetComponent<Text>().text = posS10; STextE5.GetComponent<Text>().text = negS10; break;
				case 11: STextE4.GetComponent<Text>().text = posS11; STextE5.GetComponent<Text>().text = negS11; break;
				case 12: STextE4.GetComponent<Text>().text = posS12; STextE5.GetComponent<Text>().text = negS12; break;
				case 13: STextE4.GetComponent<Text>().text = posS13; STextE5.GetComponent<Text>().text = negS13; break;
				case 14: STextE4.GetComponent<Text>().text = posS14; STextE5.GetComponent<Text>().text = negS14; break;
			}
		}
		else if (year == 5){
			switch(A5) {
				case 1: STextF2.GetComponent<Text>().text = posS1; STextF3.GetComponent<Text>().text = negS1; break;
				case 2: STextF2.GetComponent<Text>().text = posS2; STextF3.GetComponent<Text>().text = negS2; break;
				case 3: STextF2.GetComponent<Text>().text = posS3; STextF3.GetComponent<Text>().text = negS3; break;
				case 4: STextF2.GetComponent<Text>().text = posS4; STextF3.GetComponent<Text>().text = negS4; break;
				case 5: STextF2.GetComponent<Text>().text = posS5; STextF3.GetComponent<Text>().text = negS5; break;
				case 6: STextF2.GetComponent<Text>().text = posS6; STextF3.GetComponent<Text>().text = negS6; break;
				case 7: STextF2.GetComponent<Text>().text = posS7; STextF3.GetComponent<Text>().text = negS7; break;
				case 8: STextF2.GetComponent<Text>().text = posS8; STextF3.GetComponent<Text>().text = negS8; break;
				case 9: STextF2.GetComponent<Text>().text = posS9; STextF3.GetComponent<Text>().text = negS9; break;
				case 10: STextF2.GetComponent<Text>().text = posS10; STextF3.GetComponent<Text>().text = negS10; break;
				case 11: STextF2.GetComponent<Text>().text = posS11; STextF3.GetComponent<Text>().text = negS11; break;
				case 12: STextF2.GetComponent<Text>().text = posS12; STextF3.GetComponent<Text>().text = negS12; break;
				case 13: STextF2.GetComponent<Text>().text = posS13; STextF3.GetComponent<Text>().text = negS13; break;
				case 14: STextF2.GetComponent<Text>().text = posS14; STextF3.GetComponent<Text>().text = negS14; break;
			}
			switch(B5) {
				case 1: STextF4.GetComponent<Text>().text = posS1; STextF5.GetComponent<Text>().text = negS1; break;
				case 2: STextF4.GetComponent<Text>().text = posS2; STextF5.GetComponent<Text>().text = negS2; break;
				case 3: STextF4.GetComponent<Text>().text = posS3; STextF5.GetComponent<Text>().text = negS3; break;
				case 4: STextF4.GetComponent<Text>().text = posS4; STextF5.GetComponent<Text>().text = negS4; break;
				case 5: STextF4.GetComponent<Text>().text = posS5; STextF5.GetComponent<Text>().text = negS5; break;
				case 6: STextF4.GetComponent<Text>().text = posS6; STextF5.GetComponent<Text>().text = negS6; break;
				case 7: STextF4.GetComponent<Text>().text = posS7; STextF5.GetComponent<Text>().text = negS7; break;
				case 8: STextF4.GetComponent<Text>().text = posS8; STextF5.GetComponent<Text>().text = negS8; break;
				case 9: STextF4.GetComponent<Text>().text = posS9; STextF5.GetComponent<Text>().text = negS9; break;
				case 10: STextF4.GetComponent<Text>().text = posS10; STextF5.GetComponent<Text>().text = negS10; break;
				case 11: STextF4.GetComponent<Text>().text = posS11; STextF5.GetComponent<Text>().text = negS11; break;
				case 12: STextF4.GetComponent<Text>().text = posS12; STextF5.GetComponent<Text>().text = negS12; break;
				case 13: STextF4.GetComponent<Text>().text = posS13; STextF5.GetComponent<Text>().text = negS13; break;
				case 14: STextF4.GetComponent<Text>().text = posS14; STextF5.GetComponent<Text>().text = negS14; break;
			}
		}
	}
	
	
	public void SelectNewSkill(string selection){
		//am ersten März von jedem Jahr muss der Spieler sich zwischen 2 Fertigkeiten entscheiden. Diese Funktion sorgt dafür, dass genau dann ein Popup erscheint, wo der Spieler eine Wahl treffen muss. Das Spiel ist währenddessen pausiert. Speichert die Wahl des Spielers
		if (selection == "null"){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().SelectionP.gameObject.SetActive(true);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused = true;
			selection = "Choose a skill:\n" + "" + "\n";
			selection = selection + "Possibility A\n";
			if (year == 2){
				selection = selection + STextB2.GetComponent<Text>().text + "\n";
				selection = selection + STextB3.GetComponent<Text>().text + "\n" + "" +"\n";
				selection = selection + "Possibility B\n";
				selection = selection + STextB4.GetComponent<Text>().text + "\n";
				selection = selection + STextB5.GetComponent<Text>().text;
			}
			else if (year == 3){
				selection = selection + STextC2.GetComponent<Text>().text + "\n";
				selection = selection + STextC3.GetComponent<Text>().text + "\n" + "" +"\n";
				selection = selection + "Possibility B\n";
				selection = selection + STextC4.GetComponent<Text>().text + "\n";
				selection = selection + STextC5.GetComponent<Text>().text;
			}
			else if (year == 4){
				selection = selection + STextD2.GetComponent<Text>().text + "\n";
				selection = selection + STextD3.GetComponent<Text>().text + "\n" + "" +"\n";
				selection = selection + "Possibility B\n";
				selection = selection + STextD4.GetComponent<Text>().text + "\n";
				selection = selection + STextD5.GetComponent<Text>().text;
			}
			else if (year == 5){
				selection = selection + STextE2.GetComponent<Text>().text + "\n";
				selection = selection + STextE3.GetComponent<Text>().text + "\n" + "" +"\n";
				selection = selection + "Possibility B\n";
				selection = selection + STextE4.GetComponent<Text>().text + "\n";
				selection = selection + STextE5.GetComponent<Text>().text;
			}
			else if (year == 6){
				selection = selection + STextF2.GetComponent<Text>().text + "\n";
				selection = selection + STextF3.GetComponent<Text>().text + "\n" + "" +"\n";
				selection = selection + "Possibility B\n";
				selection = selection + STextF4.GetComponent<Text>().text + "\n";
				selection = selection + STextF5.GetComponent<Text>().text;
			}
			GameObject.Find("SelectionText").GetComponent<Text>().text = selection;
			GameObject.Find("SelectionA").GetComponent<Button>().Select();
		}
		else if (selection == "A"){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().SelectionP.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused = false;
			if (year == 2){
				STextB2.GetComponent<Text>().text = "<b>" + STextB2.GetComponent<Text>().text + "</b>";
				STextB3.GetComponent<Text>().text = "<b>" + STextB3.GetComponent<Text>().text + "</b>";
				switch(A1) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 3){
				STextC2.GetComponent<Text>().text = "<b>" + STextC2.GetComponent<Text>().text + "</b>";
				STextC3.GetComponent<Text>().text = "<b>" + STextC3.GetComponent<Text>().text + "</b>";
				switch(A2) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 4){
				STextD2.GetComponent<Text>().text = "<b>" + STextD2.GetComponent<Text>().text + "</b>";
				STextD3.GetComponent<Text>().text = "<b>" + STextD3.GetComponent<Text>().text + "</b>";
				switch(A3) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 5){
				STextE2.GetComponent<Text>().text = "<b>" + STextE2.GetComponent<Text>().text + "</b>";
				STextE3.GetComponent<Text>().text = "<b>" + STextE3.GetComponent<Text>().text + "</b>";
				switch(A4) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 6){
				STextF2.GetComponent<Text>().text = "<b>" + STextF2.GetComponent<Text>().text + "</b>";
				STextF3.GetComponent<Text>().text = "<b>" + STextF3.GetComponent<Text>().text + "</b>";
				switch(A5) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
		else if (selection == "B"){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().SelectionP.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused = false;
			if (year == 2){
				STextB4.GetComponent<Text>().text = "<b>" + STextB4.GetComponent<Text>().text + "</b>";
				STextB5.GetComponent<Text>().text = "<b>" + STextB5.GetComponent<Text>().text + "</b>";
				switch(B1) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 3){
				STextC4.GetComponent<Text>().text = "<b>" + STextC4.GetComponent<Text>().text + "</b>";
				STextC5.GetComponent<Text>().text = "<b>" + STextC5.GetComponent<Text>().text + "</b>";
				switch(B2) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 4){
				STextD4.GetComponent<Text>().text = "<b>" + STextD4.GetComponent<Text>().text + "</b>";
				STextD5.GetComponent<Text>().text = "<b>" + STextD5.GetComponent<Text>().text + "</b>";
				switch(B3) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 5){
				STextE4.GetComponent<Text>().text = "<b>" + STextE4.GetComponent<Text>().text + "</b>";
				STextE5.GetComponent<Text>().text = "<b>" + STextE5.GetComponent<Text>().text + "</b>";
				switch(B4) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			else if (year == 6){
				STextF4.GetComponent<Text>().text = "<b>" + STextF4.GetComponent<Text>().text + "</b>";
				STextF5.GetComponent<Text>().text = "<b>" + STextF5.GetComponent<Text>().text + "</b>";
				switch(B5) {
					case 1: S1 = true; break;
					case 2: S2 = true; break;
					case 3: S3 = true; break;
					case 4: S4 = true; break;
					case 5: S5 = true; GameObject.Find("EventSystem").GetComponent<PublicVariables>().maxpopulation = BalanceSheet.S5_negative_effect; R[3] = false; GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(false); break;
					case 6: S6 = true; break;
					case 7: S7 = true; break;
					case 8: S8 = true; break;
					case 9: S9 = true; break;
					case 10: S10 = true; break;
					case 11: S11 = true; break;
					case 12: S12 = true; break;
					case 13: S13 = true; break;
					case 14: S14 = true; break;
				}
			}
			GameObject.Find("HUDCanvas").GetComponent<AudioSource>().Play(0);
		}
	}
	
	
	public void DefineRandomEvents(){
		//Berechnet wann welche Zufallsereignisse eintreten. Pro Jahr (außer Jahr 1) treten 4 Zufallsereignisse ein, wovon eines permanent ist. Zwischen Zufallsereignissen gibt es mindestens einen Monat Pause
		if (year == 1){
			int b1 = 0;
			int b2 = 0;
			while (Mathf.Abs(b1-b2) < 90){
				b1 = prng.Next(182,366);
				b2 = prng.Next(182,366);
			}
			if (b1 > 334){
				event1month = 12;
				event1day = b1 - 334;
			}
			else if (b1 > 304){
				event1month = 11;
				event1day = b1 - 304;
			}
			else if (b1 > 273){
				event1month = 10;
				event1day = b1 - 273;
			}
			else if (b1 > 243){
				event1month = 9;
				event1day = b1 - 243;
			}
			else if (b1 > 212){
				event1month = 8;
				event1day = b1 - 212;
			}
			else if (b1 > 181){
				event1month = 7;
				event1day = b1 - 181;
			}
			if (b2 > 334){
				event2month = 12;
				event2day = b2 - 334;
			}
			else if (b2 > 304){
				event2month = 11;
				event2day = b2 - 304;
			}
			else if (b2 > 273){
				event2month = 10;
				event2day = b2 - 273;
			}
			else if (b2 > 243){
				event2month = 9;
				event2day = b2 - 243;
			}
			else if (b2 > 212){
				event2month = 8;
				event2day = b2 - 212;
			}
			else if (b2 > 181){
				event2month = 7;
				event2day = b2 - 181;
			}
			bool smallevents = false;
			int bs1 = 0;
			int bs2 = 0;
			while (smallevents == false){
				bs1 = prng.Next(11,35);
				bs2 = prng.Next(11,35);
				if (bs1 != bs2){
					if (Rtimer[bs1-1] <= 0 && Rtimer[bs2-1] <= 0){
						smallevents = true;
					}
				}
			}
			event1id = bs1;
			event2id = bs2;
		}
		else {
			int b1 = 0;
			int b2 = 0;
			int b3 = 0;
			int b4 = 0;
			while (Mathf.Abs(b1-b2) < 30 || Mathf.Abs(b1-b3) < 30 || Mathf.Abs(b1-b4) < 30 || Mathf.Abs(b2-b3) < 30 || Mathf.Abs(b2-b4) < 30 || Mathf.Abs(b3-b4) < 30){
				b1 = prng.Next(1,366);
				b2 = prng.Next(1,366);
				b3 = prng.Next(1,366);
				b4 = prng.Next(1,366);
			}
			if (b1 > 334){
				event1month = 12;
				event1day = b1 - 334;
			}
			else if (b1 > 304){
				event1month = 11;
				event1day = b1 - 304;
			}
			else if (b1 > 273){
				event1month = 10;
				event1day = b1 - 273;
			}
			else if (b1 > 243){
				event1month = 9;
				event1day = b1 - 243;
			}
			else if (b1 > 212){
				event1month = 8;
				event1day = b1 - 212;
			}
			else if (b1 > 181){
				event1month = 7;
				event1day = b1 - 181;
			}
			else if (b1 > 151){
				event1month = 6;
				event1day = b1 - 151;
			}
			else if (b1 > 120){
				event1month = 5;
				event1day = b1 - 120;
			}
			else if (b1 > 90){
				event1month = 4;
				event1day = b1 - 90;
			}
			else if (b1 > 59){
				event1month = 3;
				event1day = b1 - 59;
			}
			else if (b1 > 31){
				event1month = 2;
				event1day = b1 - 31;
			}
			else if (b1 > 0){
				event1month = 1;
				event1day = b1;
			}
			if (b2 > 334){
				event2month = 12;
				event2day = b2 - 334;
			}
			else if (b2 > 304){
				event2month = 11;
				event2day = b2 - 304;
			}
			else if (b2 > 273){
				event2month = 10;
				event2day = b2 - 273;
			}
			else if (b2 > 243){
				event2month = 9;
				event2day = b2 - 243;
			}
			else if (b2 > 212){
				event2month = 8;
				event2day = b2 - 212;
			}
			else if (b2 > 181){
				event2month = 7;
				event2day = b2 - 181;
			}
			else if (b2 > 151){
				event2month = 6;
				event2day = b2 - 151;
			}
			else if (b2 > 120){
				event2month = 5;
				event2day = b2 - 120;
			}
			else if (b2 > 90){
				event2month = 4;
				event2day = b2 - 90;
			}
			else if (b2 > 59){
				event2month = 3;
				event2day = b2 - 59;
			}
			else if (b2 > 31){
				event2month = 2;
				event2day = b2 - 31;
			}
			else if (b2 > 0){
				event2month = 1;
				event2day = b2;
			}
			if (b3 > 334){
				event3month = 12;
				event3day = b3 - 334;
			}
			else if (b3 > 304){
				event3month = 11;
				event3day = b3 - 304;
			}
			else if (b3 > 273){
				event3month = 10;
				event3day = b3 - 273;
			}
			else if (b3 > 243){
				event3month = 9;
				event3day = b3 - 243;
			}
			else if (b3 > 212){
				event3month = 8;
				event3day = b3 - 212;
			}
			else if (b3 > 181){
				event3month = 7;
				event3day = b3 - 181;
			}
			else if (b3 > 151){
				event3month = 6;
				event3day = b3 - 151;
			}
			else if (b3 > 120){
				event3month = 5;
				event3day = b3 - 120;
			}
			else if (b3 > 90){
				event3month = 4;
				event3day = b3 - 90;
			}
			else if (b3 > 59){
				event3month = 3;
				event3day = b3 - 59;
			}
			else if (b3 > 31){
				event3month = 2;
				event3day = b3 - 31;
			}
			else if (b3 > 0){
				event3month = 1;
				event3day = b3;
			}
			if (b4 > 334){
				event4month = 12;
				event4day = b4 - 334;
			}
			else if (b4 > 304){
				event4month = 11;
				event4day = b4 - 304;
			}
			else if (b4 > 273){
				event4month = 10;
				event4day = b4 - 273;
			}
			else if (b4 > 243){
				event4month = 9;
				event4day = b4 - 243;
			}
			else if (b4 > 212){
				event4month = 8;
				event4day = b4 - 212;
			}
			else if (b4 > 181){
				event4month = 7;
				event4day = b4 - 181;
			}
			else if (b4 > 151){
				event4month = 6;
				event4day = b4 - 151;
			}
			else if (b4 > 120){
				event4month = 5;
				event4day = b4 - 120;
			}
			else if (b4 > 90){
				event4month = 4;
				event4day = b4 - 90;
			}
			else if (b4 > 59){
				event4month = 3;
				event4day = b4 - 59;
			}
			else if (b4 > 31){
				event4month = 2;
				event4day = b4 - 31;
			}
			else if (b4 > 0){
				event4month = 1;
				event4day = b4;
			}
			bool bigevent = false;
			bool smallevents = false;
			int be = 0;
			int bs1 = 0;
			int bs2 = 0;
			int bs3 = 0;
			while (bigevent == false){
				be = prng.Next(1,11);
				if (R[be-1] == false){
					bigevent = true;
				}
				if (S5 == true && be == 4){
					bigevent = false;
				}
				if (year == 2 && be == 8){
					bigevent = false;
				}
				if (year >= 12){
					bigevent = true;
				}
			}
			event1id = be;
			if (year == 3){
				event1id = 8;
			}
			while (smallevents == false){
				bs1 = prng.Next(11,35);
				bs2 = prng.Next(11,35);
				bs3 = prng.Next(11,35);
				if (bs1 != bs2 && bs1 != bs3 && bs2 != bs3){
					if (Rtimer[bs1-1] <= 0 && Rtimer[bs2-1] <= 0 && Rtimer[bs3-1] <= 0){
						smallevents = true;
					}
				}
			}
			event2id = bs1;
			event3id = bs2;
			event4id = bs3;
			if (R[31] == true){
				smallevents = false;
				int bs4 = 0;
				int bs5 = 0;
				int b5 = 0;
				int b6 = 0;
				while (smallevents == false){
					bs4 = prng.Next(11,35);
					bs5 = prng.Next(11,35);
					if (bs4 != bs1 && bs4 != bs2 && bs4 != bs3 && bs5 != bs1 && bs5 != bs2 && bs5 != bs3 && bs4 != bs5){
						if (Rtimer[bs4-1] <= 0 && Rtimer[bs5-1] <= 0){
							smallevents = true;
						}
					}
				}
				event5id = bs4;
				event6id = bs5;
				while (Mathf.Abs(b1-b5) < 30 || Mathf.Abs(b2-b5) < 30 || Mathf.Abs(b3-b5) < 30 || Mathf.Abs(b4-b5) < 30 || Mathf.Abs(b1-b6) < 30 || Mathf.Abs(b2-b6) < 30 || Mathf.Abs(b3-b6) < 30 || Mathf.Abs(b4-b6) < 30 || Mathf.Abs(b5-b6) < 30){
					b5 = prng.Next(1,366);
					b6 = prng.Next(1,366);
				}
				if (b5 > 334){
					event5month = 12;
					event5day = b5 - 334;
				}
				else if (b5 > 304){
					event5month = 11;
					event5day = b5 - 304;
				}
				else if (b5 > 273){
					event5month = 10;
					event5day = b5 - 273;
				}
				else if (b5 > 243){
					event5month = 9;
					event5day = b5 - 243;
				}
				else if (b5 > 212){
					event5month = 8;
					event5day = b5 - 212;
				}
				else if (b5 > 181){
					event5month = 7;
					event5day = b5 - 181;
				}
				else if (b5 > 151){
					event5month = 6;
					event5day = b5 - 151;
				}
				else if (b5 > 120){
					event5month = 5;
					event5day = b5 - 120;
				}
				else if (b5 > 90){
					event5month = 4;
					event5day = b5 - 90;
				}
				else if (b5 > 59){
					event5month = 3;
					event5day = b5 - 59;
				}
				else if (b5 > 31){
					event5month = 2;
					event5day = b5 - 31;
				}
				else if (b5 > 0){
					event5month = 1;
					event5day = b5;
				}
				if (b6 > 334){
					event6month = 12;
					event6day = b6 - 334;
				}
				else if (b6 > 304){
					event6month = 11;
					event6day = b6 - 304;
				}
				else if (b6 > 273){
					event6month = 10;
					event6day = b6 - 273;
				}
				else if (b6 > 243){
					event6month = 9;
					event6day = b6 - 243;
				}
				else if (b6 > 212){
					event6month = 8;
					event6day = b6 - 212;
				}
				else if (b6 > 181){
					event6month = 7;
					event6day = b6 - 181;
				}
				else if (b6 > 151){
					event6month = 6;
					event6day = b6 - 151;
				}
				else if (b6 > 120){
					event6month = 5;
					event6day = b6 - 120;
				}
				else if (b6 > 90){
					event6month = 4;
					event6day = b6 - 90;
				}
				else if (b6 > 59){
					event6month = 3;
					event6day = b6 - 59;
				}
				else if (b6 > 31){
					event6month = 2;
					event6day = b6 - 31;
				}
				else if (b6 > 0){
					event6month = 1;
					event6day = b6;
				}
				R[31] = false;
			}
		}
	}
	
	
	void CallRandomEvent(int eID){
		//Wenn das Datum mit dem Startzeitpunkt eines Zufallsereignisses übereinstimmt, wird dieses aufgerufen und aktiviert. Der Spieler wird mithilfe eines Popups informiert.
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused = true;
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().RandomP.gameObject.SetActive(true);
		GameObject.Find("RandomButton").GetComponent<Button>().Select();
		string eventtext = "A new event has happened:\n" + "" + "\n";
		eventtext = eventtext + Rtext[eID-1];
		R[eID-1] = true;
		switch(eID) {
			case 1: Rtimer[0] = 0; break;
			case 2: Rtimer[1] = 0; break;
			case 3: Rtimer[2] = 0; break;
			case 4: Rtimer[3] = 0; break;
			case 5: Rtimer[4] = 0; break;
			case 6: Rtimer[5] = 0; break;
			case 7: Rtimer[6] = 0; break;
			case 8: Rtimer[7] = 0; break;
			case 9: Rtimer[8] = 0; break;
			case 10: Rtimer[9] = 0; break;
			case 11: Rtimer[10] = BalanceSheet.event11_time; break;
			case 12: Rtimer[11] = BalanceSheet.event12_time; break;
			case 13: Rtimer[12] = BalanceSheet.event13_time; break;
			case 14: Rtimer[13] = BalanceSheet.event14_time; break;
			case 15: Rtimer[14] = BalanceSheet.event15_time; break;
			case 16: Rtimer[15] = BalanceSheet.event16_time; break;
			case 17: Rtimer[16] = BalanceSheet.event17_time; break;
			case 18: Rtimer[17] = BalanceSheet.event18_time; break;
			case 19: Rtimer[18] = BalanceSheet.event19_time; break;
			case 20: Rtimer[19] = BalanceSheet.event20_time; break;
			case 21: Rtimer[20] = BalanceSheet.event21_time; break;
			case 22: Rtimer[21] = BalanceSheet.event22_time; break;
			case 23: Rtimer[22] = BalanceSheet.event23_time; break;
			case 24: Rtimer[23] = BalanceSheet.event24_time; break;
			case 25: Rtimer[24] = BalanceSheet.event25_time; break;
			case 26: Rtimer[25] = BalanceSheet.event26_time; break;
			case 27: Rtimer[26] = BalanceSheet.event27_time; break;
			case 28: Rtimer[27] = BalanceSheet.event28_time; break;
			case 29: Rtimer[28] = BalanceSheet.event29_time; break;
			case 30: Rtimer[29] = BalanceSheet.event30_time; break;
			case 31: Rtimer[30] = BalanceSheet.event31_time; break;
			case 32: Rtimer[31] = 366; break;
			case 33: Rtimer[32] = BalanceSheet.event33_time; break;
			case 34: Rtimer[33] = 366; break;
		}
		if (S11 == true){
			Rtimer[eID-1] = (int) ((Rtimer[eID-1] - 365)* BalanceSheet.S11_positive_effect + 365);
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster + BalanceSheet.S11_negative_effect;
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating - BalanceSheet.S11_negative_effect2;
		}
		if (eID > 10){
			eventtext = eventtext + "\nDuration of event: " + (Rtimer[eID-1] - 365) + " days";
		}
		if (eID == 21){
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating > 75){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().mating = 75;
			}
		}
		if (eID == 34){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster + BalanceSheet.event34_effect;
			if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster > 160){
				GameObject.Find("EventSystem").GetComponent<PublicVariables>().monster = 160;
			}
		}
		if (eID == 3){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableE3.gameObject.SetActive(true);
		}
		if (eID == 4){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableV3P4.gameObject.SetActive(true);
		}
		if (eID == 19){
			GameObject.Find("EventSystem").GetComponent<PublicVariables>().DisableM2.gameObject.SetActive(true);
		}
		GameObject.Find("RandomText").GetComponent<Text>().text = eventtext;
	}
	
	
	void EndHint(){
		//zuständig um die Spielermeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().HintP.gameObject.SetActive(false);
		CancelInvoke("EndHint");
	}
	
	
	void EndEventHint(){
		//zuständig um die Eventmeldungen nach 3 Sekunden wieder auszublenden
		GameObject.Find("EventSystem").GetComponent<PublicVariables>().EventHintP.gameObject.SetActive(false);
		CancelInvoke("EndEventHint");
	}
	
	
	public void UpdateEventText(){
		//Sorgt dafür, dass sich der Spieler im Pausemenü anschauen kann, welche Events noch für wie lange aktiv sind
		string eventsummary = "<size=22>Active events\n</size>" + "" + "\n";
		for (int i = 0; i < 34; i++){
			if (R[i] == true){
				eventsummary = eventsummary + Rtext[i] + "\n";
				if (i > 9 && i != 31 && i != 33){
					eventsummary = eventsummary + "Remaining Duration: " + (Rtimer[i] - 365) + " days\n";
				}
				eventsummary = eventsummary + "\n";
			}
		}
		GameObject.Find("EventText").GetComponent<Text>().text = eventsummary;
	}
	
	//alle untenstehenden Funktionen sind notwendig, um die Daten korrekt zuzuteilen, wenn das Spiel geladen wird
	public int GetYear(){
		
		return year;
	}
	
	
	public int GetMonth(){
		
		return month;
	}
	
	
	public int GetDay(){
		
		return day;
	}
	
	
	public bool GetS1(){
		
		return S1;
	}
	
	
	public bool GetS2(){
		
		return S2;
	}
	
	
	public bool GetS3(){
		
		return S3;
	}
	
	
	public bool GetS4(){
		
		return S4;
	}
	
	
	public bool GetS5(){
		
		return S5;
	}
	
	
	public bool GetS6(){
		
		return S6;
	}
	
	
	public bool GetS7(){
		
		return S7;
	}
	
	
	public bool GetS8(){
		
		return S8;
	}
	
	
	public bool GetS9(){
		
		return S9;
	}
	
	
	public bool GetS10(){
		
		return S10;
	}
	
	
	public bool GetS11(){
		
		return S11;
	}
	
	
	public bool GetS12(){
		
		return S12;
	}
	
	
	public bool GetS13(){
		
		return S13;
	}
	
	
	public bool GetS14(){
		
		return S14;
	}
	
	
	public int GetA1(){
		
		return A1;
	}
	
	
	public int GetB1(){
		
		return B1;
	}
	
	
	public int GetA2(){
		
		return A2;
	}
	
	
	public int GetB2(){
		
		return B2;
	}
	
	
	public int GetA3(){
		
		return A3;
	}
	
	
	public int GetB3(){
		
		return B3;
	}
	
	
	public int GetA4(){
		
		return A4;
	}
	
	
	public int GetB4(){
		
		return B4;
	}
	
	
	public int GetA5(){
		
		return A5;
	}
	
	
	public int GetB5(){
		
		return B5;
	}
	
	
	public int GetEvent1ID(){
		
		return event1id;
	}
	
	
	public int GetEvent2ID(){
		
		return event2id;
	}
	
	
	public int GetEvent3ID(){
		
		return event3id;
	}
	
	
	public int GetEvent4ID(){
		
		return event4id;
	}
	
	
	public int GetEvent5ID(){
		
		return event5id;
	}
	
	
	public int GetEvent6ID(){
		
		return event6id;
	}
	
	
	public int GetEvent1m(){
		
		return event1month;
	}
	
	
	public int GetEvent2m(){
		
		return event2month;
	}
	
	
	public int GetEvent3m(){
		
		return event3month;
	}
	
	
	public int GetEvent4m(){
		
		return event4month;
	}
	
	
	public int GetEvent5m(){
		
		return event5month;
	}
	
	
	public int GetEvent6m(){
		
		return event6month;
	}
	
	
	public int GetEvent1d(){
		
		return event1day;
	}
	
	
	public int GetEvent2d(){
		
		return event2day;
	}
	
	
	public int GetEvent3d(){
		
		return event3day;
	}
	
	
	public int GetEvent4d(){
		
		return event4day;
	}
	
	
	public int GetEvent5d(){
		
		return event5day;
	}
	
	
	public int GetEvent6d(){
		
		return event6day;
	}
	
	
	public int GetRTimer(int r){
		
		return Rtimer[r];
	}
	
	
	public void LoadYear(int lyear){
		
		year = lyear;
	}
	
	
	public void LoadMonth(int lmonth){
		
		month = lmonth;
	}
	
	
	public void LoadDay(int lday){
		
		day = lday;
	}
	
	
	public void LoadSkills(bool S1l, bool S2l, bool S3l, bool S4l, bool S5l, bool S6l, bool S7l, bool S8l, bool S9l, bool S10l, bool S11l, bool S12l, bool S13l, bool S14l, int A1l, int B1l, int A2l, int B2l, int A3l, int B3l, int A4l, int B4l, int A5l, int B5l){
		
		S1 = S1l;
		S2 = S2l;
		S3 = S3l;
		S4 = S4l;
		S5 = S5l;
		S6 = S6l;
		S7 = S7l;
		S8 = S8l;
		S9 = S9l;
		S10 = S10l;
		S11 = S11l;
		S12 = S12l;
		S13 = S13l;
		S14 = S14l;
		A1 = A1l;
		B1 = B1l;
		A2 = A2l;
		B2 = B2l;
		A3 = A3l;
		B3 = B3l;
		A4 = A4l;
		B4 = B4l;
		A5 = A5l;
		B5 = B5l;
	}
	
	
	public void LoadEvents(int e1id, int e1m, int e1d, int e2id, int e2m, int e2d, int e3id, int e3m, int e3d, int e4id, int e4m, int e4d, int e5id, int e5m, int e5d, int e6id, int e6m, int e6d){
		
		event1id = e1id;
		event1month = e1m;
		event1day = e1d;
		event2id = e2id;
		event2month = e2m;
		event2day = e2d;
		event3id = e3id;
		event3month = e3m;
		event3day = e3d;
		event4id = e4id;
		event4month = e4m;
		event4day = e4d;
		event5id = e5id;
		event5month = e5m;
		event5day = e5d;
		event6id = e6id;
		event6month = e6m;
		event6day = e6d;
	}
	
	
	public void LoadArrays(int pos, bool R1, int R3){
		
		R[pos] = R1;
		Rtimer[pos] = R3;
	}
}
