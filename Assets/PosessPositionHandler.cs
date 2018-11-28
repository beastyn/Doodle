using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PosessPositionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        EventManager.StartListening("PosessesNewObject", CorrectPlacement);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PosessesNewObject", CorrectPlacement);
    }

    void CorrectPlacement()
    {

        transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
    }
}
