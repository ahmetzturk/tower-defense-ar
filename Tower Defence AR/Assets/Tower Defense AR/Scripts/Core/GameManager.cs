using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private GameObject baseObject;

        private Button[] buttons;
        bool isWinEditor = Application.platform == RuntimePlatform.WindowsEditor;

        public static GameManager Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
                return instance;
            }
        }

        public GameObject BaseObject { get => baseObject; }

        private void Awake()
        {
            buttons = FindObjectsOfType<Button>();
        }       

        private void Start()
        {
            baseObject = GameObject.FindWithTag("Base");
            if (!isWinEditor)
            {
                SetPassiveAllButtons();
            }
        }

        private void OnEnable()
        {
            instance = this;
            PlaceObjectsOnPlane.onPlacedObject += SetActiveAllButtons;
        }

        private void OnDisable()
        {
            PlaceObjectsOnPlane.onPlacedObject -= SetActiveAllButtons;
        }

        public void SetActiveAllBaseScripts()
        {
            MonoBehaviour[] scripts = baseObject.GetComponents<MonoBehaviour>();
            // disables base scripts (lean touch)
            foreach (var script in scripts)
            {
                script.enabled = true;
            }
        }

        public void SetPassiveAllBaseScripts()
        {
            MonoBehaviour[] scripts = baseObject.GetComponents<MonoBehaviour>();
            // disables base scripts (lean touch)
            foreach (var script in scripts)
            {
                script.enabled = false;
            }
        }

        // enables all buttons
        public void SetActiveAllButtons()
        {
            foreach (var button in buttons)
            {
                button.enabled = true;
            }
        }

        public void SetPassiveAllButtons()
        {
            foreach (var button in buttons)
            {
                button.enabled = false;
            }
        }
    }
}
