using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour{

	// TODO: Spawn loot from Loot Table component when player interacts with chest.

	public void onDamaged(){

		// another derp

		var loottable = this.GetComponent<LootTable>();

		if(loottable != null){
			loottable.spawnLoot(this.gameObject);
		}
	}
}