using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float sceneWidth = 10f;
    Camera camera_object;
    // Start is called before the first frame update
    void Start()
    {
        camera_object = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        camera_object.orthographicSize = desiredHalfHeight;
    }
}
