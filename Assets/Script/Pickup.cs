using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform PickUpPoint;
    private Transform rightHand;

    public float pickUpDistance;
    public float forceMulti;

    public bool readyToThrow;
    public bool itemIsPicked;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightHand = GameObject.Find("PlayerArmature/Skeleton/Hips/Spine/Chest/UpperChest/Right_Shoulder/Right_UpperArm/Right_LowerArm/Right_Hand").transform;

        if (PickUpPoint == null)
        {
            PickUpPoint = new GameObject("PickUpPoint").transform;
        }
        PickUpPoint.SetParent(rightHand);
        PickUpPoint.localPosition = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && itemIsPicked && readyToThrow)
        {
            forceMulti += 300 * Time.deltaTime;
        }

        pickUpDistance = Vector3.Distance(rightHand.position, transform.position);
        if (pickUpDistance <= 2)
        {
            if (Input.GetKeyDown(KeyCode.E) && !itemIsPicked && PickUpPoint.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                transform.position = PickUpPoint.position;
                transform.parent = PickUpPoint;

                itemIsPicked = true;
                forceMulti = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && itemIsPicked)
        {
            readyToThrow = true;
            if (forceMulti > 10)
            {
                rb.AddForce(rightHand.forward * forceMulti);
                transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                itemIsPicked = false;
                readyToThrow = false;
            }

            forceMulti = 0;
        }
    }
}