using UnityEngine;
using System.Collections;

public class AutoScale : MonoBehaviour {

    public bool LengthScale = false;
    public bool HeightScale = false;

	// Use this for initialization
	void Start () {
        Vector3 screenVec = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
        Vector3 oldVec = transform.localScale;
        Vector3 newVec = new Vector3();

        newVec.x = LengthScale ? screenVec.x*2 : oldVec.x;
        newVec.y = HeightScale ? screenVec.y*2 : oldVec.y;
        newVec.z = oldVec.z;

        transform.localScale = newVec;
	}
}
