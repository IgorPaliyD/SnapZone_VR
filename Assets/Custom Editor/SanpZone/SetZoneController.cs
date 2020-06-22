using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoneController : MonoBehaviour
{
   private Dictionary<string,Vector3> listOfGatherPointsPosition = new Dictionary<string,Vector3>();
   private Dictionary<string,Quaternion> listOfGatherPointsRotation = new Dictionary<string,Quaternion>();
   //Get all the current position and rotation of all childs
    public void SetGatherPoints(){
       for(int i=0;i<transform.childCount;i++){
           Transform child = transform.GetChild(i);
           listOfGatherPointsPosition.Add(child.name,child.position);
           listOfGatherPointsRotation.Add(child.name,child.rotation);
           
       }
    }
     
     public Vector3 GetPositionByName(string name){
         return listOfGatherPointsPosition[name];
     }
     public Quaternion GetRotationByName(string name){
         return listOfGatherPointsRotation[name];
     }
    
}
