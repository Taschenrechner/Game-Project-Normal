using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public bool frozen = false;
	public Vector3 target;
	private bool keypress = false;
	
	void Start(){
		//Initialisieren
		target = transform.position;
		this.GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mastervol * GameObject.Find("EventSystem").GetComponent<PublicVariables>().soundvol;
	}
	
	
	void Update(){
		//sorgt dafür, dass sich die Spielfigur bewegt. Überprüft auch, ob mit Maus oder Tastatur gesteuert wird
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().OptionP.gameObject.activeSelf == true){
			this.GetComponent<AudioSource>().volume = GameObject.Find("SoundSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
		}
		if (Input.anyKey){
			if(Input.GetMouseButton(0) || Input.GetMouseButton(2)){
			}
			else {
				keypress = true;
			}
		}
		var x = Input.GetAxis("Horizontal") * GameObject.Find("EventSystem").GetComponent<PublicVariables>().speedmod * 0.1f;
		if (frozen == true || GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == true || GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == true){
			x = 0;
		}
		var y = Input.GetAxis("Vertical") * GameObject.Find("EventSystem").GetComponent<PublicVariables>().speedmod * 0.1f;
		if (frozen == true || GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == true || GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == true){
			y = 0;
		}
		if (x != 0 && y != 0){
			x = x * 0.7f;
			y = y * 0.7f;
		}
		if (x > 0){
			GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (x < 0){
			GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = false;
		}
		if ((x != 0 || y != 0) && (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater == true || (Mathf.Abs(GameObject.Find("E6").transform.position.x - GameObject.Find("Player").transform.position.x) + (Mathf.Abs(GameObject.Find("E6").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 2.5))){
			if (this.GetComponent<AudioSource>().isPlaying == false){
				this.GetComponent<AudioSource>().Play(0);
			}
		}
		transform.Translate(x, y, 0);
		if (Input.GetMouseButtonDown(0) && frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			keypress = false;
			if (target.y < -13){
				target.y = -13;
			}
			else if (target.y > 13){
				target.y = 13;
			}
			if (target.x > GameObject.Find("Player").transform.position.x){
				GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = true;
			}
			else if (target.x < GameObject.Find("Player").transform.position.x){
				GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX = false;
			}
		}
		if ((target.x != GameObject.Find("Player").transform.position.x || target.y != GameObject.Find("Player").transform.position.y) && (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater == true || (Mathf.Abs(GameObject.Find("E6").transform.position.x - GameObject.Find("Player").transform.position.x) + (Mathf.Abs(GameObject.Find("E6").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 2.5))){
			if (this.GetComponent<AudioSource>().isPlaying == false && frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
				this.GetComponent<AudioSource>().Play(0);
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater != true && (Mathf.Abs(GameObject.Find("E6").transform.position.x - GameObject.Find("Player").transform.position.x) + (Mathf.Abs(GameObject.Find("E6").transform.position.y - GameObject.Find("Player").transform.position.y)) > 2.5)){
			this.GetComponent<AudioSource>().Stop();
		}
		if (keypress == false && frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			transform.position = Vector3.MoveTowards(transform.position, target, GameObject.Find("EventSystem").GetComponent<PublicVariables>().speedmod * 0.1f);
			if(GameObject.Find("EventSystem").GetComponent<PublicVariables>().clickbreak == true){
				target = transform.position;
			}
		}
	}
}