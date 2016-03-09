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


public class Resultados : MonoBehaviour {
	Text txtResult;
	public int coluna;
	public int total;
	StatusPlayer status_Player;
	public const int COL_DOWN = 0;
	public const int COL_UP = 1;
	public const int COL_DESORDEM = 2;
	public const int COL_SECO = 3;



	// Use this for initialization
	void Start () {
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();
		txtResult = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		QResult ();
	}



	//Controle das direcoes na tabela. Identifica se a jogada e permitida
	void QResult()
	{
		switch (coluna) {
		case COL_DOWN:
			if(total == 0){
				txtResult.text = "" + status_Player.T1_Down;
			} 
			if(total == 1){
				txtResult.text = "" + status_Player.T2_Down;
			}
			if(total == 3){
				txtResult.text = "" + status_Player.Bonus_Down;
			}
			break;
			
		case COL_UP:
			if(total == 0){
				txtResult.text = "" + status_Player.T1_Up;
			} 
			if(total == 1){
				txtResult.text = "" + status_Player.T2_Up;
			}
			if(total == 3){
				txtResult.text = "" + status_Player.Bonus_Up;
			}
			break;
			
		case COL_DESORDEM:
			if(total == 0){
				txtResult.text = "" + status_Player.T1_Des;
			} 
			if(total == 1){
				txtResult.text = "" + status_Player.T2_Des;
			}
			if(total == 3){
				txtResult.text = "" + status_Player.Bonus_Des;
			}
			break;
			
		case COL_SECO:
			if(total == 0){
				txtResult.text = "" + status_Player.T1_Seco;
			} 
			if(total == 1){
				txtResult.text = "" + status_Player.T2_Seco;
			}
			if(total == 3){
				txtResult.text = "" + status_Player.Bonus_Seco;
			}
			break;
		}

		if (total == 2) {
			txtResult.text = "" + status_Player.Score;
		}
	}



}
