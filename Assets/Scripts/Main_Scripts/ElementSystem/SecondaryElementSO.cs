using Main_Scripts.ElementSystem;
using UnityEngine;

namespace ElementSystem {
    [CreateAssetMenu(fileName = "new Secondary Element", menuName = "Secondary Element")]
    public class SecondaryElementSO : ElementSO {
        //Aqui teremos os sprites de plataforma e os comportamentos que elas terao de acordo com o elemento
        
        public ElementSO[] _primeElementsComposerArray;
    }
}