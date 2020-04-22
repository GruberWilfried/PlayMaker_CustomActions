using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Math)]
    [Tooltip("Remaps a value from one range to another")]
    public class RemapValue : FsmStateAction
    {
        [RequiredField]
        [Tooltip("Min Value of Range From")]
        public FsmFloat fromMin;

        [RequiredField]
        [Tooltip("Max Value of Range From")]
        public FsmFloat fromMax;

        [RequiredField]
        [Tooltip("Min Value of Range To")]
        public FsmFloat toMin;

        [RequiredField]
        [Tooltip("Max Value of Range To")]
        public FsmFloat toMax;


        [RequiredField]
        [Tooltip("Value to Remap")]
        public FsmFloat value;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the result in this float variable.")]
        public FsmFloat storeResult;

        [Tooltip("Repeat every frame. Useful if any of the values are changing.")]
        public bool everyFrame;

        public override void Reset()
        {
            storeResult = null;
            everyFrame = true;
        }

        public override void OnEnter()
        {
            DoRemap();

            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoRemap();
        }

        void DoRemap()
        {
            float val = Mathf.InverseLerp(fromMin.Value, fromMax.Value, value.Value);
            storeResult.Value = Mathf.Lerp(toMin.Value, toMax.Value, val);
        }
    }
}
