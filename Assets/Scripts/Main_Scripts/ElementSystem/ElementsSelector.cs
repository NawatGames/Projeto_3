using ElementSystem;
using EventSystem.SimpleEvents;
using Main_Scripts.SingletonsSO;
using UnityEngine;

namespace Main_Scripts.ElementSystem {
    [RequireComponent(typeof(ElementGeneratorMonoBehaviour))]
    public class ElementsSelector : MonoBehaviour {
        [SerializeField] private IntegerEvent eventToListen;
        [SerializeField] private ElementSelectedSingleton elementSelectedSingleton;

        private ElementGeneratorMonoBehaviour _generatorMonoBehaviour;
        private ElementSO[] _currentPrimesSelectedArray = new ElementSO[2];
        private ElementSO _currentElementSelected;

        private void Awake() {
            _generatorMonoBehaviour = GetComponent<ElementGeneratorMonoBehaviour>();
        }
        
        private void OnEnable() {
            eventToListen.SubscribeUnityEvent(SelectElementFromIndex);
        }

        private void OnDisable() {
            eventToListen.UnsubscribeUnityEvent(SelectElementFromIndex);
        }

        public void CleanSelectedArray() {
            _currentPrimesSelectedArray[0] = null;
            _currentPrimesSelectedArray[1] = null;
        }
        
        public void SelectElementFromIndex(int inputIndex) {
            var index = inputIndex - 1;
            if(index >= _generatorMonoBehaviour.AllPrimeElementsArray.Length)
                return;

            if (_currentPrimesSelectedArray[0] == null) {
                var primeElementSelected = _generatorMonoBehaviour.AllPrimeElementsArray[index];
                _currentElementSelected = primeElementSelected;
                _currentPrimesSelectedArray[0] = primeElementSelected;
                elementSelectedSingleton.Value = _currentElementSelected;

                return;
            }

            if (_currentPrimesSelectedArray[0] != null && _currentPrimesSelectedArray[1] == null) {
                _currentPrimesSelectedArray[1] = _generatorMonoBehaviour.AllPrimeElementsArray[index];

               var elementCreated = _generatorMonoBehaviour.CreateAElement(ref _currentPrimesSelectedArray);
               if (elementCreated == null) {
                   _currentElementSelected = _currentPrimesSelectedArray[1];
                   CleanSelectedArray();
                   _currentPrimesSelectedArray[0] = _currentElementSelected;
                   elementSelectedSingleton.Value = _currentElementSelected;
                   return;
               }

               _currentElementSelected = elementCreated;
               CleanSelectedArray();
               _currentPrimesSelectedArray[0] = elementCreated;
               elementSelectedSingleton.Value = _currentElementSelected;
            }

        }


    }
}