using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour{
    private Animator animator;
	// TOP DOWN 2D CONTROLLER

	// Assigned in inspector
	[SerializeField]
	private PlayerBehavior player;

	[SerializeField]
	private float moveSpeed;

	private float moveSpeedDiag;
	private float moveCurrent;

	public bool controllerIsActive;

	public float MoveSpeed{
		get{ return moveSpeed; }
	}

	public void Start(){
        //animator = this.GetComponent<Animator>();
		controllerIsActive = true;

		moveSpeed = moveSpeed * GameManager.MOVE_SCALE;

		moveSpeedDiag = moveSpeed - (moveSpeed * 0.3f);
		//moveSpeedDiag = moveSpeed;
	}

	public void Update(){

		//Debug.Log(this.transform.position);

		if(controllerIsActive){ 
		

			// Mouse input
			if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)){
				// Primary attack
				player.primeAttack();
               
			}

			//Note: GetAxis causes lag

			//Un-accelerated
			//2D Movement diaganol
			if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
				//Up-Right
				this.transform.position += new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position += new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.4f, -0.9f);
                //animator.SetBool("right", true);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
            }
			else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
				//Up-Left
				this.transform.position += new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position -= new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.4f, 0.9f);
                //animator.SetBool("left", true);
                //animator.SetBool("up", false);
                //animator.SetBool("right", false);
                //animator.SetBool("down", false);
            }
			else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)){
				//Down-Right
				this.transform.position -= new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position += new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.9f, -0.4f);
                //animator.SetBool("right", true);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
            }
			else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
				//Down-Left
				this.transform.position -= new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position -= new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.9f, 0.4f);
                //animator.SetBool("left", true);
                //animator.SetBool("up", false);
                //animator.SetBool("right", false);
                //animator.SetBool("down", false);
            }

			//2D Movement non-diaganol
			else if(Input.GetKey(KeyCode.D)){
				//Right
				this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, -7.0f, 7.0f);
                //animator.SetBool("right", true); //Starts the walkRight animation
                //animator.SetBool("left", false);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);

            }
			else if(Input.GetKey(KeyCode.A)){
				//Left
				this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 7.0f, 7.0f);
                //animator.SetBool("left", true); //Starts the walkLeft animation
                //animator.SetBool("right", false);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
            }
			else if(Input.GetKey(KeyCode.W)){
				//Up
				this.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 1.0f);
                //animator.SetBool("up", true); //Starts the walkBack animation
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
                //animator.SetBool("right", false);
            }
			else if(Input.GetKey(KeyCode.S)){
				//Down
				this.transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 1.0f, 0f);
                //animator.SetBool("down", true); //Starts the walkForward animation
                //animator.SetBool("up", false);
                //animator.SetBool("right", false);
                //animator.SetBool("left", false);
            }
            else
            {
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
                //animator.SetBool("right", false);
            }
		}
	}
}