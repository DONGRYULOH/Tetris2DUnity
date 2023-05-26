using UnityEngine;
using UnityEngine.Tilemaps;


/*
    enum 문법 정리) 
    정의 : 상수값을 여러개 모아놓은 열거형 상수 집합 

    정적(static)이 아니고 인스턴스화도 불가능 
    "enum 명.enum 멤버값" 값을 가져올 수 있음

    enum 멤버의 값은 모두 상수값이며 즉, 변경이 불가능
    값을 명시적으로 할당하지 않으면 0부터 차레대로 1씩 증가한 정수값이 할당됨 
    정수뿐만 아니라 다양한 형식의 값도 할당 가능
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
    구조체와 클래스의 차이점? 
    1. 구조체는 스택에 저장되고 클래스는 힙 영역에 저장됨 
    2. 만들어진 구조체를 다른 구조체 변수에 할당하면 새로운 사본이 만들어지고 스택에 새로 할당됨
*/
[System.Serializable]
public struct TetrominoData 
{
    public Tetromino tetromino; // 유니티 인스펙터 창에서 테트로미노 추가 
    public Tile tile; // 유니티 인스펙터 창에서 해당 테트로미노 색깔을 그릴 타일 추가 

    // 각 테트로미노에 해당되는 4가지의 블록의 좌표값이 배열형태로 들어가 있음 [0] ~[3]
    public Vector2Int[] cells { get; private set; }

    public void Initialize() {
        // 각 테트로미노에 해당되는 4가지의 블록의 좌표값을 설정
        // key-value 형태의 데이터 구조에서 [인덱스] 값으로 value 값을 가져올 수 있음? 
        // public TValue this[TKey key] { get; set; } -> 배열형태로 value값을 가져올 수 있음 
        this.cells = Data.Cells[this.tetromino];
    }
}