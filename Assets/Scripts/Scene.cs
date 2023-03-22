using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene : MonoBehaviour
{
    [SerializeField]
    private Button exitButton;
    public void SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        if (exitButton != null)
        {
            Application.Quit();
        }
    }
}