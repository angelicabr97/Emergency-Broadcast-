using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class GenerateImageAnchor : MonoBehaviour {


	[SerializeField]
	private ARReferenceImage referenceImage;

	[SerializeField]
	private GameObject prefabToGenerate;

    [Tooltip("Tick this if you want your object to keep matching its position to the image position.")]
    public bool bindObjectToImage = true;

    [Tooltip("Tick this if you want to have the object disappear if you loose track of the image. This means that you will possibly have a new object appear everytime the object is detected")]
    public bool destroyObjectOnEnd = true;
    private bool hasAlreadyGeneratedPrefab = false;

	private GameObject imageAnchorGO;

	// Use this for initialization
	void Start () {
		UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += UpdateImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += RemoveImageAnchor;

	}

	void AddImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.LogFormat("image anchor added[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
		if (arImageAnchor.referenceImageName == referenceImage.imageName) {
            
            // ---------------------------------------------------------------
            // THIS PART IS WHERE CODE GETS EXECUTED WHEN AN IMAGE IS DETECTED
            // ---------------------------------------------------------------

			Vector3 position = UnityARMatrixOps.GetPosition (arImageAnchor.transform);
			Quaternion rotation = UnityARMatrixOps.GetRotation (arImageAnchor.transform);

            if(!destroyObjectOnEnd){
                if(!hasAlreadyGeneratedPrefab){
                    imageAnchorGO = Instantiate<GameObject>(prefabToGenerate, position, rotation);
                    hasAlreadyGeneratedPrefab = true;
                }
            }else{
                imageAnchorGO = Instantiate<GameObject>(prefabToGenerate, position, rotation);
            }
			    


		}
	}

	void UpdateImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.LogFormat("image anchor updated[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
		if (bindObjectToImage && arImageAnchor.referenceImageName == referenceImage.imageName) {
            if (arImageAnchor.isTracked)
            {
                if (!imageAnchorGO.activeSelf)
                {
                    imageAnchorGO.SetActive(true);
                }

                if (bindObjectToImage)
                {
                    imageAnchorGO.transform.position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
                    imageAnchorGO.transform.rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);
                }
            }
            else if (destroyObjectOnEnd && imageAnchorGO)
            {
                GameObject.Destroy(imageAnchorGO);
            }
        }

	}

	void RemoveImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.LogFormat("image anchor removed[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
		if (destroyObjectOnEnd && imageAnchorGO) {
			GameObject.Destroy (imageAnchorGO);
		}

	}

	void OnDestroy()
	{
		UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= UpdateImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= RemoveImageAnchor;

	}

	// Update is called once per frame
	void Update () {
		
	}
}
