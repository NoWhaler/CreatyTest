using Game.Furniture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.FurnitureSelector.View
{
    public class FurnitureSlotView: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _furnitureImage;

        [SerializeField] private TMP_Text _furnitureName;

        [field: SerializeField] public FurnitureModel FurniturePrefab { get; set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            if (FurnitureSelectorService.CurrentActiveFurniture == null) return;
            if (!IsFurnitureTypeSimilar()) return;
            
            var newFurniture = Instantiate(FurniturePrefab,
                FurnitureSelectorService.CurrentActiveFurniture.InitialPosition,
                FurnitureSelectorService.CurrentActiveFurniture.InitialRotation);
            Destroy(FurnitureSelectorService.CurrentActiveFurniture.gameObject);
            FurnitureSelectorService.CurrentActiveFurniture = null;
            FurnitureSelectorService.CurrentActiveFurniture = newFurniture;
        }

        public void SetFurnitureName(string furnitureName)
        {
            _furnitureName.text = furnitureName;
        }

        public void SetFurnitureImage(Sprite furnitureSprite, bool imageActiveState)
        {
            _furnitureImage.enabled = imageActiveState;
            _furnitureImage.sprite = furnitureSprite;
        }

        public bool IsFurnitureTypeSimilar()
        {
            return FurnitureSelectorService.CurrentActiveFurniture.FurnitureType == FurniturePrefab.FurnitureType;
        }
    }
}