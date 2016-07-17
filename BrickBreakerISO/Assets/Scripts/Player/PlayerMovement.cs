using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	private Rigidbody player_RB;

	// Use this for initialization
	void Start () {
		//Set position of player


		//Get Components
		player_RB = GetComponent <Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//Get Input Horizontal
		//float moveHorizontal = -Input.GetAxis("Vertical");
		float moveVertical = Input.GetAxis ("Horizontal");

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//player_RB.AddForce (movement * speed);
		Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);
		player_RB.velocity = (movement * speed);
	//Get Input Vertical
	//Apply Input to Rigidbody of player

	}
}
