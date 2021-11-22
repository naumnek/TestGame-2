using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public bool loadFileManager = false;
    public GameObject general;
    public GameObject GameManager;
    public GameObject Player;
    public GameObject MainCamera;
    public FileManager _fileManager;
    private static LoadManager instance;

    void Start()
    {
        instance = this;
        MainCamera = Player.gameObject.transform.GetChild(0).gameObject;
        if(loadFileManager)
        {
            _fileManager = FileManager.GetFileManager();
            _fileManager._LoadManager = this.GetComponent<LoadManager>();
        }
    }

    private void Update()
    {
        if (!FileManager.load)
        {
            LoadObjects();
        }
    }

    // Start is called before the first frame update
    public void LoadObjects()
    {
        general.SetActive(true);
    }
}
