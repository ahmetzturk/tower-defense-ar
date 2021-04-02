using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Manager
{
    public class GameManager : MonoBehaviour
    {
        static Button[] buttons;
        bool isWinEditor = Application.platform == RuntimePlatform.WindowsEditor;


        private void Awake()
        {
            buttons = GameObject.FindObjectsOfType<Button>();
        }

        private void Start()
        {
            if (!isWinEditor)
            {
                SetPassiveAll();
            }
        }

        private void OnEnable()
        {
            PlaceObjectsOnPlane.onPlacedObject += SetActiveAll;
        }

        private void OnDisable()
        {
            PlaceObjectsOnPlane.onPlacedObject -= SetActiveAll;
        }

        public static void SetActiveAll()
        {
            foreach (var button in buttons)
            {
                button.enabled = true;

            }
        }

        public static void SetPassiveAll()
        {
            foreach (var button in buttons)
            {
                button.enabled = false;

            }
        }


    }
}
