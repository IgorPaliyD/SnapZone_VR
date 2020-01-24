using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapLocation : MonoBehaviour
{

    private bool grabbed;
    private Renderer rend;
    private bool insideSnapZone;
    public bool Snapped;
    public GameObject Part;
    public GameObject SnapRotationReference;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == Part.name)
        {
            
            insideSnapZone = true;
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == Part.name)
        {
            insideSnapZone = false;
        }
    }
    // Start is called before the first frame update
void SnapObject()
    {
        if( /*grabbed==false && */ insideSnapZone == true)
        {
            Part.gameObject.transform.position = transform.position;
            Part.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
        }
        if (insideSnapZone == false)
        {
            Snapped = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        rend = GetComponent<Renderer>();
        if (insideSnapZone == true)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
      */
        //grabbed = Part.GetComponent<Throwable>().attached;
        SnapObject();
    }
}
