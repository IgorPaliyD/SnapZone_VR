using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    public GameObject SnapLocation;
    public GameObject gear;
    public bool isSnapped;
    private bool objectSnapped;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        objectSnapped = SnapLocation.GetComponent<SnapLocation>().Snapped;
        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(gear.transform);
            isSnapped = true;
        }

        if(objectSnapped == false){

            gameObject.transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
