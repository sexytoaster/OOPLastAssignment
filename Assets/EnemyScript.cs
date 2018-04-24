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
        x = GameObject.Find("GameManager").GetComponent<GameManager>().level;
        int tempHealth = Random.Range(20, 30);
        health = tempHealth * (1 + (x / 5));
        initialAttack = 6;
    }

    void Attack()
    {
        
        GameObject.Find("Player").GetComponent<Player>().playerHealth -= (initialAttack * (1 + (x/ 5)));
        GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn = true;
    }

    void Update()
    {
        textMesh = GetComponentsInChildren<TextMesh>();
        textMesh[0].text = health.ToString();
        textMesh[1].text = initialAttack.ToString();

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