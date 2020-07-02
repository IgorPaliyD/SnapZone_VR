﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class CloneSetup : MonoBehaviour
{
    private SnapParent thisParent;
    public Transform origin;
    private Color matchColor = new Color(0,255,255,0.5f);
    private Color misMatchColor = new Color(255,0,0,0.5f);
    public bool isMatched;
    
    public bool isVisible = true;

    public bool CollisionMatch;


private void SetupVisuals(){
    MeshRenderer cloneRenderer = this.GetComponent<MeshRenderer>();
    if(isVisible){
        cloneRenderer.gameObject.SetActive(true);
        if(isMatched) {Debug.Log("blue"); cloneRenderer.material.color = matchColor;}
        else{Debug.Log("red"); cloneRenderer.material.color = misMatchColor;}  
    }
    else this.GetComponent<MeshRenderer>().gameObject.SetActive(false);
}
public void InitializeClone(SnapParent p, Transform tr, bool m){
    isMatched = m;
    thisParent = p;
    origin = tr;
}

public void Start(){
    this.GetComponent<Collider>().isTrigger = true;
    SetupVisuals();
}
private void InstalOriginObject(){
    origin.position  = transform.position;
    origin.rotation = transform.rotation;
    origin.SetParent(thisParent.mainParent);
    thisParent.mainParent.GetComponent<MainParent>().AddToParent(origin.name);
    MadeOriginSatic();
    SwapStacks();
}
private void MadeOriginSatic(){
    origin.GetComponent<Rigidbody>().isKinematic = true;
    Destroy(origin.GetComponent<Throwable>());

}
private void SwapStacks(){
thisParent.KillChild();
thisParent.mainParent.GetComponent<MainParent>().AddToParent(origin.name);
}

public void OnTriggerEnter(Collider other){
if(other.name == origin.name && isMatched){
    CollisionMatch = true;
    InstalOriginObject();
}

else return;
}


}
