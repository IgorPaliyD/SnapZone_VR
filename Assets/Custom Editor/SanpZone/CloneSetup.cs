using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSetup : MonoBehaviour
{
    public Transform mainParentT;
    public Transform freeParentT;
    public string originName;
    private Color matchColor = new Color(0,255,255,0.5f);
    private Color misMatchColor = new Color(255,0,0,0.5f);
    public bool isMatched;
    
    public bool isVisible;


private void SetupVisuals(){
    if(isVisible){
        this.GetComponent<MeshRenderer>().gameObject.SetActive(true);
        if(isMatched) this.GetComponent<MeshRenderer>().material.color = matchColor;
        else this.GetComponent<MeshRenderer>().material.color = misMatchColor;  
    }
    else this.GetComponent<MeshRenderer>().gameObject.SetActive(false);
}
public void Awake(){
    SetupVisuals();
    mainParentT = freeParentT.GetComponent<SnapParent>().mainParent;
}

}
