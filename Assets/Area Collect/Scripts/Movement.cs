using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public const float MOVEMENT_VALUE = 2f;

    Vector2 velocity;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) == true) velocity.y += MOVEMENT_VALUE;
        if (Input.GetKey(KeyCode.S) == true) velocity.y -= MOVEMENT_VALUE;
        if (Input.GetKey(KeyCode.A) == true) velocity.x -= MOVEMENT_VALUE;
        if (Input.GetKey(KeyCode.D) == true) velocity.x += MOVEMENT_VALUE;	
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;

        velocity.x = velocity.y = 0;
    }
}
