using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board { get; private set; }
    public TetrominoData data { get; private set; }

    /*
        it'll be vector three in because tile maps use vector three instead of vector two


        TetrominoData -> cells 배열이 있는데 따로 cells 배열을 추가하는 이유는? 

        we're going to be manipulating those cells per piece 
        
        테트로미노가 움직이거나 회전할 때 각각의 조각들의 위치값이 변하기 때문
     */
    public Vector3Int[] cells { get; private set; }

    // 보드상에 테트로미노가 그려지는 위치
    public Vector3Int position { get; private set; }


    /*
        what is the tetromino data (that you want to use while this piece is active)
        -> 조각이 활성화 되는 동안 사용해야될 테트로미노 데이터는 무엇인가?     
        
        piece 클래스와 Board 클래스의 차이점? 
        the difference in these two classes is our game board is going to control 
        the kind of general (like overall state of our game)
        -> board 클래스가 (게임의 전반적인 상태와 같은 종류들) 통제할 것이다. 

        it has the entire tile map and it can rander 
        -> 전체적인 타일맵을 가지고 있고 렌더링 할 수 있음 

        our piece is just the individual piece 
        and this is where we will add logic for like inputs and controls you know moving rotating
        
     */
    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;

        if (this.cells == null)
        {
            // 모든 테트로미노는 4개의 조각으로 이루어져 있기 때문에 
            // new Vector3Int[4] -> 하드코딩으로 쓰지 않는다. 왜냐하면 테트로미노가 커스터마이징 될 가능성도 있기 때문
            // 6개의 조각으로 이루어진 테트로미노의 게임을 만들때도 코드를 수정하지 않아도 되므로 편리하다.
            this.cells = new Vector3Int[data.cells.Length];
        }

        // 테트로미노 블록의 좌표값 세팅 
        for (int i = 0; i < data.cells.Length; i++)
        {
            this.cells[i] = (Vector3Int)data.cells[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {

        }
    }


    private void Move(Vector2Int translation) {

        // 이동한 뒤의 좌표값 
        Vector3Int newPosition = this.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;


        // 이동한 좌표값이 유효한지 확인(보드의 범위를 넘어갔거나 이미있는 블록을 침범한 경우)
        for (int i = 0; i < this.cells.Length; i++) {

            

        //    cells[i].x = cells[i].x + (Vector3Int)translation + this.position;

        }
    }



}
