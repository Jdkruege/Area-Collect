using UnityEngine;
using System.Collections;

public class SpawnDetection : MonoBehaviour {

    public GameState state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GetComponentInParent<ObjectiveState>().active && !(state.paused || state.gameOver))
        {
            if (other.tag == "Objective" 
                && (transform.parent.name.CompareTo(other.transform.parent.name) != 0) 
                && (GetComponentInParent<ObjectiveState>().spawnTime > other.GetComponentInParent<ObjectiveState>().spawnTime))
            {
                state.respawn(transform.parent.gameObject);
            }
        }
        
    }
}
