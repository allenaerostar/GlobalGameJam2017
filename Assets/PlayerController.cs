using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float chargeLvl;
    public float maxCharge;
    public float chargeSpeed;
    bool onGround;
    public float groundcastDist;
    int groundMask;
    public Vector2 circleOffset;
    public float circleRadius;
    public float ballSmashMultiplier;
    

    // Use this for initialization
    void Start () {
        chargeLvl = 0f;
        onGround = false;
        groundMask = LayerMask.NameToLayer("Ground");
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, distance: groundcastDist, layerMask: groundMask);

        if (onGround)
        {
            if (Input.GetButton("Fire") && chargeLvl < maxCharge)
            {
                chargeLvl += Time.deltaTime * chargeSpeed;
                // risk of overcharge?
            }
            else if (Input.GetButtonUp("Fire"))
            {
                SmashTheTile();
                chargeLvl = 0;
            }
        }

        else {
            chargeLvl = 0;
            Collider2D ballInReach = Physics2D.OverlapCircle(new Vector2 (transform.position.x + circleOffset.x, transform.position.y + circleOffset.y), circleRadius, layerMask: LayerMask.NameToLayer("Ball"));
            if (ballInReach != null && Input.GetButtonDown("Fire"))
            {
                SmashTheBall(ballInReach.gameObject);
            }
        }

	}

    void SmashTheTile() {
        //Smash the tile
        //Use localscale.x for dir
        RaycastHit2D findBlock = Physics2D.Raycast(transform.position, Vector2.down, distance: groundcastDist, layerMask: LayerMask.NameToLayer("Block"));
        if (findBlock) {
            findBlock.collider.gameObject.GetComponent<KnockUpBlock>().StartKnockUp((int)chargeLvl, chargeLvl, transform.localScale.x == 1);
        }
    }

    void SmashTheBall(GameObject ball) {
        //Smash the ball
        Vector2 dirToBall = ball.transform.position - transform.position;
        ball.GetComponent<Rigidbody2D>().AddForce(ballSmashMultiplier * dirToBall, ForceMode2D.Impulse);
    }
}
