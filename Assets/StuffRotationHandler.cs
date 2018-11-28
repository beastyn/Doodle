using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class StuffRotationHandler : MonoBehaviour {

    [SerializeField] float rotationSpeed = 8f;


    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.GetPosessedStuff() == gameObject.transform)
        {
            float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            float directionRotation = 0f;
            if (Mathf.Sign(horizontal) == -1)
            {
                directionRotation = 180f;
            }
            else
            {
                directionRotation = 0f;
            }

            bool stuffHasHorizontalSpeed = horizontal != 0;

            if (stuffHasHorizontalSpeed)
            {
                Debug.Log(stuffHasHorizontalSpeed);
                var newRotation = Quaternion.Euler(transform.rotation.x, directionRotation, transform.rotation.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
            }
        }

    }
}
