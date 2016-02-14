using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonSwitch : MonoBehaviour {

    public bool Switched = false;
    bool LastSwtiched = false;
    Animator myAnimator;
    public List<Switchable> Targets;
    
	void Awake() {
        myAnimator = GetComponent<Animator>();
	}

    void Start()
    {

    }
	
	void Update () {
        Debug.DrawLine(transform.position, transform.position + transform.up);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, .15f, transform.up, .5f);

        Switched = false;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.tag == "Grabbable" ||
                hit.collider.tag == "Player")
            {
                Switched = true;
                break;
            }
        }

        if (LastSwtiched != Switched)
        {
            myAnimator.Play(Switched ? "Button_On" : "Button_Off");
            foreach(Switchable target in Targets)
            {
                //target.OnSwitch(Switched);
                target.SendMessage("OnSwitch", Switched);
            }
        }
        LastSwtiched = Switched;
    }
    
    
}
