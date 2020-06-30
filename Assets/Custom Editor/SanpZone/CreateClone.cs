using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CreateClone : MonoBehaviour
{
   
    private GameObject cloneObject;
    private Vector3 clonePosition;

    private Quaternion cloneRotation;
    
    public bool isGrabbed = false;

    private string currentStackElement;

    private bool isStackMached = false;
    
    private void GetCloneTransform(){
         clonePosition = transform.GetComponentInParent<SetZoneController>().GetPositionByName(transform.name);
         cloneRotation = transform.GetComponentInParent<SetZoneController>().GetRotationByName(transform.name);
    }
    void Awake(){
       GetCloneTransform();
    }
    private void CreateCloneZone(){
        cloneObject = Instantiate(this.gameObject, clonePosition, cloneRotation);
         Destroy(cloneObject.GetComponent<Throwable>());
         Destroy(cloneObject.GetComponent<CreateClone>());
         cloneObject.AddComponent<CloneSetup>();
         CloneSetup newClone = cloneObject.GetComponent<CloneSetup>();
         newClone.origin = transform;
         newClone.freeParentT = transform.parent;
        
    }
        
    public void OnAttachedToHand(){
        isGrabbed = true;
        CreateCloneZone();
    }
    public void OnDetachedFromHand(){
        isGrabbed = false;
        Destroy(cloneObject);
    }
   
}
