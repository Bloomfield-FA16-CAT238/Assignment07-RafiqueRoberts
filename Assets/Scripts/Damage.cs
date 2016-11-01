using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{

    public GameController gameControler;
    public int damage;



    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameControler.Damage(damage);

        }
    }

}
