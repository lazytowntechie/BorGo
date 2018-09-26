using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f; //stores the paddle and is able to be edited in the inspector panel
	public float xPos; //this will store where the paddle is placed on the x axis

	private Vector3 playerPos = new Vector3 (0, -9.5f, 0); //sets the player's position 

	void Update () 
	{
        //the crossPlatformInputManager listens for when something is pressed, in this case buttons will be pressed and this line of code will listen for when they are pressed
        //the xPos will take the position of the x axis and add it to the crossPlatformInput and then multiply it by the paddleSpeed
		xPos = transform.position.x + (CrossPlatformInputManager.GetAxis("Horizontal") * paddleSpeed);
        //create a new Vector3 that will limit how far our paddle move 
		playerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0f);
        //set the position based on the input from the keyboard
		transform.position = playerPos;

	}
}