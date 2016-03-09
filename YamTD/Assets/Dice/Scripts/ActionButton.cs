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
using UnityEngine.UI;


public class ActionButton : MonoBehaviour {
	public Text txtButton;
	public int coluna;
	public int linha;
	StatusPlayer status_Player;
	public bool markResult;
	SoundEffects sound_button;
	Mensagem msg_gamer;
	string msgCurrent;
	bool buttonValid;
	Yam diceselected;


	// Use this for initialization
	void Start () {
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();
		diceselected  = GameObject.Find("app").GetComponent<Yam>();
		markResult = false;
		msg_gamer = GameObject.Find ("Canvas").GetComponent<Mensagem> ();
		buttonValid = false;

	}




	// Update is called once per frame
	void Update () {
		if (markResult == true && status_Player.isValidate == true) {
			markResult = false;
			txtButton.text = "" + status_Player.soma;
		} else {
			status_Player.buttonPress = false;
			markResult = false;
		}
	}





	public void CalcDices()
	{
		if (posCurrentValid (coluna) == true) {
			if (status_Player.numberRoll > 0) {
				txtButton.text = "";
				status_Player.buttonPress = true;
				status_Player.linha = linha;
				status_Player.coluna = coluna;
				markResult = true;
				diceselected.DiceFullSelection();
			} else {
				sound_button.AudioEfeitos (5, false);
				msgCurrent = "LANCE OS DADOS!!!";
				msg_gamer.Avisos (msgCurrent, true);
			}
		} else {
			sound_button.AudioEfeitos (5, false);
		}
	}







	bool posCurrentValid(int col)
	{
		switch (col) {
		case 0:
			if (status_Player.onDOWN [linha - 1] == true) {
				buttonValid = true;
			} else {buttonValid = false;}
			break;
			
		case 1:
			if (status_Player.onUP [linha - 1] == true) {
				buttonValid = true;
			} else {buttonValid = false;}
			break;
			
		case 2:
			if (status_Player.onDESORDEM [linha - 1] == true) {
				buttonValid = true;
			} else {buttonValid = false;}
			break;
			
		case 3:
			if (status_Player.onSECO [linha - 1] == true) {
				buttonValid = true;
			} else {buttonValid = false;}
			break;
		}
		return buttonValid;
	}





}
