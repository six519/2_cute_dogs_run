using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float BackgroundSpeed = 2;
    public Renderer BackgroundRender;
    public AudioSource BackgroundMusic;
    public GameObject CloudOne;
    public GameObject CloudTwo;
    public GameObject CloudThree;
    public GameObject[] Hearts;
    public GameObject Heart;
    public GameObject Loot;
    public GameObject Arrow;
    public float RespawnTimeCloudOne = 3.0f;
    public float RespawnTimeCloudTwo = 2.5f;
    public float RespawnTimeCloudThree = 5.0f;
    public float RespawnTimeLoot = 1.5f;
    public float RespawnTimeArrow = 4f;
    private Vector2 ScreenBounds;
    private TextMesh ScoreTextMesh;
    private float PrevAddSpeed;
    private float Multiplier = 0;
    void Start()
    {
        PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
        BackgroundMusic.Play();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ScoreTextMesh = GameObject.Find("Score").GetComponent<TextMesh>();
        StartCoroutine(ShowCloudOne());
        StartCoroutine(ShowCloudTwo());
        StartCoroutine(ShowCloudThree());
        StartCoroutine(ShowLoot());
        StartCoroutine(ShowArrow());

        Hearts = new GameObject[GlobalVariableScript.GameLives];

        if (GlobalVariableScript.SelectedCharacter == 0)
        {
            Heart.GetComponent<SpriteRenderer>().sprite = Resources.Load("heart_resize", typeof(Sprite)) as Sprite;
        }
        else
        {
            Heart.GetComponent<SpriteRenderer>().sprite = Resources.Load("heart_resize3", typeof(Sprite)) as Sprite;
        }

        float heart_x = -6.2f;
        for (int num=0; num < 3; num++)
        {
            GameObject go = Instantiate(Heart);
            go.transform.position = new Vector2(heart_x, 3.8f);
            heart_x += 0.75f;
            Hearts[num] = go;
        }
    }

    public void UpdateHearts()
    {
        //Destroy hearts first
        for (int num=0; num < GlobalVariableScript.GameLives + 1; num++)
        {
            Destroy(Hearts[num]);
        }

        //Redraw hearts
        float heart_x = -6.2f;
        for (int num = 0; num < GlobalVariableScript.GameLives; num++)
        {
            GameObject go = Instantiate(Heart);
            go.transform.position = new Vector2(heart_x, 3.8f);
            heart_x += 0.75f;
            Hearts[num] = go;
        }
    }

    void Update()
    {

        if (PrevAddSpeed != GlobalVariableScript.AdditionalSpeed)
        {
            PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
            Multiplier += 1f;
        }

        float speedNegator = 0.30f * Multiplier;

        BackgroundRender.material.mainTextureOffset -= new Vector2((BackgroundSpeed + (PrevAddSpeed - speedNegator)) * Time.deltaTime, 0f);
        //Show score
        ScoreTextMesh.text = "Score:" + GlobalVariableScript.GameScore;
    }


    private void SpawnCloudOne()
    {
        GameObject c1 = Instantiate(CloudOne);
        c1.transform.position = new Vector2(-15, Random.Range(-2, 5));
    }

    private void SpawnCloudTwo()
    {
        GameObject c2 = Instantiate(CloudTwo);
        c2.transform.position = new Vector2(-15, Random.Range(-2, 5));
    }

    private void SpawnCloudThree()
    {
        GameObject c3 = Instantiate(CloudThree);
        c3.transform.position = new Vector2(-15, Random.Range(-2, 5));
    }

    private void SpawnLoot()
    {
        GameObject l = Instantiate(Loot);
        l.transform.position = new Vector2(-15, Random.Range(-4, 2));
    }

    private void SpawnArrow()
    {
        Instantiate(Arrow);
    }

    IEnumerator ShowCloudOne()
    {
        while(true)
        {
            float timeNegator = 0.35f * Multiplier;
            yield return new WaitForSeconds(RespawnTimeCloudOne - (PrevAddSpeed - timeNegator));
            SpawnCloudOne();
        }
    }

    IEnumerator ShowCloudTwo()
    {
        while (true)
        {
            float timeNegator = 0.35f * Multiplier;
            yield return new WaitForSeconds(RespawnTimeCloudTwo - (PrevAddSpeed - timeNegator));
            SpawnCloudTwo();
        }
    }

    IEnumerator ShowCloudThree()
    {
        while (true)
        {
            float timeNegator = 0.35f * Multiplier;
            yield return new WaitForSeconds(RespawnTimeCloudThree - (PrevAddSpeed - timeNegator));
            SpawnCloudThree();
        }
    }

    IEnumerator ShowLoot()
    {
        while (true)
        {
            float timeNegator = 0.10f * Multiplier;
            yield return new WaitForSeconds(RespawnTimeLoot - (PrevAddSpeed - timeNegator));
            SpawnLoot();
        }
    }

    IEnumerator ShowArrow()
    {
        while (true)
        {
            float timeNegator = 0.10f * Multiplier;
            yield return new WaitForSeconds(RespawnTimeArrow - (PrevAddSpeed - timeNegator));
            SpawnArrow();
        }
    }
}
