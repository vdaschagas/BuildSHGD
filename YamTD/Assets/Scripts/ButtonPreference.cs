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

public class ButtonPreference : MonoBehaviour {
	public GameObject buttonPress;
	public bool button_On;
	public int buttonId;
	Inventary inventario;
	Yam color_Yam;

	
	// Use this for initialization
	void Start () {
		inventario = GameObject.Find("app").GetComponent<Inventary>();
		color_Yam = GameObject.Find("app").GetComponent<Yam>();
		button_On = (buttonPress.activeSelf);

	}



	// Update is called once per frame
	void Update () {
		if (buttonId == 0) {
			button_On = inventario.CarregarBoolean("Config_Cor_Random");
			color_Yam.chkSCor = button_On;
		}


		if (inventario.CarregarInteiro("Config_GroupSingle") == 2) {
			inventario.button_press [1] = true;
			inventario.button_press [2] = false;
		}
		if (inventario.CarregarInteiro("Config_GroupSingle") == 1) {
			inventario.button_press [1] = false;
			inventario.button_press [2] = true;
		}


		if (buttonId == 5) {
			button_On = inventario.audioOn;
		}

		buttonPress.SetActive (inventario.button_press [buttonId]);
	}
	





	public void ActivePreference()
	{
		buttonPress.SetActive (!buttonPress.activeSelf);
		button_On = (buttonPress.activeSelf);

			
		switch (buttonId) {
			case 0:
			if(button_On == true){
				inventario.button_press [1] = button_On;
				inventario.GroupSingle = 2;
				inventario.button_press [2] = !button_On;
				color_Yam.chkSCor = true;
				inventario.Salvar("Config_Cor_Random", 1);

			} else {
				inventario.button_press [1] = button_On;
				inventario.button_press [2] = button_On;
				inventario.GroupSingle = 1;
				color_Yam.chkSCor = false;
				inventario.Salvar("Config_Cor_Random", 0);

			}
			inventario.button_press [0] = button_On;

			break;
				
		case 1:
			if(inventario.button_press [0] == true){
				inventario.Salvar("Config_GroupSingle", 2);
				inventario.button_press [1] = button_On;
				inventario.button_press [2] = !button_On;
				inventario.GroupSingle = 2;
			}
			break;
			
		case 2:
			if(inventario.button_press [0] == true){
				inventario.Salvar("Config_GroupSingle", 1);
				inventario.button_press [1] = !button_On;
				inventario.button_press [2] = button_On;
				inventario.GroupSingle = 1;
			}
			break;
			
		case 3:
			inventario.button_press [3] = button_On;
			inventario.button_press [4] = !button_On;
			inventario.gallery = color_Yam.dadoEscolhido;
			color_Yam.SetGalleryDie("d6-" + color_Yam.dadoEscolhido.Split('-')[1] + "-dots");
			color_Yam.txSelector = (Texture)Resources.Load("Textures/GUI-selector/select-d6-dots");
			break;
			
		case 4:
			inventario.button_press [3] = !button_On;
			inventario.button_press [4] = button_On;
			inventario.gallery = color_Yam.dadoEscolhido;
			color_Yam.SetGalleryDie("d6-" + color_Yam.dadoEscolhido.Split('-')[1]);
			color_Yam.txSelector = (Texture)Resources.Load("Textures/GUI-selector/select-d6");
			break;
			
		case 5:
			if(button_On == true){
				inventario.Salvar("Config_Audio", 1);

			} else {
				inventario.Salvar("Config_Audio", 0);
			}
			inventario.button_press [5] = button_On;
			break;
		}


	}
	
}
