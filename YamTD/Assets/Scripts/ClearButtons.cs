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


public class ClearButtons : MonoBehaviour {
	public bool cleaning;
	public Text[] txtClearButtons = new Text[52];
	public Button[] btnClear;
	Inventary inventario;



	// Use this for initialization
	void Start () {
		cleaning = false;
		txtClearButtons = GameObject.Find("BotoesTabela").GetComponentsInChildren<Text>();
		inventario  = GameObject.Find("app").GetComponent<Inventary>();

		beginButtons ();
	}



	// Update is called once per frame
	void Update () {
		if (inventario.gameOver == true) {
			beginButtons ();
		}
	
	}




	//Limpa os valores registrados nos botoes da tabela do jogo
	public void beginButtons()
	{
		for (int b = 0; b < txtClearButtons.Length; b++) {
			txtClearButtons[b].text = "";
		}
	}



}
