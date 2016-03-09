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


public class RadialBarProgress : MonoBehaviour {
	public Transform bar;
	public Transform txt_Indicator;
	public Transform txt_State;
	public bool activeBar;
	public string strState;
	public string strColor;
	public Transform centerBar;
	float count;
	bool stopCount;
	public bool beginAmount;
	public Color colorRED;
	public Color colorWHITE;

	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;


	// Use this for initialization
	void Start () {
		activeBar = false;
		beginAmount = false;
		currentAmount = 0;
		stopCount = true;
		colorRED = new Color (255, 0, 0, 255);
		colorWHITE = new Color (255, 255, 255, 255);

	}
	
	// Update is called once per frame
	void Update () {
		if (strColor == "Red") {
			centerBar.GetComponent<Image>().color = colorRED;
		} else {
			centerBar.GetComponent<Image>().color = colorWHITE;

		}

		if (activeBar == true) {
			if(beginAmount == true){
				beginAmount = false;
				currentAmount = 0;

			}
			if (currentAmount < 100) {
				currentAmount += speed * Time.deltaTime;
				txt_Indicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%";
				txt_State.GetComponent<Text> ().text = strState;
				txt_State.gameObject.SetActive (true);
				stopCount = false;
			} else {
				txt_State.gameObject.SetActive (false);
				txt_Indicator.GetComponent<Text> ().text = "CONCLUIDO!";
				if(stopCount == false){count += 1 * Time.deltaTime;}
				if(count > 2){
					count = 0;
					activeBar = false;
					stopCount = true;
				}
			}
			bar.GetComponent<Image> ().fillAmount = currentAmount / 100;
		}
	}
}
