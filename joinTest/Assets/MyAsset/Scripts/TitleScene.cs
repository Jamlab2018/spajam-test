using System;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("photoAlubum");
    }
}
