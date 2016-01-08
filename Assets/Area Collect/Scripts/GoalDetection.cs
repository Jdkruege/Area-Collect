using UnityEngine;
using System.Collections;

public class GoalDetection : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") Debug.Log("Player has entered goal");

        //transform.position = new Vector3(0, 0, 0);
    }
}
