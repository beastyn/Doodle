using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PaperController : MonoBehaviour
{
    [SerializeField] float speed = 10;

    GameManager gameManager;
  
    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

       
    }

    // Update is called once per frame
    void Update()

    {
        if (gameManager.GetPosessedStuff() == gameObject.transform)
        {
            float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Vector3 direction = horizontal * Vector3.right;
            rigidbody.AddForce(direction * speed);
        }
    }
}
