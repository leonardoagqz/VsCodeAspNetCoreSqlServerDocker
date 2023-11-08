# VsCodeAspNetCoreSqlServerDocker
Docker - Conteineirizando (Aplicação: Asp.Net Core) e (Banco de Dados: SqlServer) | Utilizando IDE VsCode | Para fins de estudo.

Detalhes sobre as etapas:

Utilizando VsCode como IDE

Criando container do Sql Server utilizando imagem oficial.

Baixando a imagem
- docker pull mcr.microsoft.com/mssql/server:2022-latest

Criando Container
- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=xxxxxxxx" -p 1450:1433 --name sqlserverdb -d  mcr.microsoft.com/mssql/server:2022-latest

![image](https://github.com/leonardoagqz/VsCodeAspNetCoreSqlServerDocker/assets/38500433/97591376-800b-4067-a7dc-18425e3a1169)


Cria um novo projeto dotnet no modelo mvc no diretório livraria sem ter serviço autenticação
- dotnet new mvc -o nomeProjeto -au none
    
Incluir poacotes do EF Core
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.EntityFrameworkCore.Design

Configurando conexão com banco no arquivo appsettings
- "DefaultConnection": "Initial Catalog=NovoDb; Data Source=localhost,1450; Persist Security Info=True; TrustServerCertificate=true; User ID=SA;Password= xxxxxxx"

Comando para criar a migration:
- dotnet ef migrations add Inicial

Conteinerizando a aplicação Asp .NET Core

- Criar o arquivo Dockerfile
- Definir as intruções para criação da imagem
- Criar a Imagem   
 

Criar e configurar arquivo: docker-compose.yml

Configuração essencial para que a aplicação .Net no container consiga acessar o banco de dados sqlserver do container

