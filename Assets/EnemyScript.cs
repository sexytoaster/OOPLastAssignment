using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class EnemyScript : MonoBehaviour
{
    private GameManager gameManager;
    private TextMesh[] textMesh;
    public int health;

    void Awake()
    {
        int x = GameObject.Find("GameManager").GetComponent<GameManager>().level;
        int tempHealth = Random.Range(20, 30);
        health = tempHealth * (1 + (x / 5));
    }

    void Update()
    {
        textMesh = GetComponentsInChildren<TextMesh>();
        textMesh[0].text = health.ToString();


    }




    //Start overrides the virtual Start function of the base class.
    /*void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

    }*/
}