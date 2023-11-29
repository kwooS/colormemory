using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestManager : MonoBehaviour
{
    public string dataDir = "C:\\Users\\HCI-TECH 07\\Desktop\\kw\\classes\\2023 fall\\인간공학\\project+paper\\final project\\ut scenes\\colormemory\\Assets\\Data";
    public int userNo = 1;
    public int trialNo = 1;
    public bool isPractice = false;
    public int practiceIdx = 10;

    public string[] order;
    public string[] digits;
    public string[] practiceDigits;

    // Start is called before the first frame update
    void Awake()
    {
        //just in case you forget to uncheck
        if (trialNo > 1)
        {
            isPractice = false;
        }
    }

    public void UpdateInformation()
    {
        string orderDir = dataDir + "\\order.csv";
        string digitDir = dataDir + "\\digits.csv";

        StreamReader orderSR = new StreamReader(orderDir);
        StreamReader digitSR = new StreamReader(digitDir);

        string orderStr = "";
        string digitStr = "";
        string practiceStr = "";

        for (int i = 0; i < userNo; i++)
        {
            orderStr = orderSR.ReadLine();
        }
        orderSR.Close();

        for (int i = 0; i < (userNo - 1) * 4 + trialNo; i++)
        {
            digitStr = digitSR.ReadLine();
        }
        digitSR.Close();

        if (isPractice)
        {
            StreamReader practiceSR = new StreamReader(digitDir);
            for (int i = 0; i < practiceIdx + 1; i++)
            {
                practiceStr = practiceSR.ReadLine();
            }

            practiceDigits = practiceStr.Split(',')[0..3];
            practiceSR.Close();
        }

        Debug.Log(orderStr);
        Debug.Log(digitStr);

        order = orderStr.Split(';')[trialNo-1].Split(",");
        order[0] = order[0][1..];
        order[1] = order[1][..^1];
        digits = digitStr.Split(',')[0..14];
    }
}
