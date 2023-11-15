using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorControl : MonoBehaviour
{
    public MeshRenderer screenMesh;
    public TextMeshProUGUI text;
    public int colorTime;

    private string[] order;
    private string[] digits;
    private string[] practice;
    private bool isPractice;

    private Color color;
    private float time;

    private int idx=0;

    // Start is called before the first frame update
    void Start()
    {
        TestManager testManager = transform.GetComponent<TestManager>();
        order = testManager.order;
        digits = testManager.digits;
        isPractice = testManager.isPractice;
        if (isPractice)
        {
            practice = testManager.practiceDigits;
        }
        getColor(order[0]);
        time = float.Parse(order[1]);
    }

    void getColor(string colorStr)
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

    public void proceed()
    {
        string digit = digits[idx];
        int length = digit.Length;
        StartCoroutine(StartDigitSpan(digit, length));
        idx++;
    }

    IEnumerator StartDigitSpan(string digit, int length)
    {
        Color previous = screenMesh.material.color;
        screenMesh.material.color = color;
        yield return new WaitForSeconds((float)colorTime);

        //Change screen color back to default
        screenMesh.material.color = previous;

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
    }
}
