using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeData{
    private string[,] cube1 = new string[3, 3];
    private string[,] cube2 = new string[3, 3];
    private string[,] cube3 = new string[3, 3];

    private string[] centerPiece = new string[6];

    private string[,] up_Red, front_White, right_Blue,
        rear_Yellow, left_Green, down_Purple;

    private string[,] cube2DUp, cube2DDown, cube2DRight, cube2DLeft, cube2DFront, cube2DRear;

    private string solveData = null;


    public CubeData()
    {
        initCubeArray();
        initTileArray();
        initCube2DArray();
        initCenterPiece();
    }

    ///////////////////////////////////////////////////////
    //세팅

    public string[] getCenterPiece()
    {
        return centerPiece;
    }

    private void initCubeArray()
    {
        //회전축
        cube1[1, 1] = "Center Piece 1";
        cube2[2, 1] = "Center Piece 2";
        cube2[1, 2] = "Center Piece 3";
        cube2[0, 1] = "Center Piece 4";
        cube2[1, 0] = "Center Piece 5";
        cube3[1, 1] = "Center Piece 6";

        //꼭짓점
        cube1[0, 2] = "Corner Piece 1";
        cube1[0, 0] = "Corner Piece 2";
        cube1[2, 2] = "Corner Piece 3";
        cube1[2, 0] = "Corner Piece 4";
        cube3[0, 2] = "Corner Piece 5";
        cube3[0, 0] = "Corner Piece 6";
        cube3[2, 2] = "Corner Piece 7";
        cube3[2, 0] = "Corner Piece 8";

        //모서리
        cube2[0, 2] = "Edge Piece 1";
        cube2[0, 0] = "Edge Piece 2";
        cube2[2, 2] = "Edge Piece 3";
        cube2[2, 0] = "Edge Piece 4";
        cube1[1, 2] = "Edge Piece 5";
        cube1[1, 0] = "Edge Piece 6";
        cube1[0, 1] = "Edge Piece 7";
        cube1[2, 1] = "Edge Piece 8";
        cube3[1, 2] = "Edge Piece 9";
        cube3[1, 0] = "Edge Piece 10";
        cube3[0, 1] = "Edge Piece 11";
        cube3[2, 1] = "Edge Piece 12";

        //센터
        cube2[1, 1] = "CubeCenter";
    }

    private void initTileArray()
    {
        up_Red = new string[3, 3];
        front_White = new string[3, 3];
        right_Blue = new string[3, 3];
        rear_Yellow = new string[3, 3];
        left_Green = new string[3, 3];
        down_Purple = new string[3, 3];

        for(int i = 0; i<3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                up_Red[i, j] = "red";
                front_White[i, j] = "white";
                right_Blue[i, j] = "blue";
                rear_Yellow[i, j] = "yellow";
                left_Green[i, j] = "green";
                down_Purple[i, j] = "purple";
            }
        }
    }

    private void initCube2DArray()
    {
        cube2DUp = new string[3, 3];
        cube2DDown = new string[3, 3];
        cube2DRight = new string[3, 3];
        cube2DLeft = new string[3, 3];
        cube2DFront = new string[3, 3];
        cube2DRear = new string[3,3];

        int count = 0;

        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                cube2DUp[i, j] = "up" + count;
                cube2DDown[i, j] = "down" + count;
                cube2DRight[i, j] = "right" + count;
                cube2DLeft[i, j] = "left" + count;
                cube2DFront[i, j] = "front" + count;
                cube2DRear[i, j] = "rear" + count;
                count++;
            }
        }

    }

    private void initCenterPiece()
    {
        for(int i = 0; i<6; ++i)
        {
            centerPiece[i] = "Center Piece " + (i + 1);
        }
    }

    ////////////////////////////////////////////////////
    //반환

    public string[,] getSurface(int select)
    {
        switch (select)
        {
            case 0:
                return getUpFace();

            case 1:
                return getFrontFace();

            case 2:
                return getRightFace();

            case 3:
                return getRearFace();

            case 4:
                return getLeftFace();

            case 5:
                return getDownFace();

            default:
                return null;

        }
    }

    public string[,] getUpFace()
    {
        string[,] face = new string[3, 3];

        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                face[i, j] = cube1[i, j];

        return face;
    }

    public string[,] getDownFace()
    {
        string[,] face = new string[3, 3];

        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                face[i, j] = cube3[i, j];

        return face;
    }

    public string[,] getFrontFace()
    {
        string[,] face = new string[3, 3];

        face[0, 0] = cube1[2, 0]; face[0, 1] = cube1[2, 1]; face[0, 2] = cube1[2, 2];
        face[1, 0] = cube2[2, 0]; face[1, 1] = cube2[2, 1]; face[1, 2] = cube2[2, 2];
        face[2, 0] = cube3[2, 0]; face[2, 1] = cube3[2, 1]; face[2, 2] = cube3[2, 2];

        return face;
    }

    public string[,] getRightFace()
    {
        string[,] face = new string[3, 3];

        face[0, 0] = cube1[2, 2]; face[0, 1] = cube1[1, 2]; face[0, 2] = cube1[0, 2];
        face[1, 0] = cube2[2, 2]; face[1, 1] = cube2[1, 2]; face[1, 2] = cube2[0, 2];
        face[2, 0] = cube3[2, 2]; face[2, 1] = cube3[1, 2]; face[2, 2] = cube3[0, 2];

        return face;
    }

    public string[,] getLeftFace()
    {
        string[,] face = new string[3, 3];

        face[0, 0] = cube1[0, 0]; face[0, 1] = cube1[1, 0]; face[0, 2] = cube1[2, 0];
        face[1, 0] = cube2[0, 0]; face[1, 1] = cube2[1, 0]; face[1, 2] = cube2[2, 0];
        face[2, 0] = cube3[0, 0]; face[2, 1] = cube3[1, 0]; face[2, 2] = cube3[2, 0];

        return face;
    }

    public string[,] getRearFace()
    {
        string[,] face = new string[3, 3];

        face[0, 0] = cube1[0, 0]; face[0, 1] = cube1[0, 1]; face[0, 2] = cube1[0, 2];
        face[1, 0] = cube2[0, 0]; face[1, 1] = cube2[0, 1]; face[1, 2] = cube2[0, 2];
        face[2, 0] = cube3[0, 0]; face[2, 1] = cube3[0, 1]; face[2, 2] = cube3[0, 2];

        return face;
    }

    public void resetParent()
    {
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
            {
                GameObject.Find(cube1[i, j]).transform.SetParent(GameObject.Find("CubeCenter").transform);
                GameObject.Find(cube2[i, j]).transform.SetParent(GameObject.Find("CubeCenter").transform);
                GameObject.Find(cube3[i, j]).transform.SetParent(GameObject.Find("CubeCenter").transform);
            }
    }

    public string[,] getTilesName(int face)
    {
        switch (face)
        {
            case 0:
                {
                    return cube2DUp;
                }
            case 1:
                {
                    return cube2DFront;
                }
            case 2:
                {
                    return cube2DRight;
                }
            case 3:
                {
                    return cube2DRear;
                }
            case 4:
                {
                    return cube2DLeft;
                }
            case 5:
                {
                    return cube2DDown;
                }
            default:
                {
                    return null;
                }
        }

    }

    public string[,] getTilesColor(int face)
    {
        switch (face)
        {
            case 0:
                {
                    return up_Red;
                }
            case 1:
                {
                    return front_White;
                }
            case 2:
                {
                    return right_Blue;
                }
            case 3:
                {
                    return rear_Yellow;
                }
            case 4:
                {
                    return left_Green;
                }
            case 5:
                {
                    return down_Purple;
                }
            default:
                {
                    return null;
                }
        }
    }

    public void resetSolveData()
    {
        solveData = null;
    }

    ////////////////////////////////////////////////////
    //회전

    public void Rotate(int face)
    {//시계방향 회전
        switch (face)
        {
            //블록회전
            case 0://up
                {
                    solveData = solveData + "0";
                    //꼭짓점
                    string temp = cube1[0, 0];
                    cube1[0, 0] = cube1[2, 0];
                    cube1[2, 0] = cube1[2, 2];
                    cube1[2, 2] = cube1[0, 2];
                    cube1[0, 2] = temp;

                    //모서리
                    temp = cube1[0, 1];
                    cube1[0, 1] = cube1[1, 0];
                    cube1[1, 0] = cube1[2, 1];
                    cube1[2, 1] = cube1[1, 2];
                    cube1[1, 2] = temp;

                    rotateUpTile();

                    break;
                }
            case 1://front
                {
                    solveData = solveData + "1";

                    //꼭짓점
                    string temp = cube1[2, 0];
                    cube1[2, 0] = cube3[2, 0];
                    cube3[2, 0] = cube3[2, 2];
                    cube3[2, 2] = cube1[2, 2];
                    cube1[2, 2] = temp;

                    //모서리
                    temp = cube1[2, 1];
                    cube1[2, 1] = cube2[2, 0];
                    cube2[2, 0] = cube3[2, 1];
                    cube3[2, 1] = cube2[2, 2];
                    cube2[2, 2] = temp;

                    rotateFrontTile();
                    break;
                }
            case 2://right
                {
                    solveData = solveData + "2";

                    //꼭짓점
                    string temp = cube1[0, 2];
                    cube1[0, 2] = cube1[2, 2];
                    cube1[2, 2] = cube3[2, 2];
                    cube3[2, 2] = cube3[0, 2];
                    cube3[0, 2] = temp;

                    //모서리
                    temp = cube1[1, 2];
                    cube1[1, 2] = cube2[2, 2];
                    cube2[2, 2] = cube3[1, 2];
                    cube3[1, 2] = cube2[0, 2];
                    cube2[0, 2] = temp;

                    rotateRightTile();
                    break;
                }
            case 3://rear
                {
                    solveData = solveData + "3";

                    //꼭짓점
                    string temp = cube1[0, 0];
                    cube1[0, 0] = cube1[0, 2];
                    cube1[0, 2] = cube3[0, 2];
                    cube3[0, 2] = cube3[0, 0];
                    cube3[0, 0] = temp;

                    //모서리
                    temp = cube1[0,1];
                    cube1[0, 1] = cube2[0, 2];
                    cube2[0, 2] = cube3[0, 1];
                    cube3[0, 1] = cube2[0, 0];
                    cube2[0, 0] = temp;

                    rotateRearTile();

                    break;
                }
            case 4://left
                {
                    solveData = solveData + "4";

                    //꼭짓점
                    string temp = cube1[0, 0];
                    cube1[0, 0] = cube3[0, 0];
                    cube3[0, 0] = cube3[2, 0];
                    cube3[2, 0] = cube1[2, 0];
                    cube1[2, 0] = temp;

                    //모서리
                    temp = cube1[1, 0];
                    cube1[1, 0] = cube2[0, 0];
                    cube2[0, 0] = cube3[1, 0];
                    cube3[1, 0] = cube2[2, 0];
                    cube2[2, 0] = temp;

                    rotateLeftTile();
                    break;
                }
            case 5://down
                {
                    solveData = solveData + "5";

                    //꼭짓점
                    string temp = cube3[0, 0];
                    cube3[0, 0] = cube3[0, 2];
                    cube3[0, 2] = cube3[2, 2];
                    cube3[2, 2] = cube3[2, 0];
                    cube3[2, 0] = temp;

                    //모서리
                    temp = cube3[0, 1];
                    cube3[0, 1] = cube3[1, 2];
                    cube3[1, 2] = cube3[2, 1];
                    cube3[2, 1] = cube3[1, 0];
                    cube3[1, 0] = temp;

                    rotateDownTile();
                    break;
                }
        }
    }

    private void rotateUpTile()
    {
        string[] temp = new string[3];
        for (int i = 0; i < 3; ++i)
            temp[i] = front_White[0,i];

        for (int i = 0; i < 3; ++i)
            front_White[0, i] = right_Blue[0, i];

        for (int i = 0; i < 3; ++i)
            right_Blue[0, i] = rear_Yellow[0, i];

        for (int i = 0; i < 3; ++i)
            rear_Yellow[0, i] = left_Green[0, i];

        for (int i = 0; i < 3; ++i)
            left_Green[0, i] = temp[i];

        //꼭짓점
        temp[0] = up_Red[0, 0];
        up_Red[0, 0] = up_Red[2, 0];
        up_Red[2, 0] = up_Red[2, 2];
        up_Red[2, 2] = up_Red[0, 2];
        up_Red[0, 2] = temp[0];

        //모서리
        temp[0] = up_Red[0, 1];
        up_Red[0, 1] = up_Red[1, 0];
        up_Red[1, 0] = up_Red[2, 1];
        up_Red[2, 1] = up_Red[1, 2];
        up_Red[1, 2] = temp[0];
    }

    private void rotateFrontTile()
    {
        string[] temp = new string[3];
        for (int i = 0; i < 3; ++i)
            temp[i] = up_Red[2,i];

        for (int i = 0; i < 3; ++i)
            up_Red[2, i] = left_Green[2 - i, 2];

        for (int i = 0; i < 3; ++i)
            left_Green[i, 2] = down_Purple[0, i];

        for (int i = 0; i < 3; ++i)
            down_Purple[0, i] = right_Blue[2 - i, 0];

        for (int i = 0; i < 3; ++i)
            right_Blue[i, 0] = temp[i];

        //꼭짓점
        temp[0] = front_White[0, 0];
        front_White[0, 0] = front_White[2, 0];
        front_White[2, 0] = front_White[2, 2];
        front_White[2, 2] = front_White[0, 2];
        front_White[0, 2] = temp[0];

        //모서리
        temp[0] = front_White[0,1];
        front_White[0, 1] = front_White[1, 0];
        front_White[1, 0] = front_White[2, 1];
        front_White[2, 1] = front_White[1, 2];
        front_White[1, 2] = temp[0];
    }

    private void rotateRightTile()
    {
        string[] temp = new string[3];
        for (int i = 0; i < 3; ++i)
            temp[i] = up_Red[i, 2];

        for (int i = 0; i < 3; ++i)
            up_Red[i, 2] = front_White[i, 2];

        for (int i = 0; i < 3; ++i)
            front_White[i, 2] = down_Purple[i, 2];

        for (int i = 0; i < 3; ++i)
            down_Purple[i, 2] = rear_Yellow[2 - i, 0];

        for (int i = 0; i < 3; ++i)
            rear_Yellow[2 - i, 0] = temp[i];

        //꼭짓점
        temp[0] = right_Blue[0, 0];
        right_Blue[0, 0] = right_Blue[2, 0];
        right_Blue[2, 0] = right_Blue[2, 2];
        right_Blue[2, 2] = right_Blue[0, 2];
        right_Blue[0, 2] = temp[0];

        //모서리
        temp[0] = right_Blue[0, 1];
        right_Blue[0, 1] = right_Blue[1, 0];
        right_Blue[1, 0] = right_Blue[2, 1];
        right_Blue[2, 1] = right_Blue[1, 2];
        right_Blue[1, 2] = temp[0];
    }

    private void rotateRearTile()
    {
        string[] temp = new string[3];
        for (int i = 0; i < 3; ++i)
            temp[i] = up_Red[0, i];

        for (int i = 0; i < 3; ++i)
            up_Red[0, i] = right_Blue[i, 2];

        for (int i = 0; i < 3; ++i)
            right_Blue[i, 2] = down_Purple[2, 2-i];

        for (int i = 0; i < 3; ++i)
            down_Purple[2, 2 - i] = left_Green[2 - i, 0];

        for (int i = 0; i < 3; ++i)
            left_Green[2 - i, 0] = temp[i];

        //꼭짓점
        temp[0] = rear_Yellow[0, 0];
        rear_Yellow[0, 0] = rear_Yellow[2, 0];
        rear_Yellow[2, 0] = rear_Yellow[2, 2];
        rear_Yellow[2, 2] = rear_Yellow[0, 2];
        rear_Yellow[0, 2] = temp[0];

        //모서리
        temp[0] = rear_Yellow[0, 1];
        rear_Yellow[0, 1] = rear_Yellow[1, 0];
        rear_Yellow[1, 0] = rear_Yellow[2, 1];
        rear_Yellow[2, 1] = rear_Yellow[1, 2];
        rear_Yellow[1, 2] = temp[0];
    }

    private void rotateLeftTile()
    {
        string[] temp = new string[3];
        for (int i = 0; i < 3; ++i)
            temp[i] = up_Red[i, 0];

        for (int i = 0; i < 3; ++i)
            up_Red[i, 0] = rear_Yellow[2 - i, 2];

        for (int i = 0; i < 3; ++i)
            rear_Yellow[i, 2] = down_Purple[2 - i, 0];

        for (int i = 0; i < 3; ++i)
            down_Purple[i, 0] = front_White[i, 0];

        for (int i = 0; i < 3; ++i)
            front_White[i, 0] = temp[i];

        //꼭짓점
        temp[0] = left_Green[0, 0];
        left_Green[0, 0] = left_Green[2, 0];
        left_Green[2, 0] = left_Green[2, 2];
        left_Green[2, 2] = left_Green[0, 2];
        left_Green[0, 2] = temp[0];

        //모서리
        temp[0] = left_Green[0, 1];
        left_Green[0, 1] = left_Green[1, 0];
        left_Green[1, 0] = left_Green[2, 1];
        left_Green[2, 1] = left_Green[1, 2];
        left_Green[1, 2] = temp[0];
    }

    private void rotateDownTile()
    {
        string[] temp = new string[3];
        for (int i = 0; i < 3; ++i)
            temp[i] = front_White[2, i];

        for (int i = 0; i < 3; ++i)
            front_White[2, i] = right_Blue[2, i];

        for (int i = 0; i < 3; ++i)
            right_Blue[2, i] = rear_Yellow[2, i];

        for (int i = 0; i < 3; ++i)
            rear_Yellow[2, i] = left_Green[2, i];

        for (int i = 0; i < 3; ++i)
            left_Green[2,i] = temp[i];

        //꼭짓점
        temp[0] = down_Purple[0, 0];
        down_Purple[0, 0] = down_Purple[2, 0];
        down_Purple[2, 0] = down_Purple[2, 2];
        down_Purple[2, 2] = down_Purple[0, 2];
        down_Purple[0, 2] = temp[0];

        //모서리
        temp[0] = down_Purple[0, 1];
        down_Purple[0, 1] = down_Purple[1, 0];
        down_Purple[1, 0] = down_Purple[2, 1];
        down_Purple[2, 1] = down_Purple[1, 2];
        down_Purple[1, 2] = temp[0];
    }



    ///////////////////////////////////////////////////
    //풀이

    public bool completeCube()
    {
        for(int i = 0; i <3; ++i)
            for(int j = 0; j<3; ++j)
            {
                if (up_Red[i, j] == "red" && front_White[i, j] == "white"
                    && right_Blue[i, j] == "blue" && rear_Yellow[i, j] == "yellow"
                    && left_Green[i, j] == "green" && down_Purple[i, j] == "purple")
                    return true;
                else break;
            }
        return false;
    }

    public string[,,] getAllFace()
    {
        string[,,] allFace = new string[3, 3, 3];

        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
            {
                allFace[0, i, j] = cube1[i, j];
                allFace[1, i, j] = cube2[i, j];
                allFace[2, i, j] = cube3[i, j];
            }
        return allFace;
    }

    public bool compareFace(string[,,]allFace)
    {
        //같다면 false 다르면 true
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
            {
                if (cube1[i, j] == allFace[0, i, j] &&
                    cube2[i, j] == allFace[1, i, j] &&
                    cube3[i, j] == allFace[2, i, j])
                    return false;
                else break;
            }

        return true;
    }

    ///

    public void print()
    {
        for(int i = 0; i <3; ++i)
            for(int j = 0; j < 3; ++j)
            {
                Debug.Log(cube1[i,j]);
            }
    }

}
