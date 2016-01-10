using UnityEngine;
using System.Collections;

public class ObjectiveState : MonoBehaviour {

    public bool active = false;
    public float fadeSpeed;
    public float spawnTime;

    private Color _color;

    public GameState state;

	public void Spawn(float time)
    {
        active = false;

        spawnTime = time;

        _color = GetComponentInChildren<Renderer>().material.color;
        _color.a = 0;
        GetComponentInChildren<Renderer>().material.color = _color;

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
                _color.a = 1 * (fade / 10);

                GetComponentInChildren<Renderer>().material.color = _color;

                fadeTime = Time.time + fadeSpeed / 10;
                fade++;
            }

            yield return null;
        }

        Activate();
    }

    public void Activate()
    {
        _color.a = 1;
        GetComponentInChildren<Renderer>().material.color = _color;
        active = true;
    }

    void Update()
    {
        if (state.paused || state.gameOver) GetComponentInParent<Spin>().pause = true;
        else GetComponentInParent<Spin>().pause = false;
    }
}
