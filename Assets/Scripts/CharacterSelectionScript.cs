using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour
{
    public int CharacterSelection = 0;

    private void OnMouseDown()
    {
        GlobalVariableScript.SelectedCharacter = CharacterSelection;
        SceneManager.LoadScene("GameScene");
    }
}
