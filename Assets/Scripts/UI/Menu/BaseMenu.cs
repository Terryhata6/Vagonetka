﻿using UnityEngine;


namespace Vagonetka
{
    public abstract class BaseMenu : MonoBehaviour
    {
        protected bool IsShow { get; set; }

        public abstract void Hide();
        public abstract void Show();
    }
}
