using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D myRigidbody;
    SpriteRenderer myRenderer;
    Animator myAnimator;
    float speed = 3f;
    float direction = 1f;

    GameObject grabbing;

	void Awake ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
	}
	
	void Update () {
        float y = myRigidbody.velocity.y;
        if (y == 0 && Input.GetKeyDown(KeyCode.W))
            y = 5;
        Vector3 newVelocity = Vector3.right * Input.GetAxisRaw("Horizontal") * speed;
        newVelocity.y = y;

        myRigidbody.velocity = newVelocity;

        direction = myRigidbody.velocity.x != 0 ? Mathf.Sign(myRigidbody.velocity.x) : direction;
        myRenderer.flipX = direction < 0;

        if(Input.GetKeyDown(KeyCode.Space) && grabbing == null)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, .5f, transform.forward, .5f);
            foreach(RaycastHit2D hit in hits)
            {
                //Debug.Log("Found: " + hit.transform.name);
                if(hit.collider.tag == "Grabbable")
                {
                    grabbing = hit.collider.gameObject;
                    grabbing.GetComponent<Rigidbody2D>().isKinematic = true;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && grabbing != null)
        {
            Rigidbody2D grabbedRigidbody = grabbing.GetComponent<Rigidbody2D>();
            if (grabbedRigidbody != null)
            {
                grabbedRigidbody.isKinematic = false;
                grabbedRigidbody.velocity = myRigidbody.velocity * 3;
                grabbing = null;
            }
        }

        if (grabbing != null)
        {
            grabbing.transform.position = transform.position + Vector3.up * .5f + Vector3.right * direction * .5f;
            grabbing.GetComponent<Rigidbody2D>().rotation = 45 * direction;
        }

        if(y != 0)
        {
            if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Player_M_Jump")
            {
                myAnimator.Play("Player_M_Jump");
            }
        }
        else if(myRigidbody.velocity.x != 0)
        {
            if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Player_M_Walk")
            {
                myAnimator.Play("Player_M_Walk");
            }
        }
        else
        {
            myAnimator.Play("Player_M_Idle");
        }
    }
}
