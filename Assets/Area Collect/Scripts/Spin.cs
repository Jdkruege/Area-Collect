using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public enum Direction { Left, None, Right };
	public const float ROTATION_AMOUNT = 1;
    
    public float _spd;
    public float _dir;

    public Spin(float speed, Direction direction)
    {
        _spd = speed;

        switch(direction)
        {
            case Direction.Left:
                _dir = 1;
                break;
            case Direction.Right:
                _dir = -1;
                break;
            default:
                _dir = 0;
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        
        transform.Rotate(new Vector3(0, 0, 1), ROTATION_AMOUNT*_spd*_dir);
	}
}
