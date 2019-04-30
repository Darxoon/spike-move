using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton 

    public static LevelManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
    }

    #endregion

    [System.Serializable]
    public struct Level
    {
        public string name;
        public Vector3Int exits;
        public string scene;
    }


    public int currentLevel = 0;
    public Level[] levels; 


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    } 

    public void LoadExit(int exit)
    {
        SceneManager.LoadScene(levels[levels[currentLevel].exits[exit]].scene);
    } 
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
