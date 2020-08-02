using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideToOrigin : MonoBehaviour
{
    Transform mytransform;
    [SerializeField]
    float Speed = 0.2f;
    // Start is called before the first frame update
    private void Awake()
    {
        mytransform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        mytransform.localPosition = mytransform.localPosition * (1f - Speed);
    }
}
