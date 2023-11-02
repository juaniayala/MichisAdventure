using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraZoomOut : MonoBehaviour
{
    public KeyCode zoomOutKey;

    CinemachineVirtualCamera cineCam;

    [SerializeField, Range(0f, 3f)] float transitionDuration = 1f;
    [SerializeField] bool isTransitioning = false;
    [SerializeField] float timer = 0f;

    private Move chMove;

    public float zoomOutValue = 13;

    public float zoomInValue = 9;

    float targetSize;
    // Start is called before the first frame update
    void Start()
    {
        cineCam = GetComponent<CinemachineVirtualCamera>();
        chMove = GameObject.Find("Character").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chMove.getMove())
        {
            if (Input.GetKeyDown(zoomOutKey))
            {
                startTransition(zoomOutValue);
            }
            else if (Input.GetKeyUp(zoomOutKey))
            {
                startTransition(zoomInValue);
            }

            if (isTransitioning)
            {
                timer += Time.deltaTime;
                float t = Mathf.Clamp01(timer / transitionDuration);
                zoomTransitioning(targetSize, t);
                if (t >= 1.0f)
                {
                    isTransitioning = false;
                }
            }
        }
    }
        
    void startTransition(float target)
    {
        targetSize = target;
        timer = 0;
        isTransitioning = true;
    }

    void zoomTransitioning(float value, float time)
    {
        float actualValue = cineCam.m_Lens.OrthographicSize;
        cineCam.m_Lens.OrthographicSize = Mathf.Lerp(actualValue, value, time);
    }
}
