using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour{
	// TOP DOWN 2D CONTROLLER

	// Assigned in inspector
	[SerializeField]
	private PlayerBehavior player;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private Animator animator;

	private float moveSpeedDiag;
	private float moveCurrent;

	public bool controllerIsActive;

	/// Facing direction
	/// 0 = north; 1 = west; 2 = south; 3 = east
	private int direction = 0;

	/// Strings used to hold parameter names in the animator.
	private string[] animationMoveStates = {"up", "left", "right", "down"};
	private string[] animationAttackStates = {"up attack", "right attack", "left attack", "down attack"};

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
		

			/// Action input
			if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)){
				/// Primary attack
				player.primeAttack();

				/// Attack animation
				animateAttack(this.direction);
			}

			/// Note: GetAxis causes lag

			/// Un-accelerated
			/// 2D Movement diaganol
			if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
				/// Up-Right
				this.transform.position += new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position += new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.4f, -0.9f);

				/// No aniamtions need to be played here.
                //animator.SetBool("right", true);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
            }
			else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
				/// Up-Left
				this.transform.position += new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position -= new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.4f, 0.9f);

				/// No aniamtions need to be played here.
                //animator.SetBool("left", true);
                //animator.SetBool("up", false);
                //animator.SetBool("right", false);
                //animator.SetBool("down", false);
            }
			else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)){
				/// Down-Right
				this.transform.position -= new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position += new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.9f, -0.4f);

				/// No aniamtions need to be played here.
                //animator.SetBool("right", true);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
            }
			else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
				/// Down-Left
				this.transform.position -= new Vector3(0, moveSpeedDiag * Time.deltaTime, 0);
				this.transform.position -= new Vector3(moveSpeedDiag * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0.9f, 0.4f);

				/// No aniamtions need to be played here.
                //animator.SetBool("left", true);
                //animator.SetBool("up", false);
                //animator.SetBool("right", false);
                //animator.SetBool("down", false);
            }

			//2D Movement non-diaganol
			else if(Input.GetKey(KeyCode.D)){
				/// Right
				this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, -7.0f, 7.0f);

				this.direction = 1;

				setMoveAnimation("right");
                //animator.SetBool("right", true); //Starts the walkRight animation
                //animator.SetBool("left", false);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);

            }
			else if(Input.GetKey(KeyCode.A)){
				/// Left
				this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 7.0f, 7.0f);

				this.direction = 2;

				setMoveAnimation("left");
                //animator.SetBool("left", true); //Starts the walkLeft animation
                //animator.SetBool("right", false);
                //animator.SetBool("up", false);
                //animator.SetBool("down", false);
            }
			else if(Input.GetKey(KeyCode.W)){
				/// Up
				this.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 1.0f);

				this.direction = 0;

				setMoveAnimation("up");
                //animator.SetBool("up", true); //Starts the walkBack animation
                //animator.SetBool("down", false);
                //animator.SetBool("left", false);
                //animator.SetBool("right", false);
            }
			else if(Input.GetKey(KeyCode.S)){
				/// Down
				this.transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
				player.hitbox.gameObject.transform.rotation = new Quaternion(0f, 0f, 1.0f, 0f);

				this.direction = 3;

				setMoveAnimation("down");
                //animator.SetBool("down", true); //Starts the walkForward animation
                //animator.SetBool("up", false);
                //animator.SetBool("right", false);
                //animator.SetBool("left", false);
            }
            else
            {
                setMoveAnimation("");
            }
		}
	}

	/// Call this method passing the string name of the bool
	///  that needs to be switched on in the animator.
	private void setMoveAnimation(string state){

		/// Switch off all moving animations.
		for(int i = 0; i < animationMoveStates.Length; i++){
			this.animator.SetBool(animationMoveStates[i], false);
		}

		/// Switch on desired aniamtion.
		this.animator.SetBool(state, true);
	}

	private void animateAttack(int n){
		animator.SetTrigger(animationAttackStates[n]);	
	}
}