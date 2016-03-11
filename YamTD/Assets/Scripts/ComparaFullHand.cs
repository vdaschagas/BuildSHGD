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

public class ComparaFullHand : MonoBehaviour {
	public int[] mapa_full_hand;
	bool ok;
	
	
	
	// Use this for initialization
	void Start () {
		mapa_full_hand = new int[300];
		PreecherMapa ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public bool MapaFullHand(int jogada)
	{
		for (int a = 0; a < mapa_full_hand.Length; a++) {
			if(jogada == mapa_full_hand[a]){
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
		mapa_full_hand[0] = 12121;
		mapa_full_hand[1] = 13131;
		mapa_full_hand[2] = 14141;
		mapa_full_hand[3] = 15151;
		mapa_full_hand[4] = 16161;
		mapa_full_hand[5] = 11122;
		mapa_full_hand[6] = 11221;
		mapa_full_hand[7] = 12211;
		mapa_full_hand[8] = 11212;
		mapa_full_hand[9] = 12112;
		mapa_full_hand[10] = 11133;
		mapa_full_hand[11] = 11331;
		mapa_full_hand[12] = 13311;
		mapa_full_hand[13] = 11313;
		mapa_full_hand[14] = 13113;
		mapa_full_hand[15] = 11144;
		mapa_full_hand[16] = 11441;
		mapa_full_hand[17] = 14411;
		mapa_full_hand[18] = 11414;
		mapa_full_hand[19] = 14114;
		mapa_full_hand[20] = 11155;
		mapa_full_hand[21] = 11551;
		mapa_full_hand[22] = 15511;
		mapa_full_hand[23] = 11515;
		mapa_full_hand[24] = 15115;
		mapa_full_hand[25] = 11166;
		mapa_full_hand[26] = 11661;
		mapa_full_hand[27] = 16611;
		mapa_full_hand[28] = 11616;
		mapa_full_hand[29] = 16116;
		mapa_full_hand[30] = 11222;
		mapa_full_hand[31] = 12221;
		mapa_full_hand[32] = 12212;
		mapa_full_hand[33] = 12122;
		mapa_full_hand[34] = 11333;
		mapa_full_hand[35] = 13331;
		mapa_full_hand[36] = 13313;
		mapa_full_hand[37] = 13133;
		mapa_full_hand[38] = 11444;
		mapa_full_hand[39] = 14441;
		mapa_full_hand[40] = 14414;
		mapa_full_hand[41] = 14144;
		mapa_full_hand[42] = 11555;
		mapa_full_hand[43] = 15551;
		mapa_full_hand[44] = 15515;
		mapa_full_hand[45] = 15155;
		mapa_full_hand[46] = 11666;
		mapa_full_hand[47] = 16661;
		mapa_full_hand[48] = 16616;
		mapa_full_hand[49] = 16166;
		mapa_full_hand[50] = 21212;
		mapa_full_hand[51] = 23232;
		mapa_full_hand[52] = 24242;
		mapa_full_hand[53] = 25252;
		mapa_full_hand[54] = 26262;
		mapa_full_hand[55] = 22111;
		mapa_full_hand[56] = 21112;
		mapa_full_hand[57] = 21121;
		mapa_full_hand[58] = 21211;
		mapa_full_hand[59] = 22211;
		mapa_full_hand[60] = 22112;
		mapa_full_hand[61] = 21122;
		mapa_full_hand[62] = 22121;
		mapa_full_hand[63] = 21221;
		mapa_full_hand[64] = 22233;
		mapa_full_hand[65] = 22332;
		mapa_full_hand[66] = 23322;
		mapa_full_hand[67] = 22323;
		mapa_full_hand[68] = 23223;
		mapa_full_hand[69] = 22244;
		mapa_full_hand[70] = 22442;
		mapa_full_hand[71] = 24422;
		mapa_full_hand[72] = 22424;
		mapa_full_hand[73] = 24224;
		mapa_full_hand[74] = 22255;
		mapa_full_hand[75] = 22552;
		mapa_full_hand[76] = 25522;
		mapa_full_hand[77] = 22525;
		mapa_full_hand[78] = 25225;
		mapa_full_hand[79] = 22266;
		mapa_full_hand[80] = 22662;
		mapa_full_hand[81] = 26622;
		mapa_full_hand[82] = 22626;
		mapa_full_hand[83] = 26226;
		mapa_full_hand[84] = 22333;
		mapa_full_hand[85] = 23332;
		mapa_full_hand[86] = 23323;
		mapa_full_hand[87] = 23233;
		mapa_full_hand[88] = 22444;
		mapa_full_hand[89] = 24442;
		mapa_full_hand[90] = 24424;
		mapa_full_hand[91] = 24244;
		mapa_full_hand[92] = 22555;
		mapa_full_hand[93] = 25552;
		mapa_full_hand[94] = 25525;
		mapa_full_hand[95] = 25255;
		mapa_full_hand[96] = 22666;
		mapa_full_hand[97] = 26662;
		mapa_full_hand[98] = 26626;
		mapa_full_hand[99] = 26266;
		mapa_full_hand[100] = 31313;
		mapa_full_hand[101] = 32323;
		mapa_full_hand[102] = 34343;
		mapa_full_hand[103] = 35353;
		mapa_full_hand[104] = 36363;
		mapa_full_hand[105] = 33111;
		mapa_full_hand[106] = 31113;
		mapa_full_hand[107] = 31131;
		mapa_full_hand[108] = 31311;
		mapa_full_hand[109] = 33222;
		mapa_full_hand[110] = 32223;
		mapa_full_hand[111] = 32232;
		mapa_full_hand[112] = 32322;
		mapa_full_hand[113] = 33311;
		mapa_full_hand[114] = 33113;
		mapa_full_hand[115] = 31133;
		mapa_full_hand[116] = 33131;
		mapa_full_hand[117] = 31331;
		mapa_full_hand[118] = 33322;
		mapa_full_hand[119] = 33223;
		mapa_full_hand[120] = 32233;
		mapa_full_hand[121] = 33232;
		mapa_full_hand[122] = 32332;
		mapa_full_hand[123] = 33344;
		mapa_full_hand[124] = 33443;
		mapa_full_hand[125] = 34433;
		mapa_full_hand[126] = 33434;
		mapa_full_hand[127] = 34334;
		mapa_full_hand[128] = 33355;
		mapa_full_hand[129] = 33553;
		mapa_full_hand[130] = 35533;
		mapa_full_hand[131] = 35335;
		mapa_full_hand[132] = 33366;
		mapa_full_hand[133] = 33663;
		mapa_full_hand[134] = 36633;
		mapa_full_hand[135] = 33535;
		mapa_full_hand[136] = 33636;
		mapa_full_hand[137] = 36336;
		mapa_full_hand[138] = 33444;
		mapa_full_hand[139] = 34443;
		mapa_full_hand[140] = 34434;
		mapa_full_hand[141] = 34344;
		mapa_full_hand[142] = 33555;
		mapa_full_hand[143] = 35553;
		mapa_full_hand[144] = 35535;
		mapa_full_hand[145] = 35355;
		mapa_full_hand[146] = 33666;
		mapa_full_hand[147] = 36663;
		mapa_full_hand[148] = 36636;
		mapa_full_hand[149] = 36366;
		mapa_full_hand[150] = 41414;
		mapa_full_hand[151] = 42424;
		mapa_full_hand[152] = 43434;
		mapa_full_hand[153] = 45454;
		mapa_full_hand[154] = 46464;
		mapa_full_hand[155] = 44111;
		mapa_full_hand[156] = 41114;
		mapa_full_hand[157] = 41141;
		mapa_full_hand[158] = 41411;
		mapa_full_hand[159] = 44222;
		mapa_full_hand[160] = 42224;
		mapa_full_hand[161] = 42242;
		mapa_full_hand[162] = 42422;
		mapa_full_hand[163] = 44333;
		mapa_full_hand[164] = 43334;
		mapa_full_hand[165] = 43343;
		mapa_full_hand[166] = 43433;
		mapa_full_hand[167] = 44411;
		mapa_full_hand[168] = 44114;
		mapa_full_hand[169] = 41144;
		mapa_full_hand[170] = 44141;
		mapa_full_hand[171] = 41441;
		mapa_full_hand[172] = 44422;
		mapa_full_hand[173] = 44224;
		mapa_full_hand[174] = 42244;
		mapa_full_hand[175] = 44242;
		mapa_full_hand[176] = 42442;
		mapa_full_hand[177] = 44433;
		mapa_full_hand[178] = 44334;
		mapa_full_hand[179] = 43344;
		mapa_full_hand[180] = 44343;
		mapa_full_hand[181] = 43443;
		mapa_full_hand[182] = 44455;
		mapa_full_hand[183] = 44554;
		mapa_full_hand[184] = 45544;
		mapa_full_hand[185] = 44545;
		mapa_full_hand[186] = 45445;
		mapa_full_hand[187] = 44466;
		mapa_full_hand[188] = 44664;
		mapa_full_hand[189] = 46644;
		mapa_full_hand[190] = 44646;
		mapa_full_hand[191] = 46446;
		mapa_full_hand[192] = 45554;
		mapa_full_hand[193] = 45545;
		mapa_full_hand[194] = 45455;
		mapa_full_hand[195] = 44666;
		mapa_full_hand[196] = 46664;
		mapa_full_hand[197] = 46646;
		mapa_full_hand[198] = 46466;
		mapa_full_hand[199] = 44555;
		mapa_full_hand[200] = 51515;
		mapa_full_hand[201] = 52525;
		mapa_full_hand[202] = 53535;
		mapa_full_hand[203] = 54545;
		mapa_full_hand[204] = 56565;
		mapa_full_hand[205] = 55111;
		mapa_full_hand[206] = 51115;
		mapa_full_hand[207] = 51151;
		mapa_full_hand[208] = 51511;
		mapa_full_hand[209] = 55222;
		mapa_full_hand[210] = 52225;
		mapa_full_hand[211] = 52252;
		mapa_full_hand[212] = 52522;
		mapa_full_hand[213] = 55333;
		mapa_full_hand[214] = 53335;
		mapa_full_hand[215] = 53353;
		mapa_full_hand[216] = 53533;
		mapa_full_hand[217] = 55444;
		mapa_full_hand[218] = 54445;
		mapa_full_hand[219] = 54454;
		mapa_full_hand[220] = 54544;
		mapa_full_hand[221] = 55511;
		mapa_full_hand[222] = 55115;
		mapa_full_hand[223] = 51155;
		mapa_full_hand[224] = 55151;
		mapa_full_hand[225] = 51551;
		mapa_full_hand[226] = 55522;
		mapa_full_hand[227] = 55225;
		mapa_full_hand[228] = 52255;
		mapa_full_hand[229] = 55252;
		mapa_full_hand[230] = 52552;
		mapa_full_hand[231] = 55533;
		mapa_full_hand[232] = 55335;
		mapa_full_hand[233] = 53355;
		mapa_full_hand[234] = 55353;
		mapa_full_hand[235] = 53553;
		mapa_full_hand[236] = 55544;
		mapa_full_hand[237] = 55445;
		mapa_full_hand[238] = 54455;
		mapa_full_hand[239] = 55454;
		mapa_full_hand[240] = 54554;
		mapa_full_hand[241] = 55566;
		mapa_full_hand[242] = 55665;
		mapa_full_hand[243] = 56655;
		mapa_full_hand[244] = 55656;
		mapa_full_hand[245] = 56556;
		mapa_full_hand[246] = 55666;
		mapa_full_hand[247] = 56665;
		mapa_full_hand[248] = 56656;
		mapa_full_hand[249] = 56566;
		mapa_full_hand[250] = 61616;
		mapa_full_hand[251] = 62626;
		mapa_full_hand[252] = 63636;
		mapa_full_hand[253] = 64646;
		mapa_full_hand[254] = 65656;
		mapa_full_hand[255] = 66111;
		mapa_full_hand[256] = 61116;
		mapa_full_hand[257] = 61161;
		mapa_full_hand[258] = 61611;
		mapa_full_hand[259] = 66222;
		mapa_full_hand[260] = 62226;
		mapa_full_hand[261] = 62262;
		mapa_full_hand[262] = 62622;
		mapa_full_hand[263] = 66333;
		mapa_full_hand[264] = 63336;
		mapa_full_hand[265] = 63363;
		mapa_full_hand[266] = 63633;
		mapa_full_hand[267] = 66444;
		mapa_full_hand[268] = 64446;
		mapa_full_hand[269] = 64464;
		mapa_full_hand[270] = 64644;
		mapa_full_hand[271] = 66555;
		mapa_full_hand[272] = 65556;
		mapa_full_hand[273] = 65565;
		mapa_full_hand[274] = 65655;
		mapa_full_hand[275] = 66611;
		mapa_full_hand[276] = 66116;
		mapa_full_hand[277] = 61166;
		mapa_full_hand[278] = 66161;
		mapa_full_hand[279] = 61661;
		mapa_full_hand[280] = 66622;
		mapa_full_hand[281] = 66226;
		mapa_full_hand[282] = 62266;
		mapa_full_hand[283] = 66262;
		mapa_full_hand[284] = 62662;
		mapa_full_hand[285] = 66633;
		mapa_full_hand[286] = 66336;
		mapa_full_hand[287] = 63366;
		mapa_full_hand[288] = 66363;
		mapa_full_hand[289] = 63663;
		mapa_full_hand[290] = 66644;
		mapa_full_hand[291] = 66446;
		mapa_full_hand[292] = 64466;
		mapa_full_hand[293] = 66464;
		mapa_full_hand[294] = 64664;
		mapa_full_hand[295] = 66655;
		mapa_full_hand[296] = 66556;
		mapa_full_hand[297] = 65566;
		mapa_full_hand[298] = 66565;
		mapa_full_hand[299] = 65665;
	}



}
