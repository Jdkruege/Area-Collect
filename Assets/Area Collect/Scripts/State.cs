using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

    public GameObject player;
    public GameObject toSpawn;

    public Transform[] limits;

    private float _NextSpawn = 0f;
    public float spawnRate;

    void Update()
    {
        if(Time.time > _NextSpawn)
        {
            Debug.Log("Spawnning objective");
            spawn();
            _NextSpawn = Time.time + spawnRate;

            Debug.Log("Next Spawn Time: " + _NextSpawn);
        }
        
    }

    public void pointScored()
    {
        Debug.Log("Point Scored");
    }

    public void playerHit()
    {
        Debug.Log("Player Hit");

        player.transform.position = new Vector3(0, 0, 0);
    }

    public void spawn()
    {
        GameObject obj = Instantiate(toSpawn);

        float x = Random.Range(limits[0].position.x, limits[1].position.x);
        float y = Random.Range(limits[3].position.y, limits[2].position.y);

        obj.transform.position = new Vector3(x, y, 0);

        float spd = Random.Range(0.1f, 2f);

        float dir = (Random.Range(0, 2) == 1 ? 1 : -1);

        obj.GetComponent<Spin>().set(spd, dir);

        obj.GetComponentInChildren<HitDetection>()._state = this;
        obj.GetComponentInChildren<GoalDetection>()._state = this;
    }
}
