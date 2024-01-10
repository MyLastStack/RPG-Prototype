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

    [Header("Profile Buttons")]
    [SerializeField]
    Button profileButtonOne;
    [SerializeField]
    Button profileButtonTwo;
    [SerializeField]
    Button profileButtonThree;

    public int profileSelected;

    string filePath = "SaveData\\Profile1";
    
    // Start is called before the first frame update
    void Start()
    {
        myName = new NameData();

        profileSelect(1);
        LoadProfile();
    }

    private void Update()
    {
        switch(profileSelected)
        {
            case 1:
                profileButtonOne.image.color = Color.blue;
                profileButtonTwo.image.color = Color.white;
                profileButtonThree.image.color = Color.white;
                break;
            case 2:
                profileButtonOne.image.color = Color.white;
                profileButtonTwo.image.color = Color.blue;
                profileButtonThree.image.color = Color.white;
                break;
            case 3:
                profileButtonOne.image.color = Color.white;
                profileButtonTwo.image.color = Color.white;
                profileButtonThree.image.color = Color.blue;
                break;
            default:
                break;
        }
    }

    public void profileSelect(int value)
    {
        profileSelected = value;
    }



    public void ChangeName(string newName)
    {
        myName.playerName = newName;
    }
    public void ChangeValue()
    {
        myName.playerValue = mySliderField.value;
    }

    public void LoadProfile()
    {
        SaveManager.LoadData($"SaveData\\Profile{profileSelected}" + "\\PlayerData", ref  myName);

        myInputField.text = myName.playerName;
        mySliderField.value = myName.playerValue;
    }

    public void SaveProfile()
    {
        CreateFileStructure();

        SaveManager.SaveData($"SaveData\\Profile{profileSelected}" + "\\PlayerData", ref myName);
    }

    void CreateFileStructure()
    {
        // Determine whether the directory exists.
        if (Directory.Exists($"SaveData\\Profile{profileSelected}"))
        {
            Debug.Log("Folder structure already exists");
        }
        else
        {
            // Try to create the directory.
            Directory.CreateDirectory($"SaveData\\Profile{profileSelected}");
        }
    }
}

[Serializable]
public struct NameData
{
    public string playerName;
    public float playerValue;
}