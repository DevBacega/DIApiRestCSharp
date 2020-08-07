# Web Api com Dot Net

Olá! Criei essa Web Api como intuito de estudo, no qual implemento um pouco de Design Patterns, o qual estou usando é o Repository and Service Pattern.


# Executando

Para executar o projeto em sua maquina, faça um fork do projeto e crie um banco de dados no MSSQL para isso ultilize o Script que coloquei no projeto.
Após criar o banco e rodar o Script instale as dependências NuGet do .Net.
 Em seguida abra a classe ConnectionClass e vamos alterar alguns valores da ConnectionString:
  - Password: coloque a senha da instancia MSSQL Instalada em seu PC
  - User ID: coloque o usuário.
  - Initial Catalog: o nome do banco.
  - Data Source: deixe LocalHost ou o ip da maquina que esta o banco instalado.

Após feito tudo isso, basta executar o projeto.

## Rotas

As rotas implementadas no projeto:
 - user : CRUD do Usuario.
 - user/login : Login para o usuario, retorna o token para acesso.
 - category : Categoria dos produtos.
 - access: Direito de acesso do usuario, deixando o acesso de Id 1 como Admin.
 - product : Produtos.

## Duvidas

Se tiver qualquer duvida a mais, pode entrar em contato
Linkedin: [https://www.linkedin.com/in/victor-bacega/](https://www.linkedin.com/in/victor-bacega/)
