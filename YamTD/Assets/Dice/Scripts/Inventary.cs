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
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Inventary : SaveLoad {
	public string nome;
	public int score;
	public int rodada;
	public int jogada;
	public bool gameOver;

	public string tipo;
	public string gallery;
	public string cor;
	public int[] totalDePontos;
	public string[] nomeJogadores;
	public bool cor_Random;
	public bool[] button_press;
	public int GroupSingle;
	public bool audioOn;
	public float volume;
	
	private const int RANDOM_SINGLE = 1;
	private const int RANDOM_GROUP = 2;

	public int[] playCurrent;
	float alertButton;
	Color flashColor = new Color(255f, 255f, 255f, 255f);
	Image borderPlayer;
	Image borderButton;

	StatusPlayer status_Player;
	Yam yam_Componets;
	Loading loading_game;

	bool LerTipo;
	public bool loadPosition;
	Slider slider_volume;
	public string msgCurrent;
	int tempAudio;
	public GameObject particleSmoke;


	// Use this for initialization
	void Start () {
		totalDePontos = new int[3];
		playCurrent = new int[6];
		nomeJogadores = new string[3];
		button_press = new bool[6];
		rodada = 0;
		jogada = 0;
		score = 0;
		yam_Componets = GameObject.Find("app").GetComponent<Yam>();
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();
		borderButton = GameObject.Find ("Mold_Button").GetComponent<Image> ();
		borderPlayer = GameObject.Find ("L_Mold").GetComponent<Image> ();

		gameOver = false;
		LerTipo = false;
		loadPosition = false;

		slider_volume = GameObject.FindGameObjectWithTag("sliderVolume").GetComponent<Slider>();
		loading_game = GetComponent<Loading>();


		if (PlayerPrefs.GetFloat ("AudioVolume") != 0) {
			slider_volume.value = CarregarFloat ("AudioVolume");
		} else {
			slider_volume.value = 100f;
		}

		if (PlayerPrefs.GetString ("Config_Tipo") != "") {
			Configurado ();
			LerTipo = true;
		} else {
			audioOn = true;
			button_press [5] = audioOn;
		}
		Buttons_Selected ();
	}




	// Update is called once per frame
	void Update () {
		FlashLightButton ();
		ListarRecordes ();
		if (LerTipo == true) {
			Configurado();
		}
		if (loadPosition == true) {
			loadPosition = false;
			CarregarPosicoesDosDados();
		}

	}





	public void CarregarPosicoesDosDados()
	{
		loading_game.LoadGame ();
	}






	public void Buttons_Selected()
	{
		if (CarregarInteiro("Config_Cor_Random") == 1) {
			button_press [0] = true;
			if (CarregarInteiro("Config_GroupSingle") == RANDOM_GROUP) {
				button_press [1] = true;
				button_press [2] = false;
				Salvar("Config_GroupSingle", RANDOM_GROUP);
			}
			if (CarregarInteiro("Config_GroupSingle") == RANDOM_SINGLE) {
				button_press [1] = false;
				button_press [2] = true;
				Salvar("Config_GroupSingle", RANDOM_SINGLE);
			}
			Salvar("Config_Cor_Random", 1);
		} else {
			button_press [0] = false;
			button_press [1] = false;
			button_press [2] = false;
			Salvar("Config_Cor_Random", 0);
			Salvar("Config_GroupSingle", RANDOM_GROUP);
		}

		//Tipo
		string tipoTemp = CarregarString ("Config_Tipo");
		if(tipoTemp == "Ponto"){
			button_press [3] = true;
			button_press [4] = false;
			Salvar ("Config_Tipo", "Ponto");
		} else {
			button_press [3] = false;
			button_press [4] = true;
			Salvar ("Config_Tipo", "Numero");
			Salvar ("Config_Galeria", "d6-red");
		}


		//Audio
		button_press [5] = audioOn;
		volume = slider_volume.value;
		Salvar ("AudioVolume", volume);
		Salvar ("Config_Audio", 1);
		LerTipo = true;

	}





	void Configurado()
	{
		tipo = CarregarString("Config_Tipo");

		gallery = CarregarString("Config_Galeria");

		cor = CarregarString("Config_Cor");
		cor_Random = CarregarBoolean("Config_Cor_Random");
		tempAudio = CarregarInteiro("Config_Audio");
		if (tempAudio != null || tempAudio.ToString() != "") {
			audioOn = CarregarBoolean ("Config_Audio");
		} else {
			audioOn = true;
		}
		volume = slider_volume.value;

		nome = CarregarString ("User");

		GroupSingle = CarregarInteiro ("Config_GroupSingle");
	}





	public void ListarRecordes()
	{
		nomeJogadores [0] = CarregarString("Save1");
		totalDePontos [0] = CarregarInteiro ("Save_P1");

		nomeJogadores [1] = CarregarString ("Save2");
		totalDePontos [1] = CarregarInteiro ("Save_P2");

		nomeJogadores [2] = CarregarString ("Save3");
		totalDePontos [2] = CarregarInteiro ("Save_P3");
	}





	void FlashLightButton()
	{
		if (status_Player.numberRoll != 0) { 
			alertButton += 1 * Time.deltaTime;
			borderPlayer.color = Color.Lerp(borderPlayer.color, Color.clear, 5f * Time.deltaTime);
			if (alertButton > 2) 
			{
				borderPlayer.color = flashColor;
				alertButton = 0;
			}
		}

		if (status_Player.numberRoll == 0) {
			alertButton += 1 * Time.deltaTime;
			borderButton.color = Color.Lerp(borderButton.color, Color.clear, 5f * Time.deltaTime);
			if (alertButton > 2) 
			{
				borderButton.color = flashColor;
				alertButton = 0;
			}
		}
	}




}
