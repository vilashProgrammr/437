using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text lives;
    public int livesRemaining = 3;
    public int bricksCount = 25;
    public Text newText;
    public Text screenWidth;
    public Text gameOverText;
    public GameObject win;
   
    public GameObject brickParticle;
    public static GameManager instance = null;
    // Use this for initialization
    private void Awake()
    {
        win.SetActive(false);
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
      
        lives.text = "Lives : 3";
        Debug.Log("Game Manager started....");
       // screenWidth.text = "ScreenWidth:" + Screen.width;
       //  Debug.Log("INTIAL BRICKS:" + bricksCount);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void decreaseLives() {
        livesRemaining--;
        lives.text = "Lives :"+livesRemaining;
        checkIfGameOvered();
    }

    public void decreaseBricksCount() {
        bricksCount--;
        checkIfGameOvered();

    }

    void checkIfGameOvered() {
        if (bricksCount<=0) {
            Debug.Log("WIN!");
            win.SetActive(true);
            Destroy(GameObject.Find("Sphere"));
        }
        else
        if (livesRemaining < 1)
        { 
            Debug.Log("Game Over");
            gameOverText.text = "Game Over!";
            Destroy(GameObject.Find("Sphere"));


        }
    
    }
  
        void Reset()
        {
            Time.timeScale = 1f;
            
      
        }
   
}
