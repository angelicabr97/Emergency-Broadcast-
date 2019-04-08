using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ArtefactManager : MonoBehaviour {

    public GameObject my3DText;

    // Use this for initialization
    void Start () {
        UnityARSessionNativeInterface.ARAnchorAddedEvent += AddWater;

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

    public void AddWater(ARPlaneAnchor anchorData)
    {
        if (anchorData.transform.rotation.eulerAngles.x < 1)
        {

        }
         //make sure that it is within a range that could be the floor
    }
}
