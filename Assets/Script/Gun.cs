using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bulletPrefab; //stores the bullet gameObject
	public Transform spawnObject; //a transform that spawns the game object
                                 //the transform assumes the position and rotation of the object

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetMouseButtonDown(0)) {//recognizes when the mouse input when it is clicked
            //Creates a game object aka bulletPrefab that will assume the position and rotation of the gun when spawned
			GameObject gameObj = Instantiate(bulletPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
            //set the game object, sets it as a rigidbody and adds force to when shot
            gameObj.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.VelocityChange); 
        }
	}

}