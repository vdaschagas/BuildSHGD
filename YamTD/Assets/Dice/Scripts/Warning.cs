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


public class Warning : MonoBehaviour {

	public string msg;
	public int intNote;
	public bool onNote;
	public Text txtWarning;
	float timeNote;
	float alert;
	Color colorTxt = new Color(255f, 255f, 0f, 255f);
	Yam yam_Componets;


	// Use this for initialization
	void Start ()
	{
		yam_Componets = GameObject.Find("app").GetComponent<Yam>();
		txtWarning = GetComponent <Text> ();
		msg = "Use o Menu para começar...";
		timeNote = 0;
		onNote = false;
	}



	// Update is called once per frame
	void Update ()
	{
		if(onNote == true){
			timeNote += 1 * Time.deltaTime;
		}


		if (intNote == 1) {
			if (timeNote > 60) {
				onNote = false;
				timeNote = 0;
				msg = "";
			}
		}

		txtWarning.text = msg;
		if (yam_Componets.beginGame == true) {
			BeginMsg ();
		} else {
			txtWarning.color = colorTxt;
		}
	}



	void BeginMsg()
	{
		alert += 1 * Time.deltaTime;
		txtWarning.color = Color.Lerp(txtWarning.color, Color.clear, 5f * Time.deltaTime);
		if (alert > 2) 
		{
			txtWarning.color = colorTxt;
			alert = 0;
		}
	}


}
