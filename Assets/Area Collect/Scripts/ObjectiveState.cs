using UnityEngine;
using System.Collections;

public class ObjectiveState : MonoBehaviour {

    public bool active = false;
    public float fadeSpeed;
    public float spawnTime;

    public GameState state;

	public void Spawn(float time)
    {
        active = false;

        spawnTime = time;

        GetComponentInChildren<Renderer>().material.color = new Color(0, 0, 0, 0);

        StartCoroutine("Spawning");
    }

    public IEnumerator Spawning()
    {
        float fadeTime = 0;
        float fade = 0;

        while (fade < 10)
        {
            if (Time.time > fadeTime && !(state.paused || state.gameOver))
            {
                GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1, 1 * (fade / 10));

                fadeTime = Time.time + fadeSpeed / 10;
                fade++;
            }

            yield return null;
        }

        Activate();
    }

    public void Activate()
    {
        GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1, 1);
        active = true;
    }

    void Update()
    {
        if (state.paused || state.gameOver) GetComponentInParent<Spin>().pause = true;
        else GetComponentInParent<Spin>().pause = false;
    }
}
