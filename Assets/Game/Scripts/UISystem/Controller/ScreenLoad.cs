using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLoad : MonoBehaviour
{
    public void OnAnimationOver(string v)
    {
        FileManager fm = FileManager.GetFileManager();
        switch (v)
        {
            case ("Unvisibily"):
                fm.EndLoadScene();
                break;
            case ("Visibily"):
                fm.StartLoadScene();
                break;
        }
    }
}
