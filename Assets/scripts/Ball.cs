using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Ball : MonoBehaviour {

	public float ballVelocity = 600f; //This will be visible in the inspector pannel

	private Rigidbody ball;
	private bool ballPlay;

	void Awake () {

		ball = GetComponent<Rigidbody>();//gets the component reference to the rigidbody

    }

	void Update () 
	{
        //this condition listens for when the GetButtonDown("Fire1") method is called
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && ballPlay == false)
		{
            //since the ball has not yet been launched
			transform.parent = null;//the parent of the ball is the paddle so we unparent the ball from the paddle
            ballPlay = true; //the ball is now in play
			ball.isKinematic = false; //turn off is kinematic which will allow the ball to move freely
			ball.AddForce(new Vector3(ballVelocity, ballVelocity, 0)); //we use vector3 as it can be represented as a direction
		}
	}
}