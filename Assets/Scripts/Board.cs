using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    // 테트리스 맵 
    public Tilemap timemap { get; private set; }

    /*
        C# 3.0부터는 자동 구현 프로퍼티(Auto-implemented properties)를 사용하여 더 간편하게 getter와 setter를 만들 수 있습니다. 
    */
    public Piece activePiece;

    public Piece activePieces { 
        get { return activePiece; }
        set { activePiece = value; }
    }

    // 7개의 테트리스 블록 모양 
    // 유니티 인스펙터 창에서 7개의 테트로미노를 추가해줌
    public TetrominoData[] tetrominoes;

    // 테트로미노의 최초? 생성 위치를 말하는건가?
    public Vector3Int spawnPosition;

    // 보드의 범위
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
        // 랜덤 테트로미노 뽑기 
        int random = Random.Range(0, this.tetrominoes.Length);
        TetrominoData data = this.tetrominoes[random];

        // 뽑은 테트로미노 조각 초기위치 설정 
        // this.spawnPosition -> 위치를 설정한 적이 없는데 어디서 해준거지?
        this.activePiece.Initialize(this, this.spawnPosition, data);
        Set(this.activePiece);
    }

    // 타일맵에 해당 테트로미노 조각을 세팅
    public void Set(Piece piece) {

        // 테트로미노는 4개의 조각으로 이루어져 있기 때문에 4번 루프를 돌면서 각 조각들의 위치값을 가져와서 tilemap 위에 그려준다
        for (int i = 0; i < piece.cells.Length; i++) {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.timemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    // 테트로미노가 보드 상에 유효한 범위안에 있는지 체크 
    public bool IsVaildPosition(Piece piece, Vector3Int position) {

        RectInt bounds = this.Bounds;

        for(int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            // 이동시 해당 타일에 블록이 존재하는 경우 
            if (this.timemap.HasTile(tilePosition)) {
                return false;
            }

            // 보드의 경계면을 벗어난 경우 
            if (!bounds.Contains((Vector2Int)tilePosition)) {
                return false;
            }
        }

        return true;
    }
}
