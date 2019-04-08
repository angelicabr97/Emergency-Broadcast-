using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{

    public GameObject instructionText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEndEdit(string theInput){
        Debug.Log(theInput);

        if(theInput == "hello"){
            
            GetComponent<Animator>().Play("CubeScale");

        }else if(theInput == "goodbye"){
            
            GetComponent<Animator>().Play("CubeSpinning"); 

        }else{
            Debug.Log("sorry");

            instructionText.GetComponent<Text>().text = "Sorry, try again!";
        }
    }

    public void OnInput(){
        
    }

    public void OnClick()
    {
        

    }

}
