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

public class ComparaSeqMax : MonoBehaviour {
	public int[] mapa_Seq_max;
	bool ok;
	
	
	
	// Use this for initialization
	void Start () {
		mapa_Seq_max = new int[120];
		PreecherMapa ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public bool MapaSequeciaMaxima(int jogada)
	{
		for (int a = 0; a < mapa_Seq_max.Length; a++) {
			if(jogada == mapa_Seq_max[a]){
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
		mapa_Seq_max[0] = 23456;
		mapa_Seq_max[1] = 23465;
		mapa_Seq_max[2] = 23546;
		mapa_Seq_max[3] = 23564;
		mapa_Seq_max[4] = 23645;
		mapa_Seq_max[5] = 23654;
		mapa_Seq_max[6] = 24356;
		mapa_Seq_max[7] = 24365;
		mapa_Seq_max[8] = 24536;
		mapa_Seq_max[9] = 24563;
		mapa_Seq_max[10] = 24635;
		mapa_Seq_max[11] = 24653;
		mapa_Seq_max[12] = 25346;
		mapa_Seq_max[13] = 25364;
		mapa_Seq_max[14] = 25436;
		mapa_Seq_max[15] = 25463;
		mapa_Seq_max[16] = 25634;
		mapa_Seq_max[17] = 25643;
		mapa_Seq_max[18] = 26345;
		mapa_Seq_max[19] = 26354;
		mapa_Seq_max[20] = 26435;
		mapa_Seq_max[21] = 26453;
		mapa_Seq_max[22] = 26534;
		mapa_Seq_max[23] = 26543;
		mapa_Seq_max[24] = 32456;
		mapa_Seq_max[25] = 32465;
		mapa_Seq_max[26] = 32546;
		mapa_Seq_max[27] = 32564;
		mapa_Seq_max[28] = 32645;
		mapa_Seq_max[29] = 32654;
		mapa_Seq_max[30] = 34256;
		mapa_Seq_max[31] = 34265;
		mapa_Seq_max[32] = 34526;
		mapa_Seq_max[33] = 34562;
		mapa_Seq_max[34] = 34625;
		mapa_Seq_max[35] = 34652;
		mapa_Seq_max[36] = 35246;
		mapa_Seq_max[37] = 35264;
		mapa_Seq_max[38] = 35426;
		mapa_Seq_max[39] = 35462;
		mapa_Seq_max[40] = 35624;
		mapa_Seq_max[41] = 35642;
		mapa_Seq_max[42] = 36245;
		mapa_Seq_max[43] = 36254;
		mapa_Seq_max[44] = 36425;
		mapa_Seq_max[45] = 36452;
		mapa_Seq_max[46] = 36524;
		mapa_Seq_max[47] = 36542;
		mapa_Seq_max[48] = 42356;
		mapa_Seq_max[49] = 42365;
		mapa_Seq_max[50] = 42536;
		mapa_Seq_max[51] = 42563;
		mapa_Seq_max[52] = 42635;
		mapa_Seq_max[53] = 42653;
		mapa_Seq_max[54] = 43256;
		mapa_Seq_max[55] = 43265;
		mapa_Seq_max[56] = 43526;
		mapa_Seq_max[57] = 43562;
		mapa_Seq_max[58] = 43625;
		mapa_Seq_max[59] = 43652;
		mapa_Seq_max[60] = 45236;
		mapa_Seq_max[61] = 45263;
		mapa_Seq_max[62] = 45326;
		mapa_Seq_max[63] = 45362;
		mapa_Seq_max[64] = 45623;
		mapa_Seq_max[65] = 45632;
		mapa_Seq_max[66] = 46235;
		mapa_Seq_max[67] = 46253;
		mapa_Seq_max[68] = 46325;
		mapa_Seq_max[69] = 46352;
		mapa_Seq_max[70] = 46523;
		mapa_Seq_max[71] = 46532;
		mapa_Seq_max[72] = 52346;
		mapa_Seq_max[73] = 52364;
		mapa_Seq_max[74] = 52436;
		mapa_Seq_max[75] = 52463;
		mapa_Seq_max[76] = 52634;
		mapa_Seq_max[77] = 52643;
		mapa_Seq_max[78] = 53246;
		mapa_Seq_max[79] = 53264;
		mapa_Seq_max[80] = 53426;
		mapa_Seq_max[81] = 53462;
		mapa_Seq_max[82] = 53624;
		mapa_Seq_max[83] = 53642;
		mapa_Seq_max[84] = 54236;
		mapa_Seq_max[85] = 54263;
		mapa_Seq_max[86] = 54326;
		mapa_Seq_max[87] = 54362;
		mapa_Seq_max[88] = 54623;
		mapa_Seq_max[89] = 54632;
		mapa_Seq_max[90] = 56234;
		mapa_Seq_max[91] = 56243;
		mapa_Seq_max[92] = 56324;
		mapa_Seq_max[93] = 56342;
		mapa_Seq_max[94] = 56423;
		mapa_Seq_max[95] = 56432;
		mapa_Seq_max[96] = 62345;
		mapa_Seq_max[97] = 62354;
		mapa_Seq_max[98] = 62435;
		mapa_Seq_max[99] = 62453;
		mapa_Seq_max[100] = 62534;
		mapa_Seq_max[101] = 62543;
		mapa_Seq_max[102] = 63245;
		mapa_Seq_max[103] = 63254;
		mapa_Seq_max[104] = 63425;
		mapa_Seq_max[105] = 63452;
		mapa_Seq_max[106] = 63524;
		mapa_Seq_max[107] = 63542;
		mapa_Seq_max[108] = 64235;
		mapa_Seq_max[109] = 64253;
		mapa_Seq_max[110] = 64325;
		mapa_Seq_max[111] = 64352;
		mapa_Seq_max[112] = 64523;
		mapa_Seq_max[113] = 64532;
		mapa_Seq_max[114] = 65234;
		mapa_Seq_max[115] = 65243;
		mapa_Seq_max[116] = 65324;
		mapa_Seq_max[117] = 65342;
		mapa_Seq_max[118] = 65423;
		mapa_Seq_max[119] = 65432;
	}




}
