using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject IsHere;
    [SerializeField] GameObject paneloose;
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;

    public int _cubeCount;

    public Camera Camera;


    void Start()
    {
        //int cubecount = KillingCam.GetComponent<KillingCam>()._cubeCount;
        paneloose.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        IsHere.SetActive(false);
        paneloose.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
