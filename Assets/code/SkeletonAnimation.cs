using UnityEngine;
using System.Collections;

public class SkeletonAnimation : MonoBehaviour {

	private Rigidbody2D rigidbody2d;

	// *** TODO: refernce animator component
	
	private void Start(){
		if(this.GetComponent<Rigidbody2D>() != null)
			rigidbody2d = this.GetComponent<Rigidbody2D>();
		else
			Debug.LogError(this.name + " is missing reference to RigidBody2D.");
	}

	private void Update(){
		if(rigidbody2d.velocity.x > 0){
			// *** TODO: Animation moving right.
		}
		else if(rigidbody2d.velocity.x < 0){
			// *** TODO: Animation moving left.
		}
		else if(rigidbody2d.velocity.y > 0){
			// *** TODO: Animation moving up.
		}
		else if(rigidbody2d.velocity.y < 0){
			// *** TODO: Animation moving down.
		}
		else{
			// *** TODO: Animaiton standing still.
		}
	}
}
