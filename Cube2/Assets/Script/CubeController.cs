using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour {

    private CubeData cubeData;
    private CubeData solveData;

    private string[,] cube;
    private string[] centerPiece;

    private Transform pin;

    private int count = 15, speed = 15;
    private int select = 0;
    bool rotate = false;



    private Queue<string[,,]> queue1 = new Queue<string[,,]>();
    private Queue<string> queue2 = new Queue<string>();





    void Start() {
        cubeData = new CubeData();

        cube = new string[3, 3];

        centerPiece = new string[6];
        centerPiece = cubeData.getCenterPiece();
    }

    void Update() {

        rotation();
        tileColorControll();
        controll();

    }

    public void tileColorControll()
    {

        string[,] data1 = new string[3, 3];
        string[,] data2 = new string[3, 3];
        int R = 0, G = 0, B = 0;

        for (int x = 0; x < 6; ++x)
        {
            data1 = cubeData.getTilesName(x);
            data2 = cubeData.getTilesColor(x);

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    switch (data2[i, j])
                    {
                        case "red":
                            {
                                R = 255;
                                G = 0;
                                B = 0;
                                break;
                            }
                        case "blue":
                            {
                                R = 0;
                                G = 0;
                                B = 255;
                                break;
                            }
                        case "green":
                            {
                                R = 0;
                                G = 255;
                                B = 0;
                                break;
                            }
                        case "yellow":
                            {
                                R = 255;
                                G = 255;
                                B = 0;
                                break;
                            }
                        case "purple":
                            {
                                R = 255;
                                G = 0;
                                B = 255;
                                break;
                            }
                        case "white":
                            {
                                R = 255;
                                G = 255;
                                B = 255;
                                break;
                            }
                    }
                    GameObject.Find(data1[i, j]).GetComponent<Image>().color = new Color(R / 255, G / 255, B / 255);
                }
            }
        }


    }


    public void rotation()
    {
        if (rotate)
        {
            switch (select)
            {
                case 0:
                    {
                        pin.Rotate(new Vector3(0, speed, 0));
                        break;
                    }
                case 1:
                    {
                        pin.Rotate(new Vector3(0, 0, -speed));
                        break;
                    }
                case 2:
                    {
                        pin.Rotate(new Vector3(speed, 0, 0));
                        break;
                    }
                case 3:
                    {
                        pin.Rotate(new Vector3(0, 0, speed));
                        break;
                    }
                case 4:
                    {
                        pin.Rotate(new Vector3(-speed, 0, 0));
                        break;
                    }
                case 5:
                    {
                        pin.Rotate(new Vector3(0, -speed, 0));
                        break;
                    }

            }

            if (count >= 90)
            {
                rotate = false;
                count = 0;
                cubeData.Rotate(select);
                select = -1;
                cubeData.resetParent();
            }

            count += speed;


        }
    }

    public void controll()
    {
        if (Input.GetKeyDown(KeyCode.U) && !rotate)
        {
           
            select = 0;

            pinControll(select);
        }
        else if(Input.GetKeyDown(KeyCode.F) && !rotate)
        {
            select = 1;

            pinControll(select);
        }
        else if (Input.GetKeyDown(KeyCode.R) && !rotate)
        {
            select = 2;

            pinControll(select);
        }
        else if (Input.GetKeyDown(KeyCode.B) && !rotate)
        {
            select = 3;

            pinControll(select);
        }
        else if (Input.GetKeyDown(KeyCode.L) && !rotate)
        {
            select = 4;

            pinControll(select);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !rotate)
        {
            select = 5;

            pinControll(select);
        }
    }

    private void pinControll(int select)
    {
        cube = cubeData.getSurface(select);
        pin = GameObject.Find(centerPiece[select]).transform;

        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                GameObject.Find(cube[i, j]).transform.SetParent(pin);

        rotate = true;

    }

    public void onButtonClick(int select)
    {
        if (!rotate)
        {
            this.select = select;
            pinControll(select);
        }
    }

    public void solveBFS()
    {
        queue1 = new Queue<string[,,]>();
        queue2 = new Queue<string>();

        string[,,] solveData = new string[3, 3, 3];

        solveData = cubeData.getAllFace();
        queue1.Enqueue(solveData);
        queue2.Enqueue("-1");

        while (true)
        {
            if (completeCube(queue1.Peek()))
            {
                string[,,] aa = new string[3, 3, 3];
                aa = queue1.Peek();
                Debug.Log(aa[0, 0, 1]);
                break;
            }

            for (int i = 0; i < 6; ++i)
            {
                solveRotate(i, queue1.Peek(), queue2.Peek());
            }

            

            queue1.Dequeue();
            queue2.Dequeue();
        }

        Debug.Log(queue2.Peek());
    }

    private void solveRotate(int face, string[,,] cube, string solveString)
    {
        string[,,] solveData = new string[3, 3, 3];

        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                for (int k = 0; k < 3; ++k)
                {
                    solveData[i, j, k] = cube[i, j, k];
                }

        switch (face)
        {
            //블록회전
            case 0://up
                {
                    solveString = solveString + "0";
                    //꼭짓점
                    string temp = cube[0, 0, 0];
                    cube[0, 0, 0] = cube[0, 2, 0];
                    cube[0, 2, 0] = cube[0, 2, 2];
                    cube[0, 2, 2] = cube[0, 0, 2];
                    cube[0, 0, 2] = temp;

                    //모서리
                    temp = cube[0, 0, 1];
                    cube[0, 0, 1] = cube[0, 1, 0];
                    cube[0, 1, 0] = cube[0, 2, 1];
                    cube[0, 2, 1] = cube[0, 1, 2];
                    cube[0, 1, 2] = temp;

                    queue1.Enqueue(solveData);
                    queue2.Enqueue(solveString);

                    break;
                }
            case 1://front
                {
                    solveString = solveString + "1";

                    //꼭짓점
                    string temp = cube[0, 2, 0];
                    cube[0, 2, 0] = cube[2, 2, 0];
                    cube[2, 2, 0] = cube[2, 2, 2];
                    cube[2, 2, 2] = cube[0, 2, 2];
                    cube[0, 2, 2] = temp;

                    //모서리
                    temp = cube[0, 2, 1];
                    cube[0, 2, 1] = cube[1, 2, 0];
                    cube[1, 2, 0] = cube[2, 2, 1];
                    cube[2, 2, 1] = cube[1, 2, 2];
                    cube[1, 2, 2] = temp;

                    queue1.Enqueue(cube);
                    queue2.Enqueue(solveString);

                    break;
                }
            case 2://right
                {
                    solveString = solveString + "2";

                    //꼭짓점
                    string temp = cube[0, 0, 2];
                    cube[0, 0, 2] = cube[0, 2, 2];
                    cube[0, 2, 2] = cube[2, 2, 2];
                    cube[2, 2, 2] = cube[2, 0, 2];
                    cube[2, 0, 2] = temp;

                    //모서리
                    temp = cube[0, 1, 2];
                    cube[0, 1, 2] = cube[1, 2, 2];
                    cube[1, 2, 2] = cube[2, 1, 2];
                    cube[2, 1, 2] = cube[1, 0, 2];
                    cube[1, 0, 2] = temp;

                    queue1.Enqueue(cube);
                    queue2.Enqueue(solveString);

                    break;
                }
            case 3://rear
                {
                    solveString = solveString + "3";

                    //꼭짓점
                    string temp = cube[0, 0, 0];
                    cube[0, 0, 0] = cube[0, 0, 2];
                    cube[0, 0, 2] = cube[2, 0, 2];
                    cube[2, 0, 2] = cube[2, 0, 0];
                    cube[2, 0, 0] = temp;

                    //모서리
                    temp = cube[0, 0, 1];
                    cube[0, 0, 1] = cube[1, 0, 2];
                    cube[1, 0, 2] = cube[2, 0, 1];
                    cube[2, 0, 1] = cube[1, 0, 0];
                    cube[1, 0, 0] = temp;

                    queue1.Enqueue(cube);
                    queue2.Enqueue(solveString);

                    break;
                }
            case 4://left
                {
                    solveString = solveString + "4";

                    //꼭짓점
                    string temp = cube[0, 0, 0];
                    cube[0, 0, 0] = cube[2, 0, 0];
                    cube[2, 0, 0] = cube[2, 2, 0];
                    cube[2, 2, 0] = cube[0, 2, 0];
                    cube[0, 2, 0] = temp;

                    //모서리
                    temp = cube[0, 1, 0];
                    cube[0, 1, 0] = cube[1, 0, 0];
                    cube[1, 0, 0] = cube[2, 1, 0];
                    cube[2, 1, 0] = cube[1, 2, 0];
                    cube[1, 2, 0] = temp;

                    queue1.Enqueue(cube);
                    queue2.Enqueue(solveString);

                    break;
                }
            case 5://down
                {
                    solveString = solveString + "5";

                    //꼭짓점
                    string temp = cube[2, 0, 0];
                    cube[2, 0, 0] = cube[2, 0, 2];
                    cube[2, 0, 2] = cube[2, 2, 2];
                    cube[2, 2, 2] = cube[2, 2, 0];
                    cube[2, 2, 0] = temp;

                    //모서리
                    temp = cube[2, 0, 1];
                    cube[2, 0, 1] = cube[2, 1, 2];
                    cube[2, 1, 2] = cube[2, 2, 1];
                    cube[2, 2, 1] = cube[2, 1, 0];
                    cube[2, 1, 0] = temp;

                    queue1.Enqueue(cube);
                    queue2.Enqueue(solveString);

                    break;
                }
        }
    }

    private bool completeCube(string[,,] cube)
    {
        //회전축
        if (cube[0, 1, 1] == "Center Piece 1" &&
        cube[1, 2, 1] == "Center Piece 2" &&
        cube[1, 1, 2] == "Center Piece 3" &&
        cube[1, 0, 1] == "Center Piece 4" &&
        cube[1, 1, 0] == "Center Piece 5" &&
        cube[2, 1, 1] == "Center Piece 6" &&

        //꼭짓점
        cube[0, 0, 2] == "Corner Piece 1" &&
        cube[0, 0, 0] == "Corner Piece 2" &&
        cube[0, 2, 2] == "Corner Piece 3" &&
        cube[0, 2, 0] == "Corner Piece 4" &&
        cube[2, 0, 2] == "Corner Piece 5" &&
        cube[2, 0, 0] == "Corner Piece 6" &&
        cube[2, 2, 2] == "Corner Piece 7" &&
        cube[2, 2, 0] == "Corner Piece 8" &&

        //모서리
        cube[1,0, 2] == "Edge Piece 1" &&
        cube[1,0, 0] == "Edge Piece 2" &&
        cube[1,2, 2] == "Edge Piece 3" &&
        cube[1,2, 0] == "Edge Piece 4" &&
        cube[0, 1, 2] == "Edge Piece 5" &&
        cube[0, 1, 0] == "Edge Piece 6" &&
        cube[0, 0, 1] == "Edge Piece 7" &&
        cube[0, 2, 1] == "Edge Piece 8" &&
        cube[2, 1, 2] == "Edge Piece 9" &&
        cube[2, 1, 0] == "Edge Piece 10" &&
        cube[2, 0, 1] == "Edge Piece 11" &&
        cube[2, 2, 1] == "Edge Piece 12" &&

        //센터
        cube[1, 1, 1] == "CubeCenter") return true;

        return false;
    }

}
