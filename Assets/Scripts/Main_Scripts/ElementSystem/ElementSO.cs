using Main_Scripts.Platform.PlatformBehaviours;
using UnityEngine;

namespace Main_Scripts.ElementSystem {
    public class ElementSO : ScriptableObject {
        public BaseBehaviourSO[] PlatformBehavioursArray;
        public Sprite platformInitialSprite;
        public Sprite bulletSprite;
        public ElementSO elementToLoseFor;
        public RuntimeAnimatorController animatorController;
        public int elementSpawnIndex;
    }
}