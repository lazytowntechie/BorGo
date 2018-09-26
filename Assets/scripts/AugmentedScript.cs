using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AugmentedScript : MonoBehaviour
{
	private Vector3 targetPosition; //where the ojbest is to be moved to
	private Vector3 originalPosition; //keep object in a specific position (ie. keep its Y-Axis Postion)
	private float speed = .1f; // set speed of rotaion

	void Start(){
		targetPosition = transform.position;
		originalPosition = transform.position;
	}

	void Update(){
		//linearly interpolate from current position to target position
		transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
		//rotate (by 1 degree) the y axis every frame
		transform.eulerAngles += new Vector3 (0, 1f, 0);
		//prevents object from dropping
		this.GetComponent<Rigidbody>().useGravity = false;
	}
}