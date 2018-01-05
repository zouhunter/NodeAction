﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Rotorz.ReorderableList;
using Rotorz.ReorderableList.Internal;

namespace WorldActionSystem
{
    [CustomEditor(typeof(ActionGroupObj)), CanEditMultipleObjects]
    public class ActionGroupObjDrawer : ActionGroupDrawerBase
    {
      
        protected override void RemoveDouble()
        {
            var actionSystem = target as ActionGroupObj;
            var newList = new List<ActionPrefabItem>();
            var needRemove = new List<ActionPrefabItem>();
            foreach (var item in actionSystem.prefabList)
            {
                if (newList.Find(x => x.ID == item.ID) == null)
                {
                    newList.Add(item);
                }
                else
                {
                    needRemove.Add(item);
                }
            }
            foreach (var item in needRemove)
            {
                actionSystem.prefabList.Remove(item);
            }
            EditorUtility.SetDirty(actionSystem);
        }
    }

}