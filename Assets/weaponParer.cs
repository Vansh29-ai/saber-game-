using UnityEngine;

public class weaponParer : MonoBehaviour
{[SerializeField]
  private GameObject _tip;
  [SerializeField]
  private GameObject _bottom;
  [SerializeField]
  private GameObject _trailMesh; 
  [SerializeField]
  private int _trailFrameLength;

  private Mesh _mesh;

  private Vector3[] _vertices;
  private Vector3 _previousTipPosition;
  private Vector3 _previousBottomPosition;
    private int[] _triangles;
    private int _frameCount;
    private const int NUM_VERTICES = 12;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mesh = new Mesh();
        _trailMesh.GetComponent<MeshFilter>().mesh = _mesh;
        _vertices = new Vector3[NUM_VERTICES * _trailFrameLength];
        _triangles = new int[_vertices.Length];
        _previousTipPosition = _tip.transform.position;
        _previousBottomPosition = _bottom.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_frameCount == (_trailFrameLength*NUM_VERTICES))
        {
            _frameCount = 0;
        }
        _vertices[_frameCount] = _tip.transform.position;
        _vertices[_frameCount + 1] = _bottom.transform.position;
       _vertices[_frameCount + 2] = _previousTipPosition;
       _vertices[_frameCount + 3] = _bottom.transform.position;
       _vertices[_frameCount + 4] = _previousTipPosition;
       _vertices[_frameCount + 5] = _tip.transform.position;
         _vertices[_frameCount + 6] = _previousTipPosition;
            _vertices[_frameCount + 7] = _bottom.transform.position;
            _vertices[_frameCount + 8] = _previousBottomPosition;
            _vertices[_frameCount + 9] = _previousTipPosition;
            _vertices[_frameCount + 10] = _previousBottomPosition;
            _vertices[_frameCount + 11] = _bottom.transform.position;
            _triangles[_frameCount] = _frameCount;
            _triangles[_frameCount + 1] = _frameCount + 1;
            _triangles[_frameCount + 2] = _frameCount + 2;
            _triangles[_frameCount + 3] = _frameCount + 3;
            _triangles[_frameCount + 4] = _frameCount + 4;
            _triangles[_frameCount + 5] = _frameCount + 5;
            _triangles[_frameCount + 6] = _frameCount + 6;
            _triangles[_frameCount + 7] = _frameCount + 7;
            _triangles[_frameCount + 8] = _frameCount + 8;
            _triangles[_frameCount + 9] = _frameCount + 9;
            _triangles[_frameCount + 10] = _frameCount + 10;
            _triangles[_frameCount + 11] = _frameCount + 11;
            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            _previousTipPosition = _tip.transform.position;
            _previousBottomPosition = _bottom.transform.position;
            _frameCount += NUM_VERTICES;


    }
}
