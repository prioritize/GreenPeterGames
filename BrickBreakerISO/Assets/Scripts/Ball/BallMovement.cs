using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	public Rigidbody rb;
	public float speed = 10;
	public Vector3 ballVelocity;
	public Color rayColor = Color.red;
	private 
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(speed, 0, 0);
	}
	void FixedUpdate() {
		Debug.DrawRay (transform.position, ballVelocity, rayColor, 100.0f);
	}
}