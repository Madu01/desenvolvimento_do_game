using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{
    public void LoadScene(string nome){
        SceneManager.LoadScene(nome);
    }

    public void EncerrarJogo(){
        Application.Quit();
    }
}
