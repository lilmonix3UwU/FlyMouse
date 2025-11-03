using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = transform.position;
        cam.transform.position += new Vector3(0, 0, -10);
    }
}
