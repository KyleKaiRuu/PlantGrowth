using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCashStats : MonoBehaviour
{
    public int cash = 0;

    public Text cashText;

    private void Awake()
    {
        LoadCash();
    }

    private void Update()
    {
        cashText.text = "Current cash: " + cash.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cash += 100;
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("QUIT");
        SaveCash();
    }

    public void SaveCash()
    {
        //Path
        string path = Application.dataPath + "/cash.txt";
        //Content
        string content = cash.ToString();
        content = EncryptDecrypt(content);
        //Add Text
        File.WriteAllText(path, content);
    }

    public void LoadCash()
    {
        string path = Application.dataPath + "/cash.txt";
        if (File.Exists(Application.dataPath + "/cash.txt"))
        {
            string content = File.ReadAllText(path);
            content = EncryptDecrypt(content);
            cash = Convert.ToInt16(content);
            Debug.Log(content);
        }
        else
        {
            Debug.LogWarning("File does not exit. Will be created on quit.");
        }
    }

    public static string EncryptDecrypt(string textToEncrypt)
    {
        int key = 129;
        StringBuilder inSb = new StringBuilder(textToEncrypt);
        StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
        char c;
        for (int i = 0; i < textToEncrypt.Length; i++)
        {
            c = inSb[i];
            c = (char)(c ^ key);
            outSb.Append(c);
        }
        return outSb.ToString();
    }
}
