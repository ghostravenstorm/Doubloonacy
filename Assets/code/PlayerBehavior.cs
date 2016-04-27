using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerBehavior : MonoBehaviour{

	[SerializeField]
	public Hitbox hitbox;

	[SerializeField]
	private SoundManager soundmanager;

	private IEnumerator IE_MakeInvulnerable;

	public void Start(){
		IE_MakeInvulnerable = makeInvulnerable();
	}

	public void Update(){
		//Debug.Log("Player position: " + this.transform.position);
	}

	public void primeAttack(){

		List<GameObject> defenders = hitbox.getEntitiesHit();

		AudioSource sound = soundmanager.getSwordSwish();
		sound.Play();

		defenders.ForEach(delegate(GameObject defender){
			
			int damageDealt = Combat.calculateDamage(this.gameObject, defender);
			Combat.applyDamage(defender, damageDealt);

		});
	}

	public void OnCollisionEnter2D(Collision2D collision){
		
		string tag = collision.gameObject.tag;
		
		// Damage player when enemies run into him.
		if(tag.ToLower() == "enemy"){
			int damageDealt = Combat.calculateDamage(collision.gameObject, this.gameObject);
			Combat.applyDamage(this.gameObject, damageDealt);
			StartCoroutine(IE_MakeInvulnerable);
		}
	}

	private IEnumerator makeInvulnerable(){

		var stats = this.GetComponent<Stats>();

		stats.makeInvulnerable();

		yield return new WaitForSeconds(1.0f);

		stats.makeVulnerable();
		StopCoroutine(IE_MakeInvulnerable);
	}


	private float getDist(GameObject a, GameObject b){
		return Vector3.Distance(a.transform.position, b.transform.position);
	}
}