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

public class ComparaYam : MonoBehaviour {
	public int[] mapa_yam;
	bool ok;



	// Use this for initialization
	void Start () {
		mapa_yam = new int[6];
		PreecherMapa ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public bool MapaYam(int jogada)
	{
		for (int a = 0; a < mapa_yam.Length; a++) {
			if(jogada == mapa_yam[a]){
				ok = true;
				goto endFor;
			} else {
				ok = false;
			}
		}

	endFor:
			return ok;
	}






	void PreecherMapa()
	{
		mapa_yam[0] = 11111;
		mapa_yam[1] = 22222;
		mapa_yam[2] = 33333;
		mapa_yam[3] = 44444;
		mapa_yam[4] = 55555;
		mapa_yam[5] = 66666;
	}



}
