using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		GM.instance.Death ();
	}
}

