using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	float reach;
	float distance;
	public float speed;
	Vector3 direction;

	void Start(){
		distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position + direction * speed;
		distance += speed;
		if (distance >= reach) {
			Destroy (this.gameObject);
		}
	}

	public void Setup(float newReach, Vector3 newDirection){
		reach = newReach;
		direction = newDirection;
	}
}
