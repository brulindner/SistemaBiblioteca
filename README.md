# 📚 Sistema de Gerenciamento de Biblioteca

Este projeto é uma **API REST** desenvolvida em **C# com .NET** e integrada ao **MySQL** através do **Entity Framework Core**, criada para praticar e consolidar conceitos de backend, orientação a objetos e organização de aplicações.

## 🚀 Tecnologias Utilizadas
- C# / .NET 8
- MySQL
- Entity Framework Core
- REST API

## ⚙️ Funcionalidades
- 📘 **Cadastro de alunos**
  - Inserir, listar, atualizar e remover alunos
  - Cada aluno possui matrícula e informações pessoais
- 📚 **Gerenciamento de livros**
  - Inserir, listar, atualizar e remover livros
- ⏳ **Controle de empréstimos**
  - Registrar empréstimos de livros para alunos
  - Listar e gerenciar empréstimos ativos
- 💾 **Persistência em MySQL com Entity Framework**
  - Mapeamento objeto-relacional (ORM)
  - Garantia de integridade e persistência dos dados

## 📂 Estrutura do Projeto
- **Controllers/** → Controladores da API (Alunos, Livros, Empréstimos)  
- **Models/** → Modelos de dados da aplicação  
- **Program.cs** → Configuração inicial da aplicação, conexão com MySQL e Entity Framework  

## ▶️ Como Executar
1. Clone este repositório:
   ```bash
   git clone https://github.com/brulindner/SistemaBiblioteca.git
   
2. Configure a connection string no arquivo Program.cs para o seu banco MySQL.
   
3. Execute as migrations (se estiver utilizando EF Core):
   ```dotnet ef database update```

4. Rode o Projeto
   ```dotnet run```

5. Acesse os endpoints via navegador ou Postman.

📌 Exemplos de Endpoints
👩‍🎓 Alunos

GET /aluno → Lista todos os alunos
GET /aluno/{id} → Retorna um aluno pelo ID
POST /aluno → Cadastra um novo aluno

{
  "matricula": "2025001",
  "nome": "Maria Silva",
  "cpf": "12345678900",
  "telefone": "99999-9999"
}

PUT /aluno/{id} → Atualiza os dados de um aluno
DELETE /aluno/{id} → Remove um aluno

📚 Livros

GET /livro → Lista todos os livros
GET /livro/{id} → Retorna um livro pelo ID
POST /livro → Cadastra um novo livro

{
  "titulo": "O Senhor dos Anéis",
  "autor": "J.R.R. Tolkien",
  "genero": "Aventura"
}

PUT /livro/{id} → Atualiza os dados de um livro
DELETE /livro/{id} → Remove um livro

⏳ Empréstimos

GET /emprestimo → Lista todos os empréstimos
GET /emprestimo/{id} → Retorna um empréstimo pelo ID
POST /emprestimo → Registra um novo empréstimo

{
  "alunoId": 1,
  "livroId": 2,
  "dataEmprestimo": "2025-09-20",
  "dataDevolucao": "2025-10-20"
}

PUT /emprestimo/{id} → Atualiza um empréstimo
DELETE /emprestimo/{id} → Remove um empréstimo
 
✨ Desenvolvido para estudos e prática de backend.
