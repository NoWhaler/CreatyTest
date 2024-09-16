using Game.Dropdown.Model;
using Game.Dropdown.Presenter;
using Game.Dropdown.View;
using Game.DropdownFurniture.Model;
using Game.DropdownFurniture.Presenter;
using Game.DropdownFurniture.View;
using Game.FurnitureSelector;
using Game.FurnitureSelector.View;
using Game.Widgets.Model;
using Game.Widgets.Presenter;
using Game.Widgets.View;
using UnityEngine;

namespace Core.GameEntryPoint
{
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField] private DropdownView _dropdownView;

        [SerializeField] private WidgetsPanelView _widgetsPanelView;

        [SerializeField] private DropdownFurnitureView[] _furnitureViews;

        [SerializeField] private FurnitureSelectorView _furnitureSelectorView;
        
        private void Awake()
        {
            InitWidgetButtons();
            InitDropDown();
            InitFurnitureViews();
        }

        private void InitDropDown()
        {
            DropdownModel dropdownModel = new DropdownModel(_dropdownView);
            DropdownPresenter dropdownPresenter = new DropdownPresenter(dropdownModel);

            _dropdownView.Init(dropdownPresenter);
        }

        private void InitWidgetButtons()
        {
            WidgetsPanelModel widgetsPanelModel = new WidgetsPanelModel(_widgetsPanelView);
            WidgetsPanelPresenter widgetsPanelPresenter = new WidgetsPanelPresenter(widgetsPanelModel);
            
            _widgetsPanelView.Init(widgetsPanelPresenter);
            FurnitureSelectorService.WidgetsPanelView = _widgetsPanelView;
        }

        private void InitFurnitureViews()
        {
            foreach (var furnitureView in _furnitureViews)
            {
                DropdownFurnitureModel dropdownFurnitureModel = new DropdownFurnitureModel(_furnitureSelectorView, furnitureView);
                DropdownFurniturePresenter dropdownFurniturePresenter = new DropdownFurniturePresenter(dropdownFurnitureModel);
                
                furnitureView.Init(dropdownFurniturePresenter);
            }
        }
    }
}