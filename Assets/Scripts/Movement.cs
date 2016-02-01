using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public const float MOVEMENT_VALUE = 2f;
    public const float MAX_VELOCITY = 10;

    Vector2 velocity;

    public bool pause = false;

	// Update is called once per frame
	void Update () {
        if(!pause) velocity = new Vector2(Input.GetAxis("Mouse X")*MOVEMENT_VALUE, Input.GetAxis("Mouse Y")*MOVEMENT_VALUE);
	}

    void FixedUpdate()
    {
        if (velocity.x > MAX_VELOCITY) velocity.x = MAX_VELOCITY;
        if (velocity.y > MAX_VELOCITY) velocity.y = MAX_VELOCITY;
        if (velocity.x < -MAX_VELOCITY) velocity.x = -MAX_VELOCITY;
        if (velocity.y < -MAX_VELOCITY) velocity.y = -MAX_VELOCITY;

        GetComponent<Rigidbody2D>().velocity = velocity;

        velocity = new Vector2();
    }

}
