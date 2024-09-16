using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.FurnitureSelector.View
{
    public class FurnitureSelectorView: MonoBehaviour
    {
        [field: SerializeField] public List<FurnitureSlotView> FurnitureSlots { get; set; }
        
        [field: SerializeField] public GameObject SelectorScrollView { get; private set; }

        public Image CurrentSelectedFurniture { get; set; }

        private void Start()
        {
            FurnitureSlots = GetComponentsInChildren<FurnitureSlotView>().ToList();
        }
    }
}