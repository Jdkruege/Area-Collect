using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour
{
    public GameState state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponentInParent<ObjectiveState>().active && !(state.paused || state.gameOver))
        {
            if (other.tag == "Alive Player") state.playerHit();
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (GetComponentInParent<ObjectiveState>().active && !(state.paused || state.gameOver))
        {
            if (other.tag == "Alive Player") state.playerHit();
        }

    }
}
