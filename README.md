# Bar do DG - API em .Net Core e Front em Angular

- Versão do Framework da API: .Net Core 2.2 (\BarDG\src\BarDg\BarDg.sln)
- Versão do Front-End Angular: 9.1.11 (\BarDG\src\BarDg\bar-dg-front)

## Pontos de evolução futura:

Criar uma tela para a consulta e listagem de demandas criadas.

## Estratégias:

Foi adotada a estratégia de utilizar tecnologias mais atuais como .Net core e Angular, pois o meu conhecimento é u pouco mais amplo nestas tecnologias. Estas tecnologias também são minhas ferramentas de trabalho atuais.
A autenticação via token foi escolhida pela segurança e também ser uma ferramenta que está sendo muito utilizada nos dias atuais e também muito bem avaliada.

## Configurações

### _1 - Passo a Passo Banco:_

1. Executar o script de criação das tabelas (\BarDG\DB\1 - Banco.sql)
2. Executar o script de geração das cargas das tabelas (\BarDG\DB\2 - Carga.sql)
3. Opcional: Para criar um novo usuário de autenticação da API utilizar o script localizado em \BarDG\DB\Criar novo Usuário.sql alterar nas variaveis do front (Configurações 3 - Passo a Passo FRONT, observações).

### _2 - Passo a Passo API:_

1. Alterar a variável 'ConnectionString' do appsettings.json;

### _3 - Passo a Passo FRONT:_

1. Instalar o Node JS;
2. Executar o comando: npm install
3. Executar o comando: ng serve

OBS: As configurações do front (\BarDg\bar-dg-front\src\environments\environment.ts) não precisam ser alteradas, apenas se desejado.

# Informações

## _Caminhos:_

- Link API: https://localhost:44399/doc/index.html
- Link Front: http://localhost:4200/

## _Arquitetura:_

Foi utilizada uma arquitetura Hexagonal.

## __Front-End Angular__

![Front-End](https://github.com/felidan/BarDG/blob/master/Img/front.JPG)

## _Swagger:_

Para acessar a documentação da API, gerada pelo Swagger, é necessário incluir o pré fixo **'doc'** na URL (a API subirá automaticamente neste caminho).

#### _Exemplo:_

- https://localhost:44399/doc

#### _Documentação com Swagger:_

![Swagger doc](https://github.com/felidan/BarDG/blob/master/Img/doc.JPG)

## _Autenticação_ 

Para conseguir utilizar os serviços da API é necessário a geração de um token JWT através da controller **/Login/Login** ([controller]/[método]) passando um usuário e senha de sistema. O front-end em Angular já realiza esta autenticação utilizando o usuário e senha padrão. 

Para testar via Swagger é necessário antes utilizar o end-point citado acima para gerar um token e em seguida anexar o token no swagger clicando no botão 'Authorize' no cando superior direito. O token é valido durante 30 minutos.

Parâmetros do Swagger para a autenticação:
{
  "Id": 1,
  "Login": "BARDG",
  "Senha": "BAR01",
  "Ativo": true
}

![Autenticação](https://github.com/felidan/BarDG/blob/master/Img/aut.JPG)

## _Logs_

- A API possui uma implementação para controle de erros internos, onde os logs, stack trace, data, objeto são inseridos no banco de dados na tabela **TbBDG_Log**

## _Conceitos utilizados_

- API - .Net Core 2.2 
- Angular 9
- Arquitetura Hexagonal
- Autenticação do JWT (Json Web Token)
- Documentação com Swagger
- Dapper
- Fluent Map
- Auto Mapper
- Banco de dados SQL Server
- IoC
- Testes unitários