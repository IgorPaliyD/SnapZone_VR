using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClone : MonoBehaviour
{
    private Vector3 clonePosition;
    private GameObject cloneObject;
    private Transform cloneZone;


    void Awake(){
        cloneZone = transform.GetComponentInParent<SetZoneController>().GetValueByName(transform.name);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
