using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    [SerializeField] private float delay;
    private Vector3 temp;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        temp = (Vector3.Lerp(cam.transform.position, player.transform.position, delay)) + offset;
        cam.transform.position = temp;
    }
}
