using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour
{
    //so we can grab the animator that is on this  game object
    public Animator GingerBeardAnimator;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log ("DSfdsfS");
        /*
        //GetKey is for holding it down, GetKey is for the key is depressed the first time
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("movingUp", true);
        }
        */
        //

        /*if (Input.GetButtonDown(KeyCode.A) )//|| Input.GetKeyDown(KeyCode.DownArrow))
        {

            anim.SetBool("back", true);
        }
		*/

        //this if-else if-else block is for movement
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {//|| Input.GetKeyDown(KeyCode.DownArrow))

            GingerBeardAnimator.SetBool("up", true);
            GingerBeardAnimator.SetBool("left", false);
            GingerBeardAnimator.SetBool("right", false);
            GingerBeardAnimator.SetBool("down", false);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
        {//|| Input.GetKeyDown(KeyCode.DownArrow))

            GingerBeardAnimator.SetBool("up", false);
            GingerBeardAnimator.SetBool("left", false);
            GingerBeardAnimator.SetBool("right", false);
            GingerBeardAnimator.SetBool("down", true);
        }

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {

            GingerBeardAnimator.SetBool("up", false);
            GingerBeardAnimator.SetBool("left", false);
            GingerBeardAnimator.SetBool("right", true);
            GingerBeardAnimator.SetBool("down", false);
        }

        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
        {

            GingerBeardAnimator.SetBool("up", false);
            GingerBeardAnimator.SetBool("left", true);
            GingerBeardAnimator.SetBool("right", false);
            GingerBeardAnimator.SetBool("down", false);
        }


        else
        {//no movement keys pressed
            GingerBeardAnimator.SetBool("up", false);
            GingerBeardAnimator.SetBool("left", false);
            GingerBeardAnimator.SetBool("right", false);
            GingerBeardAnimator.SetBool("down", false);
        }

    }
}
