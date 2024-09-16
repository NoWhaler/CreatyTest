using System.Collections.Generic;
using Game.Dropdown.Presenter;
using Game.DropdownFurniture.View;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Dropdown.View
{
    public class DropdownView : MonoBehaviour
    {
        private DropdownPresenter _dropdownPresenter;

        [SerializeField] private Scrollbar _scrollbar;

        [SerializeField] private List<DropdownFurnitureView> _dropdownFurnitureButtons;

        [SerializeField] private Button _arrowUpbutton;

        [SerializeField] private Button _arrowDownButton;

        
        private void Start()
        {
            _arrowUpbutton.onClick.AddListener(() => _dropdownPresenter.MoveScrollbarUp());
            _arrowDownButton.onClick.AddListener(() => _dropdownPresenter.MoveScrollbarDown());
        }

        private void Update()
        {
            _dropdownPresenter.SetCurrentScrollBarValue();
        }

        public void Init(DropdownPresenter dropdownPresenter)
        {
            _dropdownPresenter = dropdownPresenter;
        }

        public float CurrentScrollbarValue()
        {
            return _scrollbar.value;
        }

        public void SetScrollBarValue(float value)
        {
            _scrollbar.value = value;
        }

        public int FurnitureTypesCount()
        {
            return _dropdownFurnitureButtons.Count;
        }
    }
}