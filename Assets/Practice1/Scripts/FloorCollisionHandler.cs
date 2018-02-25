using UnityEngine;

public class FloorCollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision happened with object of name " + collision.gameObject.name);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with collider of name " + other.name);
    }
}
