using System;
using UnityEngine;

public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        Debug.Log("Hello World");
        Debug.LogWarning("Hello World");
        Debug.LogError("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello World");
    }
}