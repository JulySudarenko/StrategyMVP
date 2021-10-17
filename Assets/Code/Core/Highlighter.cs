using System.Linq;
using Interfaces;
using UnityEngine;

public class Highlighter : MonoBehaviour, IHighlightable
{
    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private Material _highlightMaterial;
    [SerializeField] private GameObject _highlightCircle;
    [SerializeField] private bool _isOutlined;
    [SerializeField] private bool _isHighlighted;
    private bool _isSelectedActual;

    public void HighlightSelectedObject(bool isSelected)
    {
        if (this == null)
        {
            return;
        }
        
        if (_isSelectedActual == isSelected)
        {
            return;
        }

        if (_isHighlighted)
        {
            MakeHighlighted(isSelected);
        }

        if (_isOutlined)
        {
            MakeOutlined(isSelected);
        }
        
        _isSelectedActual = isSelected;
    }

    private void MakeHighlighted(bool isSelected)
    {
        if (isSelected)
        {
            _highlightCircle.SetActive(true);
        }
        else
        {
            _highlightCircle.SetActive(false);
        }
    }

    private void MakeOutlined(bool isSelected)
    {
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
    }
}