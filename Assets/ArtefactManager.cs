using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactManager : MonoBehaviour {

    public GameObject my3DText;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ReceivedTouch(Vector3 position, Quaternion rotation){
        GameObject.Instantiate(my3DText, position, rotation);
    }

    public void TouchedObject(GameObject touchedObject){
        Debug.Log("touched! " + touchedObject);
    }
}
