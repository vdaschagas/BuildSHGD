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

//Retorna os valores dos dados...
public class ValorDado : MonoBehaviour {
	Text txtDado;
	public int Id;
	Yam v_dice;
	int somaCurrent;
	string resCurrent;



	// Use this for initialization
	void Start () {
		txtDado = GetComponent <Text> ();
		v_dice = GameObject.Find("app").GetComponent<Yam>();
		somaCurrent = 0;
		resCurrent = "";
	}



	// Update is called once per frame
	void Update ()
	{

		if (Id != 9) {
			txtDado.text = resultados();
		} 

		if (Id == 9) {
			somaCurrent = 0;
				for(int x = 1; x < v_dice.diceCurrent.Length; x++)
				{
					if (x < 6) {
						somaCurrent += v_dice.diceCurrent[x];
					}
				}

			txtDado.text = "" + somaCurrent;
		}
	}




	string resultados()
	{
		if (v_dice.diceCurrent [Id] != 0) {
			resCurrent = "" + v_dice.diceCurrent [Id];
		} else {
			resCurrent = "?";
		}

		return resCurrent;
	}



}
