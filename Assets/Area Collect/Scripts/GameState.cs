using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    
    private const int SPAWN_MIN = 2;
    private const int SPAWN_MAX = 8;

    public GameObject player;
    public GameObject toSpawn;

    public Text scoreText;
    public Text timerText;
    public Text livesText;

    public Transform[] limits;

    public int timeLimit;

    public float spawnRate;
    private float _NextSpawn = 0f;

    private int _score = 0;
    private int _lives = 5;
    private int _uID = 0;
    private int _numSpawned = 0;

    private bool _gameOver = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.visible = !Cursor.visible;

        if ((Time.time > _NextSpawn && _numSpawned < SPAWN_MAX) || (_numSpawned < SPAWN_MIN))
        {
            spawn();
            _NextSpawn = Time.time + spawnRate;
            _numSpawned++;
        }

        HandleTime();


        if (_gameOver) Debug.Log("Game is technically over."); // Game end logic follows here.
    }

    public void HandleTime()
    {
        if (Time.time > timeLimit) _gameOver = true;

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

        if (_lives >= 0) _gameOver = true;
    }

    public void respawn(GameObject obj)
    {
        Destroy(obj);
        spawn();
    }

    public void spawn()
    {
        GameObject obj = Instantiate(toSpawn);

        obj.name = "Objective " + _uID++;

        float x = Random.Range(limits[0].position.x, limits[1].position.x);
        float y = Random.Range(limits[3].position.y, limits[2].position.y);

        obj.transform.position = new Vector3(x, y, 0);

        float spd = Random.Range(0.1f, 2f);

        float dir = (Random.Range(0, 2) == 1 ? 1 : -1);

        obj.GetComponent<Spin>().set(spd, dir);

        obj.GetComponentInChildren<HitDetection>()._state = this;
        obj.GetComponentInChildren<GoalDetection>()._state = this;
        obj.GetComponentInChildren<SpawnDetection>()._state = this;
        obj.GetComponent<ObjectiveState>().Spawn(Time.time);
    }
}
