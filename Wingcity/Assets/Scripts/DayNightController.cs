using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {


    private int dayLength;
    private int dayStart;
    private int nightStart;
    public int currentTime;
    public float cycleSpeed;
    private bool isDay;
    private Vector3 sunPosition;
    public Light sun;
    public GameObject earth;

	// Use this for initialization
	void Start () {

        dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentTime = 120;
        StartCoroutine(TimeOfDay());
        earth = gameObject.transform.parent.gameObject;

	}
	
	// Update is called once per frame
	void Update () {

        if (currentTime > 0 && currentTime < dayStart)
        {
            isDay = false;
            sun.intensity = 50;

        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            isDay = true;
            sun.intensity = 100;
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            isDay = false;
            sun.intensity = 50;
        }

        

        else if (currentTime >= dayLength)
        {
            currentTime = 50;
        }

        float currentTimeF = currentTime;
        float dayLengthF = dayLength;
        earth.transform.eulerAngles = new Vector3(0, (-(currentTimeF / dayLengthF) * 360) + 90, 0);

	}

    IEnumerator TimeOfDay()
    {
        while (true)
        {
            currentTime += 1;
            int hours = Mathf.RoundToInt(currentTime / 60);
            int minutes = currentTime % 60;
            //Debug.Log(hours + ":" + minutes);
            yield return new WaitForSeconds(1f / cycleSpeed);

        }
    }

}
