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

public class ViewInventary : MonoBehaviour {
	Text txtInventary;
	public int Id;
	Inventary inventario;
	string txtJogada;
	string txtRodada;
	
	
	// Use this for initialization
	void Start () {
		txtInventary = GetComponent <Text> ();
		inventario = GameObject.Find("app").GetComponent<Inventary>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (Id) {
		case 1:
			txtInventary.text = "" + inventario.nome;
			break;

		case 2:
			txtInventary.text = "Pontos: " + inventario.score;
			break;

		case 3:
			if(inventario.rodada > 0){txtRodada = "ª - Rodada";} else {txtRodada = "";}
			txtInventary.text = "" + inventario.rodada + txtRodada;
			break;
			
		case 4:
			if(inventario.jogada > 1){txtJogada = " - Jogadas";} else {txtJogada = " - Jogada";}
			txtInventary.text = "" + inventario.jogada + txtJogada;
			break;
			
		case 5:
			txtInventary.text = "" + inventario.tipo;
			break;
			
		case 6:
			txtInventary.text = "" + inventario.cor;
			break;
			
		case 7:
			if(inventario.totalDePontos[0] != 0 && inventario.nomeJogadores[0] != ""){
			txtInventary.text = "" + inventario.totalDePontos[0] + " - " + inventario.nomeJogadores[0];
			} else {
				txtInventary.text = "";
			}
			break;
			
		case 8:
			if(inventario.totalDePontos[1] != 0 && inventario.nomeJogadores[1] != ""){
			txtInventary.text = "" + inventario.totalDePontos[1] + " - " + inventario.nomeJogadores[1];
			} else {
				txtInventary.text = "";
			}
			break;
			
		case 9:
			if(inventario.totalDePontos[2] != 0 && inventario.nomeJogadores[2] != ""){
			txtInventary.text = "" + inventario.totalDePontos[2] + " - " + inventario.nomeJogadores[2];
			} else {
				txtInventary.text = "";
			}
			break;
			

		}
	}



}
