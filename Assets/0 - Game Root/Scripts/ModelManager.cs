using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour {


    [SerializeField] private Vector3 m_SpawnPosition;
    [Header("Prefabs")]
    [SerializeField] private GameObject m_MannequinPrefab;
    [SerializeField] private GameObject m_FemalePrefab;
    [SerializeField] private GameObject m_MalePrefab;

    private enum modelTypes {male, female, mannequin, nun};

    private GameObject _currentSpawnedModel;
    private modelTypes _currentModelType = modelTypes.nun;
    private GameObject _mannequinModel;
    private GameObject _femaleModel;
    private GameObject _maleModel;



    private bool _showingJoints = true;

    public void Awake()
    {
        SwitchToFemale();
    }

    void Start () {

	}


    void Update () {

	}

    public void SwitchToMannequin(bool reset = false)
    {
        if(!_mannequinModel || reset)
        {
            _mannequinModel = Instantiate(m_MannequinPrefab);
            _mannequinModel.transform.position = m_SpawnPosition;
        }

        if(_currentSpawnedModel)
            _currentSpawnedModel.SetActive(false);

        _mannequinModel.SetActive(true);
        _currentSpawnedModel = _mannequinModel;
        _currentModelType = modelTypes.mannequin;
        UpdateHighlightJoints();
    }

    public void SwitchToFemale(bool reset = false)
    {
        if (!_femaleModel || reset)
        {
            _femaleModel = Instantiate(m_FemalePrefab);
            _femaleModel.transform.position = m_SpawnPosition;
        }

        if(_currentSpawnedModel)
            _currentSpawnedModel.SetActive(false);

        _femaleModel.SetActive(true);
        _currentSpawnedModel = _femaleModel;
        _currentModelType = modelTypes.female;
        UpdateHighlightJoints();
    }

    public void SwitchToMale(bool reset = false)
    {
        if (!_maleModel || reset)
        {
            _maleModel = Instantiate(m_MalePrefab);
            _maleModel.transform.position = m_SpawnPosition;
        }

        if (_currentSpawnedModel)
            _currentSpawnedModel.SetActive(false);

        _maleModel.SetActive(true);
        _currentSpawnedModel = _maleModel;
        _currentModelType = modelTypes.male;
        UpdateHighlightJoints();
    }

    public void mekGud () {
      var wut = _currentSpawnedModel;
      Destroy(_currentSpawnedModel);

      switch (_currentModelType) {
        case modelTypes.female:
          SwitchToFemale(true);
          break;
        case modelTypes.male:
          SwitchToMale(true);
          break;
        case modelTypes.mannequin:
          SwitchToMannequin(true);
          break;
      }
    }

    public void ToggleHighlightedJoints()
    {
        _showingJoints = !_showingJoints;
        UpdateHighlightJoints();
    }

    private void UpdateHighlightJoints()
    {
        var joints = _currentSpawnedModel.GetComponentsInChildren<InteractionGizmo>();
        foreach (var joint in joints)
        {
            joint.ToggleHighlighter(_showingJoints);
        }
    }

}
