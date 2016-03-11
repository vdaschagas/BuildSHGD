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

public class SaveGame : Inventary {
	StatusPlayer status;
	Inventary numerosDaPartida;
	Yam yamGame;
	int On_Down, On_Up, On_Desordem, On_Seco;
	public bool endSave;
	public bool saveProgress;
	float countLoading;
	SoundEffects sound_button;
	public bool saveExit;


	// Use this for initialization
	void Start () {
		status  = GameObject.Find("app").GetComponent<StatusPlayer>();
		yamGame = GetComponent<Yam>();
		numerosDaPartida = GetComponent<Inventary>();
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		endSave = false;
		saveProgress = false;
		countLoading = 0;
		saveExit = false;
	}





	// Update is called once per frame
	void Update () {
		rodada = numerosDaPartida.rodada;
		jogada = numerosDaPartida.jogada;
		score = numerosDaPartida.score;

		if (saveProgress == true) {
			countLoading += 1 * Time.deltaTime;
			yamGame.rBarProgress.activeBar = true;
		}
		
		
		if (countLoading > 8) {
			saveProgress = false;
			countLoading = 0;
			Partida ();
		}

		if(endSave == true){
			yamGame.endGame.SetActive(false);
			yamGame.go_radialBar.SetActive(false);
			sound_button.AudioEfeitos(10, false);
			endSave = false;
			yamGame.msgCurrent = "";
			yamGame.msg_gamer.Avisos (msgCurrent, true);
			if(saveExit == true){
				saveExit = false;
				Application.Quit ();
			}
		}

	}





	public void SavePlayCurrent()
	{
		saveProgress = true;
		yamGame.rBarProgress.strState = "Salvando...";
		yamGame.rBarProgress.strColor = "Red";
		yamGame.rBarProgress.beginAmount = true;
		yamGame.go_radialBar.SetActive(true);
		Config ();
	}
	
	
	
	
	
	
	void Config()
	{
		//Salvar
		Salvar ("Config_Tipo_Partida", tipo);
		Salvar ("Config_Galeria_Partida", gallery);
		Salvar ("Config_Cor_Partida", cor);
		Salvar ("User_Partida", nome);
		Salvar ("Config_GroupSingle_Partida", GroupSingle);
		if (cor_Random == false){
			Salvar ("Config_Cor_Random_Partida", 0);
		}
		if (cor_Random == true){
			Salvar ("Config_Cor_Random_Partida", 1);
		}

		//RESERVA CONFIG!!!
//		Salvar ("Config_Tipo", "Ponto");
//		Salvar ("Config_Galeria", "d6-red-dots");
//		Salvar ("Config_Cor", "Aleatoria");
//		Salvar ("User", "");
//		Salvar ("Config_GroupSingle", 2);
//		Salvar ("Config_Cor_Random", 1);

	}
	




	
	void Partida()
	{
		Salvar("Pontos_Partida", score);;
		Salvar("Rodada_Partida", rodada);
		Salvar("Jogada_Partida", jogada);
		
		//POSICOES
		Salvar ("posDado1", yamGame.v3Dado [1]);
		Salvar ("posDado2", yamGame.v3Dado [2]);
		Salvar ("posDado3", yamGame.v3Dado [3]);
		Salvar ("posDado4", yamGame.v3Dado [4]);
		Salvar ("posDado5", yamGame.v3Dado [5]);
		
		Salvar ("rotaDado1", yamGame.v3Rota [1]);
		Salvar ("rotaDado2", yamGame.v3Rota [2]);
		Salvar ("rotaDado3", yamGame.v3Rota [3]);
		Salvar ("rotaDado4", yamGame.v3Rota [4]);
		Salvar ("rotaDado5", yamGame.v3Rota [5]);
		



		//STATUS
		//VALORES
		for(int i=0; i < status.valueDOWN.Length; i++){
			Salvar("valueDOWN"+i, status.valueDOWN[i]);
		}
		for(int i=0; i < status.valueUP.Length; i++){
			Salvar("valueUP"+i, status.valueUP[i]);
		}
		for(int i=0; i < status.valueDESORDEM.Length; i++){
			Salvar("valueDESORDEM"+i, status.valueDESORDEM[i]);
		}
		for(int i=0; i < status.valueSECO.Length; i++){
			Salvar("valueSECO"+i, status.valueSECO[i]);
		}
		//BOOLEAN
		for(int i=0; i < status.onDOWN.Length; i++){
			if(status.onDOWN[i] == true){
				On_Down = 1;
			} else {
				On_Down = 0;
			}
			Salvar("OnDOWN"+i, On_Down);
		}

		for(int i=0; i < status.onUP.Length; i++){
			if(status.onUP[i] == true){
				On_Up = 1;
			} else {
				On_Up = 0;
			}
			Salvar("OnUP"+i, On_Up);
		}

		for(int i=0; i < status.onDESORDEM.Length; i++){
			if(status.onDESORDEM[i] == true){
				On_Desordem = 1;
			} else {
				On_Desordem = 0;
			}
			Salvar("OnDESORDEM"+i, On_Desordem);
		}

		for(int i=0; i < status.onSECO.Length; i++){
			if(status.onSECO[i] == true){
				On_Seco = 1;
			} else {
				On_Seco = 0;
			}
			Salvar("OnSECO"+i, On_Seco);
		}
		
		Salvar ("tdPlay", status.tdPlay);
		Salvar ("numberRoll", status.numberRoll);
		Salvar ("PartidaSalva", 1);
		endSave = true;
	}

}
