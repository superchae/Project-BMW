using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    [SerializeField] GameObject player;

    int maxHealth;
    int playerHealth;

    Text health;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = player.GetComponent<PlayerController>().GetMaxHealth();
        health = GameObject.Find("Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthUpdate();
    }

    public void HealthUpdate()
    {
        playerHealth = player.GetComponent<PlayerController>().GetPlayerHealth();

        string healthIndicator = "";
        /*
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < playerHealth)
            {
                healthIndicator += "@ ";
            }
        }
        */

        // int leftDistance = playerHealth * 15;
        int leftDistance = SideViewGameplay1.sideViewGameplay1.playerHealth * 15;
        healthIndicator += "<<< " + leftDistance.ToString() + " m";

        health.text = healthIndicator;
    }
}
