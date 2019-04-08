using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public Image notifImage;
    public Sprite aiSprite;
    public Sprite plagueSprite;
    public Sprite stockSprite;

    // Start is called before the first frame update
    void Start()
    {
        SendNotif(stockSprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendNotif(Sprite img)
    {

    }
}
