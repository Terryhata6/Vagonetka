using UnityEngine;


namespace Vagonetka
{
    public class DoorCloseTrigger : MonoBehaviour
    {
        private string _open = "Open";

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerModel>())
            {
                transform.parent.GetComponentInChildren<Animator>().SetBool(_open, false);
            }
        }
    }
}
