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

public class Mensagem : MonoBehaviour {
	public bool warning;
	public string message;
	Animator anim;
	Warning warningFlash;
	Warning _note;
	float timerScreen;
	public float grandTimer;
	GameObject msgGO;
	
	
	void Start()
	{
		anim = GetComponent<Animator>();
		warning = false;
		warningFlash = GameObject.Find ("txtMsg").GetComponent<Warning> ();
		_note = GameObject.Find ("txtNote").GetComponent<Warning> ();
		msgGO = GameObject.Find ("MsgFlash");
		timerScreen = 0;
	}
	
	
	void Update()
	{
		//Se aviso for passado como verdadeiro, imprime a mensagem na tela atraves de uma animacao
		if (warning == true) {
			msgGO.SetActive(true);
			warningFlash.msg = message;
			anim.SetBool ("onScreen", true);
			timerScreen += 1 * Time.deltaTime;
			if(timerScreen > grandTimer){
				warning = false;
				_note.onNote = true;
				_note.msg = message;
				anim.SetBool ("onScreen", false);
				timerScreen = 0;
				msgGO.SetActive(false);
			}
		}
		
	}





	public void Avisos(string msgScreen, bool active)
	{
		message = msgScreen;
		warning = true;
		
	}
	


}
