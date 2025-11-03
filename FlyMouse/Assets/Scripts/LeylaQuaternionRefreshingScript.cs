using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeylaQuaternionRefreshingScript : MonoBehaviour
{
    [SerializeField] Quaternion Q;
    [SerializeField] float x, y, z, w, angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Q = new Quaternion(x,y,z,w);
        transform.rotation = Q;
    }
}
