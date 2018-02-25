using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall_Original : MonoBehaviour {

	public float force; //use this for initialization 
	private List<Vector3> pinPositions;
	private List<Quaternion> pinRotations;
	private Vector3 ballPosition;

	// Use this for initialization
	void Start () 
	{
		var pins = GameObject.FindGameObjectsWithTag ("Pin");
		pinPositions = new List<Vector3>();
		pinRotations = new List<Quaternion>();
		foreach (var pin in pins) {
			pinPositions.Add(pin.transform.position);
			pinRotations.Add(pin.transform.rotation);
		}
		ballPosition = GameObject.FindGameObjectWithTag ("Ball").transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.UpArrow))
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, force));		
		if (Input.GetKeyUp (KeyCode.LeftArrow))
			GetComponent<Rigidbody> ().AddForce (new Vector3 (-1, 0, 0),ForceMode.Impulse);
		if (Input.GetKeyUp (KeyCode.RightArrow))
			GetComponent<Rigidbody> ().AddForce (new Vector3 (1, 0, 0),ForceMode.Impulse);
		if (Input.GetKeyUp (KeyCode.R))  //Reset for the game
		{
			var pins = GameObject.FindGameObjectsWithTag ("Pin");
			for (int i = 0; i < pins.Length; i++) {
				var pinPhysics = pins [i].GetComponent<Rigidbody> ();
				pinPhysics.velocity = Vector3.zero;
				pinPhysics.position = pinPositions [i];
				pinPhysics.rotation = pinRotations [i];
				pinPhysics.velocity = Vector3.zero;
				pinPhysics.angularVelocity = Vector3.zero;

				var ball = GameObject.FindGameObjectWithTag ("Ball");
				ball.transform.position = ballPosition;
				ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			}
		}
		if (Input.GetKeyUp (KeyCode.B))		//To get back the ball for the playing game
		{
			var ball = GameObject.FindGameObjectWithTag ("Ball");
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			ball.transform.position = ballPosition;
		}
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Pin")
			print ("Collided");
	}
}
