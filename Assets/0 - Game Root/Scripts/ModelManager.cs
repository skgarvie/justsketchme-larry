using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour {


    [SerializeField] private Vector3 m_SpawnPosition;
    [Header("Prefabs")]
    [SerializeField] private GameObject m_MannequinPrefab;
    [SerializeField] private GameObject m_FemalePrefab;
    [SerializeField] private GameObject m_MalePrefab;

    private GameObject _currentSpawnedModel;
    private GameObject _mannequinModel;
    private GameObject _femaleModel;
    private GameObject _maleModel;

    public void Awake()
    {
        SwitchToFemale();
    }

    void Start () {
		
	}


    void Update () {
		
	}

    public void SwitchToMannequin()
    {
        if(!_mannequinModel)
        {
            _mannequinModel = Instantiate(m_MannequinPrefab);
            _mannequinModel.transform.position = m_SpawnPosition;
        }

        if(_currentSpawnedModel)
            _currentSpawnedModel.SetActive(false);

        _mannequinModel.SetActive(true);
        _currentSpawnedModel = _mannequinModel;
    }

    public void SwitchToFemale()
    {
        if (!_femaleModel)
        {
            _femaleModel = Instantiate(m_FemalePrefab);
            _femaleModel.transform.position = m_SpawnPosition;
        }

        if(_currentSpawnedModel)
            _currentSpawnedModel.SetActive(false);

        _femaleModel.SetActive(true);
        _currentSpawnedModel = _femaleModel;
    }

    public void SwitchToMale()
    {
        if (!_maleModel)
        {
            _maleModel = Instantiate(m_MalePrefab);
            _maleModel.transform.position = m_SpawnPosition;
        }

        if (_currentSpawnedModel)
            _currentSpawnedModel.SetActive(false);

        _maleModel.SetActive(true);
        _currentSpawnedModel = _maleModel;
    }

}
