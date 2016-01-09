using UnityEngine;
using System.Collections;

public class GoalDetection : MonoBehaviour {

    public GameState _state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponentInParent<ObjectiveState>().active)
        {
            if (other.tag == "Alive Player")
            {
                _state.pointScored();
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
