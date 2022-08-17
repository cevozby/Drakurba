using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{

    public Transform playerTransform;

    [SerializeField]
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.y > transform.position.y && transform.position.y < maxY)
        {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
