using UnityEngine;
using System.Collections;

public class SkeletonAnimation : MonoBehaviour {
    
    private Rigidbody2D rigidbody2d;
    public Animator animator; 
    // *** TODO: refernce animator component

    private void Start(){
		if(this.GetComponent<Rigidbody2D>() != null)
			rigidbody2d = this.GetComponent<Rigidbody2D>();
		else
			Debug.LogError(this.name + " is missing reference to RigidBody2D.");
	}

	private void Update(){
		if(rigidbody2d.velocity.x > 0){
            animator.SetBool("right", true); 
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            // *** TODO: Animation moving right.
        }
		else if(rigidbody2d.velocity.x < 0){
            animator.SetBool("left", true);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            // *** TODO: Animation moving left.
        }
		else if(rigidbody2d.velocity.y > 0){
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("up", true);
            animator.SetBool("down", false);
            // *** TODO: Animation moving up.
        }
		else if(rigidbody2d.velocity.y < 0){
            animator.SetBool("down", true);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
           
            // *** TODO: Animation moving down.
        }
		else{
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            // *** TODO: Animaiton standing still.
        }
	}
}
