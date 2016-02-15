using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector2 velocity = new Vector2(5, 0);
    public float distance = 5;

    private Rigidbody2D bulletBody;

	// Use this for initialization
	void Start () {
        bulletBody = GetComponent<Rigidbody2D>();

        bulletBody.velocity = velocity * transform.localScale.x;    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Solid"))
        {
            //Destroy(gameObject);
        }
    }
}
