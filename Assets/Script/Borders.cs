using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour {
    //this method will execute once an object has hit it's box collider
	void OnTriggerEnter(Collider other)
	{
        //if the object hit has the tag of border
		if(other.gameObject.tag == "border")
		{
            //destroy the game object that hit it
			Destroy (this.gameObject);
		}
	}
}
