using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelScript : MonoBehaviour {

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

	public GameObject m_lane;
	public GameObject m_ball;
	//public GameObject m_canvas;
	// Use this for initialization
	void Start () 
	{
		m_pin1.SetActive (false);
		m_pin2.SetActive (false);
		m_pin3.SetActive (false);
		m_pin4.SetActive (false);
		m_pin5.SetActive (false);
		m_pin6.SetActive (false);
		m_pin7.SetActive (false);
		m_pin8.SetActive (false);
		m_pin9.SetActive (false);
		m_pin10.SetActive (false);
		m_ball.SetActive (false);
		m_lane.SetActive (false);
		//m_canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if (Input.GetMouseButtonUp (0))
		//	SceneManager.LoadScene ("GameScene");
	}
	public void OnStartGameButtonPressed(){
		m_pin1.SetActive (true);
		m_pin2.SetActive (true);
		m_pin3.SetActive (true);
		m_pin4.SetActive (true);
		m_pin5.SetActive (true);
		m_pin6.SetActive (true);
		m_pin7.SetActive (true);
		m_pin8.SetActive (true);
		m_pin9.SetActive (true);
		m_pin10.SetActive (true);
		m_ball.SetActive (true);
		m_lane.SetActive (true);
		this.gameObject.SetActive (false);
	}


}
