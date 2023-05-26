using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    // ��Ʈ���� �� 
    public Tilemap timemap { get; private set; }

    /*
        C# 3.0���ʹ� �ڵ� ���� ������Ƽ(Auto-implemented properties)�� ����Ͽ� �� �����ϰ� getter�� setter�� ���� �� �ֽ��ϴ�. 
    */
    public Piece activePiece;

    public Piece activePieces { 
        get { return activePiece; }
        set { activePiece = value; }
    }

    // 7���� ��Ʈ���� ��� ��� 
    // ����Ƽ �ν����� â���� 7���� ��Ʈ�ι̳븦 �߰�����
    public TetrominoData[] tetrominoes;

    // ��Ʈ�ι̳��� ����? ���� ��ġ�� ���ϴ°ǰ�?
    public Vector3Int spawnPosition;

    // ������ ����
    public Vector2Int boardSize = new Vector2Int(10, 20);

    public RectInt Bounds
    {
        get {
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
            return new RectInt(position, this.boardSize);
        }
        
    }

    private void Awake()
    {
        this.timemap = GetComponentInChildren<Tilemap>();
        this.activePieces = GetComponentInChildren<Piece>();

        for (int i = 0; i < this.tetrominoes.Length; i++) {
            this.tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    
    public void SpawnPiece() {
        // ���� ��Ʈ�ι̳� �̱� 
        int random = Random.Range(0, this.tetrominoes.Length);
        TetrominoData data = this.tetrominoes[random];

        // ���� ��Ʈ�ι̳� ���� �ʱ���ġ ���� 
        // this.spawnPosition -> ��ġ�� ������ ���� ���µ� ��� ���ذ���?
        this.activePiece.Initialize(this, this.spawnPosition, data);
        Set(this.activePiece);
    }

    // Ÿ�ϸʿ� �ش� ��Ʈ�ι̳� ������ ����
    public void Set(Piece piece) {

        // ��Ʈ�ι̳�� 4���� �������� �̷���� �ֱ� ������ 4�� ������ ���鼭 �� �������� ��ġ���� �����ͼ� tilemap ���� �׷��ش�
        for (int i = 0; i < piece.cells.Length; i++) {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.timemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    // ��Ʈ�ι̳밡 ���� �� ��ȿ�� �����ȿ� �ִ��� üũ 
    public bool IsVaildPosition(Piece piece, Vector3Int position) {

        RectInt bounds = this.Bounds;

        for(int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            // �̵��� �ش� Ÿ�Ͽ� ����� �����ϴ� ��� 
            if (this.timemap.HasTile(tilePosition)) {
                return false;
            }

            // ������ ������ ��� ��� 
            if (!bounds.Contains((Vector2Int)tilePosition)) {
                return false;
            }
        }

        return true;
    }
}
