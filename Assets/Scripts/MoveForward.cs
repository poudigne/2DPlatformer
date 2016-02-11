using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float speed = 0.3f;
    public Transform sighStart, sighEnd;
    public bool needsCollision = true;

    private Rigidbody2D body;
    private bool collision = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        body.velocity = new Vector2(this.transform.localScale.x * speed, body.velocity.y);
        collision = Physics2D.Linecast(sighStart.position, sighEnd.position, 1 << LayerMask.NameToLayer("Solid"));

        Debug.DrawLine(sighStart.position, sighEnd.position, Color.green);

        if (collision == needsCollision)
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1,1,1);
	}
}
