using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Copyright © 2020, Frank Martin
public class HealthManager : MonoBehaviour
{
    public static Transform healthDisplay;
    public static float maxHealth = 100.0f;
    public static float currentHealth;
    public static string newGameScene = "TitleScreen";
    private static float healthOriginalYScale;
    // Start is called before the first frame update

    
    void Start()
    {
        healthDisplay = GameObject.FindGameObjectWithTag("HealthBarBar").transform;
        currentHealth = maxHealth;
        healthOriginalYScale = healthDisplay.localScale.y;
    }

    
    public static void damagePlayer(float damageAmount)  //function to decrease health of player
    {
        Debug.Log("Damage player called");
        if (damageAmount <= 0)
        {
            Debug.Log("Cannot damage player for a negative value. That would heal them.");
        }
        else
        {
            currentHealth = currentHealth - damageAmount;
            healthDisplay.localScale = new Vector3(healthDisplay.localScale.x, healthOriginalYScale * (currentHealth/ maxHealth), healthDisplay.localScale.z);
            if (currentHealth < 0)
            {
                Debug.Log("Player has died");
                currentHealth = 0;
                
                SceneManager.LoadScene(newGameScene);
                //Not sure what I want to do here
            }
        }
    }

    public static void healPlayer(float healAmount)  //function to decrease health of player
    {
        if (healAmount < 0)
        {
            Debug.Log("Cannot heal player for a negative value. That would damage them.");
        }
        else
        {
            if (currentHealth + healAmount > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = currentHealth + healAmount;
            }

            healthDisplay.localScale = new Vector3(healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.z);
        }
    }
}
