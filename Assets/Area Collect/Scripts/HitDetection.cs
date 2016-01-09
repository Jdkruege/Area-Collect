using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour
{
    public State _state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") _state.playerHit();
    }
}
