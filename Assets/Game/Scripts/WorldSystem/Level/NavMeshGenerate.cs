using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

namespace naumnek.FPS
{
    public class NavMeshGenerate : MonoBehaviour
    {
        private static NavMeshGenerate instance;

        void Start() //запускаем самый первый процесс
        {
            instance = this;
        }

        public static NavMeshGenerate GetNavMeshGenerate()
        {
            return instance.GetComponent<NavMeshGenerate>();
        }

        // Start is called before the first frame update
        public static void StartBuildNavMesh()
        {
            instance.GetComponent<NavMeshSurface>().BuildNavMesh();
        }

    }
}

