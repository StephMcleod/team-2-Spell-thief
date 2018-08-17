using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwaper : MonoBehaviour {

    public string ToOpen;

    public void button()
    {
        SceneManager.LoadScene(ToOpen);
    }
}
