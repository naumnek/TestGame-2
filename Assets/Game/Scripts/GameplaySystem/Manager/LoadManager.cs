using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace naumnek.FPS
{
    public class LoadManager : MonoBehaviour
    {
        public bool load = true;
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
        }

        private void Update()
        {
            if (!FileManager.load && load)
            {
                load = false;
                _fileManager = FileManager.GetFileManager();
                _fileManager._LoadManager = this.GetComponent<LoadManager>();
                LoadObjects();
            }
        }

        // Start is called before the first frame update
        public void LoadObjects()
        {
            general.SetActive(true);
            NavMeshGenerate.StartBuildNavMesh();
            Player.transform.position = GameObject.FindGameObjectWithTag("Spawnpoint").transform.position;
            Player.GetComponent<CharacterController>().enabled = true;
        }
    }
}

