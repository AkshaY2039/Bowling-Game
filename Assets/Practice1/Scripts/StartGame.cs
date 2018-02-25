using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject m_CubeManager;
    public GameObject m_Floor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGameButtonPressed()
    {
        this.gameObject.SetActive(false);
        m_CubeManager.SetActive(true);
        m_Floor.SetActive(true);
    }
}
