using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker;
public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] healthIcons;

    public void TakeHealth()
    {
        health--;
        healthIcons[health].gameObject.SetActive(false);
        if(health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<PointTracker>().SaveGamePoints();
            SceneManager.LoadScene("GameOver");
        }
        
    } 

}