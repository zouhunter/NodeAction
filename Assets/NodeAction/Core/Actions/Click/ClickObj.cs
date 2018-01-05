﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
namespace WorldActionSystem
{
    public class ClickObj : ActionObj
    {
        private float autoCompleteTime { get { return Config.autoExecuteTime; } }

        public override ControllerType CtrlType
        {
            get
            {
               return ControllerType.Click;
            }
        }

        private Coroutine waitCoroutine;
        [HideInInspector]
        public UnityEvent onMouseDown;
        [HideInInspector]
        public UnityEvent onMouseEnter;
        [HideInInspector]
        public UnityEvent onMouseExit;

        protected override void Start(){
            base.Start();
            InitLayer();
        }
        private void InitLayer()
        {
            GetComponentInChildren<Collider>().gameObject.layer = Layers.clickItemLayer;
        }

        public override void OnStartExecute(bool auto = false)
        {
            base.OnStartExecute(auto);
            if (auto){
                if (waitCoroutine == null)
                {
                    StartCoroutine(WaitClose());
                }
            }
        }
        IEnumerator WaitClose()
        {
            yield return new WaitForSeconds(autoCompleteTime);
            OnEndExecute(false);
        }
        public override void OnEndExecute(bool force)
        {
            base.OnEndExecute(force);
            if (auto && waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
                waitCoroutine = null;
            }
        }
        public override void OnUnDoExecute()
        {
            base.OnUnDoExecute();
            if (auto && waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
                waitCoroutine = null;
            }
        }
        
        public void OnMouseDown()
        {
            onMouseDown.Invoke();
        }
        public void OnMouseEnter()
        {
            onMouseEnter.Invoke();
        }
        public void OnMouseExit()
        {
            onMouseExit.Invoke();
        }
    }

}