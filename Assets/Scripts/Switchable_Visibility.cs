using UnityEngine;
using System.Collections;
using System;

public class Switchable_Visibility : Switchable {

    Renderer myRenderer;
    public bool StartingVisibility = false;
    public bool Toggle = true;
    public bool Invert = false;
    
    void Start () {
        myRenderer = GetComponent<Renderer>();

        myRenderer.enabled = StartingVisibility;
	}
	
	void Update () {

    }

    public override void OnSwitch(bool switched)
    {
        if (Toggle)
            myRenderer.enabled = switched;
        else if (switched)
            myRenderer.enabled = true;
    }
}
