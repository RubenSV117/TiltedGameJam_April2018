using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class ExplodeAction : FsmStateAction {
    public FsmOwnerDefault gameObject;
    private Explosive explosive;

    public override void Awake() {
        explosive = Fsm.GetOwnerDefaultTarget(gameObject).GetComponentInChildren<Explosive>();
    }

    public override void OnEnter() {
        Attack();
    }

    public override void OnUpdate() {

    }

    public void Attack() {
        if (explosive) {
            explosive.Explode();
        }
    }
}
