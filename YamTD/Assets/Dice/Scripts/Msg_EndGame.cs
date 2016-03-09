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

public class Msg_EndGame : MonoBehaviour {

	public string msg;
	public Text txtEnd;


	// Use this for initialization
	void Start ()
	{
		txtEnd = GetComponent <Text> ();
		msg = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		txtEnd.text = msg;
	}
}
