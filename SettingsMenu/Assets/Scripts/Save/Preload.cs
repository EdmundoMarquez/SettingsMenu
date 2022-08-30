using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fragsfot.Save
{
    public class Preload : MonoBehaviour
    {
        private void Awake() 
        {
            // SaveFileHandler.Load();
            DontDestroyOnLoad(gameObject);
        }
    }    
}