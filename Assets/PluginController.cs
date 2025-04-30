using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginController : MonoBehaviour
{
    public static PluginController instance;
    public Transform[] voicePlugins;

    public Transform[] micButtons;

    // Start is called before the first frame update

    void Start()
    {
        instance = this;
    }

    void FixedUpdate() { }

    public void ShowRightPlugin()
    {
        if (CheckInternet.instance.isWifiConnected || CheckInternet.instance.isMobileConnected)
        {

            //  Debug.Log("internet ");
            voicePlugins[0].gameObject.SetActive(true);
            voicePlugins[1].gameObject.SetActive(false);
            micButtons[0].gameObject.SetActive(true);
            micButtons[1].gameObject.SetActive(false);


        }
        else
        {
            //     Debug.Log("no internet, not accureate");
            voicePlugins[0].gameObject.SetActive(false);
            voicePlugins[1].gameObject.SetActive(false);
            micButtons[0].gameObject.SetActive(false);
            micButtons[1].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() { }
}
