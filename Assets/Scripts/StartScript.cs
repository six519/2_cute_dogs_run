using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public float timeToSwitch = 5.0f;
    void Update()
    {
        timeToSwitch -= Time.deltaTime;

        if (timeToSwitch <= 0.0f)
        {
            GoToMainScene();
        }
    }

    void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
