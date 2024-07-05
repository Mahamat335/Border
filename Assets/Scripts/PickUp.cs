using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

    [SerializeField] public Transform holdPos;
    
    public float pickUpRange = 5f; 
    private GameObject heldObj; 
    private Rigidbody heldObjRb;
    private int LayerNumber;

    void Start() {
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        //mouseLookScript = player.GetComponent<MouseLookScript>();
    }
    void Update() {
        if (Input.GetMouseButton(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) {
                    if (hit.transform.gameObject.tag == "Object") {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else {
                    StopClipping();
                    DropObject();
            }

        }
        if (heldObj != null) 
        {
            MoveObject(); 

        }
    }
    void PickUpObject(GameObject pickUpObj) {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj; 
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; 
            heldObj.layer = LayerNumber;
        }
    }
    void DropObject() {
        heldObj.layer = 0; 
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; 
        heldObj = null;
    }
    void MoveObject() {
        heldObj.transform.position = holdPos.transform.position;
    }

    void StopClipping() {

        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        
        if (hits.Length > 1) {
            
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); 
        }
    }
}