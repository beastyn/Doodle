using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BallController : MonoBehaviour {

    [SerializeField] float forwardForce = 10;
    [SerializeField] float jumpForce = 2f;
    GameManager gameManager;
    Rigidbody myRigidbody;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()

    {
        if (gameManager.GetPosessedStuff() == gameObject.transform)
        {
            MoveForward();
            Jump();
        }
    }

    private void MoveForward()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        
        Vector3 direction = horizontal * Vector3.right;
        myRigidbody.AddForce(direction * forwardForce);
    }
    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
           
          
            myRigidbody.AddForce(Vector3.up * jumpForce);
            
        }
    }
}
