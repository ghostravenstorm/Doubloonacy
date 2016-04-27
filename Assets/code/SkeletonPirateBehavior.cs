using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkeletonPirateBehavior : MonoBehaviour{

	[SerializeField]
	private PlayerBehavior player;

	[SerializeField]
	private SoundManager soundmanager;

	// Variables to hold coroutine data.
	private IEnumerator IE_CheckDistance;
	private IEnumerator IE_ChasePlayer;
	private IEnumerator IE_ReturnToStart;

	// Keep a list of every coroutine running.
	private List<IEnumerator> routines = new List<IEnumerator>();

	private Vector3 startPos;

	public void Awake(){
		IE_CheckDistance = checkDistance();
		IE_ChasePlayer = chasePlayer(player.transform, this.transform);
		IE_ReturnToStart = returnToStart();

		routines.Add(IE_CheckDistance);
		routines.Add(IE_ChasePlayer);
		routines.Add(IE_ReturnToStart);
	}
	
	public void Start(){
		startPos = this.transform.position;
		StartCoroutine(IE_CheckDistance);

		//Scale movement.
		if(this.GetComponent<Stats>() != null){
			var stats = this.GetComponent<Stats>();
			stats.setMovement(stats.getMovement() * GameManager.MOVE_SCALE);
		}
	}

	public void Update(){
		//Debug.Log(currentHealth);
	}

	public void OnDestroy(){
		//soundmanager.setAmbientMusic();
	}

	// Constantly check if player is in range of this entity.
	private IEnumerator checkDistance(){

		// TODO: Make ranges changable in inspector.

		float startDelay = 1.0f;
		float interval = 0.1f;

		// Distance which this entity detects the player.
		float distRange = 5f * GameManager.DIST_SCALE;

		// Distance which this entity will chase the player before returning to position.
		float returnRange = 10f * GameManager.DIST_SCALE;

		bool isChasing = false;
		bool isReturning = false;

		yield return new WaitForSeconds(startDelay);

		while(true){

			float distFromPlayer = GameManager.getDist(this.gameObject, player.gameObject);
			float distFromStart = Vector2.Distance(this.transform.position, startPos);
			//Debug.Log(GameManager.getDist(this.gameObject, player.gameObject));
			
			// Distance check to change music.
			if( distFromPlayer <= distRange && !soundmanager.isCombatMusicPlaying() ){
				// change combat music
				//Debug.Log("Switching to combat.");
				//soundmanager.setCombatMusic();
			}
			else if( distFromPlayer > distRange && !soundmanager.isAmbientMusicPlaying() ){
				// change ambient music
				//Debug.Log("Switching to ambient.");
				//soundmanager.setAmbientMusic();
			}

			// Distance check to enable chase or return to starting position.
			if( distFromPlayer <= distRange && !isChasing){
				// Chase the player when within range
				StartCoroutine(IE_ChasePlayer);
				isChasing = true;
			}
			else if( distFromPlayer > distRange && isChasing){
				// Stop chasing once player leaves range.
				StopCoroutine(IE_ChasePlayer);
				isChasing = false;

				if(!isReturning){
					// Return to original position.
					StartCoroutine(IE_ReturnToStart);
					isReturning = true;
				}
			}
			else if(isReturning && distFromStart <= 0.5f){
				// Stop returning once entity has returned
				StopCoroutine(IE_ReturnToStart);
				isReturning = false;
			}

			yield return new WaitForSeconds(interval);
		}
	}

	private IEnumerator chasePlayer(Transform playerPos, Transform entityPos){

		var stats = this.GetComponent<Stats>();

		float stopRange = 1f * GameManager.DIST_SCALE;	// Distance at which this entity will stop moving towards the player

		while(true){
			float dist = GameManager.getDist(this.gameObject, player.gameObject);

			//if( dist > stopRange)
			entityPos.position = Vector3.MoveTowards(entityPos.position, playerPos.position, stats.getMovement() * Time.deltaTime);
			
			yield return null;
		}
	}

	private IEnumerator returnToStart(){

		var stats = this.GetComponent<Stats>();

		while(true){
			this.transform.position = Vector3.MoveTowards(this.transform.position, startPos, stats.getMovement() * Time.deltaTime);
			yield return null;
		}
	}

	// Stops all other corountines except the one passed in.
	private void stopAllOtherRoutines(IEnumerator a){

		routines.ForEach(delegate(IEnumerator b){
			if(a != b)
				StopCoroutine(b);
		});
	}
}