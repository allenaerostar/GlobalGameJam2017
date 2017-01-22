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
    bool launchedCheck;
    int groundMask;
    string fire = "Fire";

    // Make into coroutine later
    public float spikeCD;
    float currentCD;

    //announcing attack
    public bool canMove;

    Animator anim;

    // Use this for initialization
    void Start () {
        chargeLvl = 0f;
        onGround = false;
        groundMask = LayerMask.GetMask("Ground");
        fire += playerNo;
        Debug.Log(fire);
        currentCD = 0;
        canMove = true;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, distance: groundcastDist, layerMask: groundMask);
        anim.SetBool("grounded", onGround);
        if (onGround)
        {
            if (Input.GetButton(fire) && chargeLvl < maxCharge)
            {
                canMove = false;
                chargeLvl += Time.deltaTime * chargeSpeed;
                anim.SetBool("charging", true);
                // risk of overcharge?
            }
            else if (Input.GetButtonUp(fire))
            {
                anim.SetBool("charging", false);
                if (chargeLvl >= 1)
                {
                    SmashTheTile();
                    Disable(spikeCD);
                }
                canMove = true;
                chargeLvl = 0;
            }
            if (launchedCheck)
            {
                launchedCheck = false;
            }
        }

        else
        {
            chargeLvl = 0;
            canMove = true;
            anim.SetBool("charging", false);
            if (!launchedCheck)
            {
                StartCoroutine(WatchForSmash());
                launchedCheck = true;
            }
        }
            /*Collider2D ballInReach = Physics2D.OverlapCircle(new Vector2 (transform.position.x + circleOffset.x, transform.position.y + circleOffset.y), circleRadius, layerMask: LayerMask.GetMask("Ball"));
            if (ballInReach != null && Input.GetButtonDown(fire) && currentCD <= 0)
            {
                SmashTheBall(ballInReach.gameObject);
            }
        }

        if (currentCD > 0) {
            currentCD -= Time.deltaTime;
        }*/
       
	}

    void SmashTheTile() {
        //Smash the tile
        //Use localscale.x for dir
        anim.SetTrigger("fire");
        Collider2D body = GetComponent<Collider2D>();
        Bounds bodySize = body.bounds;
        Collider2D[] findBlock = Physics2D.OverlapAreaAll(new Vector2(body.transform.position.x - bodySize.extents.x, body.transform.position.y + bodySize.extents.y),
                                                          new Vector2(body.transform.position.x + bodySize.extents.x, body.transform.position.y - bodySize.extents.y - 0.5f),
                                                          layerMask: LayerMask.GetMask("Block"));
        Debug.Log(onGround + "  " + chargeLvl);
        if (findBlock.Length != 0) {
            if (transform.localScale.x > 0) {
                getGreatestX(findBlock).GetComponent<KnockUpBlock>().StartKnockUp((int)chargeLvl, flatForce, true);
            }
            else
            {
                getLeastX(findBlock).GetComponent<KnockUpBlock>().StartKnockUp((int)chargeLvl, flatForce, false);
            }
            
        }
    }

    void SmashTheBall(GameObject ball) {
        //Smash the ball
        Vector2 dirToBall = ball.transform.position - transform.position;
        float angle = -Vector2.Angle(Vector2.down, dirToBall)/2;
        Vector2 newDir = Quaternion.Euler(0, 0, angle) * dirToBall;
        Debug.Log("dirToBall " + dirToBall + ", hit Vector " + newDir);
		Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D> ();
		ballRb.velocity = Vector2.zero;
		ballRb.AddForce(ballSmashMultiplier * newDir, ForceMode2D.Impulse);
        currentCD = spikeCD;
    }

    IEnumerator WatchForSmash() {

        while (!onGround) {
            Collider2D ballInReach = Physics2D.OverlapCircle(
                new Vector2(transform.position.x + circleOffset.x, transform.position.y + circleOffset.y), 
                circleRadius, 
                layerMask: LayerMask.GetMask("Ball"));
            if (Input.GetButtonDown(fire))
            {
                anim.SetTrigger("fire");
                if (ballInReach != null)
                {
                    SmashTheBall(ballInReach.gameObject);
                    yield return new WaitForSeconds(spikeCD);
                }
                else
                {
                    yield return new WaitForFixedUpdate();
                }
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }

        }
        yield return null;
    }

    void Disable(float time)
    {
        enabled = false;
        // If we were called multiple times, reset timer.
        CancelInvoke("Enable");
        // Note: Even if we have disabled the script, Invoke will still run.
        Invoke("Enable", time);
    }

    void Enable()
    {
        enabled = true;
    }

    GameObject getLeastX(Collider2D[] ptList) {
        GameObject res = null;
        for (int i = 0; i  < ptList.Length; i++){
            if (res == null || ptList[i].transform.position.x < res.transform.position.x)
            {
                res = ptList[i].gameObject;
            }
        }
        return res;
    }

    GameObject getGreatestX(Collider2D[] ptList)
    {
        GameObject res = null;
        for (int i = 0; i < ptList.Length; i++)
        {
            if (res == null || ptList[i].transform.position.x > res.transform.position.x)
            {
                res = ptList[i].gameObject;
            }
        }
        return res;
    }
}
