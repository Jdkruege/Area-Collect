using UnityEngine;
using System.Collections;

public class AutoTranslate : MonoBehaviour {

    public int LengthScale = 0;
    public int HeightScale = 0;

    // Use this for initialization
    void Start()
    {
        Vector3 screenVec = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
        Vector3 oldVec = transform.position;
        Vector3 newVec = new Vector3();

        newVec.x = screenVec.x * LengthScale;
        newVec.y = screenVec.y * HeightScale;
        newVec.z = oldVec.z;

        transform .position = newVec;
    }
}
