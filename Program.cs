
using System.Runtime.Intrinsics.X86;

CalcularFibonacci(0, null, null);

void CalcularFibonacci(int n, Fibonacci obj1, Fibonacci obj2)
{
    if (n < 1000)
    {
        if (n <= 1)
        {
            if (n == 0)
            {
                ArregloDeDatos b1 = new ArregloDeDatos(null, null, 1);
                obj1 = new Fibonacci(null, null, b1);
                b1.Anterior = b1;
                Console.WriteLine(n + ": " + b1.Datos);
                CalcularFibonacci(n + 1, obj1, null);
            }
            if (n == 1)
            {
                ArregloDeDatos b2 = new ArregloDeDatos(null, null, 1);
                obj2 = new Fibonacci(null, obj1, b2);
                obj1.Siguiente = obj2;
                obj2.Inicio.Anterior = obj2.Inicio;
                Console.WriteLine(n + ": " + b2.Datos);
                CalcularFibonacci(n + 1, obj1, obj2);
            }
        }
        else
        {
            ArregloDeDatos b3 = new ArregloDeDatos(null, null, 0);
            Fibonacci obj3 = new Fibonacci(null, obj2, b3);
            obj2.Siguiente = obj3;
            b3.Anterior = b3;
            Console.Write(n + ": ");
            SumarDatos(obj1.Inicio, obj2.Inicio, b3);
            Console.WriteLine();
            CalcularFibonacci(n + 1, obj2, obj3);
        }   
    }
}

void SumarDatos(ArregloDeDatos b1, ArregloDeDatos b2, ArregloDeDatos b3)
{
    bool extra = false;
    if (b1 != null && b2 != null)
    {
        b3.Datos = b1.Datos + b2.Datos + b3.Datos;
    }
    if (b1 != null && b2 == null)
    {
        b3.Datos = b3.Datos + b1.Datos;
    }
    if (b1 == null && b2 != null)
    {
        b3.Datos = b3.Datos + b2.Datos;
    }
    if (b3.Datos > 9)
    {
        if (b3.Siguiente == null)
        {
            ArregloDeDatos b4 = new ArregloDeDatos(null, b3, 1);
            b3.Siguiente = b4;
            extra = true;
        }
        else
        {
            b3.Siguiente.Datos = b3.Siguiente.Datos + 1;
        }
        b3.Datos = b3.Datos - 10;
      
    }
    if (b2.Siguiente != null)
    {
        if (b3.Siguiente == null)
        {
            ArregloDeDatos b5 = new ArregloDeDatos(null, null, 0);
            b5.Anterior = b3;
            b3.Siguiente = b5;
        }
        SumarDatos(b1.Siguiente, b2.Siguiente, b3.Siguiente);
        extra = false;
    }
    if(extra == true)
    {
        Console.Write(b3.Siguiente.Datos);
    }
    
    Console.Write(b3.Datos);
}


public class ArregloDeDatos
{
    public ArregloDeDatos Siguiente;
    public ArregloDeDatos Anterior;
    public int Datos;
    public ArregloDeDatos(ArregloDeDatos siguiente, ArregloDeDatos anterior, int datos)
    {
        Siguiente = siguiente;
        Anterior = anterior;
        Datos = datos;
    }
}

public class Fibonacci
{
    public Fibonacci Siguiente;
    public Fibonacci Anterior;
    public ArregloDeDatos Inicio;
    public Fibonacci Bandera;
    public Fibonacci(Fibonacci siguiente, Fibonacci anterior, ArregloDeDatos inicio)
    {
        Siguiente = siguiente;
        Anterior = anterior;
        Inicio = inicio;
    }
}
