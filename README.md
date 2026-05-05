# API - Taxa de Juros

[![License](https://img.shields.io/github/license/grecojoao/InterestRates)](https://github.com/grecojoao/InterestRates/blob/master/LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)

## ⚡ Sobre o projeto

API Taxa de Juros é uma aplicação back-end desenvolvida em ASP.NET Core para fornecer a taxa de juros padrão a outras aplicações.

A aplicação disponibiliza o endpoint `/taxajuros` que retorna a taxa de juros de **1% (0.01)**.

### 🔗 Endpoints

- **GET** `/taxajuros` - Retorna a taxa de juros padrão (0.01)
- **Swagger UI** - Documentação interativa da API disponível em `/swagger`

## 🚀 Tecnologias

- **C# / .NET 10.0**
- **ASP.NET Core Web API**
- **Swagger/OpenAPI** - Documentação da API
- **Docker** - Containerização
- **xUnit** - Testes unitários

## 📋 Pré-requisitos

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) ou superior
- [Docker](https://www.docker.com/) (opcional, para execução em container)

## 🔧 Como executar o projeto

### Executando localmente

```bash
# Clonar o repositório
git clone https://github.com/grecojoao/InterestRates.git

# Entrar na pasta da API
cd InterestRates/InterestRates.API

# Restaurar as dependências
dotnet restore

# Executar o projeto
dotnet run

# Ou executar com hot reload
dotnet watch run
```

A API estará disponível em:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger: `http://localhost:5000/swagger`

### Executando com Docker

```bash
# Construir a imagem
docker build -t interestrates-api -f InterestRates.API/Dockerfile .

# Executar o container
docker run -p 5000:8080 interestrates-api
```

Ou usando a imagem publicada:

```bash
# Baixar e executar a imagem
docker pull grecojoao/interestratesapi
docker run -p 5000:8080 grecojoao/interestratesapi
```

## 🧪 Executando os testes

```bash
# Executar todos os testes
dotnet test

# Executar testes com cobertura
dotnet test /p:CollectCoverage=true
```

## 📦 Estrutura do projeto

```
InterestRates/
├── InterestRates.API/          # Projeto principal da API
│   ├── Controllers/            # Controllers da API
│   ├── Program.cs              # Configuração e inicialização
│   └── Dockerfile              # Configuração Docker
├── InterestRates.Tests/        # Projeto de testes unitários
└── InterestRates.sln           # Solution do projeto
```

## 🌐 Implantação em produção

- [Microsoft Azure](https://interestrates.azurewebsites.net/swagger) - Ambiente de produção

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## ✨ Melhorias implementadas

- ✅ Atualizado para .NET 10.0
- ✅ Migrado para minimal hosting model
- ✅ Pacotes atualizados para versões mais recentes
- ✅ Testes unitários com alta cobertura
- ✅ Documentação aprimorada
- ✅ .gitignore completo e atualizado
