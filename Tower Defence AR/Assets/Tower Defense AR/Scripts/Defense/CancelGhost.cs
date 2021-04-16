using System.Collections;
using System.Collections.Generic;
using TowerDefense.Core;
using UnityEngine;

namespace TowerDefense.Defense
{
    public class CancelGhost : MonoBehaviour
    {
        public void CancelGhostObject()
        {
            Ghost ghost = FindObjectOfType<Ghost>();
            Destroy(ghost.gameObject);
            // enables all buttons again
            GameManager.Instance.SetActiveAllButtons();
            SetPassive();
        }

        public void SetPassive()
        {
            gameObject.SetActive(false);
        }
    }
}
