using Game.DropdownFurniture.Enum;
using Game.FurnitureSelector;
using UnityEngine;

namespace Game.Furniture
{
    public class FurnitureModel: MonoBehaviour
    {
        [SerializeField] private FurnitureType _furnitureType;
        
        [field: SerializeField] public Sprite FurnitureSprite { get; set; }

        public FurnitureType FurnitureType => _furnitureType;
        
        public Vector3 InitialPosition => transform.position;

        public Quaternion InitialRotation => transform.rotation;

        private void OnMouseDown()
        {
            FurnitureSelectorService.WidgetsPanelView.SetFurnitureSelector();
            FurnitureSelectorService.CurrentActiveFurniture = this;
            FurnitureSelectorService.ChooseFurniture(_furnitureType);
        }
    }
}