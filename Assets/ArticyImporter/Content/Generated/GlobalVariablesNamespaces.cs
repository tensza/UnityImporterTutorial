//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Articy.Unity;
using Articy.Unity.Interfaces;
using System;
using System.Collections;
using UnityEngine;


namespace Articy.UnityImporterTutorial.GlobalVariables
{
    
    
    [Serializable()]
    public class GameState : IArticyNamespace
    {
        
        [SerializeField()]
        private BaseGlobalVariables _VariableStorage;
        
        // Player received a tip about what to ask the Oracle
        public bool gotTip
        {
            get
            {
                return _VariableStorage.Internal_GetVariableValueBoolean(0);
            }
            set
            {
                _VariableStorage.Internal_SetVariableValueBoolean(0, value);
            }
        }
        
        // Player talked to Kirian before
        public bool dialogue1Visited
        {
            get
            {
                return _VariableStorage.Internal_GetVariableValueBoolean(1);
            }
            set
            {
                _VariableStorage.Internal_SetVariableValueBoolean(1, value);
            }
        }
        
        // Player talked to the Oracle before
        public bool dialogue2Visited
        {
            get
            {
                return _VariableStorage.Internal_GetVariableValueBoolean(2);
            }
            set
            {
                _VariableStorage.Internal_SetVariableValueBoolean(2, value);
            }
        }
        
        public void RegisterVariables(BaseGlobalVariables aStorage)
        {
            _VariableStorage = aStorage;
            aStorage.RegisterVariable("GameState.gotTip", false);
            aStorage.RegisterVariable("GameState.dialogue1Visited", false);
            aStorage.RegisterVariable("GameState.dialogue2Visited", false);
        }
    }
}