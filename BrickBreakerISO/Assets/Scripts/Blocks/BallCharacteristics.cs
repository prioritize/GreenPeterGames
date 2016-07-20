using UnityEngine;
using System.Collections;


public class BallCharacteristics : MonoBehaviour {

	public Vector3 ball_velocity;
	public Rigidbody ball_RB;
	private bool tagEnv;
	private bool tagBall;
	private bool tagPlayer;
	// Use this for initialization
	void Start () {
		ball_RB = GetComponent < Rigidbody > ();
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
		tagEnv = collision.gameObject.CompareTag("Environment");
		tagPlayer = collision.gameObject.CompareTag ("Player");

		ball_RB.velocity = -Vector3.Reflect (collision.relativeVelocity, collision.contacts[0].normal);
		ball_velocity = ball_RB.velocity;
		print (collision.contacts [0].normal);
		//ball_RB.velocity = ball_velocity;	

		if(tagEnv == false) {
			if (tagPlayer == false) {
				Destroy (collision.gameObject);
			}
			if(tagPlayer == true){
				print ("Collision Point: " + collision.contacts [0].point);
				print ("Transform Position: " + transform.position);

			}
		}
		else if (tagPlayer == true){
			print (collision.contacts [0].point);
					
		}
		
	}
}
