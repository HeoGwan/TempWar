using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TempWar
{
    public class Weapon : MonoBehaviour
    {
        public virtual void Action() {}
        public virtual void Action(Vector3 forward) {}
    }
}