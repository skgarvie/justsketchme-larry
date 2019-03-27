using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManager : MonoBehaviour {


    [SerializeField] private Vector3 m_SpawnPosition;
    [Header("Prefabs")]
    [SerializeField] List<GameObject> models;
    [SerializeField] Transform grid;

    private GameObject _currentSpawnedModel;
   
    private GameObject _mannequinModel;
    private GameObject _femaleModel;
    private GameObject _maleModel;
    private GameObject _robotModel;

    public List<List<Quaternion>> _previousSteps = new List <List <Quaternion>>();

    private bool _showingJoints = true;

    public void Awake()
    {
        foreach(GameObject model in models)
        {
            GameObject button = new GameObject(model.name);
            button.AddComponent<Image>().sprite = model.GetComponent<Model>().buttonSprite;
            button.AddComponent<Button>().onClick.AddListener(() => SwitchTo(model.name));
            button.transform.parent = grid;

        }
    }

    void Start()
    {
        SwitchTo(models[0].name);
    }

    public void SwitchTo(string name)
    {
        foreach(GameObject model in models)
        {
            if(model.name == name)
            {
                Debug.Log(name + " " + model.name);
                Destroy(_currentSpawnedModel);
                _currentSpawnedModel = Instantiate(model);
                _currentSpawnedModel.name = name;
                _currentSpawnedModel.transform.position = m_SpawnPosition;
            }
        }

        UpdateHighlightJoints();
    }

    public void Reset()
    {
        SwitchTo(_currentSpawnedModel.name);
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

    public void StoreState() {
        List<Quaternion> _localRotations = new List<Quaternion>();
        foreach (Transform trns in _currentSpawnedModel.GetComponentsInChildren<Transform>()) {
            _localRotations.Add(trns.localRotation);
        }
        _previousSteps.Add(_localRotations);
    }

    public void Undo() {
        if (_previousSteps.Count > 0)
        {
            int i = 0;
            foreach (Transform trns in _currentSpawnedModel.GetComponentsInChildren<Transform>())
            {
                trns.localRotation = _previousSteps[_previousSteps.Count - 1][i];
                i++;
            }
            _previousSteps.RemoveAt(_previousSteps.Count - 1);
        }
    }
}
