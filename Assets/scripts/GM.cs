using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f; //the time in seconds after the game has ended
	public Text livesText;
	public GameObject gameOver;
	public GameObject win;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null; //by make instance a static variable it means that we are going to access it in the class through other class

    public List<GameObject> characters = new List<GameObject>();//this list is an array of gameobjects
    public GameObject currentCharacter;
    int index;

    private GameObject clonePaddle;

    void Start()
    {
        index = Random.Range(0, characters.Count);
        characters[index].SetActive(false);
        bricksPrefab.SetActive(true);
        paddle.SetActive(true);
    }
    // Use this for initialization
    void Awake () { //this will check if there are two copies of the game manager
		if(instance == null) //checks if a game manager is present
			instance = this;
		else if(instance != this) // if there is already a game manager
			Destroy (gameObject);
		Setup ();

	}

	public void Setup(){ //setup the game
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject; //creates the paddle as a gameobject, Quaternion means no rotation
		Instantiate(bricksPrefab, transform.position, Quaternion.identity); //create the pricks 
	}

    //after a life has been lost we'll check if the game has ended
	void CheckGameOver(){
		if(bricks < 1)
		{
			win.SetActive (true);
            currentCharacter = characters[index];
            characters[index].SetActive(true);
            bricksPrefab.SetActive(false);
            paddle.SetActive(false);
        }
		if(lives < 1){
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

	}

	void Reset () {
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);//the last level that was loaded will be reloaded
	}

	public void Death(){
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;

	}

	public void RemoveBricks(){

		bricks--;
		CheckGameOver ();
	}

}