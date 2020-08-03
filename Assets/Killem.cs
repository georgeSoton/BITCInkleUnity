using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in GameObject.FindObjectsOfType<DontDestoryOnLoad>())
        {
            Destroy(obj.gameObject);
        }
    }
}
