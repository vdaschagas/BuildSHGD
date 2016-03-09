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

//Controla o numero da jogada em cada rodada
public class NumberPlay : MonoBehaviour {

	Text txtMaxPlay;
	Yam yam_de;
	public Image[] imgNumber;

	
	
	// Use this for initialization
	void Start () {
		txtMaxPlay = GetComponent <Text> ();
		yam_de = GameObject.Find("app").GetComponent<Yam>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		txtMaxPlay.text = "DE ";
		if (yam_de.play_X == 1) {
			imgNumber [0].color = new Color (255, 255, 255, 255);
			imgNumber [1].color = new Color (255, 255, 255, 0);
		}
		if (yam_de.play_X == 3) {
			imgNumber [0].color = new Color (255, 255, 255, 0);
			imgNumber [1].color = new Color (255, 255, 255, 255);
		}

	}
}
