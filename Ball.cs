using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 10.0f;
	public float deviateAmount = 5.0f;

	private bool readyToShoot = false;


	private Rigidbody2D rigidbody;
	private Rigidbody2D racketbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		racketbody = GameObject.FindGameObjectWithTag ("Racket").GetComponent<Rigidbody2D> ();







		readyToShoot = true;
	}

	void Update(){
		if (readyToShoot == true &&	Input.GetButtonDown ("Jump")) {
			rigidbody.velocity = Vector2.up * speed;
			readyToShoot = false;
		}
	}

	void FixedUpdate(){
		if (readyToShoot == true) {
			rigidbody.position = racketbody.position + Vector2.up * 0.35f;


		}
	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.CompareTag ("Racket")) {


			float deviateFactor = (transform.position.x - 
									other.transform.position.x 
				/ other.collider.bounds.size.x/ 2 )  ;
			rigidbody.velocity += Vector2.right * deviateFactor * deviateAmount;

		}
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Triggerenter");
		if (other.gameObject.CompareTag("Deadzone")){
			readyToShoot = true;
		}
	
	}


}
