using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    public void play(){
        SceneManager.LoadScene("level1");
    }
    public void quitGame(){
        Application.Quit();
    }
    public void show(){
        menu.SetActive(true);
    }
    public void pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Volume(float value){
        audioMixer.SetFloat("MainVolume",value);
    }
}
