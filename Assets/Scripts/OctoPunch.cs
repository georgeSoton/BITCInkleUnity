using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoPunch : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    bool fired;

    [SerializeField]
    float shrinkspeed = 1f;
    float normshrink;
    [SerializeField]
    float flyspeed = 1f;
    float normfly;

    [SerializeField]
    float rotationspeed = 10f;

    [SerializeField]
    GameObject SparkPrefab;
    Transform tf;
    // Update is called once per frame

    private void Awake()
    {
        var storymanager = FindObjectOfType<StoryManager>();
        storymanager.onNewStoryLineAdded += StoryLineAdded;
        tf = GetComponent<Transform>();
        normshrink = 1 / (1 + shrinkspeed);
        normfly = 1 / (1 + flyspeed);
    }

    void StoryLineAdded(object e, StoryManager.line line)
    {
        if (line.tags.Contains("octopunch"))
        {
            fired = true;
        }
    }
    void FixedUpdate()
    {
        if (fired)
        {
            tf.localScale = tf.localScale * normshrink;
            var diff = (Target.transform.position - tf.position)*(1 - normfly);
            tf.position = tf.position + diff;
            tf.Rotate(0, 0, rotationspeed);

            if (tf.localScale.sqrMagnitude <= 0.001)
            {
                GameObject.Instantiate(SparkPrefab, tf.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    [ExecuteInEditMode]
    void Punch()
    {
        fired = true;
    }
}
