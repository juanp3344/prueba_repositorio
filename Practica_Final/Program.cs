using System.Security.Cryptography.X509Certificates;

var Lista_Bibliotecas = new List<Bibliotecas>();
Lista_Bibliotecas.Add(new Bibliotecas(){ id= 1, Nombre = "Biblioteca del paisa", Ciudad = "Medellin", correo_electronico= "Paisa@Gmail.com", Telefono = "300938AC", Activa = true});
Lista_Bibliotecas.Add(new Bibliotecas(){ id= 2, Nombre = "Biblioteca del vago", Ciudad = "Bucaramanga", correo_electronico= "Vagosalcan@Gmail.com", Telefono = "3009219319", Activa = true});
Lista_Bibliotecas.Add(new Bibliotecas(){ id= 3, Nombre = "Bibliotecarios yeah", Ciudad = "Medellin", correo_electronico= "yeahboiiiiiii@Gmail.com", Telefono = "1074983521", Activa = false});

var Lista_Prestamos = new List<Prestamos>();
Lista_Prestamos.Add(new Prestamos(){ Id= 1, Fecha_Inicio = DateTime.Parse("2025-12-12"), Fecha_Fin = DateTime.Parse("2025-12-26"), Activo = true, Estado = "Atrasado", Usuario = 1, Biblioteca =1, Libro = 2 });
Lista_Prestamos.Add(new Prestamos(){ Id= 2, Fecha_Inicio = DateTime.Parse("2026-02-12"), Fecha_Fin = DateTime.Parse("2026-03-01"), Activo = true, Estado = "Activo", Usuario =2, Biblioteca=1, Libro = 3});
Lista_Prestamos.Add(new Prestamos(){ Id= 3, Fecha_Inicio = DateTime.Parse("2026-02-15"), Fecha_Fin = DateTime.Parse("2026-02-24"), Activo = true, Estado = "Atrasado", Usuario = 3, Biblioteca= 2, Libro = 1});

var Lista_Libros = new List<Libros>();
Lista_Libros.Add(new Libros(){ id= 1, Titulo = "EL AVE Y EL PERSA",ISBN = "37827-23872", Activo = false, Biblioteca = 1, Autor = 3});
Lista_Libros.Add(new Libros(){ id= 2, Titulo = "MIRA LAS HORAS DEL ARREPENTIMIENTO",ISBN = "83822-54472", Activo = true, Biblioteca = 1, Autor = 2});
Lista_Libros.Add(new Libros(){ id= 3, Titulo = "EL PROTAGONISTA",ISBN = "43782-950432", Activo = false, Biblioteca = 2, Autor = 1});


var Lista_Usuarios = new List<Usuarios>();
Lista_Usuarios.Add(new Usuarios(){ id= 1, Nombre = "Pedro", Cedula = "81239892AC", Activo= true, Fecha_Registro = DateTime.Parse("2025-12-14"), Biblioteca = 2 });
Lista_Usuarios.Add(new Usuarios(){ id= 2, Nombre = "Mano", Cedula = "5894839358", Activo= false, Fecha_Registro = DateTime.Parse("2024-12-03"), Biblioteca = 2 });
Lista_Usuarios.Add(new Usuarios(){ id= 3, Nombre = "Carla", Cedula = "437287212", Activo= true, Fecha_Registro = DateTime.Parse("2023-06-14"), Biblioteca = 1 });

Console.WriteLine("PRESTAMOS CON RETRASOS: ");
metodos.VerificarRetrasos(Lista_Prestamos);
public class metodos
{
    public static void VerificarRetrasos(List<Prestamos> prestamos)
    {
        foreach(var prestamoAtrasado in prestamos.Where(x => x.Estado.Equals("Atrasado")))
        {
             Console.WriteLine(prestamoAtrasado.Id + "|" + 
        prestamoAtrasado.Fecha_Inicio + "|" + 
        prestamoAtrasado.Fecha_Fin + "|" + 
        prestamoAtrasado.Activo + "|" +  
        prestamoAtrasado.Estado + "|" + 
        prestamoAtrasado.Usuario);  
        }
    }
}
public class Bibliotecas{
    public int id {get; set;}
    public string? Nombre {get; set;}
    public string? Ciudad {get; set;}
    public string? correo_electronico {get; set;}
    public string? Telefono {get; set;}
    public bool Activa {get; set;}

    public List<Prestamos>? Prestamo{get; set;}
    public List<Libros>? Libro{get; set;}
    public List<Usuarios>? Usuario{get; set;}
}

public class Libros{
public int id {get; set;}
public string? Titulo {get; set;}
public string? ISBN {get; set;}
public bool Activo {get; set;}
public int Biblioteca {get; set;}
public int Autor {get; set;}

public Bibliotecas? _Biblioteca {get; set;}
public Autores? _Autor {get; set;}
public List<Prestamos>? Prestamo{get; set;}
}

public class Usuarios: Personas{
public DateTime Fecha_Registro{get; set;}
public int Biblioteca {get; set;}

public Bibliotecas? _Biblioteca {get; set;}
public List<Prestamos>? Prestamos {get; set;}
}

public class Personas{
public int id {get; set;}
public string?  Nombre {get; set;}
public string? Cedula {get; set;}
public bool Activo {get; set;}

}

public class Prestamos{
    public int Id{get; set;}
    public DateTime Fecha_Inicio{get; set;}
    public DateTime Fecha_Fin{get; set;}
    public bool Activo{get; set;}
    public string? Estado{get; set;}
    public int Multa {get; set;}
    public int Usuario {get; set;}
    public int Biblioteca {get; set;}
    public int Libro {get; set;}


    public Multas? _Multa {get; set;}
    public Usuarios? _Usuario {get; set;}
    public Bibliotecas? _Biblioteca {get; set;}
    public Libros? _Libro {get; set;}
}

public class Autores: Personas{
public string? Nacionalidad{get; set;}

public List<Libros>? Libro{get; set;}
}

public class Categorias{
    public int id {get; set;}
    public string? Nombre {get; set;}
    public string? Descripcion {get; set;}
    public bool Activo {get; set;}
}

public class Multas{
    public int id {get; set;}
    public decimal costo {get; set;}
    public DateTime Fecha {get; set;}
    public bool Activo {get; set;}
    public int prestamo {get; set;}

    public Prestamos? _prestamo {get; set;}
}