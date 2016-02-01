using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public enum Direction { Left, None, Right };
	public const float ROTATION_AMOUNT = 1;
    
    public float _spd;
    public float _dir;

    public bool pause = false;

    public void set(float speed, float direction)
    {
        _spd = speed;
        _dir = direction;
    }

	// Update is called once per frame
	void Update () {
        if (!pause) transform.Rotate(new Vector3(0, 0, 1), ROTATION_AMOUNT*_spd*_dir);
	}
}
