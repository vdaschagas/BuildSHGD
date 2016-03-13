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
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour {

	public Text txtNome;
	public int Id;
	Inventary inventario;
	StatusPlayer status_Player;
	public InputField textInput;
	UnityEvent m_MyEvent;
	public string MeuTexto;
	ViewInventary saveScore;
	public string nameSave;
	public string nameSaveP;
	int Pontos;
	string tempName1;
	int tempPontos1;
	string tempName2;
	int tempPontos2;
	string userName;


	// Use this for initialization
	void Start () {
		txtNome = GameObject.FindWithTag("nomeRegistro").GetComponent <Text> ();
		textInput = GameObject.FindWithTag("meuInput").GetComponent <InputField> ();
		inventario = GameObject.Find("app").GetComponent<Inventary>();
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();
		tempName1 = "";
		tempPontos1 = 0;
		tempName2 = "";
		tempPontos2 = 0;


		if (m_MyEvent == null)
			m_MyEvent = new UnityEvent ();
			m_MyEvent.AddListener (EntradaDoJogador);


	}
	
	// Update is called once per frame
	void Update ()
	{
		Id = status_Player.numberRegister;

		if (Input.anyKeyDown && m_MyEvent != null)
		{
			m_MyEvent.Invoke ();
		}

		tempPontos1 = inventario.CarregarInteiro ("Save_P1");
		tempName1 = inventario.CarregarString ("Save1");
		tempPontos2 = inventario.CarregarInteiro ("Save_P2");
		tempName2 = inventario.CarregarString ("Save2");
	}




	//Verifica a posicao que os pontos serao salvos na lista de recordes
	void ChoiceSave()
	{
		if(Id == 0){
			nameSave = "Save1"; 
			nameSaveP = "Save_P1";
			OrdemList (0);
		}
		if(Id == 1){
			nameSave = "Save2"; 
			nameSaveP = "Save_P2";
			OrdemList (1);
		}
		if(Id == 2){
			nameSave = "Save3"; 
			nameSaveP = "Save_P3";
			OrdemList (2);
		}
	}


	//Recebe o nome do jogador. Se vazio lista apenas como Player
	private void SubmitName(string name)
	{
		if (name != "") {
			txtNome.text = name;
		} else {
			txtNome.text = "Player";
		}

	}




	public void EntradaDoJogador()
	{
		SubmitName (textInput.text);
		MeuTexto = textInput.text;
	}



	//Grava na ordem decrescente os recordes, na posicao com o nome e a pontuaçao do jogador
	void OrdemList(int pos)
	{
		switch (Id) {
			case 0:
			Pontos = inventario.score;
			inventario.Salvar(nameSaveP, Pontos);
			inventario.Salvar(nameSave, txtNome.text);

			inventario.Salvar("Save_P2", tempPontos1);
			inventario.Salvar("Save2", tempName1);

			inventario.Salvar("Save_P3", tempPontos2);
			inventario.Salvar("Save3", tempName2);

			break;

		case 1:
			Pontos = inventario.score;
			inventario.Salvar(nameSaveP, Pontos);
			inventario.Salvar(nameSave, txtNome.text);

			inventario.Salvar("Save_P3", tempPontos2);
			inventario.Salvar("Save3", tempName2);

			break;

		case 2:
			Pontos = inventario.score;
			inventario.Salvar(nameSaveP, Pontos);
			inventario.Salvar(nameSave, txtNome.text);
	
			break;
			
		}
		inventario.Salvar("User", txtNome.text);
	}



	//Reinicia o jogo
	public void SubmitRecord ()
	{
		ChoiceSave ();
		status_Player.congratulation.SetActive (false);
        //Application.LoadLevel ("YamGame");
        SceneManager.LoadScene("YamGame");
        //SceneManager.LoadScene(0);

	}


	
}
