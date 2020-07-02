using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPositionPoint : MonoBehaviour
{
    public Vector3 GatherPoint;

    public void SetupPoint(){
        GatherPoint = this.transform.position;
    }
}
