using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FadeInText : MonoBehaviour
{
    [SerializeField]
    float fadeover = 10f;
    Text mytext;
    float StartTime;
    // Start is called before the first frame update
    void Awake()
    {
        mytext = GetComponent<Text>();
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var timedelta = Time.time - StartTime;
        float alpha = math.min(timedelta / fadeover, 1);
        mytext.color = new Color(mytext.color.r, mytext.color.g, mytext.color.b, alpha);
    }
}
