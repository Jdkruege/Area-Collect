using UnityEngine;
using System.Collections;

public class GoalDetection : MonoBehaviour {

    public GameState state;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponentInParent<ObjectiveState>().active && !(state.paused || state.gameOver))
        {
            if (other.tag == "Alive Player")
            {
                state.pointScored();
                Destroy(transform.parent.gameObject);

                
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (GetComponentInParent<ObjectiveState>().active && !(state.paused || state.gameOver))
        {
            if (other.tag == "Alive Player")
            {
                state.pointScored();
                Destroy(transform.parent.gameObject);


            }
        }
    }
}
