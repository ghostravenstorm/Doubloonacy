using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Attach this to a hitbox object 

public class Hitbox : MonoBehaviour{

	// List to hold every entity inside this hitbox
	private List<GameObject> entities = new List<GameObject>();
	
	// Add entity to list when they enter.
	public void OnTriggerEnter2D(Collider2D collider){

		string tag = collider.gameObject.tag;

		// Filter eligible entities by tag.
		if(tag.ToLower() == "destructible" || tag.ToLower() == "enemy" || tag.ToLower() == "player"){
			Debug.Log("Adding " + collider.gameObject.name + " to list." );
			this.entities.Add(
				collider.gameObject);
		}
	}

	// Remove entity from list when they leave.
	public void OnTriggerExit2D(Collider2D collider){
		if(this.entities.Contains(collider.gameObject)){
			Debug.Log("Removing " + collider.gameObject.name + " to list." );
			this.entities.Remove(collider.gameObject);	
		}
		
	}

	// Returns ALL entities in this hitbox.
	public List<GameObject> getEntitiesHit(){

		nullcheck();

		return this.entities;
	}

	// Returns all entities in this hitbox by tag.
	public List<GameObject> getEntitiesByTag(string tag){

		List<GameObject> entities = new List<GameObject>();

		nullcheck();

		for(int i = 0; i < this.entities.Count; i++){
			if(this.entities[i].tag.ToLower() == tag.ToLower()){
				this.entities.Add(this.entities[i]);
			}
		}

		return entities;
	}

	// Returns the first entity found by tag in this hitbox.
	public GameObject getEntityByTag(string tag){

		GameObject entity = null;

		nullcheck();

		for(int i = 0; i < this.entities.Count; i++){
			if(this.entities[i].tag.ToLower() == tag.ToLower()){
				entity = this.entities[i];
				break;
			}
		}

		return entity;
	}

	// Check if an object in this list has been destroyed then remove it.
	private void nullcheck(){

		this.entities.ForEach(delegate(GameObject entity){
			if(entity == null)
				this.entities.Remove(entity);
		});
	}
}