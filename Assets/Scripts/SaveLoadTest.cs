using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TMPro;
using UnityEngine.UI;

public class SaveLoadTest : MonoBehaviour
{
    [SerializeField]
    NameData myName;

    [SerializeField]
    TMP_InputField myInputField;
    [SerializeField]
    Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        myName = new NameData();

        LoadData();
    }

    public void ChangeName(string newName)
    {
        myName.playerName = newName;
    }

    public void SaveData()
    {
        myName.playerValue = mySlider.value;

        Stream stream = File.Open("PlayerData.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(NameData));
        serializer.Serialize(stream, myName);
        stream.Close();
    }

    public void LoadData()
    {
        Stream stream = File.Open("PlayerData.xml", FileMode.Open);
        XmlSerializer serializer = new XmlSerializer(typeof(NameData));
        myName = (NameData)serializer.Deserialize(stream);
        stream.Close();

        myInputField.text = myName.playerName;
        mySlider.value = myName.playerValue;
    }
}

[Serializable]
public struct NameData
{
    public string playerName;
    public float playerValue;
}