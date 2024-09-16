using System;
using Game.DropdownFurniture.Enum;
using Game.Furniture;
using Game.Widgets.View;

namespace Game.FurnitureSelector
{
    public static class FurnitureSelectorService
    {
        public static FurnitureModel CurrentActiveFurniture;

        public static WidgetsPanelView WidgetsPanelView;

        public static event Action<FurnitureType> OnChooseFurniture;

        public static void ChooseFurniture(FurnitureType furnitureType)
        {
            OnChooseFurniture?.Invoke(furnitureType);
        }
    }
}