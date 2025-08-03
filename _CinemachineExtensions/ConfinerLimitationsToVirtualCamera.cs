using UnityEngine;
using Unity.Cinemachine;

namespace ThreeDent.DevelopmentTools.CinemachineExtensions
{
    [SaveDuringPlay, AddComponentMenu("")]
    public class ConfinerLimitationsToVirtualCamera : CinemachineExtension
    {
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Finalize)
            {
                state.RawPosition = state.GetCorrectedPosition();
                state.PositionCorrection = Vector3.zero;
                state.RawOrientation = state.GetCorrectedOrientation();
                state.OrientationCorrection = Quaternion.identity;
            }
        }
    }
}