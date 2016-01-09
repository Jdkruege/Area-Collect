using UnityEngine;
using System.Collections;

public class GoalDetection : MonoBehaviour {

    public State _state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _state.pointScored();
            Destroy(transform.parent.gameObject);
        }
    }
}
