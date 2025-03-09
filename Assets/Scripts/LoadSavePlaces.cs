using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class LoadSavePlaces : MonoBehaviour
{

    public GameObject bluePlatformPrefab;
    public GameObject redPlatformPrefab;
    public GameObject greenPlatformPrefab;

    void Start()
    {

        if(bluePlatformPrefab == null)
        {

            bluePlatformPrefab = Resources.Load<GameObject>("PlatformBlue");
            
        }

        if (redPlatformPrefab == null)
        {

            redPlatformPrefab = Resources.Load<GameObject>("PlatformRed");

        }

        if (greenPlatformPrefab == null)
        {

            greenPlatformPrefab = Resources.Load<GameObject>("PlatformGreen");

        }

        Instantiate(bluePlatformPrefab);
        Instantiate(redPlatformPrefab);
        Instantiate(greenPlatformPrefab);
    }



    void Update()
    {
        



    }
}
