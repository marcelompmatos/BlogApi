## PPara Rodar o projeto no Sql Server

## Criar banco de dados com o nome "Blog"  👋

## Criar Criar as tabelas abaixo"  👋

```json
{
CREATE TABLE BlogPost (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Content TEXT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Comment (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PostId INT NOT NULL,
    Content TEXT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PostId) REFERENCES BlogPost(Id) ON DELETE CASCADE
);

  }
}
