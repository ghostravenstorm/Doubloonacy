using UnityEngine;
using System.Collections;

// Restores the health of the player.

public class Orange : MonoBehaviour, Item{

	[SerializeField]
	private int restoreValue;

	public void OnTriggerEnter2D(Collider2D collider){

		var stats = collider.GetComponent<Stats>();

		string name = collider.gameObject.name;
		string tag = collider.gameObject.tag;

		if(stats != null && (name.ToLower() == "player" || tag.ToLower() == "player")){	

			Debug.Log("Restoring " + name + " health.");
			stats.addHealth(this.restoreValue);

			Destroy(this.gameObject);
		}
	}
}