using System;
using UnityEngine;

namespace Progressbars
{
    public abstract class Progressbar : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] protected float fillAmount;
        [HideInInspector]
        [SerializeField] protected float _fillAmount;

        public Action<float> OnValueUpdate = (progress) => { };

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public abstract void SetValue(float value);

        protected virtual void OnValidate()
        {
            if (_fillAmount != fillAmount)
            {
                _fillAmount = fillAmount;
                SetValue(_fillAmount);
            }
        }
    }
}