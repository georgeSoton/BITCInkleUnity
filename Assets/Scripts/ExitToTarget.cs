using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToTarget : MonoBehaviour, IExitCharacter
{
    [SerializeField]
    GameObject Target;

    [SerializeField]
    GameObject DestroyParent;

    [SerializeField]
    float speed = 0.1f;
    float normspeed;
    bool started = false;

    void Awake()
    {
        normspeed = 1 / (1 + speed);
    }
    // Start is called before the first frame update
    public void Exit()
    {
        started = true;
    }
    void Update()
    {
        if (started)
        { 
            var diff = Target.transform.position - transform.position;
            transform.position = transform.position + diff * (1 - normspeed);

            if (diff.sqrMagnitude < 0.01)
            {
                Destroy(DestroyParent);
            }
        }
    }
}
