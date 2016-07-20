using UnityEngine;
using System.Collections;


public class BallCharacteristics : MonoBehaviour {

	public Vector3 ball_velocity;
	public Rigidbody ball_RB;
	public float maxAngle;
	private bool tagEnv;
	private bool tagBall;
	private bool tagPlayer;
	private Vector3 playerPosition;
	private Vector3 ballPosition;
	private float differencePosition, x_direction, y_direction, bounceAngle;

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
		playerPosition = collision.gameObject.transform.position;
		ballPosition = transform.position;
		differencePosition = ballPosition.z - playerPosition.z;


		if (tagEnv == false) {
			if (tagPlayer == false) {
				Destroy (collision.gameObject);
				ball_RB.velocity = -Vector3.Reflect (collision.relativeVelocity, collision.contacts[0].normal);
			}
			if (tagPlayer == true) {
				bounceAngle = Mathf.Deg2Rad * (5 * differencePosition);
				x_direction = Mathf.Cos (bounceAngle); /* This really should be something like collision.collider.size/2 + transform.size/2 */
				y_direction = -Mathf.Sin (bounceAngle);
				ball_RB.velocity = -collision.relativeVelocity.magnitude* new Vector3 (x_direction, 0.0f, y_direction);
				print ("Player Transform Position " + playerPosition);
				print ("Ball Transform Position: " + ballPosition);
				print ("Difference Position: " + differencePosition);
			}

		}
		else if (tagEnv == true){
					
				ball_RB.velocity = -Vector3.Reflect (collision.relativeVelocity, collision.contacts[0].normal);
		}
		
	}
}
