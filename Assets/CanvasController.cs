using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public static CanvasController instance;

    public float maxTime;

    public float tempTime;
    void Awake()
    {
        instance = this;
    }
    public Transform internetWarning;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 2.5f;
        tempTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        tempTime -= Time.deltaTime;
        if (tempTime < 0.0f)
        {
            StartQuestion();
            tempTime = maxTime;
        }
    }


    public void StartQuestion()
    {
        PluginController.instance.ShowRightPlugin();
        CheckInternet.instance.CheckingNetwork();
    }
    void OnEnable()
    {

    }
}
