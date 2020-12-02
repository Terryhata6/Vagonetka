using UnityEngine;
using UnityEngine.UI;


namespace Vagonetka
{
    public class SliderUI : MonoBehaviour
    {
        private Slider _slider;

        public Slider GetControl()
        {
            if (!_slider)
            {
                _slider = gameObject.GetComponent<Slider>();
            }
            return _slider;
        }
    }
}
