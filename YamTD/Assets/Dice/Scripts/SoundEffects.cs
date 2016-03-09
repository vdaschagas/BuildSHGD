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

public class SoundEffects : MonoBehaviour {
	AudioSource pathAudio;
	public AudioClip[] AudioList;
	AudioSource musicBackGround;
	Inventary inventario;


	// Use this for initialization
	void Start () {
		pathAudio = GetComponent<AudioSource>();
		musicBackGround = GameObject.Find("platform").GetComponent<AudioSource>();
		inventario = GameObject.Find("app").GetComponent<Inventary>();

	}


	// Update is called once per frame
	void Update () {
		RegulagemDoAudio ();
	}



	//Com e sem audio
	public void RegulagemDoAudio()
	{
		if (inventario.button_press [5] == true) {
			musicBackGround.mute = false;
			pathAudio.mute = false;
			musicBackGround.volume = (inventario.volume / 1000);
			pathAudio.volume = (inventario.volume / 100);
		}

		if (inventario.button_press [5] == false) {
			musicBackGround.mute = true;
			pathAudio.mute = true;
		}



	}




	//Metodo para audios
	public void AudioEfeitos(int Qsom, bool variasVezes){
		pathAudio.clip = AudioList [Qsom];
		pathAudio.loop = variasVezes;
		pathAudio.Play ();
		
	}



}
