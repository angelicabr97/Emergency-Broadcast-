using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankAnimSc : MonoBehaviour
{
    [SerializeField] private Texture2D[] frames;
    [SerializeField] private float fps = 20.0f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {

        transform.Rotate(.3f, .1f, .1f);
        int index = (int)(Time.time * fps);
        index = index % frames.Length;
        mat.mainTexture = frames[index]; // usar en planeObjects
                                         //GetComponent<RawImage> ().texture = frames [index];
    }
}
