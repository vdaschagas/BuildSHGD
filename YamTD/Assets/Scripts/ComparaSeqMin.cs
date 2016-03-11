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

public class ComparaSeqMin : MonoBehaviour {
	public int[] mapa_Seq_min;
	bool ok;
	
	
	
	// Use this for initialization
	void Start () {
		mapa_Seq_min = new int[120];
		PreecherMapa ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public bool MapaSequeciaMinima(int jogada)
	{
		for (int a = 0; a < mapa_Seq_min.Length; a++) {
			if(jogada == mapa_Seq_min[a]){
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
		mapa_Seq_min[0] = 12345;
		mapa_Seq_min[1] = 12354;
		mapa_Seq_min[2] = 12435;
		mapa_Seq_min[3] = 12453;
		mapa_Seq_min[4] = 12534;
		mapa_Seq_min[5] = 12543;
		mapa_Seq_min[6] = 13245;
		mapa_Seq_min[7] = 13254;
		mapa_Seq_min[8] = 13425;
		mapa_Seq_min[9] = 13452;
		mapa_Seq_min[10] = 13524;
		mapa_Seq_min[11] = 13542;
		mapa_Seq_min[12] = 14235;
		mapa_Seq_min[13] = 14253;
		mapa_Seq_min[14] = 14325;
		mapa_Seq_min[15] = 14352;
		mapa_Seq_min[16] = 14523;
		mapa_Seq_min[17] = 14532;
		mapa_Seq_min[18] = 15234;
		mapa_Seq_min[19] = 15243;
		mapa_Seq_min[20] = 15324;
		mapa_Seq_min[21] = 15342;
		mapa_Seq_min[22] = 15423;
		mapa_Seq_min[23] = 15432;
		mapa_Seq_min[24] = 21345;
		mapa_Seq_min[25] = 21354;
		mapa_Seq_min[26] = 21435;
		mapa_Seq_min[27] = 21453;
		mapa_Seq_min[28] = 21534;
		mapa_Seq_min[29] = 21543;
		mapa_Seq_min[30] = 23145;
		mapa_Seq_min[31] = 23154;
		mapa_Seq_min[32] = 23415;
		mapa_Seq_min[33] = 23451;
		mapa_Seq_min[34] = 23514;
		mapa_Seq_min[35] = 23541;
		mapa_Seq_min[36] = 24135;
		mapa_Seq_min[37] = 24153;
		mapa_Seq_min[38] = 24315;
		mapa_Seq_min[39] = 24351;
		mapa_Seq_min[40] = 24513;
		mapa_Seq_min[41] = 24531;
		mapa_Seq_min[42] = 25134;
		mapa_Seq_min[43] = 25143;
		mapa_Seq_min[44] = 25314;
		mapa_Seq_min[45] = 25341;
		mapa_Seq_min[46] = 25413;
		mapa_Seq_min[47] = 25431;
		mapa_Seq_min[48] = 31245;
		mapa_Seq_min[49] = 31254;
		mapa_Seq_min[50] = 31425;
		mapa_Seq_min[51] = 31452;
		mapa_Seq_min[52] = 31524;
		mapa_Seq_min[53] = 31542;
		mapa_Seq_min[54] = 32145;
		mapa_Seq_min[55] = 32154;
		mapa_Seq_min[56] = 32415;
		mapa_Seq_min[57] = 32451;
		mapa_Seq_min[58] = 32514;
		mapa_Seq_min[59] = 32541;
		mapa_Seq_min[60] = 34125;
		mapa_Seq_min[61] = 34152;
		mapa_Seq_min[62] = 34215;
		mapa_Seq_min[63] = 34251;
		mapa_Seq_min[64] = 34512;
		mapa_Seq_min[65] = 34521;
		mapa_Seq_min[66] = 35124;
		mapa_Seq_min[67] = 35142;
		mapa_Seq_min[68] = 35214;
		mapa_Seq_min[69] = 35241;
		mapa_Seq_min[70] = 35412;
		mapa_Seq_min[71] = 35421;
		mapa_Seq_min[72] = 41235;
		mapa_Seq_min[73] = 41253;
		mapa_Seq_min[74] = 41325;
		mapa_Seq_min[75] = 41352;
		mapa_Seq_min[76] = 41523;
		mapa_Seq_min[77] = 41532;
		mapa_Seq_min[78] = 42135;
		mapa_Seq_min[79] = 42153;
		mapa_Seq_min[80] = 42315;
		mapa_Seq_min[81] = 42351;
		mapa_Seq_min[82] = 42513;
		mapa_Seq_min[83] = 42531;
		mapa_Seq_min[84] = 43125;
		mapa_Seq_min[85] = 43152;
		mapa_Seq_min[86] = 43215;
		mapa_Seq_min[87] = 43251;
		mapa_Seq_min[88] = 43512;
		mapa_Seq_min[89] = 43521;
		mapa_Seq_min[90] = 45123;
		mapa_Seq_min[91] = 45132;
		mapa_Seq_min[92] = 45213;
		mapa_Seq_min[93] = 45231;
		mapa_Seq_min[94] = 45312;
		mapa_Seq_min[95] = 45321;
		mapa_Seq_min[96] = 51234;
		mapa_Seq_min[97] = 51243;
		mapa_Seq_min[98] = 51324;
		mapa_Seq_min[99] = 51342;
		mapa_Seq_min[100] = 51423;
		mapa_Seq_min[101] = 51432;
		mapa_Seq_min[102] = 52134;
		mapa_Seq_min[103] = 52143;
		mapa_Seq_min[104] = 52314;
		mapa_Seq_min[105] = 52341;
		mapa_Seq_min[106] = 52413;
		mapa_Seq_min[107] = 52431;
		mapa_Seq_min[108] = 53124;
		mapa_Seq_min[109] = 53142;
		mapa_Seq_min[110] = 53214;
		mapa_Seq_min[111] = 53241;
		mapa_Seq_min[112] = 53412;
		mapa_Seq_min[113] = 53421;
		mapa_Seq_min[114] = 54123;
		mapa_Seq_min[115] = 54132;
		mapa_Seq_min[116] = 54213;
		mapa_Seq_min[117] = 54231;
		mapa_Seq_min[118] = 54312;
		mapa_Seq_min[119] = 54321;
	}


}
