using System.Linq;
using Game.DropdownFurniture.View;
using Game.FurnitureSelector.View;
using UnityEngine.UI;

namespace Game.DropdownFurniture.Model
{
    public class DropdownFurnitureModel
    {
        private FurnitureSelectorView _furnitureSelectorView;

        private DropdownFurnitureView _dropdownFurnitureView;

        private Image _currentActiveImage;

        public DropdownFurnitureModel(FurnitureSelectorView furnitureSelectorView, DropdownFurnitureView dropdownFurnitureView)
        {
            _furnitureSelectorView = furnitureSelectorView;
            _dropdownFurnitureView = dropdownFurnitureView;
        }

        public void RefreshFurnitureSelector()
        {
            ClearSlots();
            
            _furnitureSelectorView.SelectorScrollView.SetActive(true);
            
            if (_furnitureSelectorView.CurrentSelectedFurniture != null)
            {
                _furnitureSelectorView.CurrentSelectedFurniture.enabled = false;
            }

            _furnitureSelectorView.CurrentSelectedFurniture = _dropdownFurnitureView.GetImage();
            _dropdownFurnitureView.ActivateImage();

            var counter = 0;
            
            foreach (var furnitureView in _furnitureSelectorView.FurnitureSlots.TakeWhile(_ => counter < _dropdownFurnitureView.FurnitureTypeCount()))
            {
                furnitureView.FurniturePrefab = _dropdownFurnitureView.GetFurnitureModel(counter);
                furnitureView.SetFurnitureImage(furnitureView.FurniturePrefab.FurnitureSprite, true);
                counter++;
            }
        }

        private void ClearSlots()
        {
            foreach (var furnitureSlot in _furnitureSelectorView.FurnitureSlots)
            {
                furnitureSlot.SetFurnitureImage(null, false);
            }
        }
    }
}