using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Has been hit");

            other.transform.position = new Vector3(0, 0, 0);
        }
    }
}
