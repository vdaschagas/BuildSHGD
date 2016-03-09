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


public class StatusPlayer : MonoBehaviour {
	public const int COL_DOWN = 0;
	public const int COL_UP = 1;
	public const int COL_DESORDEM = 2;
	public const int COL_SECO = 3;
	public const int TOTAL_RODADAS = 52;
	public Image[] Launch;

	public int[] linhaDOWN;
	public int[] linhaUP;
	public int[] linhaDESORDEM;
	public int[] linhaSECO;

	public int[] valueDOWN;
	public int[] valueUP;
	public int[] valueDESORDEM;
	public int[] valueSECO;

	public bool[] onDOWN;
	public bool[] onUP;
	public bool[] onDESORDEM;
	public bool[] onSECO;
	
	public int coluna;
	public int linha;

	public int tdPlay;
	public bool onlyFirst;
	public bool isValidate;
	public bool valueOk;
	public bool buttonPress;
	public int numberRoll;
	public int soma;
	Yam resultadoSorte;
	string somaTexto;
	public int somaParse;
	public int T1_Down;
	public int T1_Up;
	public int T1_Des;
	public int T1_Seco;

	public int Bonus_Down;
	public int Bonus_Up;
	public int Bonus_Des;
	public int Bonus_Seco;

	public int T2_Down;
	public int T2_Up;
	public int T2_Des;
	public int T2_Seco;

	public int Score;
	public int res_quadra;
	public int res_fullHand;
	public int res_seqMax;
	public int res_seqMin;
	public int res_seqYam;
	ComparaQuadra cquadra;
	ComparaFullHand cfullhand;
	ComparaSeqMin cseqmin;
	ComparaSeqMax cseqmax;
	ComparaYam cyam;
	SoundEffects sound_button;
	Mensagem msg_gamer;
	Msg_EndGame msg_GO;

	string msgCurrent;
	public bool valorMM;
	int comparaValor;
	public int rodadaCurrent;
	Inventary inventario;
	Die_d6 dd;
	bool newRecord;
	public int numberRegister;
	public GameObject congratulation;
	bool bonus_30_Col0;
	bool bonus_30_Col1;
	bool bonus_30_Col2;
	bool bonus_30_Col3;
	public bool reloadGame;
	float countReload;
	bool activeCount;
	AnimeEndGame aeg;
	InputField goInput;

	// Use this for initialization
	void Start () {
		linhaUP = new int[13];
		
		linhaDOWN = new int[13];
		linhaDESORDEM = new int[13];
		linhaSECO = new int[13];
		
		valueUP = new int[13];
		valueDOWN = new int[13];
		valueDESORDEM = new int[13];
		valueSECO = new int[13];
		
		onUP = new bool[13];
		onDOWN = new bool[13];
		onDESORDEM = new bool[13];
		onSECO = new bool[13];
		countReload = 0f;
		activeCount = false;
		aeg = GameObject.Find("Canvas").GetComponent<AnimeEndGame>();
		msg_GO = GameObject.Find("txtGame_Over").GetComponent<Msg_EndGame>();
		goInput = GameObject.Find ("textInput").GetComponent<InputField> ();
		soma = 0;
		NewGame ();

	}



	void ViewTdPlay()
	{
		if (onlyFirst == false) {

			tdPlay = 0;
			for (int z = 0; z < 13; z++) {
				if (onDOWN[z] == false) {
					tdPlay += 1;
				}
				if (onUP[z] == false) {
					tdPlay += 1;
				}
				if (onDESORDEM[z] == false) {
					tdPlay += 1;
				}
			}
			if (tdPlay == 39) {
				onlyFirst = true;
			}
		}
	}




	public void ZeraTotais()
	{
		T1_Down = 0;
		T2_Down = 0;
		T1_Up = 0;
		T2_Up = 0;
		T1_Des = 0;
		T2_Des = 0;
		T1_Seco = 0;
		T2_Seco = 0;
		Score = 0;
		Bonus_Down = 0;
		Bonus_Up = 0;
		Bonus_Des = 0;
		Bonus_Seco = 0;

	}



	void ResultCurrents()
	{
		ZeraTotais ();

		switch (coluna) {
		case COL_DOWN:
			valueDOWN[linha - 1] = soma;
			break;
			
		case COL_UP:
			valueUP[linha - 1] = soma;
			break;

		case COL_DESORDEM:
			valueDESORDEM[linha - 1] = soma;
			break;
			
		case COL_SECO:
			valueSECO[linha - 1] = soma;
			break;
		}

		ContagemGeral ();
	}




	public void ContagemGeral()
	{
		for (int r = 0; r < 6; r++) {
			T1_Down += valueDOWN[r];
			T1_Up += valueUP[r];
			T1_Des += valueDESORDEM[r];
			T1_Seco += valueSECO[r];
		}
		
		
		
		
		if(T1_Down > 59){
			Bonus_Down = 30;
			if(bonus_30_Col0 == false){
				bonus_30_Col0 = true;
				BonusTrintaPontos();
			}
		}
		
		if(T1_Up > 59){
			Bonus_Up = 30;
			if(bonus_30_Col1 == false){
				bonus_30_Col1 = true;
				BonusTrintaPontos();
			}
		}
		
		if(T1_Des > 59){
			Bonus_Des = 30;
			if(bonus_30_Col2 == false){
				bonus_30_Col2 = true;
				BonusTrintaPontos();
			}
		}
		
		if(T1_Seco > 59){
			Bonus_Seco = 30;
			if(bonus_30_Col3 == false){
				bonus_30_Col3 = true;
				BonusTrintaPontos();
			}
		}
		
		for (int rs = 6; rs < valueDOWN.Length; rs++) {
			T2_Down += valueDOWN[rs];
			T2_Up += valueUP[rs];
			T2_Des += valueDESORDEM[rs];
			T2_Seco += valueSECO[rs];
		}
		
		Score = T1_Down + Bonus_Down +T2_Down + T1_Up + Bonus_Up + T2_Up +  T1_Des + Bonus_Des + T2_Des + T1_Seco + Bonus_Seco + T2_Seco;
		inventario.score = Score;
		ViewTdPlay ();

	}





	void BonusTrintaPontos()
	{
		sound_button.AudioEfeitos (1, false);
		msgCurrent = "BONUS DE 30 PONTOS!!!";
		msg_gamer.Avisos (msgCurrent, true);
	}







	// Update is called once per frame
	void Update () {
		rodadaCurrent = inventario.rodada;

		if(buttonPress == true){
			isValidate = false;
			valueOk = false;
			buttonPress = false;
			BotaoPressionado(coluna, linha);
			ResultCurrents();
		}
		if (numberRoll > 0) {
			for (int c=0; c < Launch.Length; c++) {
				Launch [c].color = new Color (255, 255, 255, 0);
			}
			Launch [numberRoll].color = new Color (255, 255, 255, 255);
		} else {
			for (int c=0; c < Launch.Length; c++) {
				Launch [c].color = new Color (255, 255, 255, 0);
			}
			Launch [numberRoll].color = new Color (255, 255, 255, 255);
		}
		ChkEnd ();


		if (activeCount == true) {
			countReload += 1 * Time.deltaTime;
		}

		if (newRecord == false && countReload > 3) {
			activeCount = false;
			Application.LoadLevel ("YamGame");
		}

	}



	void ChkEnd()
	{
		if (inventario.rodada == 52 && resultadoSorte.beginGame == false) {
			inventario.gameOver = true;
			resultadoSorte.beginGame = true;
			ScorePosition();
		}

	}





	void ScorePosition()
	{
		for(int p = 0; p < inventario.totalDePontos.Length; p++)
		{
			if (inventario.score > inventario.totalDePontos[p]) {
				newRecord = true;
				numberRegister = p;
				goto PulaFor;
			}
		}

	PulaFor:
		
		msgCurrent = "";
		msg_gamer.Avisos (msgCurrent, true);

		resultadoSorte.endGame.SetActive (true);
		switch (newRecord) {
		case true:
			sound_button.AudioEfeitos (7, false);
			msgCurrent = "PARABENS!!!";
			congratulation.SetActive (true);
			goInput.Select();
			goInput.ActivateInputField();

			break;

		case false:
			sound_button.AudioEfeitos (8, false);
			msgCurrent = "GAME OVER";
			activeCount = true;
			break;

			}
		aeg.OnOff_GameOver (true);

		msg_GO.msg = msgCurrent;


	}




	public void IniciaBotoes()
	{
		for (int i = 0; i < linhaUP.Length; i++)
		{
			linhaDOWN[i] = i+1;
			linhaUP[i] = i+1;
			linhaDESORDEM[i] = i+1;
			linhaSECO[i] = i+1;

			valueUP[i] = 0;
			valueDOWN[i] = 0;
			valueDESORDEM[i] = 0;
			valueSECO[i] = 0;

			onDOWN[i] = true;
			onUP[i] = true;
			onDESORDEM[i] = true;
			onSECO[i] = true;
		}

	}

	


	private void BotaoPressionado(int pColuna, int pLinha)
	{
		soma = 0;
		somaTexto = "";

		switch (pLinha) {
		case 1:
			UM(pColuna);
			break;
		case 2:
			DOIS(pColuna);
			break;
		case 3:
			TRES(pColuna);
			break;
		case 4:
			QUATRO(pColuna);
			break;
		case 5:
			CINCO(pColuna);
			break;
		case 6:
			SEIS(pColuna);
			break;
		case 7:
			QUADRA(pColuna);
			break;
		case 8:
			FULL_HAND(pColuna);
			break;
		case 9:
			SEQUENCIA_MIN(pColuna);
			break;
		case 10:
			SEQUENCIA_MAX(pColuna);
			break;
		case 11:
			MINIMO(pColuna);
			break;
		case 12:
			MAXIMO(pColuna);
			break;
		case 13:
			YAM(pColuna);
			break;

		}
	}




	private bool ValidaJogada(int IntCurrent)
	{

		switch (IntCurrent) {
		case COL_DOWN:
			if (linha == 1 || linha > 1 && onDOWN [linha - 2] == false && onDOWN [linha - 1] != false) {
					isValidate = true;
					onDOWN[linha - 1] = false;
			} else {isValidate = false;}
			break;
			
		case COL_UP:
			if (linha == 13 || linha < 13 && onUP [linha] == false && onUP [linha - 1] != false) {
				isValidate = true;
				onUP[linha - 1] = false;
			} else {isValidate = false;}
			break;

		case COL_DESORDEM:
			if (onDESORDEM [linha - 1] == true) {
				isValidate = true;
				onDESORDEM[linha - 1] = false;
			} else {isValidate = false;}
			break;
			
		case COL_SECO:
			if(numberRoll == 1 && onSECO[linha - 1] == true){
				isValidate = true;
				onSECO[linha - 1] = false;
			} else {isValidate = false;}
			break;
		}


		return isValidate;
	}






	private void FunctionPlayer(int col, int line, bool cardUP, bool addFull)
	{
		if (ValidaJogada (col) == true) {
			numberRoll = 0;
			if(cardUP == true){
				SomaJogada (addFull, line);
			} else {
				switch (line) {
				case 7:
					if (cquadra.MapaQuadra (ConcatenaJogada ()) == true) {
						soma = 20 + res_quadra;
						msgCurrent = "20 PONTOS + QUADRA!!!";
						msg_gamer.Avisos (msgCurrent, true);
						sound_button.AudioEfeitos(1, false);
					}
					break;

				case 8:
					if (cfullhand.MapaFullHand (ConcatenaJogada ()) == true) {
						PlusFullDices ();
						res_fullHand = comparaValor;
						soma = 30 + res_fullHand;
						msgCurrent = "30 PONTOS + FULL HAND!!!";
						msg_gamer.Avisos (msgCurrent, true);
						sound_button.AudioEfeitos(1, false);
					}
					break;

				case 9:
					if (cseqmin.MapaSequeciaMinima (ConcatenaJogada ()) == true) {
						PlusFullDices ();
						res_seqMin = comparaValor;
						soma = 35 + res_seqMin;
						msgCurrent = "35 PONTOS + SEQ MIN!!!";
						msg_gamer.Avisos (msgCurrent, true);
						sound_button.AudioEfeitos(1, false);
					}
					break;

				case 10:
					if (cseqmax.MapaSequeciaMaxima (ConcatenaJogada ()) == true) {
						PlusFullDices ();
						res_seqMax = comparaValor;
						soma = 40 + res_seqMax;
						msgCurrent = "40 PONTOS + SEQ MAX!!!";
						msg_gamer.Avisos (msgCurrent, true);
						sound_button.AudioEfeitos(1, false);
					}
					break;

				case 11:
					MaiorMenor();
					if(valorMM == true){
						SomaJogada (addFull, line);
					}
					break;

				case 12:
					MaiorMenor();
					if(valorMM == true){
						SomaJogada (addFull, line);
					}
					break;

				case 13:
					if (cyam.MapaYam (ConcatenaJogada ()) == true) {
						PlusFullDices ();
						res_seqYam = comparaValor;
						soma = 50 + res_seqYam;
						msgCurrent = "50 PONTOS + YAM!!!";
						msg_gamer.Avisos (msgCurrent, true);
						sound_button.AudioEfeitos(1, false);
					}
					break;

				}
			}
			rodadaCurrent += 1;
			inventario.rodada = rodadaCurrent;
			if(soma == 0){
				sound_button.AudioEfeitos(3, false);
				msgCurrent = "Pontos descartados!!!";
				msg_gamer.Avisos (msgCurrent, true);
			}

		} else {
			sound_button.AudioEfeitos(5, false);
			msgCurrent = "JOGADA NAO PERMITIDA!!!";
			msg_gamer.Avisos (msgCurrent, true);

		}
	}



	int PlusFullDices()
	{
		comparaValor = 0;

		for (int a=1; a < resultadoSorte.diceCurrent.Length; a++) {
			if (a < 6) {
				comparaValor += resultadoSorte.diceCurrent[a];
			}
		}
		return comparaValor;

	}






	//retorna verdadeiro se numero e maior ou menor nas linhas e colunas validas
	bool MaiorMenor()
	{
		PlusFullDices ();
		switch (coluna) {
		case COL_DOWN:
			if((linha - 1) == 11){
				if(onDOWN[10] == false && valueDOWN[10] < comparaValor){
					valorMM = true;
				} else {valorMM = false;}
			}
			if((linha - 1) == 10){
				if(onDOWN[9] == false){
					valorMM = true;
				} else {valorMM = false;}
			}
			break;

		case COL_UP:
			if((linha - 1) == 10){
				if(onUP[11] == false && valueUP[11] > comparaValor){
					valorMM = true;
				} else {valorMM = false;}
			}
			if((linha - 1) == 11){
				if(onUP[12] == false){
					valorMM = true;
				} else {valorMM = false;}
			}
			break;
			
		case COL_DESORDEM:
			if((linha - 1) == 10){
				if(onDESORDEM[11] == true || onDESORDEM[11] == false && valueDESORDEM[11] > comparaValor){
					valorMM = true;
				} else {valorMM = false;}
			}
			if((linha - 1) == 11){
				if(onDESORDEM[10] == true || onDESORDEM[10] == false && valueDESORDEM[10] < comparaValor){
					valorMM = true;
				} else {valorMM = false;}
			}
			break;
			
		case COL_SECO:
			if((linha - 1) == 10){
				if(onSECO[11] == true || onSECO[11] == false && valueSECO[11] > comparaValor){
					valorMM = true;
				} else {valorMM = false;}
			}
			if((linha - 1) == 11){
				if(onSECO[10] == true || onSECO[10] == false && valueSECO[10] < comparaValor){
					valorMM = true;
				} else {valorMM = false;}
			}
			break;
		}
		
		
		return valorMM;
	}







	private void UM(int col)
	{
		FunctionPlayer (col, 1, true, false);
	}



	private void DOIS(int col)
	{
		FunctionPlayer (col, 2, true, false);
	}



	private void TRES(int col)
	{
		FunctionPlayer (col, 3, true, false);
	}



	private void QUATRO(int col)
	{
		FunctionPlayer (col, 4, true, false);
	}



	private void CINCO(int col)
	{
		FunctionPlayer (col, 5, true, false);
	}



	private void SEIS(int col)
	{
		FunctionPlayer (col, 6, true, false);
	}




	private void QUADRA(int col)
	{
		FunctionPlayer (col, linha, false, false);

		//+20
	}



	private void FULL_HAND(int col)
	{
		FunctionPlayer (col, linha, false, false);
		//+30
	}



	private void SEQUENCIA_MIN(int col)
	{
		FunctionPlayer (col, linha, false, false);
		//+35
	}


	private void SEQUENCIA_MAX(int col)
	{
		FunctionPlayer (col, linha, false, false);
		//+40
	}


	private void MINIMO(int col)
	{
		FunctionPlayer (col, linha, false, true);
		//apenas a soma dos dados
	}


	private void MAXIMO(int col)
	{
		FunctionPlayer (col, linha, false, true);
		//apenas a soma dos dados
	}


	private void YAM(int col)
	{
		FunctionPlayer (col, linha, false, false);
		//+50
	}




	//Soma os resultados dos dados, dependendo da jogada
	private int SomaJogada(bool fullDices, int value)
	{
		int bonus = 0;

		for (int a=1; a < resultadoSorte.diceCurrent.Length; a++) {
			if(fullDices == false){

				if (a < 6) {
						if(resultadoSorte.diceCurrent[a] == value){
							soma += resultadoSorte.diceCurrent[a];
						}
				}

			} else {
				if (a < 6) {
						soma += resultadoSorte.diceCurrent[a];
				}
			}
		}

		if(soma == 0){
			sound_button.AudioEfeitos(3, false);
		}

		validValue ();
		return soma;
	}



	//Junta os valores dos dados em uma sequencia para ser comparado com um mapa de cada jogada
	private int ConcatenaJogada()
	{
		for (int a=1; a < resultadoSorte.diceCurrent.Length; a++) {
			if (a < 6) {
					somaTexto += resultadoSorte.diceCurrent[a].ToString();
			}
		}
		somaParse = int.Parse (somaTexto);

		return somaParse;
	}



	

	private bool validValue()
	{
		if (soma == 0) {
			valueOk = false;
			sound_button.AudioEfeitos(3, false);
		} else {
			valueOk = true;
			sound_button.AudioEfeitos(6, false);
		}
		msgCurrent = "LANCE OS DADOS!!!";
		msg_gamer.Avisos (msgCurrent, true);

		return valueOk;
	}






	public void NewGame()
	{
		IniciaBotoes ();
		newRecord = false;
		onlyFirst = false;
		valueOk = false;
		isValidate = false;
		buttonPress = false;
		valorMM = false;
		numberRoll = 0;
		comparaValor = 0;
		rodadaCurrent = 0;
		tdPlay = 0;   //Quantidade de jogadas triplas
		resultadoSorte = GameObject.Find("app").GetComponent<Yam>();
		cquadra = GetComponent<ComparaQuadra>();
		cfullhand = GetComponent<ComparaFullHand>();
		cseqmin = GetComponent<ComparaSeqMin>();
		cseqmax = GetComponent<ComparaSeqMax>();
		cyam = GetComponent<ComparaYam>();
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		msg_gamer = GameObject.Find ("Canvas").GetComponent<Mensagem> ();
		inventario = GameObject.Find("app").GetComponent<Inventary>();
		congratulation.SetActive (false);
		bonus_30_Col0 = false;
		bonus_30_Col1 = false;
		bonus_30_Col2 = false;
		bonus_30_Col3 = false;
		reloadGame = false;
		inventario.score = 0;
	}


	

}
