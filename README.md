## Para Rodar o projeto no Sql Server

## Criar banco de dados com o nome "Blog"  👋

## Criar as tabelas abaixo"  👋

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
```

 ## Melhorias  👋
```json
1. Tratamento Global de Erros 
2. Validação de Entrada com FluentValidation
3. Notificações de Domínio
4. Logging Profissional com Serilog
5. Validação de ModelState
6. Controle de Versionamento da API
7. Segurança e Validação de Token (JWT/Claims)
```
