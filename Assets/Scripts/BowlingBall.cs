using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingBall : MonoBehaviour {

	public float force; //use this for initialization 
	//for audio file
	//AudioSource m_AudioSrc;
	//bool m_play;
	//bool m_toggleChange;

	private List<Vector3> pinPositions;
	private List<Quaternion> pinRotations;
	private Vector3 ballPosition;
	public int l; //state to indicate whether the ball is moving or not
	public int count;//Ball count
	public int pinCount;
	public int r1;
	public int r2;
	public int r3;
	public int r4;
	public int r5;
	public int r6;
	public int r7;
	public int r8;
	public int r9;
	public int r10;
	public int qt;
	//l = 1(not moving) , l=0(moving)
	public GameObject m_pin1;
	public GameObject m_pin2;
	public GameObject m_pin3;
	public GameObject m_pin4;
	public GameObject m_pin5;
	public GameObject m_pin6;
	public GameObject m_pin7;
	public GameObject m_pin8;
	public GameObject m_pin9;
	public GameObject m_pin10;

	// Use this for initialization
	void Start () 
	{
		print ("Hurray, Game started\n");
		l = 1;
		count = 3;

		//To check if the ball has already counted
		r1 = 0;
		r2 = 0;
		r3 = 0;
		r4 = 0;
		r5 = 0;
		r6 = 0;
		r7 = 0;
		r8 = 0;
		r9 = 0;
		r10 = 0;
		pinCount = 0;
		qt = 1;

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
		//print ("Pin1 position : " + m_pin1.transform.position.y + "\n");
		if (m_pin1.transform.position.y < 1 & r1 == 0) {
			r1 = 1;
			pinCount = pinCount + 1;

		}
		if (m_pin2.transform.position.y < 1 & r2 == 0) {
			r2 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin3.transform.position.y < 1 & r3 == 0) {
			r3 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin4.transform.position.y < 1 & r4 == 0) {
			r4 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin5.transform.position.y < 1 & r5 == 0) {
			r5 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin6.transform.position.y < 1 & r6 == 0) {
			r6 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin7.transform.position.y < 1 & r7 == 0) {
			r7 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin8.transform.position.y < 1 & r8 == 0) {
			r8 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin9.transform.position.y < 1 & r9 == 0) {
			r9 = 1;
			pinCount = pinCount + 1;
		}
		if (m_pin10.transform.position.y < 1 & r10 == 0) {
			r10 = 1;
			pinCount = pinCount + 1;
		}
		if(pinCount==10)
		{
			print (" win....");
			SceneManager.LoadScene ("Gamewin");
			print ("quit");
			qt = 0;
			if(Input.GetKeyUp (KeyCode.Escape))
				UnityEditor.EditorApplication.isPlaying = false;   //if all the pins fall down then game is quit
		}
		//if(Input.GetKeyUp (KeyCode.Escape) & qt==0)
		//	UnityEditor.EditorApplication.isPlaying = false;
		if (Input.GetKeyUp (KeyCode.LeftArrow) & (l==1)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (-1, 0, 0), ForceMode.Impulse);
			print ("Moving towards left\n");
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) & (l==1)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (1, 0, 0), ForceMode.Impulse);
			print ("Moving towards Right\n");
		}
		if (Input.GetKeyUp (KeyCode.R))  //Reset for the game
		{
			count = 3;
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
			print ("Reset the game\n");
			l = 1;
		}
		if (Input.GetKeyUp (KeyCode.B) & count > 0)		//To reset the ball for the playing game
		{
			var ball = GameObject.FindGameObjectWithTag ("Ball");
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			ball.transform.position = ballPosition;
			l = 1;
			print ("Reset the ball\n");
		}
		if (Input.GetKeyUp (KeyCode.B) & count == 0) {
			SceneManager.LoadScene ("scene_3");
			//m_canvas.SetActive(true);
		}
		if ( Input.GetKeyUp(KeyCode.UpArrow) & l==1) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, force));
			l = 0;
			count = count - 1;
			print ("Hit the bowling pins\n");
		}
		if (Input.GetKeyUp (KeyCode.Escape)) {
			print ("Quit....");
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Pin")
			GetComponent<AudioSource> ().Play();
	}
}