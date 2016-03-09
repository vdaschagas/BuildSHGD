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

public class Loading : Inventary {

	public Vector3 posicaoDado1;
	public Vector3 posicaoDado2;
	public Vector3 posicaoDado3;
	public Vector3 posicaoDado4;
	public Vector3 posicaoDado5;
	
	public Vector3 rotacaoDado1;
	public Vector3 rotacaoDado2;
	public Vector3 rotacaoDado3;
	public Vector3 rotacaoDado4;
	public Vector3 rotacaoDado5;
	GameObject[] newPosDice;
	string tipo_Temp;
	string gallery_Temp;
	string cor_Temp;
	string nome_Temp;
	int GroupSingle_Temp;
	int cor_Random_Temp;
	//STATUS
	public int[] valueDOWN_Partida;
	public int[] valueUP_Partida;
	public int[] valueDESORDEM_Partida;
	public int[] valueSECO_Partida;
	
	public bool[] onDOWN_Partida;
	public bool[] onUP_Partida;
	public bool[] onDESORDEM_Partida;
	public bool[] onSECO_Partida;
	
	public int tdPlay_Partida;
	public int numberRoll_Partida;
	ActionButton[] botoesTabela;
	int LinhasC0, LinhasC1, LinhasC2, LinhasC3;
	StatusPlayer status;
	ClearButtons apagarTabela;
	Inventary numerosDaPartida;
	Image fundoAzul;
	Yam yamGame;
	float countLoading;
	float valueSlider;
	bool beginLoad;
	bool loadInverntaryNow;
	SoundEffects sound_button;
	bool endLoad;
	
	
	// Use this for initialization
	void Start () {
		valueUP_Partida = new int[13];
		valueDOWN_Partida = new int[13];
		valueDESORDEM_Partida = new int[13];
		valueSECO_Partida = new int[13];
		
		onUP_Partida = new bool[13];
		onDOWN_Partida = new bool[13];
		onDESORDEM_Partida = new bool[13];
		onSECO_Partida = new bool[13];
		status  = GameObject.Find("app").GetComponent<StatusPlayer>();
		botoesTabela = GameObject.Find("BotoesTabela").GetComponentsInChildren<ActionButton>();
		apagarTabela = GameObject.Find("BotoesTabela").GetComponent<ClearButtons>();
		numerosDaPartida = GetComponent<Inventary>();
		yamGame = GetComponent<Yam>();
		beginLoad = false;
		loadInverntaryNow = false;
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		endLoad = false;
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		newPosDice = GameObject.FindGameObjectsWithTag ("Dado");
		if (beginLoad == true || loadInverntaryNow == true) {
			countLoading += 1 * Time.deltaTime;
			yamGame.rBarProgress.activeBar = true;
		}

		
		if (countLoading > 2 && beginLoad == true) {
			beginLoad = false;
			countLoading = 0;
			yamGame.LANCE_OS_DADOS ();
			loadInverntaryNow = true;
		}
		
		if (countLoading > 7) {
			loadInverntaryNow = false;
			countLoading = 0;
			Config ();
			Partida ();
		}

		if(endLoad == true){
			yamGame.endGame.SetActive(false);
			yamGame.go_radialBar.SetActive(false);
			sound_button.AudioEfeitos(10, false);
			endLoad = false;
		}

	}
	
	
	
	public void LoadGame()
	{
		if (CarregarInteiro ("PartidaSalva") == 1) {
			yamGame.SetMode (2);
			LinhasC0 = 0;
			LinhasC1 = 0;
			LinhasC2 = 0;
			LinhasC3 = 0;
			beginLoad = true;
			valueSlider = 0;
			yamGame.endGame.SetActive (true);
			msgCurrent = "";
			yamGame.msg_gamer.Avisos (msgCurrent, true);
			yamGame.rBarProgress.strState = "Carregando...";
			yamGame.rBarProgress.strColor = "White";
			yamGame.rBarProgress.beginAmount = true;
			yamGame.go_radialBar.SetActive(true);
		} else {
			msgCurrent = "Nenhuma partida foi salva...";
			yamGame.msg_gamer.Avisos (msgCurrent, true);
		}
	}
	
	
	
	
	
	
	void Config()
	{
		//Carrega
		tipo_Temp = CarregarString("Config_Tipo_Partida");
		gallery_Temp = CarregarString("Config_Galeria_Partida");
		cor_Temp = CarregarString("Config_Cor_Partida");
		nome_Temp = CarregarString ("User_Partida");
		GroupSingle_Temp = CarregarInteiro("Config_GroupSingle_Partida");
		cor_Random_Temp = CarregarInteiro("Config_Cor_Random_Partida");
		
		//Salvar em...
		if (tipo_Temp != "") {
			Salvar ("Config_Tipo", tipo_Temp);
		}
		if (gallery_Temp != "") {
			Salvar ("Config_Galeria", gallery_Temp);
		}
		if (cor_Temp != "") {
			Salvar ("Config_Cor", cor_Temp);
			Salvar ("Config_GroupSingle", GroupSingle_Temp);
			Salvar ("Config_Cor_Random", cor_Random_Temp);
		}
		if (nome_Temp != "") {
			Salvar ("User", nome_Temp);
		}
	}
	
	
	
	void Partida()
	{
		//POSICOES
		posicaoDado1 = CarregarVector3 ("posDado1");
		posicaoDado2 = CarregarVector3 ("posDado2");
		posicaoDado3 = CarregarVector3 ("posDado3");
		posicaoDado4 = CarregarVector3 ("posDado4");
		posicaoDado5 = CarregarVector3 ("posDado5");
		
		rotacaoDado1 = CarregarVector3 ("rotaDado1");
		rotacaoDado2 = CarregarVector3 ("rotaDado2");
		rotacaoDado3 = CarregarVector3 ("rotaDado3");
		rotacaoDado4 = CarregarVector3 ("rotaDado4");
		rotacaoDado5 = CarregarVector3 ("rotaDado5");
		
		for (int a = 0; a < newPosDice.Length; a++) {
		}
		newPosDice [1].transform.position = posicaoDado1;
		newPosDice [2].transform.position = posicaoDado2;
		newPosDice [3].transform.position = posicaoDado3;
		newPosDice [4].transform.position = posicaoDado4;
		newPosDice [5].transform.position = posicaoDado5;
		
		newPosDice [1].transform.eulerAngles = rotacaoDado1;
		newPosDice [2].transform.eulerAngles = rotacaoDado2;
		newPosDice [3].transform.eulerAngles = rotacaoDado3;
		newPosDice [4].transform.eulerAngles = rotacaoDado4;
		newPosDice [5].transform.eulerAngles = rotacaoDado5;
		
		//STATUS
		//VALORES
		for(int i=0; i < valueDOWN_Partida.Length; i++){
			valueDOWN_Partida[i] = CarregarInteiro("valueDOWN"+i);
		}
		for(int i=0; i < valueUP_Partida.Length; i++){
			valueUP_Partida[i] = CarregarInteiro("valueUP"+i);
		}
		for(int i=0; i < valueDESORDEM_Partida.Length; i++){
			valueDESORDEM_Partida[i] = CarregarInteiro("valueDESORDEM"+i);
		}
		for(int i=0; i < valueSECO_Partida.Length; i++){
			valueSECO_Partida[i] = CarregarInteiro("valueSECO"+i);
		}
		//BOOLEAN
		for(int i=0; i < onDOWN_Partida.Length; i++){
			onDOWN_Partida[i] = CarregarBoolean("OnDOWN"+i);
		}
		for(int i=0; i < onUP_Partida.Length; i++){
			onUP_Partida[i] = CarregarBoolean("OnUP"+i);
		}
		for(int i=0; i < onDESORDEM_Partida.Length; i++){
			onDESORDEM_Partida[i] = CarregarBoolean("OnDESORDEM"+i);
		}
		for(int i=0; i < onSECO_Partida.Length; i++){
			onSECO_Partida[i] = CarregarBoolean("OnSECO"+i);
		}
		
		tdPlay_Partida = CarregarInteiro ("tdPlay");
		numberRoll_Partida = CarregarInteiro ("numberRoll");
		status.tdPlay = tdPlay_Partida;
		status.numberRoll = numberRoll_Partida;
		
		PreencherTabela ();
	}
	
	
	
	void PreencherTabela()
	{
		apagarTabela.beginButtons ();
		status.IniciaBotoes ();
		

		for (int L = 0; L < 13; L++) {
			LinhasC0 += 1;
			if(onDOWN_Partida[L] == false){
				status.onDOWN[L] = false;
				for(int b = 0; b < botoesTabela.Length; b++){
					if(botoesTabela[b].linha == LinhasC0 && botoesTabela[b].coluna == 0){
						botoesTabela[b].txtButton.text += valueDOWN_Partida[L];
						status.valueDOWN[L] = valueDOWN_Partida[L];
					}
				}
			}
		}
		
		//UP
		for (int L = 0; L < 13; L++) {
			LinhasC1 += 1;
			if(onUP_Partida[L] == false){
				status.onUP[L] = false;
				for(int b = 0; b < botoesTabela.Length; b++){
					if(botoesTabela[b].linha == LinhasC1 && botoesTabela[b].coluna == 1){
						botoesTabela[b].txtButton.text += valueUP_Partida[L];
						status.valueUP[L] = valueUP_Partida[L];
					}
				}
			}
		}
		
		//DESORDEM
		for (int L = 0; L < 13; L++) {
			LinhasC2 += 1;
			if(onDESORDEM_Partida[L] == false){
				status.onDESORDEM[L] = false;
				for(int b = 0; b < botoesTabela.Length; b++){
					if(botoesTabela[b].linha == LinhasC2 && botoesTabela[b].coluna == 2){
						botoesTabela[b].txtButton.text += valueDESORDEM_Partida[L];
						status.valueDESORDEM[L] = valueDESORDEM_Partida[L];
					}
				}
			}
		}
		
		//SECO
		for (int L = 0; L < 13; L++) {
			LinhasC3 += 1;
			if(onSECO_Partida[L] == false){
				status.onSECO[L] = false;
				for(int b = 0; b < botoesTabela.Length; b++){
					if(botoesTabela[b].linha == LinhasC3 && botoesTabela[b].coluna == 3){
						botoesTabela[b].txtButton.text += valueSECO_Partida[L];
						status.valueSECO[L] = valueSECO_Partida[L];
					}
				}
			}
		}
		if (LinhasC0 == 13 && LinhasC1 == 13 && LinhasC2 == 13 && LinhasC3 == 13) {
			status.ZeraTotais ();
			status.ContagemGeral ();
			numerosDaPartida.score = CarregarInteiro ("Pontos_Partida");
			numerosDaPartida.rodada = CarregarInteiro ("Rodada_Partida");
			numerosDaPartida.jogada = CarregarInteiro ("Jogada_Partida");
		}
		endLoad = true;

	}
	

}
