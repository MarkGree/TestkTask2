using UnityEngine;
using UnityEngine.UI;

namespace Progressbars
{
    public class ProgressbarImage : Progressbar
    {
        [SerializeField] private Image image;

        public override void SetValue(float value)
        {
            fillAmount = value;
            _fillAmount = value;

            image.fillAmount = value;
            OnValueUpdate.Invoke(value);
        }
    }
}