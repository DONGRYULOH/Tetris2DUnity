using UnityEngine;
using UnityEngine.Tilemaps;


/*
    enum ���� ����) 
    ���� : ������� ������ ��Ƴ��� ������ ��� ���� 

    ����(static)�� �ƴϰ� �ν��Ͻ�ȭ�� �Ұ��� 
    "enum ��.enum �����" ���� ������ �� ����

    enum ����� ���� ��� ������̸� ��, ������ �Ұ���
    ���� ��������� �Ҵ����� ������ 0���� ������� 1�� ������ �������� �Ҵ�� 
    �����Ӹ� �ƴ϶� �پ��� ������ ���� �Ҵ� ����
 */

public enum Tetromino 
{ 
    I = 0,
    O = 1,
    T = 2,
    J = 3,
    L = 4,
    S = 5,
    Z = 6,
}

/*
    ����ü�� Ŭ������ ������? 
    1. ����ü�� ���ÿ� ����ǰ� Ŭ������ �� ������ ����� 
    2. ������� ����ü�� �ٸ� ����ü ������ �Ҵ��ϸ� ���ο� �纻�� ��������� ���ÿ� ���� �Ҵ��
*/
[System.Serializable]
public struct TetrominoData 
{
    public Tetromino tetromino; // ����Ƽ �ν����� â���� ��Ʈ�ι̳� �߰� 
    public Tile tile; // ����Ƽ �ν����� â���� �ش� ��Ʈ�ι̳� ������ �׸� Ÿ�� �߰� 

    // �� ��Ʈ�ι̳뿡 �ش�Ǵ� 4������ ����� ��ǥ���� �迭���·� �� ���� [0] ~[3]
    public Vector2Int[] cells { get; private set; }

    public void Initialize() {
        // �� ��Ʈ�ι̳뿡 �ش�Ǵ� 4������ ����� ��ǥ���� ����
        // key-value ������ ������ �������� [�ε���] ������ value ���� ������ �� ����? 
        // public TValue this[TKey key] { get; set; } -> �迭���·� value���� ������ �� ���� 
        this.cells = Data.Cells[this.tetromino];
    }
}