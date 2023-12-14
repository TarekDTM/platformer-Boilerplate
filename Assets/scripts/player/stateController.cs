using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public interface ICharachterState
    {
        public void onEnter();
        public void UpdateState();

        public void onExit();

    }
public class stateController : MonoBehaviour
{


    ICharachterState currentState;

    public walkState walkState = new walkState();
    public jumpState jumpState = new jumpState(); 
    
    public void changeState(ICharachterState newState ) {
        currentState.onExit();    
        currentState = newState;
        currentState.onEnter();
    
    }
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
}
