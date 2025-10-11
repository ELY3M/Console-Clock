/*
// See https://aka.ms/new-console-template for more information
System.Timers.Timer timer = new System.Timers.Timer();
timer.Interval = 1000;
timer.Elapsed += Timer_Elapsed;
timer.Start();
void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
{
    //Console.WriteLine($"Timer elapsed at {e.SignalTime}\n");
    Console.Write(DateTime.Now.ToString("hh:mm:ss tt"));
}
//Console.WriteLine("Hello, World!");
Console.ReadLine();
*/


byte[] Zero = new byte[]
{
    0b11111111,
    0b11000011,
    0b11000011,
    0b11000011,
    0b11000011,
    0b11000011,
    0b11111111,
};

byte[] One = new byte[]
{
    0b00011000,
    0b00011000,
    0b00011000,
    0b00011000,
    0b00011000,
    0b00011000,
    0b00011000,
};

byte[] Two = new byte[]
{
    0b11111111,
    0b00000011,
    0b00000011,
    0b11111111,
    0b11000000,
    0b11000000,
    0b11111111,
};

byte[] Three = new byte[]
{
    0b11111111,
    0b00000011,
    0b00000011,
    0b01111111,
    0b00000011,
    0b00000011,
    0b11111111,
};

byte[] Four = new byte[]
{
    0b11000011,
    0b11000011,
    0b11000011,
    0b11111111,
    0b00000011,
    0b00000011,
    0b00000011,
};

byte[] Five = new byte[]
{
    0b11111111,
    0b11000000,
    0b11000000,
    0b11111111,
    0b00000011,
    0b00000011,
    0b11111111,
};

byte[] Six = new byte[]
{
    0b11111110,
    0b11000000,
    0b11000000,
    0b11111111,
    0b11000011,
    0b11000011,
    0b11111111,
};

byte[] Seven = new byte[]
{
    0b11111111,
    0b00000011,
    0b00000011,
    0b00000011,
    0b00000011,
    0b00000011,
    0b00000011,
};

byte[] Eight = new byte[]
{
    0b11111111,
    0b11000011,
    0b11000011,
    0b11111111,
    0b11000011,
    0b11000011,
    0b11111111,
};

byte[] Nine = new byte[]
{
    0b11111111,
    0b11000011,
    0b11000011,
    0b11111111,
    0b00000011,
    0b00000011,
    0b01111111,
};

byte[] A = new byte[]
{
    0b11111111,
    0b11000011,
    0b11000011,
    0b11111111,
    0b11000011,
    0b11000011,
    0b11000011,
};

byte[] P = new byte[]
{
    0b11111111,
    0b11000011,
    0b11000011,
    0b11111111,
    0b11000000,
    0b11000000,
    0b11000000,
};

byte[] M = new byte[]
{
    0b11111111,
    0b11011011,
    0b11011011,
    0b11011011,
    0b11011011,
    0b11000011,
    0b11000011,
};

byte[] Dots = new byte[]
{
    0b00000000,
    0b00000000,
    0b00011000,
    0b00000000,
    0b00011000,
    0b00000000,
    0b00000000,
};

byte[][] digitArray = new byte[][] { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, P, A, M };

int clockTop = 5;
int clockLeft = 5;
int digitWidth = 10;
ConsoleColor clockcolor = ConsoleColor.Green;
int position;

bool displayDots = false;
bool displayDots2 = false;
Console.CursorVisible = false;

while (Console.KeyAvailable is false)
{
    Console.Clear();
    position = clockLeft;
    DateTime time = DateTime.Now;

    string hour = time.Hour.ToString().PadLeft(2, '0');
    DisplayDigits(hour);

    //if (displayDots)
    //{
    DrawDigit(Dots, position, clockTop, clockcolor);
    //}
    displayDots = !displayDots;
    position += digitWidth;

    string minute = time.Minute.ToString().PadLeft(2, '0');
    DisplayDigits(minute);

    //if (displayDots2)
    //{
    DrawDigit(Dots, position, clockTop, clockcolor);
    //}
    displayDots2 = !displayDots2;
    position += digitWidth;

    string seconds = time.Second.ToString().PadLeft(2, '0');
    DisplayDigits(seconds);

    position += digitWidth;

    //AM or PM
    if (time.Hour >= 12)
        DrawDigit(P, position, clockTop, clockcolor);
    else
        DrawDigit(A, position, clockTop, clockcolor);
    position += digitWidth;
    DrawDigit(M, position, clockTop, clockcolor);


    Console.ResetColor();
    await Task.Delay(1000);
}
Console.CursorVisible = true;

Console.WriteLine();
Console.WriteLine("Finished drawing");

void DisplayDigits(string digits)
{
    foreach (var c in digits)
    {
        int n = int.Parse($"{c}");
        DrawDigit(digitArray[n], position, clockTop, clockcolor);
        position += digitWidth;
    }
}


void DrawDigit(byte[] digit, int X, int Y, ConsoleColor color)
{
    foreach (byte row in digit)
    {
        for (int bitPosition = 0; bitPosition < 8; bitPosition++)
        {
            var mark = (row & (128 >> bitPosition)) != 0;
            if (mark)
            {
                Draw(X + bitPosition, Y, color);
            }
        }
        Y++;
    }
}

static void Draw(int X, int Y, ConsoleColor Color)
{
    Console.SetCursorPosition(X, Y);
    Console.BackgroundColor = Color;
    Console.Write(" ");
}

