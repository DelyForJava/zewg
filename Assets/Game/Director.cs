using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public static void init()
    {
        if (director == null)
        {
            director = new GameObject("Director");
            // go.AddComponent<Timer>();
            UnityEngine.Object.DontDestroyOnLoad(director);
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static GameObject director;

}