using UnityEngine;

public class FloorCollisionHandlerAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        Animator cubeAnimator = collision.gameObject.GetComponent<Animator>();
        cubeAnimator.SetBool("StartAnimation", true);
    }
}
