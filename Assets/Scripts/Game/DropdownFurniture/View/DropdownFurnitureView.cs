using Game.DropdownFurniture.Enum;
using Game.DropdownFurniture.Presenter;
using Game.Furniture;
using Game.FurnitureSelector;
using UnityEngine;
using UnityEngine.UI;

namespace Game.DropdownFurniture.View
{
    public class DropdownFurnitureView: MonoBehaviour
    {
        private DropdownFurniturePresenter _dropdownFurniturePresenter;
        
        [field: SerializeField] public FurnitureType FurnitureType { get; set; }

        [SerializeField] private Button _furnitureButton;

        [SerializeField] private Image _buttonHighlight;

        [SerializeField] private FurnitureModel[] _furniturePrefabs;
        
        private void Start()
        {
            _furnitureButton = GetComponent<Button>();
            _furnitureButton.onClick.AddListener(() => _dropdownFurniturePresenter.OpenFurnitureSelector());
            _furnitureButton.onClick.AddListener(() => FurnitureSelectorService.CurrentActiveFurniture = null);
        }

        private void OnEnable()
        {
            FurnitureSelectorService.OnChooseFurniture += ChooseFurnitureViaScene;
        }

        private void OnDisable()
        {
            FurnitureSelectorService.OnChooseFurniture -= ChooseFurnitureViaScene;
        }

        private void ChooseFurnitureViaScene(FurnitureType furnitureType)
        {
            if (FurnitureType == furnitureType)
            {
                _dropdownFurniturePresenter.OpenFurnitureSelector();
            }
        }

        public void Init(DropdownFurniturePresenter dropdownFurniturePresenter)
        {
            _dropdownFurniturePresenter = dropdownFurniturePresenter;
        }

        public void ActivateImage()
        {
            _buttonHighlight.enabled = true;
        }

        public Image GetImage()
        {
            return _buttonHighlight;
        }

        public int FurnitureTypeCount()
        {
            return _furniturePrefabs.Length;
        }

        public FurnitureModel GetFurnitureModel(int index)
        {
            return _furniturePrefabs[index];
        }
    }
}