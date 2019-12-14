using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
    [SerializeField]
    private Transform m_playerTransform;
    public float dampTime = 0.15f;
	public float camerapos = 0.0f;
    private Vector3 velocity = Vector3.zero;
	
    void LateUpdate() {
		//sorgt dafür, dass sich die Kamera mit der Spielfigur mitbewegt. Dabei wird aber nicht der Rand des Spielfelds überschritten
		if((m_playerTransform.position.x >= - 70.8f && m_playerTransform.position.x <= 670.7f)){
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(m_playerTransform.position);
			Vector3 delta = m_playerTransform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.4f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		else if(GameObject.Find("Player").GetComponent<PlayerController>().frozen == true && camerapos != 0){
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(m_playerTransform.position);
			Vector3 delta = m_playerTransform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			destination.x = camerapos;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
    }
}
