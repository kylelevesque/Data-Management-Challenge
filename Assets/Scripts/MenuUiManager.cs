using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUiManager : MonoBehaviour
{

    TMPro.TMP_InputField inputField;

    private void Start()
    {
        inputField = gameObject.GetComponentInChildren<TMP_InputField>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateName()
    {
        Manager.Instance.playerName = inputField.text;
    }
}
