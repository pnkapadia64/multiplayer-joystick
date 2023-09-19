using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerUI : MonoBehaviour
{
    public GameObject UI;
    private RealtimeView _realtimeView;

    void Start()
    {
        _realtimeView = GetComponent<RealtimeView>();

        if (_realtimeView.isOwnedLocallyInHierarchy)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }
    }

}
