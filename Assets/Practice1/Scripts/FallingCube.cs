using UnityEngine;

public class FallingCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CubeAnimationHandler()
    {
        Animator cubeAnimator = this.gameObject.GetComponent<Animator>();
        cubeAnimator.SetBool("StartAnimation", false);
        Destroy(this.gameObject);
    }
}
