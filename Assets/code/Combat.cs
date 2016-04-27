using UnityEngine;
using System.Collections;

// Static class that handles combat logic.
public static class Combat{

	public static int calculateDamage(GameObject attacker, GameObject defender){

		var attackerStats = attacker.GetComponent<Stats>();
		var defenderStats = defender.GetComponent<Stats>();

		int damageDealt = attackerStats.DamageBase;

		return damageDealt;
	}

	public static void applyDamage(GameObject defender, int damage){

		var defenderStats = defender.GetComponent<Stats>();

		defenderStats.takeHealth(damage);

		Debug.Log(defender.name + " Health: " + defenderStats.HealthCurrent);
	}

	/*
	public static void killObject(GameObject target){
		GameObject.Destroy(target);
	}

	private static void checkHealth(Entity entity){
		if(entity.Obj.name == "Player"){
			
		}
		else if(entity.stats.CurrentHealth <= 0){
			Debug.Log(entity.Obj.name + " removed.");
			killObject(entity);
		}
	}
	*/
}