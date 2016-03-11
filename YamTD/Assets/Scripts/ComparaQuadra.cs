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

public class ComparaQuadra : MonoBehaviour {
	public int[] mapa_quadra;
	bool ok;
	int Id_Mapa;
	StatusPlayer status_Player;
	
	
	
	// Use this for initialization
	void Start () {
		mapa_quadra = new int[186];
		PreecherMapa ();
		ok = false;
		status_Player  = GameObject.Find("app").GetComponent<StatusPlayer>();

	}
	
	// Update is called once per frame
	void Update () {

	}
	


	public bool MapaQuadra(int jogada)
	{
		for (int a = 0; a < mapa_quadra.Length; a++) {
			if(jogada == mapa_quadra[a]){
				ok = true;
//				0a30	4
//				31a61	8
//				62a92	12
//				93a123	16
//				124a154	20
//				155a185	24
	
				if(a < 31){status_Player.res_quadra = 4;}
				if(a > 30 && a < 62){status_Player.res_quadra = 8;}
				if(a > 61 && a < 93){status_Player.res_quadra = 12;}
				if(a > 92 && a < 124){status_Player.res_quadra = 16;}
				if(a > 123 && a < 155){status_Player.res_quadra = 20;}
				if(a > 154 && a < 186){status_Player.res_quadra = 24;}
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
		mapa_quadra[0] = 11110;
		mapa_quadra[1] = 11101;
		mapa_quadra[2] = 11011;
		mapa_quadra[3] = 10111;
		mapa_quadra[4] = 01111;
		mapa_quadra[5] = 11112;
		mapa_quadra[6] = 11121;
		mapa_quadra[7] = 11211;
		mapa_quadra[8] = 12111;
		mapa_quadra[9] = 21111;
		mapa_quadra[10] = 11113;
		mapa_quadra[11] = 11131;
		mapa_quadra[12] = 11311;
		mapa_quadra[13] = 13111;
		mapa_quadra[14] = 31111;
		mapa_quadra[15] = 11114;
		mapa_quadra[16] = 11141;
		mapa_quadra[17] = 11411;
		mapa_quadra[18] = 14111;
		mapa_quadra[19] = 41111;
		mapa_quadra[20] = 11115;
		mapa_quadra[21] = 11151;
		mapa_quadra[22] = 11511;
		mapa_quadra[23] = 15111;
		mapa_quadra[24] = 51111;
		mapa_quadra[25] = 11116;
		mapa_quadra[26] = 11161;
		mapa_quadra[27] = 11611;
		mapa_quadra[28] = 16111;
		mapa_quadra[29] = 61111;
		mapa_quadra[30] = 11111;
		mapa_quadra[31] = 22220;
		mapa_quadra[32] = 22202;
		mapa_quadra[33] = 22022;
		mapa_quadra[34] = 20222;
		mapa_quadra[35] = 02222;
		mapa_quadra[36] = 22221;
		mapa_quadra[37] = 22212;
		mapa_quadra[38] = 22122;
		mapa_quadra[39] = 21222;
		mapa_quadra[40] = 12222;
		mapa_quadra[41] = 22223;
		mapa_quadra[42] = 22232;
		mapa_quadra[43] = 22322;
		mapa_quadra[44] = 23222;
		mapa_quadra[45] = 32222;
		mapa_quadra[46] = 22224;
		mapa_quadra[47] = 22242;
		mapa_quadra[48] = 22422;
		mapa_quadra[49] = 24222;
		mapa_quadra[50] = 42222;
		mapa_quadra[51] = 22225;
		mapa_quadra[52] = 22252;
		mapa_quadra[53] = 22522;
		mapa_quadra[54] = 25222;
		mapa_quadra[55] = 52222;
		mapa_quadra[56] = 22226;
		mapa_quadra[57] = 22262;
		mapa_quadra[58] = 22622;
		mapa_quadra[59] = 26222;
		mapa_quadra[60] = 62222;
		mapa_quadra[61] = 22222;
		mapa_quadra[62] = 33330;
		mapa_quadra[63] = 33303;
		mapa_quadra[64] = 33033;
		mapa_quadra[65] = 30333;
		mapa_quadra[66] = 03333;
		mapa_quadra[67] = 33331;
		mapa_quadra[68] = 33313;
		mapa_quadra[69] = 33133;
		mapa_quadra[70] = 31333;
		mapa_quadra[71] = 13333;
		mapa_quadra[72] = 33332;
		mapa_quadra[73] = 33323;
		mapa_quadra[74] = 33233;
		mapa_quadra[75] = 32333;
		mapa_quadra[76] = 23333;
		mapa_quadra[77] = 33334;
		mapa_quadra[78] = 33343;
		mapa_quadra[79] = 33433;
		mapa_quadra[80] = 34333;
		mapa_quadra[81] = 43333;
		mapa_quadra[82] = 33335;
		mapa_quadra[83] = 33353;
		mapa_quadra[84] = 33533;
		mapa_quadra[85] = 35333;
		mapa_quadra[86] = 53333;
		mapa_quadra[87] = 33336;
		mapa_quadra[88] = 33363;
		mapa_quadra[89] = 33633;
		mapa_quadra[90] = 36333;
		mapa_quadra[91] = 63333;
		mapa_quadra[92] = 33333;
		mapa_quadra[93] = 44440;
		mapa_quadra[94] = 44404;
		mapa_quadra[95] = 44044;
		mapa_quadra[96] = 40444;
		mapa_quadra[97] = 04444;
		mapa_quadra[98] = 44441;
		mapa_quadra[99] = 44414;
		mapa_quadra[100] = 44144;
		mapa_quadra[101] = 41444;
		mapa_quadra[102] = 14444;
		mapa_quadra[103] = 44442;
		mapa_quadra[104] = 44424;
		mapa_quadra[105] = 44244;
		mapa_quadra[106] = 42444;
		mapa_quadra[107] = 24444;
		mapa_quadra[108] = 44443;
		mapa_quadra[109] = 44434;
		mapa_quadra[110] = 44344;
		mapa_quadra[111] = 43444;
		mapa_quadra[112] = 34444;
		mapa_quadra[113] = 44445;
		mapa_quadra[114] = 44454;
		mapa_quadra[115] = 44544;
		mapa_quadra[116] = 45444;
		mapa_quadra[117] = 54444;
		mapa_quadra[118] = 44446;
		mapa_quadra[119] = 44464;
		mapa_quadra[120] = 44644;
		mapa_quadra[121] = 46444;
		mapa_quadra[122] = 64444;
		mapa_quadra[123] = 44444;
		mapa_quadra[124] = 55550;
		mapa_quadra[125] = 55505;
		mapa_quadra[126] = 55055;
		mapa_quadra[127] = 50555;
		mapa_quadra[128] = 05555;
		mapa_quadra[129] = 55551;
		mapa_quadra[130] = 55515;
		mapa_quadra[131] = 55155;
		mapa_quadra[132] = 51555;
		mapa_quadra[133] = 15555;
		mapa_quadra[134] = 55552;
		mapa_quadra[135] = 55525;
		mapa_quadra[136] = 55255;
		mapa_quadra[137] = 52555;
		mapa_quadra[138] = 25555;
		mapa_quadra[139] = 55553;
		mapa_quadra[140] = 55535;
		mapa_quadra[141] = 55355;
		mapa_quadra[142] = 53555;
		mapa_quadra[143] = 35555;
		mapa_quadra[144] = 55554;
		mapa_quadra[145] = 55545;
		mapa_quadra[146] = 55455;
		mapa_quadra[147] = 54555;
		mapa_quadra[148] = 45555;
		mapa_quadra[149] = 55556;
		mapa_quadra[150] = 55565;
		mapa_quadra[151] = 55655;
		mapa_quadra[152] = 56555;
		mapa_quadra[153] = 65555;
		mapa_quadra[154] = 55555;
		mapa_quadra[155] = 66660;
		mapa_quadra[156] = 66606;
		mapa_quadra[157] = 66066;
		mapa_quadra[158] = 60666;
		mapa_quadra[159] = 06666;
		mapa_quadra[160] = 66661;
		mapa_quadra[161] = 66616;
		mapa_quadra[162] = 66166;
		mapa_quadra[163] = 61666;
		mapa_quadra[164] = 16666;
		mapa_quadra[165] = 66662;
		mapa_quadra[166] = 66626;
		mapa_quadra[167] = 66266;
		mapa_quadra[168] = 62666;
		mapa_quadra[169] = 26666;
		mapa_quadra[170] = 66663;
		mapa_quadra[171] = 66636;
		mapa_quadra[172] = 66366;
		mapa_quadra[173] = 63666;
		mapa_quadra[174] = 36666;
		mapa_quadra[175] = 66664;
		mapa_quadra[176] = 66646;
		mapa_quadra[177] = 66466;
		mapa_quadra[178] = 64666;
		mapa_quadra[179] = 46666;
		mapa_quadra[180] = 66665;
		mapa_quadra[181] = 66656;
		mapa_quadra[182] = 66566;
		mapa_quadra[183] = 65666;
		mapa_quadra[184] = 56666;
		mapa_quadra[185] = 66666;
	}





}
