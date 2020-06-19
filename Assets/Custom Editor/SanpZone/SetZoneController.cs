using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoneController : MonoBehaviour
{
   private Dictionary<string,Transform> listOfGatherPoints = new Dictionary<string,Transform>();
    public void SetGatherPoints(){
       for(int i=0;i<transform.childCount;i++){
           Transform child = transform.GetChild(i);
           listOfGatherPoints.Add(child.name,child);
           Debug.Log(listOfGatherPoints.Count);
       }
    }
     
     public Transform GetValueByName(string name){
         return listOfGatherPoints[name];
     }
    
}
