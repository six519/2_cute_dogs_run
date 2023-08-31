using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackCloseButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainScene");
    }
}
