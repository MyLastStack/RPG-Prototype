using System;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class SaveLoadTest : MonoBehaviour
{
    [SerializeField]
    NameData myName;

    [SerializeField]
    TMP_InputField myInputField;
    [SerializeField]
    Slider mySliderField;

    string filePath = "SaveData\\Profile1";
    
    // Start is called before the first frame update
    void Start()
    {
        myName = new NameData();

        LoadProfile();
    }

    public void ChangeName(string newName)
    {
        myName.playerName = newName;
    }

    public void LoadProfile()
    {
        SaveManager.LoadData(filePath + "\\PlayerData", ref  myName);

        myInputField.text = myName.playerName;
        mySliderField.value = myName.playerValue;
    }

    public void SaveProfile()
    {
        CreateFileStructure();

        SaveManager.SaveData(filePath + "\\PlayerData", ref myName);
    }

    

    void CreateFileStructure()
    {
        // Determine whether the directory exists.
        if (Directory.Exists(filePath))
        {
            Debug.Log("Folder structure already exists");         
        }
        else
        {
            // Try to create the directory.
            Directory.CreateDirectory(filePath);
        }
    }
}

[Serializable]
public struct NameData
{
    public string playerName;
    public float playerValue;
}