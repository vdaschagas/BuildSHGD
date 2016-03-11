using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuEvent : MonoBehaviour {
	public GameObject content_menu;
	public bool MenuOpen;
	private float timerCloseMenu;
	bool closeOptions;
	public Text txtButtonGame;
	SoundEffects sound_button;


	// Use this for initialization
	void Start () {
		txtButtonGame = GameObject.Find("imgContent_Menu").GetComponentInChildren<Text>();
		sound_button  = GameObject.Find("ground").GetComponent<SoundEffects>();
		content_menu = GameObject.Find ("imgContent_Menu");
		content_menu.SetActive (false);
		timerCloseMenu = 0;
		closeOptions = true;
		MenuOpen = false;
	}


	// Update is called once per frame
	void Update () {
	
		if (closeOptions == false) {
			timerCloseMenu += 1 * Time.deltaTime;
		}


		if (timerCloseMenu > 6) {
			closeOptions = true;
			content_menu.SetActive (false);
			timerCloseMenu = 0;
			MenuOpen = false;
			sound_button.AudioEfeitos (9, false);
		}

		
	}




	public void OnMouseEnter()
	{
		content_menu.SetActive (true);
		MenuOpen = true;
		sound_button.AudioEfeitos (11, false);
	}
	



	public void OnMouseExit()
	{
		closeOptions = false;
		sound_button.AudioEfeitos (11, false);

	}
	



	public void OnMouseDown()
	{
		if(MenuOpen == false){
			content_menu.SetActive (true);
			MenuOpen = true;
		} else {
			closeOptions = true;
			content_menu.SetActive (false);
			timerCloseMenu = 0;
			MenuOpen = false;
		}
	}
	
	



}
