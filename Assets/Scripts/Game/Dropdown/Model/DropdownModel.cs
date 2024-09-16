using DG.Tweening;
using Game.Dropdown.View;

namespace Game.Dropdown.Model
{
    public class DropdownModel
    {
        private DropdownView _dropdownView;

        private float CurrentScrollBarValue;

        private const float MIN_VALUE = 0f;

        private const float MAX_VALUE = 1f;
        
        private const float TRANSITION_DURATION = 0.25f;

        public DropdownModel(DropdownView dropdownView)
        {
            _dropdownView = dropdownView;
            CurrentScrollBarValue = _dropdownView.CurrentScrollbarValue();
        }

        public void MoveUp()
        {
            var newValue = _dropdownView.CurrentScrollbarValue() + MAX_VALUE / _dropdownView.FurnitureTypesCount() * 2.5f;
            
            if (newValue > MAX_VALUE)
            {
                newValue = MAX_VALUE;
            }

            DOTween.To(() => CurrentScrollBarValue, x => {
                CurrentScrollBarValue = x;
                _dropdownView.SetScrollBarValue(CurrentScrollBarValue);
            }, newValue, TRANSITION_DURATION);
        }

        public void MoveDown()
        {
            var newValue = _dropdownView.CurrentScrollbarValue() - MAX_VALUE / _dropdownView.FurnitureTypesCount() * 2.5f;
            
            if (newValue < MIN_VALUE)
            {
                newValue = MIN_VALUE;
            }

            DOTween.To(() => CurrentScrollBarValue, x => {
                CurrentScrollBarValue = x;
                _dropdownView.SetScrollBarValue(CurrentScrollBarValue);
            }, newValue, TRANSITION_DURATION);
        }

        public void SetValue()
        {
            CurrentScrollBarValue = _dropdownView.CurrentScrollbarValue();
        }
    }
}