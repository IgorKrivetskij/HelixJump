using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeamBuilder : MonoBehaviour
{
    [SerializeField] private BeamPart _startBeamPart;
    [SerializeField] private BeamPart _beamPart;
    [SerializeField] private int _maxBeamParts;
    public UnityAction GetBonusTime;
    private int _startBeamPartsCount = 4;
    private int _beamPartUpBall;
    private Vector3 _beamPartsOffset;
    private List<BeamPart> _beam = new List<BeamPart>();
    
    private void Awake()
    {
        _beamPartUpBall = 0;
        _beamPartsOffset = _beamPart.DownPosition.localPosition - _beamPart.UpPosition.localPosition;
        BuildStartBeam();
    }

    private void BuildStartBeam()
    {
        BuildBeamPart(_startBeamPart, Vector3.zero);
        for (int i = 0; i < _startBeamPartsCount; i++)
        {
            BuildBeamPart(_beamPart, CalculateBeamPartSpawnPosition());
        }
    }

    private Vector3 CalculateBeamPartSpawnPosition()
    {
        return _beam[_beam.Count - 1].transform.position + _beamPartsOffset;
    }

    private void BuildBeamPart(BeamPart _beamPart, Vector3 spawnPosition)
    {
        BeamPart beamPartTmp;
        beamPartTmp = Instantiate(_beamPart, transform);
        beamPartTmp.transform.position = spawnPosition; 
        _beam.Add(beamPartTmp);
    }

    public void OnPlatformDestroy()
    {
        GetBonusTime?.Invoke();
    }

    private void DestroyBuilPart()
    {
        Destroy(_beam[0].gameObject);
        _beam.RemoveAt(0);
    }

    public void BuildAndDestroyBeamParts()
    {
        if(++_beamPartUpBall == 3)
        {
            BuildBeamPart(_beamPart, CalculateBeamPartSpawnPosition());
            DestroyBuilPart();
            _beamPartUpBall--;
        }
    }
}
