using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Holds which items are dropped from the objects this component is attached to.

public class LootTable : MonoBehaviour{

	// Holds prefab items.
	[SerializeField]
	private List<GameObject> loot;

	// Contains the drop chance of each item.
	[SerializeField] 
	[Tooltip("This list MUST be equal in size as the above.")]
	[Range(0,100)]
	private List<int> dropChance;

	[SerializeField]
	private int spawnRadius;

	private readonly System.Random random = new System.Random();

	public void spawnLoot(GameObject parent){

		int index = 0;

		// Fill `dropChance` with 0s while `loot` has more items.
		while(loot.Count > dropChance.Count)
			dropChance.Add(0);

		// Roll dice for each item in `loot`. 
		// `dropChance` needs to be equal to or greater than `loot` in size to avoid index out of range error.
		loot.ForEach(delegate(GameObject obj){
			if(rollDice() <= dropChance[index]){
				GameObject.Instantiate(obj, randomLocation(parent), parent.transform.rotation);
			}
			index++;
		});
	}

	// Chooses a random location based on `spawnRadius` around the parent object.
	private Vector3 randomLocation(GameObject parent){
		Vector3 position = parent.transform.position;
		int x = random.Next(-spawnRadius, spawnRadius);
		int y = random.Next(-spawnRadius, spawnRadius);
		position += new Vector3( (float)x, (float)y, 0);

		return position;
	}

	// Returns a random number between 0 and 100.
	private int rollDice(){
		int diceRoll = random.Next(0, 100);
		return diceRoll;
	}
}