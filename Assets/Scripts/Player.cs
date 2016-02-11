using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 10f;
    public Vector2 maxVelocity = new Vector2(3, 5);
    public float jumpSpeed = 5f;
    public bool standing;

    public GameObject ammo;
    public Transform fireMarker;

    private Animator playerAnimation;
    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        playerAnimation = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {
        var absVelX = Mathf.Abs(body.velocity.x);
        var absVelY = Mathf.Abs(body.velocity.y);

        var forceX = 0f;
        var forceY = 0f;

        if (absVelY <= .05f)
            standing = true;
        else
            standing = false;
        
        if (Input.GetKeyDown("up") && standing)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }

        if (Input.GetKey("right"))
        {
            playerAnimation.SetInteger("AnimState", 1);
            if (absVelX < maxVelocity.x)
            {
                forceX = speed;
                this.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if (Input.GetKey("left"))
        {
            playerAnimation.SetInteger("AnimState", 1);
            if (absVelX < maxVelocity.x)
            {
                forceX = -speed;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            playerAnimation.SetInteger("AnimState", 0);
        }
        if (Input.GetKey("space") && standing)
        {
            playerAnimation.SetInteger("AnimState", 2);
            body.velocity = Vector2.zero;
        }
        else
            body.AddForce(new Vector2(forceX, forceY));
	}


    public void Fire()
    {
        if (ammo != null)
        {
            var clone = Instantiate(ammo, fireMarker.position, Quaternion.identity) as GameObject;
            clone.transform.localScale = transform.localScale;
        }
    }
}
