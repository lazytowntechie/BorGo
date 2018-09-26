using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketBall : MonoBehaviour {

	public Text score;
	public Text attempt;

	//private int counter = 0;
	private int attemptScore = 0;
	private int currentScore = 0;
	private Vector3 IntialPosition;
	private TouchManager touchsystem;
	public List <GameObject> characters = new List<GameObject>();
	public GameObject hoop; 
	public GameObject ball; 

	public GameObject currentCharacter;

	int index;

	void Start()
	{
		//characters = GameObject.FindGameObjectsWithTag ("characters");
		index = Random.Range (0, characters.Count);
		characters [index].SetActive(false);

		hoop.SetActive(true);
		ball.SetActive (true);
		touchsystem = GameObject.FindObjectOfType<TouchManager>().GetComponent<TouchManager>();
		IntialPosition = this.transform.position; //set initial position to current ball
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ring") {
			ScoreUpdate();
		} else if(col.gameObject.tag == "Boundary")
		{
			AttemptsUpdate();
		}
	}


	private void ScoreUpdate()
	{
		currentScore++;
		score.text = currentScore.ToString();
		if(currentScore >= 2)
		{
			currentCharacter = characters [index];
			characters [index].SetActive (true);
			ball.SetActive (false);
			hoop.SetActive(false);
		}
	}

	private void AttemptsUpdate()
	{
		attemptScore++;
		attempt.text = attemptScore.ToString();
	}

	public void ResetPosition()
	{
		this.transform.position = IntialPosition + new Vector3(Random.RandomRange(-70f, 70f), 0f, 0f);
		this.GetComponent<Rigidbody>().useGravity = false;
		this.GetComponent<Rigidbody>().isKinematic = true;
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		touchsystem.canSwipe = true;
	}

}