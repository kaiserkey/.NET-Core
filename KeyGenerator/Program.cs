using System;
using System.Security.Cryptography;
using System.Text;

public class KeyGenerator{
    public static string GenerateRandomKey(int length){
        // Definir el tamaño del byte array para la clave (debe ser divisible por 2)
        if (length % 2 != 0)
            throw new ArgumentException("La longitud debe ser un número par.");
        /*
        Esta línea asegura que la longitud especificada para la clave sea un número par. Como cada byte se convertirá en dos caracteres hexadecimales, la longitud debe ser divisible por 2 para obtener una clave hexadecimal válida.
        */

        // Crear un array de bytes del tamaño especificado
        byte[] randomBytes = new byte[length / 2];
        /*
        Aquí se crea un array de bytes (randomBytes) del tamaño especificado dividido por 2. Esto se debe a que cada byte se convertirá posteriormente en dos caracteres hexadecimales en la cadena resultante.
        */

        // Utilizar RNGCryptoServiceProvider para generar bytes aleatorios
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(randomBytes);
        }
        /*
        RNGCryptoServiceProvider es una clase en .NET que proporciona métodos para generar bytes aleatorios de forma segura y criptográficamente sólida. GetBytes se utiliza para llenar el array randomBytes con bytes aleatorios generados por el proveedor criptográfico.
        */

        // Convertir bytes a una cadena hexadecimal
        string key = BitConverter.ToString(randomBytes).Replace("-", "");
        /*
        BitConverter.ToString(randomBytes) convierte el array de bytes randomBytes en una cadena donde cada byte se representa como dos caracteres hexadecimales separados por un guion ("-").
        Replace("-", "") elimina los guiones ("-") de la cadena resultante, dejando solo los caracteres hexadecimales como una cadena continua.
        */

        return key;
        /*
        Finalmente, la función devuelve la clave generada en formato hexadecimal como una cadena de caracteres. Esta clave se puede utilizar para cifrar o firmar datos de forma segura en aplicaciones que requieren claves aleatorias y seguras.
        */
    }
}
/**
    En el método Main, se llama a GenerateRandomKey(32) para obtener una clave aleatoria de 32 bytes (64 caracteres hexadecimales). Esta clave se imprime en la consola para que puedas verla.
*/
class program {
    static void Main() {
        // Ejemplo de generación de clave de longitud 32
        string randomKey = KeyGenerator.GenerateRandomKey(32);
        Console.Write("Clave generada aleatoriamente -> ");
        Console.Write(randomKey);
    }
}