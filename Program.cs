using System.Xml.Serialization;

//chasis
//marca
//modelo
//precio
//año fabricacion



Console.WriteLine("Serializacion XML en C#\r");
Console.WriteLine("-----------\n");

XmlSerializer formateador = new XmlSerializer(typeof(Datos));
Stream miStream = null;
Datos registro = null;


int chasis;
string valorChasis = "";
string marca = "";
string modelo = "";
decimal precio = 0.0M;
string valorPrecio = "";
int año;
string valorAño = "";


// Pídale al usuario que elija una opción
Console.WriteLine("Elija una opción de la siguiente lista:");
Console.WriteLine("\ts - Crear y serializar registro");
Console.WriteLine("\td - Deserializar registro");
Console.Write("¿Su opción? ");

string op = Console.ReadLine();

switch (op)
{
    case "s":
        // Se crea el Stream
        miStream = new FileStream("clientes.xml", FileMode.OpenOrCreate,
            FileAccess.Write);

        // Creamos el objeto de registro

        // Pida al usuario que escriba el número de serie del chasis.
        Console.Write("Escriba el número de serie del chasis y luego presione Enter: ");
        valorChasis = Console.ReadLine();

        while (!int.TryParse(valorChasis, out chasis))
        {
            Console.Write("Esta entrada no es válida. Introduzca un valor entero: ");
            valorChasis = Console.ReadLine();
        }

        // Pida al usuario que escriba el nombre de la marca
        Console.Write("Escriba la marca del carro y luego presione Enter: ");
        marca = Console.ReadLine();

        // Pida al usuario que escriba el modelo de la marca
        Console.Write("Escriba el modelo de la marca y luego presione Enter: ");
        modelo = Console.ReadLine();

        // Pida al usuario que escriba el precio del carro
        Console.Write("Escriba el precio del carro y luego presione Enter: ");
        valorPrecio = Console.ReadLine();

        while (!decimal.TryParse(valorPrecio, out precio))
        {
            Console.Write("Esta entrada no es válida. Introduzca un valor decimal ");
            valorPrecio = Console.ReadLine();
        }

        // Pida al usuario que escriba el año de fabricacion.
        Console.Write("Escriba el año de fabricacion y luego presione Enter: ");
        valorAño = Console.ReadLine();

        while (!int.TryParse(valorAño, out año))
        {
            Console.Write("Esta entrada no es válida. Introduzca un valor entero: ");
            valorChasis = Console.ReadLine();
        }

        registro = new Datos(chasis, marca, modelo,
            precio, año);

        Console.WriteLine("\n");
        Console.WriteLine("Registro a serializar");
        Console.WriteLine(registro.ToString());

        // Empezamos la serialización
        Console.WriteLine("-------------- Serializamos --------------");

        // Serializamos
        formateador.Serialize(miStream, registro);

        // Cerramos el Stream
        miStream.Close();

        break;
    case "d":
        // Deserialziamos el objeto
        Console.WriteLine("-------------- Deserializamos --------------");

        // Abrimos Stream
        miStream = new FileStream("clientes.xml", FileMode.Open,
            FileAccess.Read);

        //Deserializamos
        registro = (Datos)formateador.Deserialize(miStream);

        // Cerramos el Stream
        miStream.Close();

        // Usamos el objeto
        Console.WriteLine("El registro deserializado es");
        Console.WriteLine(registro.ToString());

        break;
    default:
        Console.WriteLine("Opción inválida");
        break;
}

[Serializable]
public class Datos
{
    private int chasisSerie;
    private string marca;
    private string modelo;
    private decimal precio;
    private int añoFabricacion;


    //chasis
    //marca
    //modelo
    //precio
    //año fabricacion

    public Datos() : this(0, "", "", 0.0M, 0)
    {

    }

    public Datos(int valorChasis, string valorMarca,
        string valorModelo, decimal valorPrecio, int valorAño)
    {
        ChasisSerie = valorChasis;
        Marca = valorMarca;
        Modelo = valorModelo;
        Precio = valorPrecio;
        AñoFabricacion = valorAño;
    }

    public int ChasisSerie { get => chasisSerie; set => chasisSerie = value; }
    public string Marca { get => marca; set => marca = value; }
    public string Modelo { get => modelo; set => modelo = value; }
    public decimal Precio { get => precio; set => precio = value; }
    public int AñoFabricacion { get => añoFabricacion; set => añoFabricacion = value; }

    //public int Cuenta { get => cuenta; set => cuenta = value; }
    //public string Nombre { get => nombre; set => nombre = value; }
    //public string Apellido { get => apellido; set => apellido = value; }
    //public decimal Saldo { get => saldo; set => saldo = value; }

    public override string ToString()
    {
        return "Chasis: " + ChasisSerie + "\n" +
            "Marca: " + Marca + "\n" +
            "Modelo: " + Modelo + "\n" +
            "Precio: " + Precio + "\n"+
            "Año de fabricación: " + AñoFabricacion + "\n";
    }

}


