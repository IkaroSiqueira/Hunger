using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] public Transform holdArea;
    private GameObject _heldObj;
    private Rigidbody _heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float _pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _pickupRange))
                {
                    if(hit.transform.gameObject.tag == "Pickup")
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                DropObject();
            }
        }
        if(_heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(_heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - _heldObj.transform.position);
            _heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            _heldObjRB = pickObj.GetComponent<Rigidbody>();
            _heldObjRB.useGravity = false;
            _heldObjRB.drag = 10;
            _heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            _heldObjRB.transform.parent = holdArea;
            _heldObj = pickObj;
        }
    }

    void DropObject()
    {
            _heldObjRB.useGravity = true;
            _heldObjRB.drag = 1;
            _heldObjRB.constraints = RigidbodyConstraints.None;

            _heldObjRB.transform.parent = null;
            _heldObj = null;
    }
}
