//Ejercicio 1

namespace EstacionPruebaMotor
{
    // CLASE: Representa el motor de corriente directa a evaluar
    public class MotorDC
    {
        // PROPIEDADES
        public string Id { get; set; }
        public double Voltaje { get; set; }
        public double Corriente { get; set; }

        // CONSTRUCTOR
        public MotorDC(string id, double voltaje, double corriente)
        {
            Id = id;
            Voltaje = voltaje;
            Corriente = corriente;
        }

        // MÉTODOS

        // Método que calcula la potencia eléctrica en Watts (P = V * I)
        public double CalcularPotencia()
        {
            return Voltaje * Corriente;
        }

        // Método que determina la condición de consumo del motor
        public string ObtenerEstadoConsumo()
        {
            double potencia = CalcularPotencia();
            if (potencia <= 120.0)
            {
                return "Consumo normal";
            }
            else
            {
                return "Consumo elevado";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" ESTACIÓN DE PRUEBA: EVALUACIÓN DE MOTOR DC ");
            Console.WriteLine("==================================================\n");

            // Captura del identificador
            Console.Write("Ingrese el identificador del motor (ID): ");
            string idInput = Console.ReadLine();

            // Validaciones de entrada para evitar números negativos y entradas no numéricas
            double voltajeInput = LeerNumeroPositivo("Ingrese el voltaje de alimentación [V]: ");
            double corrienteInput = LeerNumeroPositivo("Ingrese la corriente consumida [A]: ");

            // OBJETO: Instanciación del objeto motorEvaluado a partir de la clase MotorDC
            MotorDC motorEvaluado = new MotorDC(idInput, voltajeInput, corrienteInput);

            // CÁLCULO Y SALIDA
            double potenciaCalculada = motorEvaluado.CalcularPotencia();
            string estadoMotor = motorEvaluado.ObtenerEstadoConsumo();

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("               RESULTADOS DEL DIAGNÓSTICO         ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Identificador del motor : {motorEvaluado.Id}");
            Console.WriteLine($"Voltaje introducido     : {motorEvaluado.Voltaje:F2} V");
            Console.WriteLine($"Corriente introducida   : {motorEvaluado.Corriente:F2} A");
            Console.WriteLine($"Potencia calculada      : {potenciaCalculada:F2} W");
            Console.WriteLine($"Estado de consumo       : {estadoMotor}");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // MÉTODO AUXILIAR DE VALIDACIÓN: Previene ciclos infinitos y lecturas erróneas
        static double LeerNumeroPositivo(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out valor))
                {
                    if (valor >= 0)
                    {
                        return valor; // Entrada válida
                    }
                    else
                    {
                        Console.WriteLine("Error: El valor no puede ser negativo. Intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Ingrese un valor numérico válido.");
                }
            }
        }
    }
}