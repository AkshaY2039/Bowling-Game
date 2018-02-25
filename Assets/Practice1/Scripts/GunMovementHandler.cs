using UnityEngine;

public class GunMovementHandler : MonoBehaviour {

    public GameObject m_AimGameObject;

    private const float RotateByDegree = Mathf.Rad2Deg * 1f;

    private Transform m_GameObjectTransform;

	// Use this for initialization
	void Start ()
    {
        m_GameObjectTransform = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_GameObjectTransform.Rotate(new Vector3(RotateByDegree * Time.deltaTime, 0f, 0f));
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            m_GameObjectTransform.Rotate(new Vector3(-1f * RotateByDegree * Time.deltaTime, 0f, 0f));
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            m_GameObjectTransform.Rotate(new Vector3(0f, RotateByDegree * Time.deltaTime, 0f));
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            m_GameObjectTransform.Rotate(new Vector3(0f, -1f * RotateByDegree * Time.deltaTime, 0f));
        }

        m_AimGameObject.transform.position = m_GameObjectTransform.position + m_GameObjectTransform.forward * 4f;

        RaycastHit raycastHit;
        Transform objectAimedTransform = null;

        if (Physics.Raycast(Camera.main.transform.position, (m_AimGameObject.transform.position - Camera.main.transform.position), out raycastHit, Mathf.Infinity))
        {
            objectAimedTransform = raycastHit.transform;
            Debug.Log(objectAimedTransform.name);
        }

        if (Input.GetKey(KeyCode.Return))
        {
            if(objectAimedTransform != null && objectAimedTransform.name != "Floor" && objectAimedTransform.name != "Head")
            {
                Destroy(objectAimedTransform.gameObject);
            }
        }
    }
}
