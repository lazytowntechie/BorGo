/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveScript : MonoBehaviour {

    public float paddleSpeed = 1f;
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);
    float directionX;
    Rigidbody rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        directionX = transform.position.x + (CrossPlatformInputManager.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(directionX, -8f, 8f), -9.5f, 0f);
        rb.velocity = new Vector3(directionX * 10, 0);
        transform.position = playerPos;
    }
}*/
