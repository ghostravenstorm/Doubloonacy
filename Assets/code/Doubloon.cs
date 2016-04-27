using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

public class Doubloon : MonoBehaviour, Item{

	[SerializeField]
	private int iValue;

	public void OnTriggerEnter2D(Collider2D collider){

		var inventory = collider.GetComponent<Inventory>();

		string name = collider.gameObject.name;
		string tag = collider.gameObject.tag;

		if(inventory != null && (name.ToLower() == "player" || tag.ToLower() == "player")){	

			Debug.Log("Coin picked up.");

			// Add to coin count
			inventory.addCoin(this.iValue);

			Destroy(this.gameObject);
		}
	}
}