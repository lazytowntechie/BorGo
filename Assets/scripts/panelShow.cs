using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelShow : MonoBehaviour {

	public GameObject Panel;


	public void showPanel()
	{
		Panel.gameObject.SetActive (true);
	}
		
}