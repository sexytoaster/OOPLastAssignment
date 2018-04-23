using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class EnemyScript : MonoBehaviour
{
    public int health = Random.Range(20, 50);


    //Start overrides the virtual Start function of the base class.
    /*void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

    }*/
}