using System.Data.SQLite;
using System.IO;

public class TestDbFactory
{
    public static string CriarBancoTeste()
    {
        string path = "POC.db";
        if (File.Exists(path)) File.Delete(path);

        SQLiteConnection.CreateFile(path);
        using (var conn = new SQLiteConnection($"Data Source={path};Version=3;"))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                -- Tabela de Autores
                CREATE TABLE TB_AUTORES (
                    id_autor INTEGER PRIMARY KEY,
                    nm_autor TEXT NOT NULL
                );

                -- Tabela de Gêneros
                CREATE TABLE TB_GENEROS (
                    id_genero INTEGER PRIMARY KEY,
                    nm_genero TEXT NOT NULL
                );

                -- Tabela de Livros
                CREATE TABLE TB_LIVROS (
                    id_livro INTEGER PRIMARY KEY,
                    ds_titulo TEXT NOT NULL,
                    id_autor INTEGER,
                    id_genero INTEGER,
                    FOREIGN KEY (id_autor) REFERENCES Autores(id_autor),
                    FOREIGN KEY (id_genero) REFERENCES Generos(id_genero)
                );

                -- Dados de Autores
                INSERT INTO TB_AUTORES (nm_autor) VALUES 
                    ('Machado de Assis'),
                    ('Clarice Lispector');

                -- Dados de Gêneros
                INSERT INTO TB_GENEROS (nm_genero) VALUES 
                    ('Romance'),
                    ('Filosofia');

                -- Dados de Livros
                INSERT INTO TB_LIVROS (ds_titulo, id_autor, id_genero) VALUES 
                    ('Dom Casmurro', 1, 1),
                    ('A Hora da Estrela', 2, 1),
                    ('Perto do Coração Selvagem', 2, 2);
            ";
            cmd.ExecuteNonQuery();
        }

        return $"Data Source={path};Version=3;";
    }
}
