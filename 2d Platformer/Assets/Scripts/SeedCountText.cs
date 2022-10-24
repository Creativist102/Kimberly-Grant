using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedCountText : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private TextMeshProUGUI UIText;
    private string objectID;

    void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        objectID = objectPrefab.GetComponent<Object>().ID;
        PlayerPrefs.DeleteAll();
    }

    private void LateUpdate()
    {
        UIText.text = "Seed Count: " + PlayerPrefs.GetInt(objectID).ToString();
    }
}

//Used on ...