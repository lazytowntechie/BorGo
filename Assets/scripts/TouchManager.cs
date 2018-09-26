using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

	//Create a variable to store the time you start touch on the screen;
	private float InitialTouchTime;
	//Stores the time you remove yo finger from the screen
	private float FinalTouchTime;
	private Vector3 InitialTouchPosition;
	private Vector2 FinalTouchPosition;
	private float XaxisForce; //veclocity on X axis
	private float YaxisForce; //veclocity on Y axis
	private float ZaxisForce; //veclocity on Z axis
	private Vector3 RequireForce;

	public Rigidbody ball;

	public bool canSwipe = true;

	void Start()
	{
		Time.timeScale = 3; //Speeds up the game by 3
		ball.useGravity = false;
	}

	public void OnTouchDown()//gets call when mouse is pressed
	{
		if (canSwipe) {
			InitialTouchTime = Time.time;
			InitialTouchPosition = Input.mousePosition;
		}
	}

	public void OnTouchUp()//gets call when mouse is not pressed
	{
		if(canSwipe){
			FinalTouchTime = Time.time;
			FinalTouchPosition = Input.mousePosition;
			Ballthrow();
		}
	}

	public void Ballthrow()
	{
		XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x; //Force on x axis
		YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y; //Force on y axis
		ZaxisForce = FinalTouchTime - InitialTouchTime; 

		RequireForce = new Vector3 (-XaxisForce, YaxisForce/1.6f, -ZaxisForce * 200f);
		ball.useGravity = true;
        ball.isKinematic = false;
		ball.velocity = RequireForce;
		canSwipe = false;
	}
}
