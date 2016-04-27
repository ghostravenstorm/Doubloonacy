using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour{
	
	// Assigned in inspector
	[SerializeField]
	private PlayerController2D player;

	// Assigned in inspector
	[SerializeField]
	private float followDist = 3f;

	// Assigned in inspector
	[SerializeField]
	private float moveMultiplier = 3f;

	private float cameraHeight;

	private IEnumerator IE_FollowPlayer;
	private bool routineIsActive = false;

	public void Awake(){
		IE_FollowPlayer = followPlayer();
	}

	public void Start(){
		cameraHeight = this.transform.position.z;
	}

	public void Update(){

		// Check distance between player and camera
		if(getPlayerDist() > followDist && !routineIsActive){
			StartCoroutine(IE_FollowPlayer);
			routineIsActive = true;
		}
		else if(getPlayerDist() < followDist-1 && routineIsActive){
			StopCoroutine(IE_FollowPlayer);
			routineIsActive = false;
		}
	}

	// TODO: Prevent camera from going outside renderable map area
	public void OnTriggerEnter(Collider collider){

		Debug.Log("Entered camera bounds");

		Vector3 dir = (collider.gameObject.transform.position - this.transform.position).normalized;

		if(dir == Vector3.up){
			Debug.Log("Top map bound hit");
		}
	}

	private IEnumerator followPlayer(){

		while(true){
			//Debug.Log("Moving");

			// Move camera towards player
			this.transform.position = Vector3.MoveTowards(this.transform.position, player.gameObject.transform.position, moveMultiplier * player.MoveSpeed * Time.deltaTime);

			// Maintain static height
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, cameraHeight );

			yield return null;
		}
	}

	private float getPlayerDist(){
		return Vector2.Distance(player.gameObject.transform.position, this.transform.position);
	}
}