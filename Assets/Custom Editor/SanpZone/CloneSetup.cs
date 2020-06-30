using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSetup : MonoBehaviour
{
    public Transform mainParentT;
    public Transform freeParentT;
    public Transform origin;
    private Color matchColor = new Color(0,255,255,0.5f);
    private Color misMatchColor = new Color(255,0,0,0.5f);
    public bool isMatched;
    
    public bool isVisible;

    public bool CollisionMatch;


private void SetupVisuals(){
    MeshRenderer cloneRenderer = this.GetComponent<MeshRenderer>();
    if(isVisible){
        cloneRenderer.gameObject.SetActive(true);
        if(isMatched) cloneRenderer.material.color = matchColor;
        else cloneRenderer.material.color = misMatchColor;  
    }
    else this.GetComponent<MeshRenderer>().gameObject.SetActive(false);
}
private void MatchCompare(){
    if(freeParentT.GetComponent<SnapParent>().GetCurrentChild() == origin.name) isMatched = true;
    else isMatched = false;
}
public void Awake(){
    mainParentT = freeParentT.GetComponent<SnapParent>().mainParent;
    MatchCompare();
    SetupVisuals();

}
private void InstalOriginObject(){
    origin.position  = transform.position;
    origin.rotation = transform.rotation;
    origin.SetParent(mainParentT);
    mainParentT.GetComponent<MainParent>().AddToParent(origin.name);
    freeParentT.GetComponent<SnapParent>().KillChild();
}
public void OnTriggerStay(Collider other){
if(other.name == origin.name){
    CollisionMatch = true;
    InstalOriginObject();
}
else return;
}


}
