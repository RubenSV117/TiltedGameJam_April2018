using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

public class ChaseAction : FsmStateAction {
    public FsmOwnerDefault gameObject;
    private JalepenoEntity jalepeno;

    public override void Awake() {
        jalepeno = Fsm.GameObject.GetComponent<JalepenoEntity>();
    }

    public override void OnUpdate() {
        Move();
        Finish();
    }

    private void Move() {
        jalepeno.ChasePlayer();
    }
}
