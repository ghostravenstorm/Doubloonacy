using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

// Attached to objects that need health values and etc...

public class Stats : MonoBehaviour{

	[SerializeField]
	private GameObject guimanager;

	[SerializeField]
	private int healthBase;

	[SerializeField]
	private int healthCurrent;

	[SerializeField]
	private int damageBase;

	private int damageModified;

	[SerializeField]
	private bool isInvulnerable;

	private bool isAlive;

	[SerializeField]
	private float movementBase;

	public int DamageBase{
		get{ return damageBase; }
	}
	public int HealthBase{
		get{ return healthBase; }
	}
	public int HealthCurrent{
		get{ return healthCurrent; }
	}

	private void Start(){
		this.isAlive = true;

		// Update GUI
		if(guimanager != null && this.gameObject.tag.ToLower() == "player"){
			var gui = guimanager.GetComponent<GUIManager>();
			gui.updateHealth(this.healthCurrent, this.healthBase);
		}
		else if(this.gameObject.tag.ToLower() != "player"){
			// Do nothing with the gui if this is not the player.
		}
		else{
			Debug.LogError(this.gameObject.name + " Stats is missing refernce to GUI.");
		}
	}

	public void addHealth(int n){

		//Debug.Log("addHealth() enter");

		if(this.isAlive){
			this.healthCurrent += n;
			Debug.Log(this.gameObject.name + " Current health: " + this.healthCurrent);
		}

		if(this.isAlive && this.healthCurrent > this.healthBase)
			this.healthCurrent = this.healthBase;

		checkHealth();

		//Debug.Log("addHealth() exit");
	}

	public void takeHealth(int n){
		if(isInvulnerable)
			return;

		if(isAlive)
			healthCurrent -= n;

		checkHealth();
	}

	public void makeInvulnerable(){
		isInvulnerable = true;
	}

	public void makeVulnerable(){
		isInvulnerable = false;
	}

	public float getMovement(){
		return movementBase;
	}

	public void setMovement(float n){
		this.movementBase = n;
	}

	private void checkHealth(){
		string name = this.gameObject.name;
		string tag = this.gameObject.tag;

		var loot = this.GetComponent<LootTable>();

		// Update GUI
		if(guimanager != null && this.gameObject.tag.ToLower() == "player"){
			var gui = guimanager.GetComponent<GUIManager>();
			gui.updateHealth(this.healthCurrent, this.healthBase);
		}
		else if(this.gameObject.tag.ToLower() != "player"){
			// Do nothing with the gui if this is not the player.
		}
		else{
			Debug.LogError(this.gameObject.name + " Stats is missing refernce to GUI.");
		}

		// Death.
		if(this.healthCurrent <= 0){

			isAlive = false;

			// Check if player.
			if(name.ToLower() == "player" || tag.ToLower() == "player"){
				var gui = guimanager.GetComponent<GUIManager>();
				gui.displayLose();
				return;
			}

			if(loot != null)
				loot.spawnLoot(this.gameObject);

			Debug.Log("Destroying " + this.gameObject.name);

			Destroy(this.gameObject);
		}
	}
}