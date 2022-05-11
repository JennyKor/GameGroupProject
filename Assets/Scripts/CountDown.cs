using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{


    public GameObject navigation;
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;
    public GameObject countdown;

    IEnumerator CountDownToStart()
    {


        while (countdownTime > 0)
        {

            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        // do sth after the timer

      navigation.SetActive(true);
        countdown.SetActive(false);

    }

    // Update is called once per frame
    void Start()
    {
         navigation.SetActive(false);
        StartCoroutine(CountDownToStart());

    }






}
