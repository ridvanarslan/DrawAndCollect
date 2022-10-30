using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] [Range(1,5)] private int maxDrawAmount;
    [SerializeField] private UI uiManager;
    
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject line;
    
    [SerializeField] private EdgeCollider2D _edgeCollider;
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private List<Vector2> fingerPositionList;
    [SerializeField] private List<GameObject> createdLines;
    
    private Camera _mainKamera;
    

    private void Awake() => _mainKamera = Camera.main;

    private void Start() => uiManager.UpdateDrawAmountText(maxDrawAmount);

    void Update()
    {
        if (Time.timeScale == 0 || maxDrawAmount <= 0) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 fingerPosition = _mainKamera.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(fingerPosition,fingerPositionList[^1]) > .1f)
            {
                UpdateLine(fingerPosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            UpdateDrawAmount(-1);
        }
    }
    

    private void CreateLine()
    {
        line = Instantiate(linePrefab,Vector2.zero,Quaternion.identity);
        createdLines.Add(line);
        lineRenderer = line.GetComponent<LineRenderer>();
        _edgeCollider = line.GetComponent<EdgeCollider2D>();
        fingerPositionList.Clear();
        fingerPositionList.Add(_mainKamera.ScreenToWorldPoint(Input.mousePosition));
        fingerPositionList.Add(_mainKamera.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,fingerPositionList[0]);
        lineRenderer.SetPosition(1,fingerPositionList[1]);
        _edgeCollider.points = fingerPositionList.ToArray();
    }
    private void UpdateLine(Vector2 fingerPosition)
    {
        fingerPositionList.Add(fingerPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,fingerPosition);
        _edgeCollider.points = fingerPositionList.ToArray();
    }
    public void DestroyCreatedLines()
    {
        foreach (var item in createdLines)
        {
            Destroy(item.gameObject);
        }
        createdLines.Clear();
    }

    public void UpdateDrawAmount(int amount)
    {
        maxDrawAmount += amount;
        uiManager.UpdateDrawAmountText(maxDrawAmount);
    }
}
