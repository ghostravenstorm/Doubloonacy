using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Attached to objects that have an inventory system like the player for example.

public class Inventory : MonoBehaviour{


	[SerializeField]
	private GameObject guimanager;
	
	private int coinCount;

	private List<Item> HotbarItems;
	
	private Item selectedItem;
	private int selectedIndex;

	private void Start(){
		this.coinCount = 0;

		// Update GUI.
		if(guimanager != null){
			var gui = this.guimanager.GetComponent<GUIManager>();
			gui.updateCoins(this.coinCount);
			Debug.Log("Current coins: " + coinCount);
		}
		else{
			Debug.LogError(this.gameObject.name + " Inventory is missing reference to a GUI.");
		}
	}

	public void addCoin(int n){
		this.coinCount += n;

		// Update GUI.
		if(guimanager != null){
			var gui = this.guimanager.GetComponent<GUIManager>();
			gui.updateCoins(this.coinCount);
			Debug.Log("Current coins: " + coinCount);
		}
		else{
			Debug.LogError(this.gameObject.name + " Inventory is missing reference to a GUI.");
		}
	}

	// Not implemented.
	public void navigateHotbar(int n){
		selectedItem = HotbarItems[selectedIndex + n];
		selectedIndex = selectedIndex + n;
	}

	// Not implemented.
	public void addToHotBar(Item i){
		HotbarItems.Add(i);
	}

	// Not implemented.
	public void removeFromHotbar(Item i){
		HotbarItems.Remove(i);
	}
}