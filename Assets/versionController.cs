using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class versionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Version: " + Application.version;
    }

    // Update is called once per frame
    void Update() { }
}
