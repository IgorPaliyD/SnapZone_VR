using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoneController : MonoBehaviour
{
   public Dictionary<string,Vector3> listOfGatherPoints;
    public void SetGatherPoints(){
       for(int i=0;i<transform.childCount;i++){
           Transform child = transform.GetChild(i);
           listOfGatherPoints.Add(child.name,child.position);
           
       }
    }

    
}
