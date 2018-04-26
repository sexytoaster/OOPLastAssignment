using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class EnemyScript : MonoBehaviour
{
    private TextMesh[] textMesh;
    public int health;
    public int initialAttack;
    public int x;

    void Awake()
    {
        //on spawn it finds out the level, used to scale attack and health
        x = GameObject.Find("GameManager").GetComponent<GameManager>().level;
        //add randomness to enemy
        int tempHealth = Random.Range(20, 30);
        health = tempHealth * (1 + (x / 5));
        //attack starts at 6 a turn, will also add turns where this randomizes a bit i think
        initialAttack = 6;
    }

    void Attack()
    {
        //funtion for attack for enemy, reduces player health
        GameObject.Find("Player").GetComponent<Player>().playerHealth -= (initialAttack * (1 + (x/ 5)));
        //switches to player turn, should probably make a proper controller
        GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn = true;
        GameObject.Find("Player").GetComponent<Player>().StartTurn();
    }

    void Update()
    {
        textMesh = GetComponentsInChildren<TextMesh>();
        textMesh[0].text = health.ToString();
        textMesh[1].text = initialAttack.ToString();

        //if its not the players turn, do the enemy turn
        bool turn = GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn;
        if(turn == false)
        {
            Attack();
        }

    }




    //Start overrides the virtual Start function of the base class.
    /*void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

    }*/
}