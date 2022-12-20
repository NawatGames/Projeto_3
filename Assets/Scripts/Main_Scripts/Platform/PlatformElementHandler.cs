using System;
using ElementSystem;
using UnityEngine;

namespace Main_Scripts.Platform {
    public class PlatformElementHandler : MonoBehaviour {
        private ElementSO _platformElement;

        public void Inialize(ElementSO element) {
            _platformElement = element;
            print($"Inicializada com o elemento: {_platformElement.name}");

            foreach (var itemElement in _platformElement.PlatformBehavioursArray) {
                itemElement.StartBehaviour(gameObject);
            }
            
        }

        private void Update() {   
            foreach (var itemElement in _platformElement.PlatformBehavioursArray) {
                itemElement.UpdateBehaviour(gameObject);
            }
        }


        private void OnCollisionEnter2D(Collision2D col) {
            foreach (var itemElement in _platformElement.PlatformBehavioursArray) {
                itemElement.OnCollisionEventResponse(gameObject, col);
            }
        }
    }
}