using UnityEngine;
using System.Collections;
using System;

public class Switchable_Collider2D : Switchable {

    Collider2D myCollider;
    public bool StartingState = false;
    public bool Toggle = true;
    public bool Invert = false;
    
    void Start () {
        myCollider = GetComponent<Collider2D>();

        myCollider.enabled = StartingState;
	}
	
	void Update ()
    {

    }

    public override void OnSwitch(bool switched)
    {
        if (Toggle)
            myCollider.enabled = switched;
        else if (switched)
            myCollider.enabled = true;
    }
}
