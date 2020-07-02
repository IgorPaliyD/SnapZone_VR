using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CreateClone : MonoBehaviour
{
   
    private GameObject cloneObject;
    
    private SnapParent p;
    public bool isGrabbed = false;

    private string currentStackElement;

    private bool isStackMached = false;
    
   
    private void CreateCloneZone(){
        cloneObject = Instantiate(this.gameObject, transform.GetComponent<GetPositionPoint>().GatherPoint, Quaternion.identity);
         Destroy(cloneObject.GetComponent<Throwable>());
         Destroy(cloneObject.GetComponent<CreateClone>());
         CloneSetup cls = cloneObject.AddComponent<CloneSetup>();
         cls.InitializeClone(p,transform,isStackMached);
    }
    private void MatchCheck(){
        if(p.GetCurrentChild() == transform.name) isStackMached =true;
        else isStackMached = false;
    }

    public void OnAttachedToHand(){
        MatchCheck();
        isGrabbed = true;
        CreateCloneZone();
    }
    public void OnDetachedFromHand(){
        isGrabbed = false;
        Destroy(cloneObject);
    }
   public void Start(){
       p = this.transform.GetComponentInParent<SnapParent>();
   }
}
