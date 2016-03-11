/**
* Copyright (c) 2015, Chagas Valter Developer
* All rights reserved.
*
* ESTE SOFTWARE É FORNECIDO PELA SIMPLE HOUSE GAME DEVELOPMENT.
* EM NENHUM CASO A "SIMPLE HOUSE GAME DEVELOPMENT" SERÁ RESPONSÁVEL POR QUAISQUER
* DIRETO, INDIRETO, ACIDENTAL, ESPECIAL, EXEMPLAR OU CONSEQUENTE
* (INCLUINDO, SEM LIMITAÇÕES, A AQUISIÇÃO DE BENS OU SERVIÇOS;
* PERDA DE USO, DADOS OU LUCROS; OU INTERRUPÇÃO DE NEGÓCIOS) CAUSADOS E
* EM QUALQUER TEORIA DE RESPONSABILIDADE, SEJA EM CONTRATO, RESPONSABILIDADE OBJETIVA OU
* (INCLUINDO NEGLIGÊNCIA OU NÃO) LEVANTADA DE QUALQUER FORMA DE USO DESTE
* SOFTWARE, MESMO QUE AVISADO SOBRE A POSSIBILIDADE DE TAIS DANOS.
*/


using UnityEngine;
using System.Collections;

public class MoveDado : MonoBehaviour {
//	Vector3 screenPoint;
//	Transform scanPos;
//	Vector3 offset;
	Yam selected_button;
	Inventary inventario;
	public int count;
	StatusPlayer status_Player;
	SoundEffects sound_button;
	AudioSource audioForDice;
	GameObject table;
	GameObject wallFront;
	GameObject wallLeft;
	bool loading;
	bool isRed;


	// Use this for initialization
	void Start () {
//		scanPos = GetComponent<Transform> ();
		selected_button = GameObject.Find("app").GetComponent<Yam>();
		inventario = GameObject.Find("app").GetComponent<Inventary>();
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		table = GameObject.FindGameObjectWithTag("Tablado");
		wallFront = GameObject.FindGameObjectWithTag("MuroFrontal");
		wallLeft = GameObject.FindGameObjectWithTag("MuroEsquerda");
		audioForDice = GetComponent<AudioSource>();
		audioForDice.mute = true;
		count = 0;
	}


	// Update is called once per frame
	void Update () {
		loading = selected_button.endGame.activeSelf;
		if (inventario.button_press [5] == true) {
			audioForDice.mute = false;
		} else {
			audioForDice.mute = true;
		}

	}



	public GameObject cube;
	
	

	//Seleciona dados individualmente
	void OnMouseDown()
	{
//		screenPoint = Camera.main.WorldToScreenPoint(scanPos.position);
//		
//		offset = scanPos.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Die_d6 dd = GetComponent<Die_d6>();
		count = 0;
		if (status_Player.numberRoll > 0 && status_Player.numberRoll < 3) {
			isRed = selected_button.selectedDICE [dd.number];
			isRed = !isRed;
			if (isRed) {
				GetComponent<Renderer> ().material.color = Color.grey;
			} else {
				GetComponent<Renderer> ().material.color = Color.white;
			}

			selected_button.selectedDICE [dd.number] = !selected_button.selectedDICE [dd.number];
			selected_button.selectedDICE [0] = false;
			for (int b = 1; b < selected_button.selectedDICE.Length; b++) {
				if (selected_button.selectedDICE [b] == true) {
					count += 1;
				} 
			}
			sound_button.AudioEfeitos (9, false);
		} else {
			if(status_Player.numberRoll == 0){
				selected_button.msgCurrent = "LANCE OS DADOS!!!";
			}
			if(status_Player.numberRoll == 3){
				selected_button.msgCurrent = "Marque os pontos...";
			}
			selected_button.msg_gamer.Avisos(selected_button.msgCurrent, true);
			sound_button.AudioEfeitos (5, false);
		}


		if (count == 0) {
			selected_button.selectedDICE [0] = true;
		}

	}







	void OnTriggerEnter(Collider other){
		if (loading == true) {
			return;
		} else {
			if (other.gameObject == table || other.gameObject == wallFront || other.gameObject == wallLeft) {
				sound_button.AudioEfeitos (2, false);
			}
		}
	}
	

}
