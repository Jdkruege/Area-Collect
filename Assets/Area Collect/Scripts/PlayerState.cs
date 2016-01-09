using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

    public float deathTime;

    public void PlayerDead()
    {
        tag = "Dead Player";

        GetComponent<Renderer>().material.color = new Color(0, 0, 0); // Colors player black to indicate them being dead.

        StartCoroutine("Respawn");
    }

    public IEnumerator Respawn()
    {
        float deathTimer = Time.time + deathTime;

        while (Time.time < deathTimer)
        {
            yield return null;
        }

        PlayerAlive();
    }

    public void PlayerAlive()
    {
        GetComponent<Renderer>().material.color = new Color(1, 1, 1); // Restores player's color to indicate them being alive again
        tag = "Alive Player";
    }
}
