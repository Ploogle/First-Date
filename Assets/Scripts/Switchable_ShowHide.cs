using UnityEngine;
using System.Collections;
using System;

public class Switchable_ShowHide : Switchable
{
    Renderer myRenderer;
    Collider2D myCollider;
    public bool StartingVisibility = false;
    public bool Toggle = true;
    public bool Invert = false;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myCollider = GetComponent<Collider2D>();

        myRenderer.enabled = StartingVisibility;
        myCollider.enabled = StartingVisibility;
    }

    void Update()
    {

    }

    public override void OnSwitch(bool switched)
    {
        if (Toggle)
        {
            myRenderer.enabled = switched;
            myCollider.enabled = switched;
        }
        else if (switched)
        {
            myRenderer.enabled = true;
            myCollider.enabled = true;
        }
    }
}
