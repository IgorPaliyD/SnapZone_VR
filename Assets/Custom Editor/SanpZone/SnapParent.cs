using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapParent : MonoBehaviour
{
    
    private Stack<string> childs = new Stack<string>();
    private string currentChild;

    //Set all childs into a Stack
    private void SetChildsList(){
        for(int i=0;i<transform.childCount;i++){
            childs.Push(transform.GetChild(i).name);
        }
        currentChild = childs.Peek();
    }
    public string GetCurrentChild(){
        return currentChild;
    }
    //Kill child and get another
    public void KillChild(){
        childs.Pop();
        currentChild = childs.Peek();
    }
    void Start(){
        SetChildsList();
        Debug.Log(currentChild);
    }

}
