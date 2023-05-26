using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board { get; private set; }
    public TetrominoData data { get; private set; }

    /*
        it'll be vector three in because tile maps use vector three instead of vector two


        TetrominoData -> cells �迭�� �ִµ� ���� cells �迭�� �߰��ϴ� ������? 

        we're going to be manipulating those cells per piece 
        
        ��Ʈ�ι̳밡 �����̰ų� ȸ���� �� ������ �������� ��ġ���� ���ϱ� ����
     */
    public Vector3Int[] cells { get; private set; }

    // ����� ��Ʈ�ι̳밡 �׷����� ��ġ
    public Vector3Int position { get; private set; }


    /*
        what is the tetromino data (that you want to use while this piece is active)
        -> ������ Ȱ��ȭ �Ǵ� ���� ����ؾߵ� ��Ʈ�ι̳� �����ʹ� �����ΰ�?     
        
        piece Ŭ������ Board Ŭ������ ������? 
        the difference in these two classes is our game board is going to control 
        the kind of general (like overall state of our game)
        -> board Ŭ������ (������ �������� ���¿� ���� ������) ������ ���̴�. 

        it has the entire tile map and it can rander 
        -> ��ü���� Ÿ�ϸ��� ������ �ְ� ������ �� �� ���� 

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
            // ��� ��Ʈ�ι̳�� 4���� �������� �̷���� �ֱ� ������ 
            // new Vector3Int[4] -> �ϵ��ڵ����� ���� �ʴ´�. �ֳ��ϸ� ��Ʈ�ι̳밡 Ŀ���͸���¡ �� ���ɼ��� �ֱ� ����
            // 6���� �������� �̷���� ��Ʈ�ι̳��� ������ ���鶧�� �ڵ带 �������� �ʾƵ� �ǹǷ� ���ϴ�.
            this.cells = new Vector3Int[data.cells.Length];
        }

        // ��Ʈ�ι̳� ����� ��ǥ�� ���� 
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

        // �̵��� ���� ��ǥ�� 
        Vector3Int newPosition = this.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;


        // �̵��� ��ǥ���� ��ȿ���� Ȯ��(������ ������ �Ѿ�ų� �̹��ִ� ����� ħ���� ���)
        for (int i = 0; i < this.cells.Length; i++) {

            

        //    cells[i].x = cells[i].x + (Vector3Int)translation + this.position;

        }
    }



}
