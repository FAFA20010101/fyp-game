using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollAnimate : MonoBehaviour
{
    public GameObject female1rig;
    public Animator female1Animator;
    public BoxCollider maincollider;

    // Start is called before the first frame update
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "train")
        {
            RagdollModeOn();
        }
    }

    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;
    void GetRagdollBits()
    {
        ragdollColliders = female1rig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = female1rig.GetComponentsInChildren<Rigidbody>();

    }
    void RagdollModeOn()
    {
        

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        female1Animator.enabled = false;
        maincollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollModeOff()
    {
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        
        foreach(Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true; 
        }

        female1Animator.enabled = true;
        maincollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;

    }

}
