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

public class ClearScores : MonoBehaviour {
	Inventary inventario;


	// Use this for initialization
	void Start () {
		inventario = GameObject.Find("app").GetComponent<Inventary>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Remove todos os recordes da lista
	public void LimparRecordes()
	{
		inventario.Salvar("Save_P1", 0);
		inventario.Salvar("Save1", "");
		inventario.Salvar("Save_P2", 0);
		inventario.Salvar("Save2", "");
		inventario.Salvar("Save_P3", 0);
		inventario.Salvar("Save3", "");

		inventario.nomeJogadores [0] = inventario.CarregarString("Save1");
		inventario.totalDePontos [0] = inventario.CarregarInteiro ("Save_P1");
		inventario.nomeJogadores [1] = inventario.CarregarString ("Save2");
		inventario.totalDePontos [1] = inventario.CarregarInteiro ("Save_P2");
		inventario.nomeJogadores [2] = inventario.CarregarString ("Save3");
		inventario.totalDePontos [2] = inventario.CarregarInteiro ("Save_P3");

	}


}
