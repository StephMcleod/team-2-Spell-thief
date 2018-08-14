using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatforms : MonoBehaviour {

    public float timeLeft;
    public float resetTime;
    public GameObject[] platforms;
    public int platformsMax;
    public int platformCurrent;

    public int platformNum;

    // Use this for initialization
    void Start()
    {
        platformCurrent = 0;
        platformNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (platformCurrent == platformsMax)
            {
                platformCurrent = 0;
                platformNum = 1;
            }
            else
            {
                ++platformCurrent;
                ++platformNum;
            }
            timeLeft = resetTime;
        }

        switch (platformNum)
        {
            case 1:
                platforms[platformCurrent].SetActive(true);
                platforms[platformsMax].SetActive(false);
                break;

            case 2:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 3:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 4:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 5:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 6:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 7:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 8:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 9:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;

            case 10:
                platforms[platformCurrent - 1].SetActive(false);
                platforms[platformCurrent].SetActive(true);
                platforms[platformCurrent + 1].SetActive(true);
                break;
        }
    }

}
