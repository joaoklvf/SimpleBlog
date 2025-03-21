# Simple Blog - Teste Prático C#

Sistema básico de blog desenvolvido como parte de um teste prático. Permite que usuários visualizem, criem, editem e excluam postagens. O projeto segue princípios de orientação a objetos e SOLID, utiliza Entity Framework para manipulação de dados e implementa WebSockets para notificações em tempo real.

## Requisitos Funcionais

- Autenticação: Usuários podem se registrar e fazer login.
- Gerenciamento de Postagens: Usuários autenticados podem criar, editar e excluir suas próprias postagens.
- Visualização de Postagens: Qualquer visitante pode visualizar as postagens existentes.
- Notificações em Tempo Real: Quando uma nova postagem é criada, uma notificação é enviada via WebSockets.

## Requisitos Técnicos

- Arquitetura monolítica organizando autenticação, gerenciamento de postagens e notificações.
- Princípios SOLID aplicados, especialmente SRP e DIP.
- Uso do Entity Framework para interação com o banco de dados.
- Implementação de WebSockets para notificações em tempo real.
- Não inclui interface web.

## Configuração do Projeto

### Configuração do Banco de Dados
No arquivo `appsettings.json`, configurar a string de conexão com o SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=SimpleBlogDB;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```

### Aplicar Migrações
A migração inicial está localizada em `SimpleBlog.Infra.Data -> Migrations`. Para aplicá-la e criar o banco de dados:
```sh
dotnet ef database update
```

### Executar a Aplicação
Para rodar o projeto:
```sh
dotnet run
```
A API estará disponível na porta configurada no `appsettings.json`.

### Verificação das notificações
É possível visualizar e testar a comunicação websocket com a página deixada na `wwwroot` e fazendo requisições na rota `/ws`

## Tecnologias Utilizadas

- C#
- .NET
- Entity Framework Core
- SQL Server
- WebSockets

## Estrutura do Projeto
```
SimpleBlog/
├── 2 - Services/SimpleBlog.Api/           
├── 3 - Application/SimpleBlog.Application/   
├── 4 - Domain/SimpleBlog.Domain/        
├── 5 - Infra/5.1 - Data/SimpleBlog.Infra.Data/         
├── 5 - Infra/5.2 - CrossCutting/SimpleBlog.Infra.CrossCutting.Bus/
├── 5 - Infra/5.3 - CrossCutting/SimpleBlog.Infra.CrossCutting.IoC/  
└── SimpleBlog.Tests/ (não implementada)         
```

## Funcionalidades Futuras
- Implementação de interface web.
- Melhorias no sistema de notificação.
- Suporte a categorias para as postagens.

