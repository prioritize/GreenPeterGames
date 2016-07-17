using UnityEngine;
using System.Collections;

public class BlockCollision : MonoBehaviour {

		void OnTriggerEnter(Collider other) {
			if (other.CompareTag ("Ground") == false) {
				//Destroy (other.gameObject);
			}

		}
	}
