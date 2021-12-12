using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;*/
using System;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    //PUBLIC
    public Text ValueLoading;
    public Image ValueLoadingBar;
    public GameObject loading;
    public GameObject clock;
    public CharacterManager _CharacterManager;
    public ItemsManager _ItemsManager;
    public Ancestor _Ancestor;
    //PRIVATE
    private string loadscene = "Menu";
    private GameObject Canvas;
    private GameObject Menu;
    private AsyncOperation loadingSceneOperation;
    private static FileManager instance;
    public static bool load = false;
    private Animator anim;
    private Animator clockanim;

    public static void SwitchScene(string scene)
    {
        instance.anim.SetTrigger("Visibly");
        instance.clockanim.SetTrigger("ClockWait");
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(scene);
        instance.loadingSceneOperation.allowSceneActivation = false;
        instance.loadscene = scene;
    }

    public void OnAnimationOver(string v)
    {
        if(v == "Unvisibily")
        {
            Menu = GameObject.FindWithTag("Menu").gameObject.transform.GetChild(0).gameObject;
            //CharacterManager = GameObject.FindWithTag("CharacterManager");
            //ItemsManager = GameObject.FindWithTag("CharacterManager");
            //Ancestor = GameObject.FindWithTag("Ancestor");
            if (loadscene == "Menu")
            {
                Canvas = GameObject.FindWithTag("Canvas");
                _CharacterManager.enabled = false;
                _ItemsManager.enabled = false;
                _Ancestor.enabled = false;
                Canvas.gameObject.SetActive(true); //включить MenuController в Canvas
                Canvas.GetComponent<Canvas>().worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            }
            else
            {
                _CharacterManager.enabled = true;
                _ItemsManager.enabled = true;
                Menu.gameObject.SetActive(true); //включить MenuController в Canvas
                _Ancestor.enabled = true;
            }
        }
        if (v == "Visibily")
        {
            loadingSceneOperation.allowSceneActivation = true;
            LoadScene();
        }
    }

    void Start() //запускаем самый первый процесс
    {
        instance = this;
        clockanim = clock.GetComponent<Animator>();
        anim = loading.GetComponent<Animator>();
        Manager();
    }

    private void Manager()
    {
        Cursor.lockState = CursorLockMode.Locked; //заблокировать курсор
        Cursor.visible = false; //скрыть курсор
        Cursor.lockState = CursorLockMode.None; //разблокировать курсор
        Cursor.visible = true; //показать курсор
    }

    private void LoadScene()
    {
        if (loadscene == "Menu")
        {
            Menu = GameObject.FindWithTag("Menu").gameObject.transform.GetChild(0).gameObject;
            Menu.gameObject.SetActive(false); 
        }
        else
        {
            Canvas = GameObject.FindWithTag("Canvas");
            Canvas.gameObject.SetActive(false); 
        }
        anim.SetTrigger("Unvisibly");
        load = false;
    }

    void Update()
    {
        if(load == true)
        {
            ValueLoading.text = (Mathf.RoundToInt(loadingSceneOperation.progress * 100)).ToString() + "%";
            ValueLoadingBar.fillAmount = loadingSceneOperation.progress;
        }
    }
}

