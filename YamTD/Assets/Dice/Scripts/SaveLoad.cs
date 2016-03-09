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

public class SaveLoad : MonoBehaviour {
	public string varString;
	public int varInteiro;
	public float varFloat;
	public Vector3 varVector3;
	public bool varBoolean;
	int tempInt;



	//SAVE
	public void Salvar(string nomeSave, string strName)
	{
		PlayerPrefs.SetString(nomeSave, strName);
	}
	


	public void Salvar(string nomeSave, int intCurrent)
	{
		PlayerPrefs.SetInt(nomeSave, intCurrent);
	}
	



	public void Salvar(string nomeSave, float numberFloat)
	{
		PlayerPrefs.SetFloat(nomeSave, numberFloat);
	}
	


	public void Salvar(string nomeSave, Vector3 posicao)
	{
		PlayerPrefs.SetFloat(nomeSave + "_x", posicao.x);
		PlayerPrefs.SetFloat(nomeSave + "_y", posicao.y);
		PlayerPrefs.SetFloat(nomeSave + "_z", posicao.z);
	}




	//LOADING
	public string CarregarString(string nomeSave)
	{
		varString = PlayerPrefs.GetString(nomeSave);
		
		return(varString);
	}
	
	
	
	
	public int CarregarInteiro(string nomeSave)
	{
		varInteiro = PlayerPrefs.GetInt(nomeSave);
		
		return(varInteiro);
	}
	



	
	public float CarregarFloat(string nomeSave)
	{
		varFloat = PlayerPrefs.GetFloat(nomeSave);
		
		return(varFloat);
	}
	
	
	
	
	public Vector3 CarregarVector3(string nomeSave)
	{
		varVector3.x = PlayerPrefs.GetFloat(nomeSave + "_x");
		varVector3.y = PlayerPrefs.GetFloat(nomeSave + "_y");
		varVector3.z = PlayerPrefs.GetFloat(nomeSave + "_z");

		return(varVector3);
	}
	


	public bool CarregarBoolean(string nomeSave)
	{
		tempInt = PlayerPrefs.GetInt(nomeSave);
		if(tempInt == 0){
			varBoolean = false;
		}
		if(tempInt == 1){
			varBoolean = true;
		}

		return(varBoolean);
	}
	
}
