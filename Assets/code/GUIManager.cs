using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour{

	// Drag Player object onto this with PlayerBehavior.cs attached
	[SerializeField]
	private GameObject player;

	// Depreciated.
	/*
	// Assigned in editor
	[SerializeField]
	private float updateRate;

	 All objects that need to be updated are assigned in editor to this array
	[SerializeField]
	private List<GameObject> UIObjects;
	*/

	[SerializeField]
	private Text coinCount;

	[SerializeField]
	private Text health;

	[SerializeField]
	private Text timer;

	[SerializeField]
	private GameObject loseSplash;

	[SerializeField]
	private GameObject winSplash;

	public void Start(){
		StartCoroutine(updateTimer());
	}

	public void updateCoins(int n){
		this.coinCount.text = n.ToString();
	}

	public void updateHealth(int current, int max){
		this.health.text = current.ToString() + " / " + max.ToString();
	}

	// TODO: Fix to adjects fill value of health bar
	/*
	public void calculateHealthbar(Entity player){

		int healthMax = player.stats.BaseHealth;
		int healthCurrent = player.stats.CurrentHealth;
		
		RectTransform healthbar = UIObjects[0].GetComponent<RectTransform>();
		float healthbarSize = healthbar.offsetMax.x;

		float newSize = ((float)healthCurrent * healthbarSize) / (float)healthbarSize;

		float nValue = healthbarSize - newSize;

		//healthbar.offsetMax.x = nValue;
	}
	*/

	public void displayLose(){
		var controller = player.GetComponent<PlayerController2D>();
		controller.controllerIsActive = false;
		this.loseSplash.SetActive(true);
	}

	public void displayWin(){
		var controller = player.GetComponent<PlayerController2D>();
		controller.controllerIsActive = false;
		this.winSplash.SetActive(true);
	}

	// Update gui with game time.
	private IEnumerator updateTimer(){

		while(true){
			string min = ((int)(Time.time / 60)).ToString();
			string sec = ((int)(Time.time % 60)).ToString();

			string time = string.Format("{0:00}:{1:00}", min, sec);
			
			this.timer.text = "Timer: " + time;
			yield return new WaitForSeconds(0.5f);
		}
	}
	

	// Depreciated.
	/*
	public void displayHint(string text){
		//UIObjects[5].SetActive(true);
		//UIObjects[6].GetComponent<Text>().text = text;
	}

	public void hideHint(){
		//UIObjects[5].SetActive(false);
	}

	// All code that updates Canvas elements go here.
	private IEnumerator updateGUI(){

		var playerStats = player.GetComponent<Stats>();
		var playerInventory = player.GetComponent<Inventory>();

		while(true){

			yield return new WaitForSeconds(updateRate);

			// Exception handling
			if(player == null)
				throw new System.Exception( this.name + " is missing PlayerBehavior reference!");

			//UIObjects[0].GetComponent<Text>().text = player.entity.stats.CurrentHealth.ToString();
			//UIObjects[1].GetComponent<Text>().text = playerStats.HealthCurrent.ToString() + " / " + playerStats.HealthBase.ToString();
			//UIObjects[7].GetComponent<Text>().text = playerInventory.coinCount.ToString();
			//UIObjects[0].GetComponent<Image>().image
		}
	}
	*/
}