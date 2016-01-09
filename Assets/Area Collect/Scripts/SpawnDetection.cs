using UnityEngine;
using System.Collections;

public class SpawnDetection : MonoBehaviour {

    public GameState _state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!GetComponentInParent<ObjectiveState>().active)
        {
            if (other.tag == "Objective" 
                && (transform.parent.name.CompareTo(other.transform.parent.name) != 0) 
                && (GetComponentInParent<ObjectiveState>().spawnTime > other.GetComponentInParent<ObjectiveState>().spawnTime))
            {
                _state.respawn(transform.parent.gameObject);
            }
        }
        
    }
}
