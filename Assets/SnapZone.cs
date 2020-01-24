using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapZone : MonoBehaviour
{
   //объект который нужно установить 
    public GameObject objectToSnap;
    //объект который станет родителем для objectToSnap
    public GameObject parentObject;
    private bool insideSnapZone;
    private bool Snapped;
    private Collider thisCollider;
    private Renderer rend;


     void OnTriggerEnter(Collider other)
    {
        if (GameObject.ReferenceEquals(other.gameObject,objectToSnap))//other.gameObject == objectToSnap.gameObject)
        {
          
            insideSnapZone = true;
            
        }
     
    }

     void OnTriggerExit(Collider other)
    {
        if (GameObject.ReferenceEquals(other.gameObject,objectToSnap))
        {
            insideSnapZone = false;
        }
    }
    //устанавливает объект в положение, в котором находится объект который является Snap-зоной
    void TransformToSnapZone()
    {
        if ( insideSnapZone == true)
        {
            objectToSnap.gameObject.transform.position = gameObject.transform.position;
            objectToSnap.gameObject.transform.rotation = gameObject.transform.rotation;
            Snapped = true;
        }
        if (insideSnapZone == false)
        {
            Snapped = false;
        }
    }
 void SnapObject()
    {
        if (Snapped == true)
        {
           
            objectToSnap.GetComponent<Rigidbody>().isKinematic = true;
            objectToSnap.transform.SetParent(parentObject.transform);
            


        }
        if(Snapped == false)
        {
            objectToSnap.transform.parent= null;
            objectToSnap.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
/*void ColliderAble(){
     thisCollider.enabled = !thisCollider.enabled;
}
*/
    void Start()
    {
        thisCollider = GetComponent<Collider>();
        thisCollider.isTrigger = true;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        SnapObject();
        TransformToSnapZone();
    }
}
