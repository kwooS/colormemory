using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestManager : MonoBehaviour
{
    public string dataDir = "C:\\Users\\HCI-TECH 07\\Desktop\\kw\\classes\\2023 fall\\인간공학\\project+paper\\final project\\ut scenes\\colormemory\\Assets\\Data";
    public int userNo = 0;
    public int trialNo = 0;
    public bool isPractice = false;
    public int practiceIdx = 10;

    public string[] order;
    public string[] digits;
    public string[] practiceDigits;

    // Start is called before the first frame update
    void Start()
    {
        string orderDir = dataDir + "\\order.csv";
        string digitDir = dataDir + "\\digits.csv";

        StreamReader orderSR = new StreamReader(orderDir);
        StreamReader digitSR = new StreamReader(digitDir);

        string orderStr = "";
        string digitStr = "";

        for (int i = 0; i < userNo*4+trialNo + 1; i++)
        {
            orderStr = orderSR.ReadLine();
            digitStr = digitSR.ReadLine();
        }

        Debug.Log(orderStr);
        Debug.Log(digitStr);

        order = orderStr.Split(';')[trialNo].Split(",");
        digits = digitStr.Split(',')[0..14];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadData()
    {
    }
}
