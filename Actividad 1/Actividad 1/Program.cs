using System;

namespace Actividad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            float multiplicacion;

            Vector vector_1 = new Vector();
            Vector vector_2 = new Vector();
            Vector vector_mult = new Vector();
            Vector vector_resta = new Vector();

            vector_1.coordenadas(1, 1, 4, 3);
            vector_2.coordenadas(2, 3, 4, 3);

            vector_resta = vector_1 - vector_2;
            multiplicacion = vector_1 * vector_2;

            vector_mult = vector_1 * 2; //puede modificarse el vector y el entero

            Console.WriteLine($"El resultado de la resta:");
            vector_resta.mostrar_coordenadas();

            Console.WriteLine($"\nEl resultado del entero por el vector:");
            vector_mult.mostrar_coordenadas();

            Console.WriteLine($"\nEl resultado de vector*vector:");
            Console.WriteLine($"{multiplicacion}");
        }

        public class Punto
        {
            //atributos de un punto
            private float coordenada_X;
            private float coordenada_Y; 

            //constructor parametrico
            public Punto(float X, float Y)
            {
                coordenada_X = X;
                coordenada_Y = Y;
            }

            //constructor por defecto
            public Punto()
            {
                coordenada_X = 0;
                coordenada_Y = 0;
            }

            //metodos de un punto
            public void IngresarXY(float X, float Y)
            {
                coordenada_X = X;
                coordenada_Y = Y;
            }
            //ingresar datos

            public float MostrarX()
            {
                return coordenada_X;
            }
            //Obtener valor de X

            public float MostrarY()
            {
                return coordenada_Y;
            }
            //Obtener valor de Y
        }

        public class Vector
        {
            //atributos del vector
            private Punto origen;
            private Punto fin;
            double magnitud;

            //constructor por defecto
            public Vector()
            {
                origen = new Punto(0, 0);
                fin = new Punto(0, 0);
            }

            //constructor parametrico
            public Vector(Punto primera_coordenada, Punto segunda_coordenada)
            {
                origen = primera_coordenada;
                fin = segunda_coordenada;
            }

            //metodos 
            public void coordenadas(float X1, float Y1, float X2, float Y2)
            {
                origen.IngresarXY(X1, Y1);
                fin.IngresarXY(X2, Y2);
            }
            //ingresar datos

            public double calcular_magnitud()
            {
                magnitud = Math.Sqrt(Math.Pow((fin.MostrarX() - origen.MostrarX()), 2) + Math.Pow((fin.MostrarY() - origen.MostrarY()), 2));
                return magnitud;
            }

            //metodo para la resta
            public static Vector operator -(Vector primer_vector, Vector segundo_vector)
            {
                Punto Nueva_x = new Punto(primer_vector.origen.MostrarX() - segundo_vector.origen.MostrarX(),
                                          primer_vector.origen.MostrarY() - segundo_vector.origen.MostrarY());

                Punto Nueva_y = new Punto(primer_vector.fin.MostrarX() - segundo_vector.fin.MostrarX(),
                                          primer_vector.fin.MostrarY() - segundo_vector.fin.MostrarY());

                return new Vector(Nueva_x, Nueva_y);
            }

            //metodo para multiplicar un vector por un entero
            public static Vector operator *(Vector primer_vector, int escalar)
            {
                Punto Nueva_x = new Punto(primer_vector.origen.MostrarX() * escalar, primer_vector.origen.MostrarY() * escalar);

                Punto Nueva_y = new Punto(primer_vector.fin.MostrarX() * escalar, primer_vector.fin.MostrarY() * escalar);

                return new Vector(Nueva_x, Nueva_y);
            }

            //metodo para multiplicar un vector por otro vector
            public static float operator *(Vector primer_vector, Vector segundo_vector)
            {
                float solucion1 = (primer_vector.origen.MostrarX() * segundo_vector.origen.MostrarX()) + 
                                  (primer_vector.origen.MostrarY() * segundo_vector.origen.MostrarY());

                float solucion2= (primer_vector.fin.MostrarX() * segundo_vector.fin.MostrarX()) + 
                                 (primer_vector.fin.MostrarY() * segundo_vector.fin.MostrarY());

                return solucion1 + solucion2;
            }

            //metodo para mostrar datos del vector
            public void mostrar_coordenadas()
            {
                Console.WriteLine($"({origen.MostrarX()}, {origen.MostrarY()})({fin.MostrarX()}, {fin.MostrarY()})");
            }
        }
    }
}