using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class EnemyScript : MonoBehaviour
{
    private TextMesh[] textMesh;
    public int health;
    public int vunerable;
    public int weak;
    public int initialAttack;
    public int thisAttack;
    public int healthReduction;
    public int x;
    public int block;

    void Awake()
    {
        GameObject.Find("Player").GetComponent<Player>().strength = 0;
        //on spawn it finds out the level, used to scale attack and health
        x = GameObject.Find("GameManager").GetComponent<GameManager>().level;
        //add randomness to enemy
        int tempHealth = Random.Range(20, 30);
        health = tempHealth * (1 + (x / 5));
        //attack starts at 6 a turn, will also add turns where this randomizes a bit i think
        initialAttack = 6 + (3 * x/2);

    }

    void Attack()
    {
        thisAttack = initialAttack;
        if(weak > 0)
        {
            thisAttack = (thisAttack / 4) * 3;
            weak--;
        }
        if(vunerable > 0)
        {
            vunerable--;
        }
        x = GameObject.Find("GameManager").GetComponent<GameManager>().level;
        //funtion for attack for enemy, reduces player health
        if (GameObject.Find("Player").GetComponent<Player>().playerBlock > 0)
        {
            block = GameObject.Find("Player").GetComponent<Player>().playerBlock;
            healthReduction = block - thisAttack;
            if (healthReduction < 0)
            {
                GameObject.Find("Player").GetComponent<Player>().playerHealth += healthReduction;
            }
        }
        else
        {
            GameObject.Find("Player").GetComponent<Player>().playerHealth -= thisAttack;
        }
        if(GameObject.Find("Player").GetComponent<Player>().playerHealth <= 0)
        {
            SceneManager.LoadScene("Defeat", LoadSceneMode.Single);
            GameObject.Find("Player").GetComponent<Player>().playerHealth = 50;
        }
        //switches to player turn, should probably make a proper controller
        GameObject.Find("Player").GetComponent<Player>().playerBlock = 0;
        GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn = true;
        GameObject.Find("Player").GetComponent<Player>().StartTurn();
    }

    void Update()
    {
        textMesh = GetComponentsInChildren<TextMesh>();
        textMesh[0].text = health.ToString();
        textMesh[1].text = initialAttack.ToString();
        textMesh[2].text = weak.ToString();
        textMesh[3].text = vunerable.ToString(); 

        //if its not the players turn, do the enemy turn
        bool turn = GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn;
        if(turn == false)
        {
            initialAttack = (initialAttack * (1 + (x / 5)));
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