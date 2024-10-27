using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI scoreDisplay;
    int numberOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void gainScore(int gain)
    {
        score += gain;
        scoreDisplay.text = score.ToString();
        if (score == numberOfEnemies*10)
        {
            SceneManager.LoadScene(1);
        }
    }
}
