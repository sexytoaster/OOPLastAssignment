using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance = null;
    private TextMesh[] textMesh;
    public int playerHealth = 50;
    public int playerBlock = 0;
    public int currentMana = 3;
    public int maxMana = 3;
    public int strength = 0;
    public int level;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        currentMana = maxMana;
    }

    public void StartTurn()
    {
        currentMana = maxMana;
        GameObject Hand = GameObject.Find("Hand");
        foreach (Transform child in Hand.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject.Find("GameManager").GetComponent<BoardManager>().DrawHand();
        level = GameObject.Find("GameManager").GetComponent<GameManager>().level;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        textMesh = GetComponentsInChildren<TextMesh>();
        textMesh[0].text = playerHealth.ToString();
        textMesh[1].text = playerBlock.ToString();
        textMesh[2].text = currentMana.ToString();
        textMesh[3].text = "level: " + level.ToString();
    }
}
