using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private TextMesh ScoreTextMesh;
    public AudioSource Success;
    void Start()
    {
        ScoreTextMesh = GameObject.Find("Score").GetComponent<TextMesh>();
        ScoreTextMesh.text = "Score:" + GlobalVariableScript.GameScore;
        Success.Play();
    }
}
