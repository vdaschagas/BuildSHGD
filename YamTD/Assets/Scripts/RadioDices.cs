using UnityEngine;
using System.Collections;

public class RadioDices : MonoBehaviour {
	public bool isPress;
	Yam yam_components;
	public int number;
	StatusPlayer status_Player;
	SoundEffects sound_button;
	Mensagem msg_gamer;
	public GameObject radioPress;
	string msgCurrent;


	// Use this for initialization
	void Start () {
		yam_components = GameObject.Find("app").GetComponent<Yam>();
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		msg_gamer = GameObject.Find ("Canvas").GetComponent<Mensagem> ();
		isPress = false;
		radioPress.SetActive(false);
	}



	// Update is called once per frame
	void Update () {

		radioPress.SetActive (yam_components.selectedDICE [number]);
		isPress = yam_components.selectedDICE [number];
	}



	public void RadioPress()
	{
		if (status_Player.numberRoll > 0 && status_Player.numberRoll < 3) {
			sound_button.AudioEfeitos (9, false);
			isPress = !isPress;
			radioPress.SetActive(isPress);
			yam_components.selectedDICE [number] = isPress;
			if(number != 0){
				yam_components.selectedDICE [0] = false;
			} else {
				for(int nbDices = 1; nbDices < 6; nbDices++){
					yam_components.selectedDICE [nbDices] = false;
					yam_components.diceSequence[nbDices].GetComponent<Renderer> ().material.color = Color.white;
				}
				yam_components.selectedDICE [0] = true;
			}
			if (isPress) {
				yam_components.diceSequence[number].GetComponent<Renderer> ().material.color = Color.grey;
			} else {
				yam_components.selectedDICE [0] = true;
				yam_components.diceSequence[number].GetComponent<Renderer> ().material.color = Color.white;
			}
		} else {
			sound_button.AudioEfeitos (5, false);
			if(status_Player.numberRoll == 0){
				msgCurrent = "LANCE OS DADOS!!!";
			}
			if(status_Player.numberRoll == 3){
				msgCurrent = "Marque os pontos...";
			}
			msg_gamer.Avisos (msgCurrent, true);
			
		}

	}

}
