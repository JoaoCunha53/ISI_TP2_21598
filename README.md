
# Desenvolvimento SOAP e RESTful

Este projeto foi desenvolvido no âmbito da disciplina de **Integração de Sistemas de Informação (ISI)** e visa demonstrar a aplicação prática de arquiteturas baseadas em **Web Services SOAP**, **APIs REST** e integração com **bases de dados SQL Server**. O principal objetivo é oferecer uma solução segura e eficiente para **gestão de projetos**, com foco nas necessidades de pequenas e médias empresas (PMEs).

## 📝 Enquadramento

O projeto aborda desafios comuns enfrentados por PMEs na modernização e digitalização de processos, propondo:
- Uma arquitetura que utiliza **SOAP** para a comunicação direta com a base de dados.
- **REST** como intermediário seguro entre o cliente e o serviço SOAP.
- Um modelo de dados eficiente baseado em **SQL Server**.

## 🚀 Funcionalidades

### Endpoints SOAP
- **GetAllProjects**: Obtém todos os projetos.
- **GetProjectById**: Procura um projeto pelo seu ID.
- **AddProject**: Cria um novo projeto.
- **UpdateProject**: Atualiza um projeto existente.
- **DeleteProject**: Remove um projeto.
- **Login**: Realiza autenticação de usuários.

### Endpoints REST
- **/api/ObterProjetos**: Lista todos os projetos.
- **/api/ObterProjetos/{id}**: Obtém um projeto pelo ID.
- **/api/CriarNovoProjeto**: Adiciona um novo projeto.
- **/api/AtualizarProjeto/{id}**: Atualiza um projeto existente.
- **/api/EliminarProjeto/{id}**: Remove um projeto.
- **/api/SingIn**: Realiza login e retorna um token de autenticação.

## 🛠️ Arquitetura

1. **Web Service SOAP**
   - Gerencia toda a comunicação direta com o banco de dados.
   - Mantém os dados críticos protegidos do cliente final.

2. **API REST**
   - Atua como intermediário entre o cliente e o serviço SOAP.
   - Oferece métodos **GET**, **POST**, **PUT** e **DELETE** para manipulação dos dados.

3. **Base de Dados**
   - Baseado em **SQL Server** com interação via `System.Data.SqlClient`.
   - Strings de conexão armazenadas no arquivo `web.config` para maior segurança.

## 📊 Modelo de Dados

O sistema é composto por dois principais objetos:
- **Projects**: Gerencia os dados dos projetos.
- **Users**: Gerencia os dados dos usuários.

O diagrama ERD está disponível no projeto para consulta.

## 📚 Documentação

Para mais informações sobre as tecnologias utilizadas:
- [SOAP Web Services](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/webservices/soap-web-services)
- [RESTful API Design](https://learn.microsoft.com/pt-pt/azure/architecture/best-practices/api-design)
- [SQL Server](https://learn.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver16)

## ✍️ Conclusão

O projeto demonstrou com sucesso a integração de diferentes tecnologias para a criação de um sistema seguro e eficiente. A experiência proporcionou um aprendizado significativo sobre as melhores práticas de design e implementação de arquiteturas **SOAP** e **REST**.

---

### Autor
João Rafael Azevedo Cunha - a21598
