using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorControl : MonoBehaviour
{
    //[HideInInspector]
    public MeshRenderer screenMesh;
    //[HideInInspector]
    public TextMeshProUGUI text;

    public int colorTime;

    private string[] order;
    private string[] digits;
    private string[] practice;
    private bool isPractice;

    private Color color;
    private float time;

    private int idx = 0;
    private int practiceIdx = 0;

    private bool buttonLock = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInformation();
    }

    public void UpdateInformation()
    {
        if (buttonLock) { return; }
        TestManager testManager = transform.GetComponent<TestManager>();
        testManager.UpdateInformation();
        order = testManager.order;
        digits = testManager.digits;
        isPractice = testManager.isPractice;
        if (isPractice)
        {
            practice = testManager.practiceDigits;
        }
        GetColor(order[0]);
        time = float.Parse(order[1]);
        idx = 0;
    }

    void GetColor(string colorStr)
    {
        Dictionary<string, float[]> possibleColors = new Dictionary<string, float[]>()
        {
            { "r_half", new float[] { 0f, 0,5f, 1f} },
            { "r_full", new float[] { 0f, 1f, 1f} },
            { "g_half", new float[] { 1/3f, 0.5f, 1f}},
            { "g_full", new float[] { 1/3f, 1f, 1f}},
            { "b_half", new float[] { 2/3f, 0.5f, 1f}},
            { "b_full", new float[] { 2/3f, 1f, 1f}},
            { "black", new float[] { 0f, 0f, 0f}},
            { "white", new float[] { 0f, 0f, 1f}} 
        };
        float[] hsvColor = possibleColors[colorStr];

        //Debug.Log(hsvColor[0]);
        //Debug.Log(hsvColor[1]);
        //Debug.Log(hsvColor[2]);

        color = Color.HSVToRGB(hsvColor[0], hsvColor[1], hsvColor[2]);
    }

    public void PracticeSession()
    {
        if(buttonLock) { return; }
        if(idx==0 & isPractice & practiceIdx < 3)
        {
            string digit = practice[practiceIdx];
            int length = digit.Length;
            StartCoroutine(StartPracticeSession(digit, length));
            practiceIdx++;
        }
    }

    IEnumerator StartPracticeSession(string digit, int length)
    {
        buttonLock = true;
        //Start Digit Span
        for (int i = 0; i < length; i++)
        {
            text.text = digit[i].ToString();
            yield return new WaitForSeconds(1f);
            text.text = "";
            yield return new WaitForSeconds(0.1f);
        }

        //Remove number
        text.text = "";
        buttonLock = false;
    }

    public void Proceed()
    {
        if (buttonLock){ return; }
        string digit = digits[idx];
        int length = digit.Length;
        StartCoroutine(StartDigitSpan(digit, length));
        idx++;
    }

    IEnumerator StartDigitSpan(string digit, int length)
    {
        buttonLock = true;
        Color defaultColor = screenMesh.material.color;
        screenMesh.material.color = color;
        yield return new WaitForSeconds((float)colorTime);

        //Change screen color back to default
        screenMesh.material.color = defaultColor;

        //Start Digit Span
        for (int i = 0; i < length; i++)
        {
            text.text = digit[i].ToString();
            yield return new WaitForSeconds(time);
            text.text = "";
            yield return new WaitForSeconds(0.1f);
        }

        //Remove number
        text.text = "";
        buttonLock = false;
    }
}
