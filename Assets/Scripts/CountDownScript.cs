using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] private int startCountDown = 60;

    [SerializeField] private Text txtCountDown;
    // Start is called before the first frame update
    void Start()
    {
        txtCountDown.text = "Time left: " + startCountDown;
        StartCoroutine(Pause());
    }

    // Update is called once per frame
    IEnumerator Pause()
    {
        while (startCountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            startCountDown--;
            txtCountDown.text = "Time left: " + startCountDown;
        }
        
        GameObject.Find("Player").GetComponent<PlayerController>().GameOver();
    }
}
