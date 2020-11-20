using System;
using UnityEngine;

namespace Vagonetka
{
    public class CustomSnapPoint : MonoBehaviour
    {
        public enum ConnectionType
        {
            Road
        }

        public ConnectionType Type;

        private void OnDrawGizmos()
        {
            switch (Type)
            {
                case ConnectionType.Road:
                    Gizmos.color = Color.green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 1.0f);
        }
    }
}