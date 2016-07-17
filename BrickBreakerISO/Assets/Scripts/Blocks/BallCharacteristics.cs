using UnityEngine;
using System.Collections;


public class BallCharacteristics : MonoBehaviour {

	public Vector3 ball_velocity;
	private Rigidbody ball_RB;
	// Use this for initialization
	void Start () {
		ball_RB = GetComponent < Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//ball_velocity = ball_RB.velocity;

	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Environment") == false){
			Destroy(other.gameObject);
		}
	}
	void OnCollisionEnter(Collision collision){
		ball_velocity = collision.relativeVelocity;
		ball_RB.velocity = ball_velocity;	
		if(collision.gameObject.CompareTag("Environment") == false) {
			if (collision.gameObject.CompareTag ("Player") == false) {
				Destroy (collision.gameObject);
			}
		}
	
	}
}
