## O que é CRUD?
CRUD é a composição da primeira letra de 4 funções básicas de um sistema que trabalha com banco de dados:

✅ C: Create (criar) - criar um novo registro

👁 R: Read (ler) - ler (exibir) as informações de um registro

♻️ U: Update (atualizar) - atualizar os dados do registro

❌ D: Delete (apagar) - apagar um registro

Por exemplo, se você precisa desenvolver desde uma simples agenda telefônica até um sistema complexo de gestão de faturamento de pedidos, você precisará realizar essas 4 ações para manipular as tabelas do banco de dados de seu sistema.

Do ponto de vista do desenvolvedor, ele precisará criar as tabelas (modelos) do banco de dados, funções (controles) que atualizarão o banco de dados e as interfaces (visões), como página web ou aplicativo mobile, em que os usuários irão interagir com os dados. 

Em sistemas mais sofisticados, os dados do CRUD podem ser manipulados por outros sistemas via API - Application Programming Interface (em tradução livre, “Interface de Programação de Aplicativos”).

## SOBRE O PROJETO
Trata-se de uma API que realizei para aplicar e treinar meus conhecimentos em tecnologias, conceitos e princípios: REST, Clean Code e SOLID.<br><p>
  
Ela é uma idealização de uma rede Social de Games, onde consiste em:<br><p>
  
+ CRUD - Usuário ou Player<br>
  Mais um EndPoint de atualização de status por um ADMIN,<br>
+ CRUD - Console ou Platform,<br>
+ CRUD - Jogo ou Game, o Jogo é vinculado a um Console<br>
  Mais um EndPoint que busca todos os Jogos de um referente Console por Id,<br>
+ CRUD - Meus Jogos ou MyGame, onde uni o Jogador com os Jogos que ele possue<br>
  Mais um EndPoint que busca todos os Jogos de um Jogador especificado por Id,<br>
+ CRUD - Comentários ou Comment, onde uni um Jogador e um Jogo a um Comentário<br>
  Mais um EndPoint de busca por Jogo especificando um Id<br>
  Mais um EndPoint de busca por Jogador especificando um Id.<br><p>
    
Essa API foi desenvolvida em:<br>
**.NET Framework 4.8**<br>
utilizando:<br> 
*Entity Framework*,<br>
*SQL Server*,<br>
*IoC - Unity*,<br>
*Autenticação por OAuth*,<br>
*Pagination*<br>

<p><img src="https://github.com/juliodive/api-social-games/blob/master/img/006.PNG" width="250" height="300" alt="API Social Games" title="API Social Games">
<img src="https://github.com/juliodive/api-social-games/blob/master/img/001.PNG" width="400" height="300" alt="API Social Games" title="API Social Games"></p>
<p><img src="https://github.com/juliodive/api-social-games/blob/master/img/002.PNG" width="400" height="300" alt="API Social Games" title="API Social Games">
<img src="https://github.com/juliodive/api-social-games/blob/master/img/003.PNG" width="400" height="300" alt="API Social Games" title="API Social Games"></p>

## COMO RODAR O PROJETO

### CONFIGURANDO DATABASE:
Deve alterar a String de Conexão em Web.config<br><p>
Depois:<br>
>dotnet update-database --project SocialGames.Infra

### INICIAR O PROJETO:
>
Execute o comando para rodar o projeto:
>dotnet run --project SocialGames.Api

## DOCUMENTAÇÃO
Para ter acesso aos endpoints criados, utilizando Pastman,<br>
use ferramenta de import e entre o link: https://www.getpostman.com/collections/ad309759374c39648e69

