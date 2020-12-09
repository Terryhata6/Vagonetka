using UnityEngine;


namespace Vagonetka
{
    public class PlayerModel : MonoBehaviour
    {
        public bool IsMoving;
        public bool IsRotateRight;
        public bool IsRotateLeft;

        public void AlignByX(float xCoordinate)
        {
            transform.position = new Vector3(xCoordinate, transform.position.y, transform.position.z);
        }
        public void AlignByZ(float zCoordinate)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zCoordinate);
        }
        public void StartLevel()
        {
            IsRotateLeft = false;
            IsRotateRight = false;
            IsMoving = true;
        }
    }
}