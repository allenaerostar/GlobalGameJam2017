using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxCharge;
    public float chargeSpeed;
    public float groundcastDist;
    public Vector2 circleOffset;
    public float circleRadius;
    public float ballSmashMultiplier;
    public float flatForce;
    public int playerNo;

    float chargeLvl;
    bool onGround;
    int groundMask;
    string fire = "Fire";

    // Make into coroutine later
    public float spikeCD;
    float currentCD;

    // Use this for initialization
    void Start () {
        chargeLvl = 0f;
        onGround = false;
        groundMask = LayerMask.GetMask("Ground");
        fire += playerNo;
        Debug.Log(fire);
        currentCD = 0;
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, distance: groundcastDist, layerMask: groundMask);
        if (onGround)
        {
            if (Input.GetButton(fire) && chargeLvl < maxCharge)
            {
                chargeLvl += Time.deltaTime * chargeSpeed;
                // risk of overcharge?
            }
            else if (Input.GetButtonUp(fire))
            {
                SmashTheTile();
                chargeLvl = 0;
            }
        }

        else {
            chargeLvl = 0;
            Collider2D ballInReach = Physics2D.OverlapCircle(new Vector2 (transform.position.x + circleOffset.x, transform.position.y + circleOffset.y), circleRadius, layerMask: LayerMask.GetMask("Ball"));
            if (ballInReach != null && Input.GetButtonDown(fire) && currentCD <= 0)
            {
                SmashTheBall(ballInReach.gameObject);
            }
        }

        if (currentCD > 0) {
            currentCD -= Time.deltaTime;
        }

	}

    void SmashTheTile() {
        //Smash the tile
        //Use localscale.x for dir
        RaycastHit2D findBlock = Physics2D.Raycast(transform.position, Vector2.down, distance: groundcastDist, layerMask: LayerMask.GetMask("Block"));
        Debug.Log(onGround + "  " + chargeLvl);
        if (findBlock.collider != null) {
            findBlock.collider.gameObject.GetComponent<KnockUpBlock>().StartKnockUp((int)chargeLvl, flatForce, transform.localScale.x > 0);

        }
    }

    void SmashTheBall(GameObject ball) {
        //Smash the ball
        Vector2 dirToBall = ball.transform.position - transform.position;
        ball.GetComponent<Rigidbody2D>().AddForce(ballSmashMultiplier * dirToBall, ForceMode2D.Impulse);
        currentCD = spikeCD;
    }
}
