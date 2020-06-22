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
         //cloneObject.AddComponent();

    }
    //Current element in parent queue
    private void GetCurrentStackElement(){
        currentStackElement = transform.GetComponentInParent<SnapParent>().GetCurrentChild();
    }
    //check is this object name maching current queue element
    private void CheckForStackMatch(){
        if(currentStackElement == transform.name){
            isStackMached = true;
        }
        else isStackMached = false;
    }
    public void OnAttachedToHand(){
        isGrabbed = true;
        CheckForStackMatch();
        CreateCloneZone();
    }
   // создать скрипт клона, который красит цвет в синий, если isStackMached = true и красный если нет
   
}
