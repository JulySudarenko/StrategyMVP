using System.Linq;
using Interfaces;
using UnityEngine;

public class Highlighter : MonoBehaviour//, IHighlightable
{
    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private Material _highlightMaterial;
    [SerializeField] private GameObject _highlightCircle;
    //[SerializeField] private bool _isTestSelected;

    private bool _isSelectedActual;
    
    // private void Update()
    // {
    //     HighlightSelectedObject(_isTestSelected);
    // }

    public void HighlightSelectedObject(bool isSelected)
    {
        if (_isSelectedActual == isSelected)
        {
            return;
        }

        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            var renderer = _meshRenderers[i];
            var allMaterials = renderer.materials.ToList();
            if (isSelected)
            {
                _highlightCircle.SetActive(true);
                allMaterials.Add(_highlightMaterial);
            }
            else
            {
                _highlightCircle.SetActive(false);
                allMaterials.RemoveAt(allMaterials.Count - 1);
            }

            _meshRenderers[i].materials = allMaterials.ToArray();
        }

        _isSelectedActual = isSelected;
    }
}
