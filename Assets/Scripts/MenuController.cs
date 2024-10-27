using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    
    void Start()
    {
        display.text = Score.score.ToString() + " puntos";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Score.score = 0;
            SceneManager.LoadScene(0);
        }
    }
}
