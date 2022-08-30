using UnityEngine;
using System.Collections.Generic;

namespace EdsDevExp.Common
{
    
    [CreateAssetMenu(fileName = "Dropdown Options", menuName = "Common/DropdownOptions", order = 0)]
    public class DropdownOptions : ScriptableObject 
    {   
        public List<string> Ids; 
    }       
}