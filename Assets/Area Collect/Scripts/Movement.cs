using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public const float MOVEMENT_VALUE = 2f;

    Vector2 velocity;

	// Update is called once per frame
	void Update () {

        velocity.x += MOVEMENT_VALUE * Input.GetAxis("Horizontal");
        velocity.y += MOVEMENT_VALUE * Input.GetAxis("Vertical");	
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;

        velocity.x = velocity.y = 0;
    }
}
