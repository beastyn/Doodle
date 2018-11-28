using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PosessionController : MonoBehaviour {

    DoodleScalingHandler doodleScaleOnStuff;
    GameManager gameManager;
   
    // Use this for initialization
    void Start () {

        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)

        PosessNewObject();
        FlipSprite();
    }

    private void PosessNewObject()
    {
        if (Input.GetMouseButtonDown(0)) // TODO with touch
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition); // TODO Input.GetTouch(0).position
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit) && raycastHit.collider.CompareTag("Posession"))
            {
                MakeNewDoodleParent(raycastHit);
                PlaceDoodlePartsOnParent();
                EventManager.TriggerEvent("PosessesNewObject");

            }
        }
    }

    private void MakeNewDoodleParent(RaycastHit raycastHit)
    {
        Vector3 currentLocalPosition = transform.localPosition;
        Vector3 currentLocalScale = transform.localScale;
        Transform previousParent = transform.parent;

        transform.parent = raycastHit.collider.gameObject.transform;

        if (doodleScaleOnStuff == null || transform.parent!= previousParent)
        {
            doodleScaleOnStuff = transform.parent.GetComponent<DoodleScalingHandler>();
        }

        transform.localPosition = currentLocalPosition;
        transform.localScale = doodleScaleOnStuff.GetDoodleRelativeScale() * transform.parent.localScale;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gameManager.SetPosessedStuff(transform.parent);
    }

    private void PlaceDoodlePartsOnParent()
    {
        float scaleDifference = 1 / transform.localScale.x;
        Transform faceSlot = transform.parent.GetChild(0);
        Transform rightHandSlot = transform.parent.GetChild(1);
        Transform leftHandSlot = transform.parent.GetChild(2);
        transform.GetChild(0).localPosition = scaleDifference * faceSlot.localPosition;
        transform.GetChild(1).localPosition = scaleDifference * rightHandSlot.localPosition;
        transform.GetChild(2).localPosition = scaleDifference * leftHandSlot.localPosition;
    }
    void FlipSprite()
    {
       // Debug.Log(transform.parent.forward); 
    }
}
