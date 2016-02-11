using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (target != null)
        {
            var t = target.transform;
            transform.position = new Vector3(t.position.x, t.position.y, transform.position.z);
        }
	}
}
