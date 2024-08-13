using System.Collections;
using System.Collections.Generic;
using TempWar;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private Weapon m_weapon;

    void Update()
    {
        if (Input.GetMouseButton(InputButton.LEFT_MOUSE_BUTTON))
        {
            m_weapon.Action(transform.forward);
        }
    }
}
