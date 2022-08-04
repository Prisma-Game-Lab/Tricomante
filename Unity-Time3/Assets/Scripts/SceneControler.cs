using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("Fight", LoadSceneMode.Single);
    }
}
