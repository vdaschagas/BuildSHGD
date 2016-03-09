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

public class HideShow : MonoBehaviour {
	public Text labelHideShow;
	public int objectNumber;
	bool hide;
	SoundEffects sound_button;
	bool buttonEventEnter;
	Yam yam_componets;
	MenuEvent btn_menu;



	// Use this for initialization
	void Start () {
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		yam_componets = GameObject.Find("app").GetComponent<Yam>();
		labelHideShow = GetComponentInChildren<Text> ();
		btn_menu = GameObject.Find ("MenuBar").GetComponentInChildren<MenuEvent>();

		hide = true;
		buttonEventEnter = false;
	}
	
	
	
	
	// Update is called once per frame
	void Update () {


		if(yam_componets.showScroll == objectNumber){
			labelHideShow.text = "Esconder";
		} else {
			labelHideShow.text = "Mostrar";
		}



		if(buttonEventEnter == true){
			buttonEventEnter = false;
			sound_button.AudioEfeitos (11, false);
		}
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
	

	
	
	
	public void MostrarEsconder()
	{
		hide = !hide;

		if (hide == false) {
			yam_componets.showScroll = objectNumber;
		} else {
			yam_componets.showScroll = 0;
		}

	}
	
	
}
