using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelShowHide : MonoBehaviour {

	public GameObject Panel; //targets a selected object in the scene
	int counter;

	public void showHidePanel()
	{

		counter++; //used with modulus
		if (counter % 2 == 1) { //use modulus to see if value is one or another
			Panel.gameObject.SetActive (false); //make object disapear
		} 
		else {
			Panel.gameObject.SetActive (true); //make object appear
		}
	}
	//cannot make object re-appear as the option to pressa button will no longer be available

}
