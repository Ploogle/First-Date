using UnityEngine;
using System.Collections;

public class Switchable_Move : Switchable {
    
    public bool Toggle = true;
    public Vector2 Destination;
    public float Seconds = 1;

    Vector2 StartPosition;
    bool Activated = false;
    bool Returning = true;
    float Distance;
    float Speed;

    void Start()
    {
        StartPosition = transform.position;
        Distance = (StartPosition - Destination).magnitude;
        Speed = Distance / Seconds;
    }

    void Update()
    {
        if (Activated && !Returning)
        {
            if (Vector3.Distance(transform.position, Destination) < .05f)
                Activated = false;
            else
                transform.position += (Vector3)(Destination - (Vector2)transform.position).normalized * Speed * Time.deltaTime;
        }
        else if(Returning)
        {
            if (Vector3.Distance(transform.position, StartPosition) < .05f)
                Activated = false;
            else
                transform.position += (Vector3)(StartPosition - (Vector2)transform.position).normalized * Speed * Time.deltaTime;
        }
        
    }

    public override void OnSwitch(bool switched)
    {
        Debug.Log("Received: " + switched);
        if(Toggle)
        {
            Activated = switched;
            Returning = !switched;
        }
        else if(switched)
        {
            Activated = true;
            Returning = false;
        }
    }

}
