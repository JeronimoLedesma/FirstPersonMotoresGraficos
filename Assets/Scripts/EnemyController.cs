using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float health;
    public Slider healthSlider;
    public GameObject scoreManager;
    public int scoreGain;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("score");
        
    }

    public void loseHealth(float damage)
    {
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
        {
            scoreManager.gameObject.GetComponent<Score>().gainScore(scoreGain);
            Destroy(gameObject);
        }
    }
}
