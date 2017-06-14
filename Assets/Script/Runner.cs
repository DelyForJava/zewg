using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Runner : MonoBehaviour
{
        // Use this for initialization
        void Start()
        {
                ( (AppFacade)AppFacade.Instance ).Startup();
        }

        // Update is called once per frame
        void Update()
        {
        }

}
