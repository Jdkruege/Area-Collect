using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameState : MonoBehaviour {
    
    private const int SPAWN_MIN = 2;
    private const int SPAWN_MAX = 8;

    public GameObject player;
    public List<GameObject> spawnList;

    public Text scoreText;
    public Text timerText;
    public Text livesText;

    public Transform[] limits;

    public int timeLimit;

    public float spawnRate;
    private float _NextSpawn = 0f;

    public GameObject pauseHUD;
    public GameObject endHUD;

    private int _score = 0;
    private int _lives = 5;
    private int _uID = 0;
    private int _numSpawned = 0;

    public bool gameOver = false;
    public bool paused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player.GetComponent<PlayerState>().state = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            Cursor.visible = !Cursor.visible;
            paused = !paused;
            pauseHUD.SetActive(paused);
        }

        if (!gameOver && !paused)
        {
            if ((Time.time > _NextSpawn && _numSpawned < SPAWN_MAX) || (_numSpawned < SPAWN_MIN))
            {
                spawn();
                _NextSpawn = Time.time + spawnRate;
                _numSpawned++;
            }

            HandleTime();
        }

        if(gameOver && !paused)
        {
            endHUD.SetActive(true);
            Cursor.visible = !Cursor.visible;
            paused = true;
        }

    }

    public void HandleTime()
    {
        if (Time.time > timeLimit) gameOver = true;

        timerText.text = "" + Mathf.Ceil(timeLimit - Time.time);
    }


    public void pointScored()
    {
        scoreText.text = "Score: " + ++_score;
        _numSpawned--;
    }

    public void playerHit()
    {
        livesText.text = "Lives: " + --_lives;

        player.GetComponent<PlayerState>().PlayerDead();

        if (_lives <= 0) gameOver = true;
    }

    public void respawn(GameObject obj)
    {
        Destroy(obj);
        spawn();
    }

    public void spawn()
    {
        GameObject obj = Instantiate(spawnList[Random.Range(0, spawnList.Count)]);

        obj.name = "Objective " + _uID++;

        float x = Random.Range(limits[0].position.x, limits[1].position.x);
        float y = Random.Range(limits[3].position.y, limits[2].position.y);

        obj.transform.position = new Vector3(x, y, 0);

        float spd = Random.Range(0.1f, 2f);

        float dir = (Random.Range(0, 2) == 1 ? 1 : -1);

        obj.GetComponent<Spin>().set(spd, dir);

        obj.GetComponentInChildren<Renderer>().material.color = randomColor();

        obj.GetComponentInChildren<HitDetection>().state = this;
        obj.GetComponentInChildren<GoalDetection>().state = this;
        obj.GetComponentInChildren<SpawnDetection>().state = this;
        obj.GetComponent<ObjectiveState>().state = this;
        obj.GetComponent<ObjectiveState>().Spawn(Time.time);
    }

    public Color randomColor()
    {
        float r = Random.Range(0f, .75f);
        float g = Random.Range(0f, .75f);
        float b = Random.Range(0f, .75f);

        return new Color(r, g, b);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
