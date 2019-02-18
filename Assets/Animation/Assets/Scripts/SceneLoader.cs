/********************************* *
        generic Scene Loading Script

        scenes must be loaded into the build setting menu to work

        Unity3D 5.5
        2017
    *********************************/


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {    

    public int defaultScene; //can set default scene for loading.

    //this method will load your predefined default scene
    public void LoadDefaultScene()
    {
        SceneManager.LoadScene(defaultScene);
    }

    //Call this method with the scene number you siwh to load
    public void LoadSceneNumber(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    //call this method with the scene name you wish to load
    public void LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
