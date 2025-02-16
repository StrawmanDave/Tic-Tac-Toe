using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

///Two Players
///class App is responsible for knowing when someone lost or won or when there is a draw
///It is also responsible for knowing whos turn and displaying all the items in the game
///Class Squars is responsible for keeping track of each item or element in the list
///It is also responsible for not letting players choos squares that are already chosen
///Class Square will either have a X or a Y or be null.
Squars test = new Squars();
/*
for(int i = 0; i<test.Count(); i++)
{
    Console.Write($"{i}{test.GetSquare(i).State()}");
}
run.ShowBoard();
*/

new TicTacToeApp(new Squars()).Run();

public class TicTacToeApp
{
    private Squars _squars = new Squars();
    bool X = true;
    private bool _quit = false;

    public TicTacToeApp(Squars squars)
    {
        _squars = squars;
    }

    public void displayHelp()
    {
        Console.WriteLine(
        @"Use the number keys to choose a squar 
            1 2 3
            4 5 6
            7 8 9"
        );
    }

    public void showWin()
    {
        Console.WriteLine("Congradulations!!!!");
    }

    public void checkWin()
    {

        /// 0 1 2
        /// 3 4 5
        /// 6 7 8
        if(_squars.GetSquare(0).State() == 'X' && _squars.GetSquare(1).State() == 'X' && _squars.GetSquare(2).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(0).State() == 'X' && _squars.GetSquare(4).State() == 'X' && _squars.GetSquare(8).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(0).State() == 'X' && _squars.GetSquare(3).State() == 'X' && _squars.GetSquare(6).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(1).State() == 'X' && _squars.GetSquare(4).State() == 'X' && _squars.GetSquare(7).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(2).State() == 'X' && _squars.GetSquare(5).State() == 'X' && _squars.GetSquare(8).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(6).State() == 'X' && _squars.GetSquare(7).State() == 'X' && _squars.GetSquare(8).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(3).State() == 'X' && _squars.GetSquare(4).State() == 'X' && _squars.GetSquare(5).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }else if(_squars.GetSquare(2).State() == 'X' && _squars.GetSquare(4).State() == 'X' && _squars.GetSquare(6).State() == 'X' )
        {
            Console.WriteLine("X Won");
            _quit = true;
        }

        /// 0 1 2
        /// 3 4 5
        /// 6 7 8        
        if(_squars.GetSquare(0).State() == 'O' && _squars.GetSquare(1).State() == 'O' && _squars.GetSquare(2).State() == 'O' )
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(0).State() == 'O' && _squars.GetSquare(4).State() == 'O' && _squars.GetSquare(8).State() == 'O' )
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(0).State() == 'O' && _squars.GetSquare(3).State() == 'O' && _squars.GetSquare(6).State() == 'O' )
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(1).State() == 'O' && _squars.GetSquare(4).State() == 'O' && _squars.GetSquare(7).State() == 'O')
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(2).State() == 'O' && _squars.GetSquare(5).State() == 'O' && _squars.GetSquare(8).State() == 'O')
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(6).State() == 'O' && _squars.GetSquare(7).State() == 'O' && _squars.GetSquare(8).State() == 'O' )
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(3).State() == 'O' && _squars.GetSquare(4).State() == 'O' && _squars.GetSquare(5).State() == 'O' )
        {
            Console.WriteLine("O Won");
            _quit = true;
        }else if(_squars.GetSquare(2).State() == 'O' && _squars.GetSquare(4).State() == 'O' && _squars.GetSquare(6).State() == 'O' )
        {
            Console.WriteLine("O Won");
            _quit = true;
        }
        int squaresFilled = 0;
        for(int i = 0; i<_squars.Count(); i ++)
        {
            if(_squars.GetSquare(i).State() != ' ')
            {
                squaresFilled ++;
            }
        }

        if(squaresFilled > 7)
        {
            Console.WriteLine("Draw/Cats");
            _quit = true;
        }
    }

    public void Run()
    {
        while (!_quit)
        {
            Console.Clear();
            displayHelp();
            ShowBoard();
            checkWin();
            if(_quit == true)
            {
                break;
            }
            ProcessUserInput();
        }
    }

    public void DisplayBar()
    {
        Console.WriteLine("-+-+-");
    }


    public void ShowBoard()
    {
        string line = _squars.GetSquare(0).State() + "|" + _squars.GetSquare(1).State() + "|" + _squars.GetSquare(2).State();
        string line2 = _squars.GetSquare(3).State() + "|" + _squars.GetSquare(4).State() + "|" + _squars.GetSquare(5).State();
        string line3 = _squars.GetSquare(6).State() + "|" + _squars.GetSquare(7).State() + "|" + _squars.GetSquare(8).State();
        Console.WriteLine(line);
        DisplayBar();
        Console.WriteLine(line2);
        DisplayBar();
        Console.WriteLine(line3);
    }

    public void ProcessUserInput()
    {
        bool turnOver = false;
        if(X == true)
        {
            Console.WriteLine("X's turn");
            while(turnOver == false)
            {
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    if(_squars.CheckSquar(0) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(0,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D2:
                    if(_squars.CheckSquar(1) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(1,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D3:
                    if(_squars.CheckSquar(2) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(2,'X');
                        turnOver = true;
                    }
                    
                    break;
                    case ConsoleKey.D4:
                    if(_squars.CheckSquar(3) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(3,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D5:
                    if(_squars.CheckSquar(4) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(4,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D6:
                    if(_squars.CheckSquar(5) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(5,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D7:
                    if(_squars.CheckSquar(6) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(6,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D8:
                    if(_squars.CheckSquar(7) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(7,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D9:
                    if(_squars.CheckSquar(8) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(8,'X');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.Escape:
                    Console.WriteLine("X forfit");
                    turnOver = true;
                    _quit = true;
                    break;
                }
            }
            turnOver = false;
        }

        if(X != true)
        {
            Console.WriteLine("O's turn");
            while(turnOver == false)
            {
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    if(_squars.CheckSquar(0) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(0,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D2:
                    if(_squars.CheckSquar(1) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(1,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D3:
                    if(_squars.CheckSquar(2) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(2,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D4:
                    if(_squars.CheckSquar(3) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(3,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D5:
                    if(_squars.CheckSquar(4) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(4,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D6:
                    if(_squars.CheckSquar(5) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(5,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D7:
                    if(_squars.CheckSquar(6) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(6,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D8:
                    if(_squars.CheckSquar(7) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(7,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.D9:
                    if(_squars.CheckSquar(8) == false)
                    {
                        turnOver = false;
                    }else
                    {
                        _squars.setSquare(8,'O');
                        turnOver = true;
                    }
                    break;
                    case ConsoleKey.Escape:
                    Console.WriteLine("O forfit");
                    turnOver = true;
                    _quit = true;
                    break;
                }
            }
        }
        ToggleTurn();
    }

    public void ToggleTurn()
    {
        if(X == true)
        {
            X = false;
        }else
        {
            X = true;
        }
    }
}

public class Squars
{
    // new list
    private List<Square> _Squares = new List<Square>();

    public Squars()
    {
        fillAllSquares();
    }

    public void fillAllSquares()
    {
        for(int i = 0; i<Count(); i++)
        {
            AddSquar(' ');
        }
    }

    public void setSquare(int index, char set)
    {
        for(int i = 0; i<Count(); i++)
        {
            if(_Squares.IndexOf(_Squares[i]) == index)
            {
                GetSquare(index).setState(set);
            }
        }
    }

    public bool CheckSquar(int index)
    {
        // used to check if the squar is filled with something other than a ' '
        if(GetSquare(index).State() != ' ')
        {
            Console.WriteLine("You can not pick that spot it is already filled");
            return false;
        }
        return true;
    }
    public void AddSquar(char input)
    {
        //should add a square to the list _Squares
        Square newSquare = new Square(input);
        _Squares.Add(newSquare);
    }

    public Square GetSquare(int index)
    {
        //used for accesing a certain square in the list by index
        return _Squares[index];
    }

    public int Count()
    {
        int num = 1;
        // count should have a fixed set of 9 because that is how many squars there is in a tic tac toe game
        for(int i = 0; i<8; i++)
        {
            num ++;
        }
        return num;
    }
}

public class Square
{
    //The fill char is what is in the square
    private Char Fill;
    public Square()
    {
        //defualt is leaving it blank or well with a space
        Fill = ' ';
    }
    public Square(Char XorO)
    {
        //Could have some logic making sure you do not put anything but an X or a O in it
        //for now it will just let you put anything in it.
        Fill = XorO;
    }

    public char State()
    {
        // is used to acces what is in the Square
        return Fill;
    }
    public void setState(char input)
    {
        Fill = input;
    }
    void ShowState()
    {
        // is used to look at what is in the square
        Console.WriteLine(State());
    }
}