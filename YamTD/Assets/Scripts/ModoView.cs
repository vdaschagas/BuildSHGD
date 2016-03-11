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
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ModoView : MonoBehaviour {
	private const int MODE_GALLERY = 1;
	private const int MODE_ROLL = 2;
	private const int MODE_CARD = 3;

	public int btnModo;
	Yam qmodo;
	Mensagem msg_gamer;
	string msgCurrent;
	StatusPlayer status_Lauch;
	Inventary inventario;
	int jogadaCurrent;
	SoundEffects sound_button;
	SaveGame salvar;
//	private Button button;
//	bool activeCreditos;
	public bool sair;
	bool buttonEventEnter;
	MenuEvent btn_menu;
	bool menuShow;

	public int frac = 4;
	
	//Private Variables
	public float fracScreenWidth;
	public float widthMinusFrac;
	private Vector2 touchCache;
	private Vector2 touchPos;
	public bool touchedLeft = false;
	public bool touchedRight = false;
	private int screenWidth;
	private Vector2 mouseCache;
	private Vector2 mousePos;
//	Touch touch;
//	private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.


	// Use this for initialization
	void Start () {
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		qmodo = GameObject.Find("app").GetComponent<Yam>();
		msg_gamer = GameObject.Find ("Canvas").GetComponent<Mensagem> ();
		status_Lauch  = GameObject.Find("app").GetComponent<StatusPlayer>();
		inventario  = GameObject.Find("app").GetComponent<Inventary>();
		salvar = GameObject.Find("app").GetComponent<SaveGame>();
		jogadaCurrent = 0;
//		button = GetComponent<Button>();
//		activeCreditos = false;
		sair = false;
		buttonEventEnter = false;
		btn_menu = GameObject.Find ("MenuBar").GetComponentInChildren<MenuEvent>();
		btn_menu.MenuOpen = false;
		menuShow = btn_menu;
		screenWidth = Screen.width;
		fracScreenWidth = screenWidth / frac;
	}
	


	// Update is called once per frame
	void Update () {
		if (menuShow == true) {
			jogadaCurrent = inventario.jogada;

			if (buttonEventEnter == true) {
				buttonEventEnter = false;
				sound_button.AudioEfeitos (11, false);
			}
		}
		ChkTouch();

	}










	public void OnMouseEnter()
	{
		buttonEventEnter = true;
	}



	public void OnMouseDown()
	{
		sound_button.AudioEfeitos (9, false);
		CloseMenu ();
	}
	


	void CloseMenu()
	{
		btn_menu.content_menu.SetActive (false);
		btn_menu.MenuOpen = false;
	}



	public void OnMouseUp()
	{
		if (qmodo.beginGame == false) {
			if (btnModo == 12) {
				qmodo.SetMode (MODE_ROLL);
				btn_menu.txtButtonGame.text = "Novo";
			}

			if (btnModo == 13) {
				qmodo.SetMode(MODE_CARD);
			}

		}

	}




	void ChkTouch()
	{

		if (Input.GetMouseButton (0)) {
			//Cache mouse position
			mouseCache = Input.mousePosition;
			//If mouse x position is less than or equal to a fraction of the screen width
			if (mouseCache.x > mousePos.x && (mouseCache.x - mousePos.x) >= fracScreenWidth) {
				touchedLeft = true;
			}

			if (mouseCache.x < mousePos.x && (mousePos.x - mouseCache.x) >= fracScreenWidth) {
				touchedRight = true;
			}

		} else {
			mousePos = Input.mousePosition;
		}

	}



	public void BotaoSelecionado()
	{
		//Configurar
		if (btnModo == 1) {
			qmodo.SetMode(MODE_GALLERY);
			if(btn_menu.txtButtonGame.text == "Novo"){
				btn_menu.txtButtonGame.text = "Jogo";
			}
		}

		//Jogar
		if (btnModo == 2) {
			OpcaoBtnJogar();
		}

		//Carregar
		if (btnModo == 4) {
			inventario.loadPosition = true;
			if(btn_menu.txtButtonGame.text == "Jogo"){
				btn_menu.txtButtonGame.text = "Novo";
			}
		}

		//Salvar
		if (btnModo == 5) {
			if(inventario.jogada != 0){
				msgCurrent = "Aguarde...";
				salvar.SavePlayCurrent();
			} else {
				msgCurrent = "Nenhuma partida em curso...";
				sound_button.AudioEfeitos(5, false);
			}
			msg_gamer.Avisos (msgCurrent, true);
		}


		if (btnModo == 6) {
			qmodo.SetMode(MODE_CARD);
		}


		//Sair
		//Mostrar imagem com botoes sim e nao para salvar a partida em curso ou cancelar a saida do jogo...
		if (btnModo == 8) {
			if(inventario.jogada == 0){
				Application.Quit();
			} else {
				qmodo.imgsButtonsYesNo.SetActive (true);
			}
		}

		//SAIR E SALVAR A PARTIDA
		if (btnModo == 9) {
			qmodo.imgsButtonsYesNo.SetActive (false);
			msgCurrent = "Aguarde...";
			msg_gamer.Avisos (msgCurrent, true);
			sound_button.AudioEfeitos(10, false);
			salvar.saveExit = true;
			salvar.SavePlayCurrent();
		}

		//SAIR SEM SALVAR A PARTIDA
		if (btnModo == 10) {
			Application.Quit ();
		}

		//CANCELAR A SAIDA
		if (btnModo == 11) {
			qmodo.imgsButtonsYesNo.SetActive (false);
		}
		

	}





	void OpcaoBtnJogar()
	{
		if(btn_menu.txtButtonGame.text == "Jogo"){
			msgCurrent = "";
			msg_gamer.Avisos (msgCurrent, true);
			qmodo.SetMode(MODE_ROLL);
			btn_menu.txtButtonGame.text = "Novo";
			goto pulaBotao;
		}
		
		if(btn_menu.txtButtonGame.text == "Novo"){
			Application.LoadLevel ("YamGame");
			btn_menu.txtButtonGame.text = "Jogo";
			goto pulaBotao;
		}
	pulaBotao:;

	}
	




	public void RodarDados()
	{
		if (btnModo == 3) {
			if (status_Lauch.numberRoll == 3 && status_Lauch.onlyFirst == false || status_Lauch.numberRoll == 1 && status_Lauch.onlyFirst == true) {
				msgCurrent = "Marque os pontos...";
				msg_gamer.Avisos (msgCurrent, true);
				sound_button.AudioEfeitos (5, false);
				goto jumpItens;
			}
			
			if (status_Lauch.numberRoll < 3 && status_Lauch.onlyFirst == false) {
				qmodo.SetMode(MODE_ROLL);
				qmodo.LANCE_OS_DADOS();
				msgCurrent = "Selecione os dados ou marque os pontos...";
				jogadaCurrent += 1;
				inventario.jogada = jogadaCurrent;
				msg_gamer.Avisos (msgCurrent, true);
				sound_button.AudioEfeitos (0, false);
			}

			if (status_Lauch.numberRoll < 1 && status_Lauch.onlyFirst == true) {
				qmodo.SetMode(MODE_ROLL);
				qmodo.LANCE_OS_DADOS();
				jogadaCurrent += 1;
				inventario.jogada = jogadaCurrent;
				sound_button.AudioEfeitos (0, false);
			}

		jumpItens:;


		}
	}

}
