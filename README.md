# Arizo [Em andamento]

## Descrição
- Arizo é um projeto solo desenvolvido em C# que tem como objetivo apenas treinar minhas habilidades com o ecossistema .NET e entre outras coisas. Deixo-o livre e open-source para qualquer comunidade não somente usufruir e aprender, mas também contribuir para que mais pessoas aprendam.
- Por ser uma tecnologia open-source, vou documentar aqui e listar tudo o que ele tem para que não percas tempo em olhar manualmente o código-fonte.

## Tecnologias Utilizadas
- **Linguagem de Programação:** C#
- **Framework:** .NET Core (Console)
- **Banco de Dados:** PostgreSQL
- **Cache:** Redis
- **ORM:** Entity Framework Core
- **IDE:** Visual Studio Code
- **Controle de Versão:** Git
- **Outras Ferramentas:** 
    - Docker
    - Biblioteca Telegram.Bot (Nuget)
    - Testes unitários (Em andamento)

## Comandos
1. /start - inicializa o bot
2. /help - autoexplicativo, envia documentação de ajuda
3. /prof - autoexplicativo, mostra as informações do perfil
4. /col (com seus devidos filtros por série, imagem)
5. /wishlist - cada usuário tem apenas uma lista
6. /drop_card - descarta uma carta, retorna 'X' moedas baseada no peso.
7. /daily - autoexplicativo, recompensa diária
8. /recompensa - resgata recompensa específica (útil em eventos, etc)
9. /shop - lojinha do bot
10. /serie &  /card (cartas, obras e subobras por ID e nome, com filtros inclusos)
11. /afc - 'Ask for collection', pedir para adicionar uma coleção específica no bot
12. /events - Lista eventos ativos
13. /hist - Histórico de giros, o que ganhou nos últimos 10 giros
14. /gg - 'Give Gift', você pode enviar um presente (card) para um colega
15. /tc - 'Trade Cards', autoexplicativo, troca cartas com outro usuário
16. /afg - 'Ask For Gif', você pode pedir para adicionar um gif personalizado ao seu "cativeiro". Condições: Ter ao menos 40 cards repetidas.
17. /rank - Autoexplicativo. Ranking dos top 10 usuários com melhores status.
18. /cr - 'Capitivity Rank', ranking de cativeiros, baseado na consulta por uma carta específica.
19. /rpc - 'Rock, Paper and Scissor', jogo de pedra, papel e tesoura contra o bot para você ganhar pontos, giros e coins. Você tem 3 tentativas de vencer! 

## Painel administrativo
- Por questões de praticidade, decidi incluir um painel ligado ao bot.
- - O painel irá incluir tudo o que um admin pode fazer, desde criar cartas, séries, subséries, usuários, dar itens para o usuário (cards, points, coins, etc), criar eventos e também poderá ter, visualmente, um feedback sobre os rankings e entre outras informações dos usuários.
- "Mas por quê?" - E eu repito: Praticidade. Cadastrar via bot no Telegram é uma porcaria, você pode haver um mistext, erro ao enviar a mensagem, questões de separadores, tudo isso é uma porcaria de lidar. Mas não se preocupe, tudo isso será incluso como um mini app dentro do bot, e você não vai precisar guardar URLs e nem entrar em sites fora do Telegram.

## Eventos
- Os eventos já existiram desde sempre, porém eu decidi fazer, novamente, de um jeito prático. Agora os eventos permitem você concluir tarefas sem ter a necessidade de esperar receber o prêmio. Entrou no evento => concluiu a tarefa => sistema verifica => automaticamente recebe o prêmio.
- Os eventos poderão ser de qualquer coisa, poderão ter a quantidade de tarefas e prêmios que for, e terá uma duração personalizada.

## Instalação e Configuração
- Em breve um tutorial.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está licenciado sob a Licença BSD. Veja o arquivo `LICENSE` para mais detalhes.

## Contato
Para mais informações, entre em contato comigo: https://t.me/adorabat
