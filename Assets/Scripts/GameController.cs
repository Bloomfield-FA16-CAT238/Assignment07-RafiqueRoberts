using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public ParticleSystem winningParticles;

    public Text hud;

    public float fullHealth;
    public Slider healthSlider;
    float currentHealth;




    public Canvas gameOverUI;

    //The amount of ellapsed time
    private float time = 0;

    private float deaths = 0;
    private int item = 0;

    //Flag that control the state of the game
    private bool isRunning = false;

    private bool pickup = false;

    // Use this for initialization
    void Start()
    {
        currentHealth = fullHealth;
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning)
        {
            time += Time.deltaTime;
            hud.text = "Your time is " + (int)time;
        }
        else
        {
            hud.text = "Your time was " + time;
        }

        if ((item == 1) && (isRunning))
        {
            time += Time.deltaTime;
            hud.text = "Your time is " + (int)time +
           "\nDeaths: " + (int)deaths + "\nkey obtained ";
        }

        if (Input.GetAxis("Restart") > 0)
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        player.gameObject.transform.position = respawnPoint.transform.position;
        currentHealth = fullHealth;
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
    }

    public void InitGame()
    {
        time = 0;
        deaths = 0;
        isRunning = true;

        gameOverUI.enabled = false;

        winningParticles.Stop();
        winningParticles.Clear();
        RespawnPlayer();
    }

    public void Win()
    {
        isRunning = false;
        if (pickup == true)
        {
            gameOverUI.enabled = true;
            winningParticles.Play();
        }
    }

    public void Pick()
    {
        isRunning = true;

        pickup = true;
        item = 1;
    }

    public void Damage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;


        if (currentHealth <= 0)
            RespawnPlayer();
    }


}
