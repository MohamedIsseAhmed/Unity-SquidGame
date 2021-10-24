using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target!=null)
             transform.position = target.position + offset;
    }
}
