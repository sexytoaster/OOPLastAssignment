using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    //private GameManager gameManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        SceneManager.LoadScene("backupBreslav", LoadSceneMode.Single);
        //GameObject.Find("GameManager").GetComponent<GameManager>().InitGame();
        GameObject.Find("GameManager").GetComponent<BoardManager>().DrawHand();
        GameObject.Find("Player").GetComponent<Player>().currentMana = GameObject.Find("Player").GetComponent<Player>().maxMana;

    }
}
