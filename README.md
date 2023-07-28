
## Instalação

- Clone o projeto para sua máquina em seu local de preferência.

- Com o Docker instalado em sua máquina, navegue até a raiz do seu projeto pelo terminal. 

- Na raiz do projeto execute o seguinte comando "docker-compose up -d".

- Quando o processo concluir acesse a rota "http://localhost:8001/health" para conferir se o serviço foi iniciado.

Obs: através do docker compose, será feito o download da imagem e configurado o container, tanto do .net quanto do SQL Server, irá criar o banco de dados e ao executar a aplicação automaticamente executará a migration, com isso toda nossa aplicação estará pronta para uso.