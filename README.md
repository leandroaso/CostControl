# CostControl

- CRUD básico simulando um pequeno sistema de controle de custos.
# Tecnologias utilizadas
- .Net Core Web API
- Angular 7

# Patterns e features do sistema
> Backend
- Domain Notifications
- Fail-fast validations
- Anticorruption Layer
- Entity Framework Core
- Migrations
- Fluent Mapping
- Repository Pattern
- Service Pattern
- Separação em camadas
- Autenticação com JWT

> Frontend
- Reactive Forms
- Angular Routes
- Services
- Interceptor
- Gerenciamento de localstorage para armazenar token
- Inserção de token em todas as requisições
- Bootstrap
- TypeScript

> Framework Frontend
- Coreui: https://coreui.io/angular/


# Instalação

> Aplicação backend
- Ajustar connectionstrings no arquivo Settings.cs(Projeto CostControl.Shared).
- Executar migrations no projeto CostControl.Infra; comando: "update-database"


> Aplicação frontend
- Digitar no prompt, o seguinte comando para instalar os pacotes necessários:
```javascript
npm i
```
- Digitar no prompt, o seguinte comando para iniciar a aplicação:
```javascript
npm run start
```

# Uso

> Login
- Username: admin
- Password: 123456