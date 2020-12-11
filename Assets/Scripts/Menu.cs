using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Menu : MonoBehaviour
{
    public void changeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
