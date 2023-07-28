
# Desafio Dev

Projeto DesafioDev foi desenvolvido para o teste técnico da Bycoders. 




## Tecnologias

**Back-end:** .NET 6

**Banco de dados:** SQL Server

## Ferramentas necessárias

**Back-end:** Visual Studio, Docker

**Testes integrados:** Postman


## Funcionalidades

- Upload de arquivo
- Lista com totalizador de saldo


## Documentação da API

#### Upload do arquivo

```http
  POST /api/file/upload
```
| Content-Type | multipart/form-data |
| :----------- | :------------------


| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `file` | `IFormFile` | **Obrigatório**. Arquivo que será enviado. |

#### Lista Estabelecimento com totalizador

```http
  GET /api/establishment
```
## Debug

- Para executar a aplicação localmente crie um database localmente e insira a connection string no "appsettings.Development.json" .

Obs: Ao executar o projeto a migration será executada automáticamente criando as tabelas em sua database.

## Instalação

- Clone o projeto para sua máquina em seu local de preferência.

- Com o Docker instalado em sua máquina, navegue até a raiz do seu projeto pelo terminal. 

- Na raiz do projeto execute o seguinte comando "docker-compose up -d".

- Quando o processo concluir acesse a rota "http://localhost:8001/health" para conferir se o serviço foi iniciado.

Obs: através do docker compose, será feito o download da imagem e configurado o container, tanto do .net quanto do SQL Server, irá criar o banco de dados e ao executar a aplicação automaticamente executará a migration, com isso toda nossa aplicação estará pronta para uso.


## Testes Integrados

- Abra o Postman.
- Importe a configuração salva no diretório do projeto (integration-test).
- Execute a colletion para obter o resultado dos testes.