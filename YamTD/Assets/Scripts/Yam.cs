/**
 * Copyright (c) 2010-2015, WyrmTale Games and Game Components
 * All rights reserved.
 * http://www.wyrmtale.com
 *
 * THIS SOFTWARE IS PROVIDED BY WYRMTALE GAMES AND GAME COMPONENTS 'AS IS' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL WYRMTALE GAMES AND GAME COMPONENTS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
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
using System.Collections.Generic;
using UnityEngine.UI;

public class Yam : MonoBehaviour {
	// constant of current mode
	private const int MODE_GALLERY = 1;
	private const int MODE_ROLL = 2;
	private const int MODE_CARD = 3;
	// current mode
	public int mode = 0;

	// next camera position when moving the camera after switching mode
	private GameObject nextCameraPosition = null;
	// start camera position when moving the camera after switching mode
	private GameObject startCameraPosition = null;
	// store gameObject (empty) for mode MODE_ROLL camera position
	private GameObject camRoll = null;
	// store gameObject (empty) for mode MODE_GALLERY camera position
	private GameObject camCard = null;
	// store gameObject (empty) for mode MODE_CARD camera position
	private GameObject camGallery = null;
	// speed of moving camera after switching mode
	private float cameraMovementSpeed = 0.8F;
	private float cameraMovement = 0;
	
	// initial/starting die in the gallery
	private string galleryDie = "d6-red";
	private GameObject galleryDieObject = null;
	
	// handle drag rotating the die in the gallery
	private bool dragging = false;
	private Vector2 dragStart;
	private Vector3 dragStartAngle;
	private Vector3 dragLastAngle;
	
	// rectangle GUI area's 
	private Rect rectGallerySelectBox;
	private Rect rectGallerySelect;	
	private Rect rectModeSelect;
	
	// GUI gallery die selector texture
	public Texture txSelector = null;


	public int[] diceCurrent;
	public GameObject[] diceSequence;
	public List<int> lstSwap;  // = new List<int>();


	StatusPlayer status_Lauch;
	GameObject choiceMnuRight;
	GameObject BorderTop;
	GameObject cartela;
	GameObject baseCartela;
	public GameObject regrasDoJogo;
	public GameObject endGame;
	public GameObject creditos;
	public GameObject fundoAzul;
	Text txt_score;
	float vol_Temp;

	public bool jogar;
	public int countDice;
	public bool[] selectedDICE;
	public bool[] diceRoll;
	public int play_X;
	Inventary inventario;
	public string txtRandom;
	public bool chkSCor;
	SoundEffects sound_button;
	public string dadoEscolhido;
	public string dotNumber;
	bool dot_num;
	string tp;
	Die_d6 dd;
	public bool prefOn;
	Image bg_blue;
	int intPREF;
	int posNewDice;
	public int lastDice;
	Die_d6 dd3;
	Die_d6 dd4;
	int countSum;
	int elementoZero;
	public bool beginGame;
	int tempRandom;
	public Vector3[] v3Dado;
	public Vector3[] v3Rota;
	public Mensagem msg_gamer;
	public string msgCurrent;
	public GameObject imgsButtonsYesNo;
	public RadialBarProgress rBarProgress;
	public GameObject go_radialBar;
	public int showScroll;
	private const int SCROLL_NULL = 0;
	private const int SCROLL_RULES = 1;
	private const int SCROLL_CRED = 2;
	Image select_color_dices;
	int chkTouch;
	GameObject dragToCard;
	GameObject dragToRoll;


	// Use this for initialization
	void Start () {		
		// store/cache mode assiociated camera positions
		camRoll = GameObject.Find("cameraPositionRoll");
		camGallery = GameObject.Find("cameraPositionGallery");
		camCard = GameObject.Find("cameraPositionCard");
		// set GUI rectangles of the (screen related) gallery selector
		rectGallerySelectBox = new Rect(Screen.width - 260, 10, 250, 170);
		rectGallerySelect = new Rect(Screen.width-250,35,219,109);
		rectModeSelect =  new Rect(800,10,80, 80);
		// set (first) mode to CARD
		SetMode(MODE_CARD);	
		status_Lauch  = GameObject.Find("app").GetComponent<StatusPlayer>();
		inventario = GameObject.Find("app").GetComponent<Inventary>();
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		txt_score = GameObject.FindWithTag ("Pontos").GetComponent<Text>();
		msg_gamer = GameObject.Find ("Canvas").GetComponent<Mensagem> ();
		diceCurrent = new int[6];
		diceSequence = new GameObject[6];
		v3Dado = new Vector3[6];
		v3Rota = new Vector3[6];

		selectedDICE = new bool[6];
		lstSwap = new List<int>();

		DiceFullSelection ();
		chkTouch = 0;
		cartela = GameObject.Find ("backgroudCard");  //VERIFICAR GAME OBJECT
		baseCartela = GameObject.Find ("BaseCard");
		regrasDoJogo = GameObject.Find ("RegrasYam");
		choiceMnuRight = GameObject.Find ("mnuRight");
		endGame = GameObject.FindWithTag("Finish");
		creditos = GameObject.FindWithTag ("CreditosYam");
		BorderTop = GameObject.Find ("ImageTopRight");
		fundoAzul = GameObject.FindWithTag("AnimeEnd");
		creditos.SetActive (false);
		jogar = false;
		countDice = 0;
		elementoZero = 0;
		play_X = 3;
		txtRandom = "";
		imgsButtonsYesNo = GameObject.Find ("ImgSair");
		imgsButtonsYesNo.SetActive (false);
		regrasDoJogo.SetActive (false);
		prefOn = false;
		inventario.tipo = inventario.CarregarString ("Config_Tipo");
		dotNumber = inventario.tipo;
		beginGame = true;
		txt_score.color = new Color (0, 0, 0, 0);
		if (inventario.CarregarString ("Config_Galeria") != "") {
			galleryDie = inventario.CarregarString("Config_Galeria"); 
		}
		go_radialBar  = GameObject.Find("RadialBar");
		rBarProgress = GameObject.Find("BarProgress").GetComponent<RadialBarProgress>();
		go_radialBar.SetActive(false);
		select_color_dices = GameObject.Find ("ImgSelectColor").GetComponent<Image> ();
		select_color_dices.color = Color.white;
		dragToCard = GameObject.Find("btnCard");
		dragToRoll = GameObject.Find("btnRollDices");
		dragToCard.SetActive (false);
		dragToRoll.SetActive (false);
		vol_Temp = inventario.CarregarFloat("AudioVolume");
		if (vol_Temp != 0 || vol_Temp.ToString() != "") {
			inventario.volume = vol_Temp;
		} else {
			inventario.volume = 100f;
			inventario.audioOn = true;
		}

	}	






	public void SetMode(int pMode)
	{
		if(beginGame == true)
		{
			IniciarGame();
		}
		// camera is already moving - mode switching - no new mode will be set and we exit here
		if (nextCameraPosition != null || pMode == mode) return;
		
		switch(pMode)
		{
		case MODE_GALLERY:
			// switch to gallery mode
			startCameraPosition = camRoll;
			nextCameraPosition = camGallery;
			// create die that will be displayed in the gallery
			SetGalleryDie(galleryDie);
			prefOn = true;
			break;

		case MODE_ROLL:
			// switch to rolling mode
			startCameraPosition = camCard;
			nextCameraPosition = camRoll;
			GravarVolume();
			break;

		case MODE_CARD:
			// switch to card mode
			startCameraPosition = camRoll;
			nextCameraPosition = camCard;
			prefOn = true;
			break;

		}
		
		if (nextCameraPosition!=null && mode==0)
		{
			// first time we set mode, so we do not move camera but set it at the right position
			Camera.main.transform.position = nextCameraPosition.transform.position;
			Camera.main.transform.rotation = nextCameraPosition.transform.rotation;
			// next camera position to null so camera will not start moving ( nextCameraPosition is camera moving indicator variable )
			nextCameraPosition = null;

		}		
		
		mode = pMode;
		cameraMovement = 0;	

	}
	
	// determine a random color
	string randomColor
	{
		get
		{
			string _color = "blue";
			int c = System.Convert.ToInt32(Random.value * 6);
			switch(c)
			{
			case 0: _color = "red"; break;
			case 1: _color = "green"; break;
			case 2: _color = "blue"; break;
			case 3: _color = "yellow"; break;
			case 4: _color = "white"; break;
			case 5: _color = "black"; break;				
			}
			return _color;
		}
	}
	
	// Update is called once per frame
	void Update () {

		inventario.tipo = inventario.CarregarString ("Config_Tipo");
		dotNumber = inventario.tipo;
		diceSequence = GameObject.FindGameObjectsWithTag ("Dado");
		// if next camera position is set we are , or have to start moving the camera.
		if (nextCameraPosition!=null)
			MoveCamera();

		switch(mode)
		{
		case MODE_GALLERY:
			// gallery mode to update the gallery
			UpdateGallery();
			cartela.SetActive (false);
			baseCartela.SetActive (false);
			BorderTop.SetActive(true);
			dragToCard.SetActive (false);
			dragToRoll.SetActive (true);
			break;

		case MODE_ROLL:
			// rolling mode to update the dice rolling
			cartela.SetActive (true);
			baseCartela.SetActive (false);
			choiceMnuRight.SetActive (false);
			BorderTop.SetActive(true);
			RodarDados();
			dragToCard.SetActive (true);
			dragToRoll.SetActive (false);
			break;

		case MODE_CARD:
			// rolling mode to update the mark card
			cartela.SetActive (true);
			baseCartela.SetActive (true);
			choiceMnuRight.SetActive (false);
			if(beginGame == true)
			{
				SetGalleryDie(galleryDie);
				UpdateGallery();
				BorderTop.SetActive(true);
			} else {
				BorderTop.SetActive(false);
			}
			dragToCard.SetActive (false);
			dragToRoll.SetActive (true);
			break;
			
		}
		if (status_Lauch.onlyFirst == true) {
			play_X = 1;
		}
//		inventario.cor = txtRandom;
		if (inventario.CarregarInteiro("Config_Cor_Random") == 1) {
			inventario.cor_Random = true;
		} 
		if (inventario.CarregarInteiro("Config_Cor_Random") == 0) {
			inventario.cor_Random = false;
		}
		txtRandom = inventario.CarregarString("Config_Cor");

		dadoEscolhido = galleryDie;


		if(inventario.jogada == 0){
			diceCurrent[1] = 0;
			diceCurrent[2] = 0;
			diceCurrent[3] = 0;
			diceCurrent[4] = 0;
			diceCurrent[5] = 0;
			UpdateDiceInventary ();

		}


		if (showScroll == SCROLL_RULES) {
			SwapShow(creditos);
			regrasDoJogo.SetActive(true);
		}

		if (showScroll == SCROLL_CRED) {
			SwapShow(regrasDoJogo);
			creditos.SetActive(true);
		}

		if (showScroll == SCROLL_NULL) {
			SwapShow(regrasDoJogo);
			SwapShow(creditos);
		}

		chkTouch = Input.touchCount;

	}



	void SwapShow(GameObject showActive)
	{
		showActive.SetActive(false);
	}




	void ChkSELECAO()
	{
		for (int sel = 1; sel < 6; sel++) {
			if(selectedDICE [sel] == true){
				selectedDICE[0] = false;
			}
		}

	}





	// Moving the camera
	void MoveCamera()
	{
		// increment total moving time
		cameraMovement += Time.deltaTime * 1;
		// if we surpass the speed we have to cap the movement because we are 'slerping'
		if (cameraMovement>cameraMovementSpeed) 
			cameraMovement = cameraMovementSpeed;
		
		// slerp (circular interpolation) the position between start and next camera position
		Camera.main.transform.position = Vector3.Slerp(startCameraPosition.transform.position, nextCameraPosition.transform.position,  cameraMovement / cameraMovementSpeed );
		// slerp (circular interpolation) the rotation between start and next camera rotation
		Camera.main.transform.rotation = Quaternion.Slerp(startCameraPosition.transform.rotation, nextCameraPosition.transform.rotation,  cameraMovement / cameraMovementSpeed );
		
		// stop moving if we arrived at the desired next camera postion
		if (cameraMovement == cameraMovementSpeed)
			nextCameraPosition = null;	
	}






	// updating the gallery
	void UpdateGallery()
	{
		if (!PointInRect(GuiMousePosition(), rectModeSelect) && !PointInRect(GuiMousePosition(), rectGallerySelectBox ))
		{
			// mouse position is not on GUI mode selector or gallery selector
			if (Input.GetMouseButton(Dice.MOUSE_LEFT_BUTTON) || Input.touchCount > 0 && chkTouch == 0)
			{
				// mouse left button is held down
				if (!dragging)
				{
					// start dragging 
					dragging = true;
					// remember where (mouse coords) we started to drag and what the start angle of the die was
					dragStart = Input.mousePosition;
					dragStartAngle = galleryDieObject.transform.eulerAngles;
					// stop the gallery die rotation
					galleryDieObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				}
				else
				{
					// we are dragging
					Vector2 delta = Input.mousePosition;
					// calculate delta vector of the mouse position related to our drag start point
					delta -= dragStart;
					// normalize this vector so we can use it to determine the desired rotation angle
					Vector2 dn = delta.normalized;
					// initialize the rotation of gallery die to its starting point
					galleryDieObject.transform.eulerAngles = dragStartAngle;
					// if we move the mouse horizontal we want to rotate around the Y axis (Vector3.up -> normalized vector)
					Vector3 mouseXRotationVector = Vector3.up;
					// if we move the mouse vertical we want to rotate towards the camera. we calculate this normalized rotation
					// vector by using the vector from the camera to the gallery die and rotating it 45 degrees around the Y-axis
					Vector3 mouseYRotationVector = Vector3.Lerp(camGallery.transform.position, galleryDieObject.transform.position, 1).normalized;
					mouseYRotationVector = Quaternion.Euler(0, 45, 0) * mouseYRotationVector;
					// we only want to rotate around the X and Z axis when moving the mouse vertical so we set y-axis to 0
					mouseYRotationVector.y = 0;
					// calculate the right rotation angle and rotate the die around its position using the mouse position delta vector
					Vector3 angle = (mouseYRotationVector * dn.y) + (mouseXRotationVector * dn.x * -1);
					galleryDieObject.transform.RotateAround(galleryDieObject.transform.position, angle, delta.magnitude * .6F);
					// store this angle as the 'last' angle so we can determine the right rotation when we release
					// the mouse button and stop dragging
					dragLastAngle = angle;
				}
			}
			else
				if (Input.GetMouseButtonUp(Dice.MOUSE_LEFT_BUTTON) && dragging || Input.touchCount > 0 && chkTouch == 0 && dragging )
			{
				// left mouse button was released while we were dragging
				float force = .4F;
				dragging = false;
				// add correct torque to spin the gallery die
				galleryDieObject.GetComponent<Rigidbody>().AddTorque(dragLastAngle.normalized * force, ForceMode.Impulse);
				return;
			}
		}
	}








	// dertermine random rolling force
	private GameObject spawnPoint = null;
	private Vector3 Force()
	{
		Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
		return Vector3.Lerp(spawnPoint.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20);
	}
	







	void GravarVolume()
	{
		float vol = inventario.volume;
		inventario.Salvar ("AudioVolume", vol);
	}



	//Habilita jogada com todos os dados
	public void DiceFullSelection()
	{
		selectedDICE [0] = true;
		selectedDICE [1] = false;
		selectedDICE [2] = false;
		selectedDICE [3] = false;
		selectedDICE [4] = false;
		selectedDICE [5] = false;
	}
	
	
	






	//Atualiza os valores e sequencia dos dados no inventario
	void UpdateDiceInventary()
	{
		for (int z = 0; z < diceCurrent.Length; z++) {
			inventario.playCurrent[z] = diceCurrent [z];
		}
	}








	//Numera os dados instanciados
	void NumeraSequenciaDosDados()
	{
		countSum = 0;
		for (int dado = 0; dado < diceSequence.Length; dado++) {
			if (dado < 6) {
				dd = diceSequence [dado].GetComponent<Die_d6> ();
				dd.number = dado;   //Colocando numeraçao em cada dado
				if(diceSequence[dado].transform.position.x >= 50f){
					dd.sum = false;
					dd.number = 0;
				} else {
					countSum += 1;
					dd.sum = true;
					dd.number = countSum;
				}
				v3Dado[dado] = new Vector3(diceSequence[dado].transform.position.x, diceSequence[dado].transform.position.y, diceSequence[dado].transform.position.z);
				v3Rota[dado] = new Vector3(diceSequence[dado].transform.eulerAngles.x, diceSequence[dado].transform.eulerAngles.y, diceSequence[dado].transform.eulerAngles.z);
			}
		}


		//Limpa lista (lstSwap) para carrega-la novamente
		lstSwap.Clear();
		for (int m = 0; m < diceSequence.Length; m++) {
			dd = diceSequence [m].GetComponent<Die_d6> ();
			if(dd.sum == true){
				lstSwap.Add(dd.value);
			} else {
				elementoZero = dd.value;
			}
		}

		//Preenche os valores dos dados correntes
		diceCurrent [0] = elementoZero;
		for (int a = 0; a < lstSwap.Count; a++) {
			if(a < 6){
				diceCurrent [a + 1] = lstSwap [a];
			}
		}
		UpdateDiceInventary ();
	}




	public void PlayType()
	{
		Dice.Roll("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());

	}











	public void RodarDados()
	{
		spawnPoint = GameObject.Find("spawnPoint");

		NumeraSequenciaDosDados();

	}






	public void LANCE_OS_DADOS()
	{
		// check if we have to roll dice
		if (status_Lauch.numberRoll != play_X) {

			ChkSELECAO ();
			
			if (selectedDICE [0] == true) {
				countDice = 5;
			} else {
				countDice = 0;
				for (int s = 1; s < selectedDICE.Length; s++) {
					if (selectedDICE [s] == true) {
						countDice += 1;
					}
				}
			}
			
			if (countDice == 5) {
				Dice.Clear ();
				prefOn = false;
			} else {
				diceSequence = GameObject.FindGameObjectsWithTag ("Dado");
				for (int s = 1; s < selectedDICE.Length; s++) {
					if (selectedDICE [s] == true) {
						for (int des = 0; des < diceSequence.Length; des++) {
							dd = diceSequence [des].GetComponent<Die_d6> ();
							if (dd.number == s) {
								GameObject.Destroy (diceSequence [des].gameObject);
							}
						}
						
					} else {
						int id_Dado = diceCurrent [s];
						switch (id_Dado) {
						case 1:
							Rigidbody d1 = diceSequence [s].GetComponent<Rigidbody> ();
							d1.freezeRotation = true;
							break;
							
						case 2:
							Rigidbody d2 = diceSequence [s].GetComponent<Rigidbody> ();
							d2.freezeRotation = true;
							break;
							
						case 3:
							Rigidbody d3 = diceSequence [s].GetComponent<Rigidbody> ();
							d3.freezeRotation = true;
							break;
							
						case 4:
							Rigidbody d4 = diceSequence [s].GetComponent<Rigidbody> ();
							d4.freezeRotation = true;
							break;
							
						case 5:
							Rigidbody d5 = diceSequence [s].GetComponent<Rigidbody> ();
							d5.freezeRotation = true;
							break;
							
						case 6:
							Rigidbody d6 = diceSequence [s].GetComponent<Rigidbody> ();
							d6.freezeRotation = true;
							break;
							
						}
						
					}
				}
				
				
			}
			
			string[] a = galleryDie.Split ('-');
			string typeDice = galleryDie.Split ('-') [1];

			if (inventario.cor_Random == true) {
				inventario.cor = "Aleatoria";
				if (inventario.GroupSingle == 2) {
					if (dotNumber == "Ponto") {
						Dice.Roll (countDice + a [0], "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
					} 
					if (dotNumber == "Numero") {
						Dice.Roll (countDice + a [0], "d6-" + randomColor, spawnPoint.transform.position, Force ());
					}
					
				} else {
					if (dotNumber == "Ponto") {
						switch (countDice) {
						case 1:
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							break;
							
						case 2:
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							break;
							
						case 3:
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							break;
							
						case 4:
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							break;
							
						case 5:
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor + "-dots", spawnPoint.transform.position, Force ());
							break;
							
						}
						
					} 
					if (dotNumber == "Numero") {
						switch (countDice) {
						case 1:
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							break;
							
						case 2:
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							break;
							
						case 3:
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							break;
							
						case 4:
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							break;
							
						case 5:
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							Dice.Roll ("1d6", "d6-" + randomColor, spawnPoint.transform.position, Force ());
							break;
							
						}
						
					}
				}
			} else {
				
				if (dotNumber == "Ponto") {
					Dice.Roll (countDice + a [0], "d6-" + typeDice + "-dots", spawnPoint.transform.position, Force ());
				} 
				if (dotNumber == "Numero") {
					Dice.Roll (countDice + a [0], "d6-" + typeDice, spawnPoint.transform.position, Force ());
				}
			}
			status_Lauch.numberRoll += 1;
			DiceFullSelection ();

		} else {
			sound_button.AudioEfeitos (5, false);

		}

		if (prefOn == true) {
			RodarDados();
		}
	}





	// handle GUI
	void OnGUI()
	{

		switch (mode) {
		case MODE_GALLERY:

			if (nextCameraPosition == null) {
				// camera is not moving so display dice selector
				GUI.Box (rectGallerySelectBox, "Selecione o Dado");						
				if (txSelector == null) {
					// determine dieType dependent selection texture
					string add = "";
					if (galleryDie.IndexOf ("-dots") >= 0)
						// dice with dots found so we have to append -dots when loading material
						add = "-dots";
					// we have to load our selector texture
					txSelector = (Texture)Resources.Load ("Textures/GUI-selector/select-" + galleryDie.Split ('-') [0] + add);
				}



				//COLOCA NO INVENTARIO O TIPO DE DADO
				if (galleryDie.IndexOf ("-dots") >= 0) {
					tp = "Ponto";
					dot_num = true;
				} else {
					tp = "Numero";
					dot_num = false;
				}
				inventario.button_press [3] = dot_num;  
				inventario.button_press [4] = !dot_num;  
				inventario.tipo = tp;  
				inventario.gallery = galleryDie;
				inventario.Salvar ("Config_Tipo", tp);
				inventario.Salvar ("Config_Galeria", galleryDie);

				string colorDice = galleryDie.Split ('-') [1];

				if (chkSCor == true) {
					txtRandom = "Aleatoria";
					inventario.cor_Random = true;
					tempRandom = 1;
					inventario.Salvar ("Config_Cor_Random", tempRandom);
					inventario.Salvar ("Config_Cor", txtRandom);
				}

				if (chkSCor == false) {
					txtRandom = chk_Status_selected (colorDice);
					inventario.cor_Random = false;
					tempRandom = 0;
					inventario.Salvar ("Config_Cor_Random", tempRandom);
					inventario.Salvar ("Config_Cor", txtRandom);
				}



				if (txSelector != null) {
					// draw our selector texture
					GUI.DrawTexture (rectGallerySelect, txSelector, ScaleMode.ScaleToFit, true, 0f);
				}
				
				// check current mouseposition against selector
				string status = CheckSelection (rectGallerySelect);
				if (status == "")
					status = "[Selecione o tipo de dado e a cor]";
				
				// display status label
				GUI.Label (new Rect (Screen.width - 245, 145, 230, 20), status);					
				choiceMnuRight.SetActive (true);
			}
			break;

		}
	}



	// check if a point is within a rectangle
	private bool PointInRect(Vector2 p, Rect r)
	{
		return  (p.x>=r.xMin && p.x<=r.xMax && p.y>=r.yMin && p.y<=r.yMax);
	}
	
	private string CheckSelection(Rect r)
	{
//		galleryDie = inventario.gallery;
		string status = "";
		// mlb is true when left mouse button is clicked
		bool mlb = Input.GetMouseButtonDown(Dice.MOUSE_LEFT_BUTTON);
		bool tscreen = Input.touchCount > 0 && chkTouch == 0; 
		// determine current GUI mouse position
		Vector2 mp = GuiMousePosition();
		// check current GUI mouse position 
		if (PointInRect(mp, new Rect(r.xMin + 12, r.yMin + 9, 200, 46)))
		{
			// we are in dice type selection so determine what dieType we are over
			// set the die if mouse button is clicked
			txSelector = null;
			if (mp.x - r.xMin < 45)
			{
//				status = "d4 - not available in Dices - Light";
//				if (mlb) 
//					status = "Cor-aleatoria";
			}
			else
				if (mp.x - r.xMin < 75)
			{
				if (mp.y - r.yMin < 30)
				{
					if (mlb || tscreen) SetGalleryDie("d6-" + galleryDie.Split('-')[1] + "-dots");
					status = "d6 dotted";
				}
				else
				{
					if (mlb || tscreen) SetGalleryDie("d6-" + galleryDie.Split('-')[1]);
					status = "d6";
				}
			}
		}
		else
			if (PointInRect(mp, new Rect(r.xMin+ 12, r.yMin + 70, 200, 28)))
		{
			// we are in dice color selection so set active color if mouse button was clicked
			
			// check if we had a d6 with dots
			string add = "";
			if (galleryDie.IndexOf("-dots") >= 0)
				// dice with dots found so we have to append -dots when loading material
				add = "-dots";               
			
			if (mp.x - r.xMin < 45)
			{
				if (mlb || tscreen) SetGalleryDie(galleryDie.Split('-')[0] + "-red" + add);
					status = "red";
			}
			else
				if (mp.x - r.xMin < 75)
			{
				if (mlb || tscreen) SetGalleryDie(galleryDie.Split('-')[0] + "-black" + add);
					status = "black";
			}
			else
				if (mp.x - r.xMin < 115)
			{
				if (mlb || tscreen) SetGalleryDie(galleryDie.Split('-')[0] + "-white" + add);
					status = "white";
			}
			else
				if (mp.x - r.xMin < 147)
			{
				if (mlb || tscreen) SetGalleryDie(galleryDie.Split('-')[0] + "-yellow" + add);
					status = "yellow";
			}
			else
				if (mp.x - r.xMin < 180)
			{
				if (mlb || tscreen) SetGalleryDie(galleryDie.Split('-')[0] + "-green" + add);
					status = "green";
			}
			else
			{
				if(mlb || tscreen)SetGalleryDie(galleryDie.Split('-')[0] + "-blue" + add);
					status = "blue";
			}
		}
		return status;	
	}










	private string chk_Status_selected(string chk)
	{

		switch (chk) {
		case "red":
			inventario.cor_Random = false;
			txtRandom = "Vermelho";
			select_color_dices.color = Color.red;
			break;
			
		case "black":
			inventario.cor_Random = false;
			txtRandom = "Preto";
			select_color_dices.color = Color.black;
			break;
			
		case "white":
			inventario.cor_Random = false;
			txtRandom = "Branco";
			select_color_dices.color = Color.white;
			break;
			
		case "yellow":
			inventario.cor_Random = false;
			txtRandom = "Amarelo";
			select_color_dices.color = Color.yellow;
			break;
			
		case "green":
			inventario.cor_Random = false;
			txtRandom = "Verde";
			select_color_dices.color = Color.green;
			break;
			
		case "blue":
			inventario.cor_Random = false;
			txtRandom = "Azul";
			select_color_dices.color = Color.blue;
			break;

		case "all":
			inventario.cor_Random = true;
			txtRandom = "Aleatoria";
			break;

		}
		return txtRandom;
	}








	// translate Input mouseposition to GUI coordinates using camera viewport
	private Vector2 GuiMousePosition()
	{
		Vector2 mp = Input.mousePosition;
		Vector3 vp = Camera.main.ScreenToViewportPoint (new Vector3(mp.x,mp.y,0));
		mp = new Vector2(vp.x * Camera.main.pixelWidth, (1-vp.y) * Camera.main.pixelHeight);
		return mp;
	}
	
	// set spcific gallery die type	
	public void SetGalleryDie(string die)
	{
		Vector3 newRotation = new Vector3(-90, -65, 0);
		Vector4 angleVelocity = Vector3.zero;
		// destroy current gallery die if we have one
		if (galleryDie != "" && galleryDieObject != null)
		{
			// save rotation and angle velocity so we can set it on the new die later
			newRotation = galleryDieObject.transform.eulerAngles;
			angleVelocity  = galleryDieObject.GetComponent<Rigidbody>().angularVelocity;
			galleryDieObject.SetActive(false);
			// destroy die gameObject
			GameObject.Destroy(galleryDieObject);
		}		
		galleryDie = die;
		string[] a = galleryDie.Split('-');						
		GameObject g = GameObject.Find("platform-2");
		if (g!=null)
		{
			// create the new die
			galleryDieObject = Dice.prefab(a[0], g.transform.position + new Vector3(0, 3.8F, 0), newRotation , new Vector3(1.4f,1.4f,1.4f),die);
			// disable rigidBody gravity
			galleryDieObject.GetComponent<Rigidbody>().useGravity = false;
			// add saved angle and angle velocity or torque impulse
			if (angleVelocity.x == 0 && angleVelocity.y == 0 && angleVelocity.z==0)
				galleryDieObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -.4F, 0), ForceMode.Impulse);
			else
				galleryDieObject.GetComponent<Rigidbody>().angularVelocity = angleVelocity;
		}
	}



	
	void IniciarGame()
	{
		beginGame = false;
		bg_blue = fundoAzul.GetComponent<Image>();
		bg_blue.color = new Color(13, 88, 176, 0);
		endGame.SetActive(false);
		txt_score.color = new Color (255, 255, 255, 255);
		Dice.Clear ();
		prefOn = false;
		creditos.SetActive (false);
		imgsButtonsYesNo.SetActive (false);

	}
	
	


}
