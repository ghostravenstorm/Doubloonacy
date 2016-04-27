using UnityEngine;
using System.Collections;

public class NorthingtonBehavior : MonoBehaviour{
	
	[SerializeField]
	private GameObject hitbox;

	private IEnumerator ieMoveTowardsPlayer;

	private void Start(){
		ieMoveTowardsPlayer = moveTowardsPlayer();
	}

	private IEnumerator checkDistance(){

		var detectionZone = this.hitbox.GetComponent<Hitbox>();
		var player = detectionZone.getEntityByTag("player");

		float dist;

		while(true){
			dist = GameManager.getDist(player.gameObject, this.gameObject);
		}

	}

	private IEnumerator moveTowardsPlayer(){

		var detectionZone = this.hitbox.GetComponent<Hitbox>();
		var player = detectionZone.getEntityByTag("player");
		var stats = this.GetComponent<Stats>();

		while(true){

			this.transform.position = 
				Vector3.MoveTowards(
					this.transform.position, 
					player.transform.position, 
					stats.getMovement() * Time.deltaTime
				);

			yield return null;
		}
	}

	private IEnumerator attackPlayer(){
		// TODO:
		// if in melee range...
		// face player and execute attack

		yield return null;
	}
}