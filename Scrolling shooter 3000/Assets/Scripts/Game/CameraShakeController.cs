using UnityEngine;
using Cinemachine;

public class CameraShakeController : MonoBehaviour
{
    public static CameraShakeController Instance { get; private set; }

    CinemachineVirtualCamera _virtualCamera;
    CinemachineBasicMultiChannelPerlin _perlin;
    float _shakeTimer;

    private void Awake()
    {
        Instance = this;

        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _perlin = _virtualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        _perlin.m_AmplitudeGain = intensity;
        _shakeTimer = time;
    }

    private void Update()
    {
        if (_shakeTimer <= 0) { _perlin.m_AmplitudeGain = 0f; }
        else if (_shakeTimer > 0) { _shakeTimer -= Time.deltaTime; }
    }
}
