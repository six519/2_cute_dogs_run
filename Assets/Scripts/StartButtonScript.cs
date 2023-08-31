using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        //reset global vars
        GlobalVariableScript.GameScore = 0;
        GlobalVariableScript.GameLives = 3;
        GlobalVariableScript.AdditionalSpeed = 0;
        GlobalVariableScript.GlobMultiplier = 0;
        //goto character selection screen
        SceneManager.LoadScene("CharacterSelectionScene");
    }
}
