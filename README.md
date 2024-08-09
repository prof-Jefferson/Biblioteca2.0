# Biblioteca 2.0

## Introdução

O projeto Biblioteca 2.0 foi desenvolvido com o objetivo de ensinar os conceitos básicos de Programação Orientada a Objetos (POO) de forma prática e aplicada. Este projeto simula o funcionamento de uma biblioteca, onde é possível gerenciar livros, empréstimos e devoluções.

## Conceitos de Programação Orientada a Objetos (POO)

### 1. Interface
   **Definição:** Uma interface define um contrato que as classes devem seguir. Em outras palavras, ela especifica métodos que uma classe deve implementar, mas não fornece a implementação desses métodos.

   **Aplicação no Projeto:** No projeto Biblioteca 2.0, a interface `IBiblioteca` define métodos que todas as classes relacionadas à biblioteca devem implementar, como `AdicionarLivro`, `RemoverLivro`, e `PesquisarLivro`.

### 2. Polimorfismo
   **Definição:** O polimorfismo permite que objetos de diferentes classes sejam tratados como objetos de uma classe comum, geralmente através de uma interface ou de uma classe base comum. Isso permite que um mesmo método possa ter diferentes implementações dependendo do tipo do objeto.

   **Aplicação no Projeto:** No projeto, o polimorfismo é utilizado ao implementar diferentes tipos de livros, como `LivroFisico` e `LivroDigital`, que herdam de uma classe base `Livro`. Assim, métodos que manipulam objetos do tipo `Livro` podem trabalhar com qualquer tipo de livro, físico ou digital, sem a necessidade de conhecer detalhes específicos de cada tipo.

### 3. Classe Abstrata
   **Definição:** Uma classe abstrata é uma classe que não pode ser instanciada diretamente e que pode conter métodos com ou sem implementação. Classes que herdam de uma classe abstrata são obrigadas a implementar seus métodos abstratos.

   **Aplicação no Projeto:** No projeto, a classe `Usuario` é abstrata, representando um usuário genérico da biblioteca. Classes como `UsuarioAluno` e `UsuarioProfessor` herdam de `Usuario` e implementam métodos específicos para cada tipo de usuário.

### 4. Métodos Estáticos e Dinâmicos
   **Definição:** Métodos estáticos são aqueles que pertencem à classe e não a uma instância específica. Eles podem ser chamados sem criar um objeto da classe. Métodos dinâmicos, por outro lado, são associados a instâncias específicas de uma classe.

   **Aplicação no Projeto:** No projeto, métodos estáticos são usados, por exemplo, para validar o formato de ISBN de um livro, já que essa validação não depende de uma instância específica. Métodos dinâmicos são utilizados para ações como `EmprestarLivro`, que dependem do estado específico do objeto `Usuario`.

### 5. Manipulação de Arquivos
-    **Escrita:** Aqui faremos escrita em arquivos JSON.    
-    **Leitura:** Aqui faremos leitura em arquivos JSON.

## 6. Estrutura do Projeto

- **Biblioteca.cs**: a definir`.

### 7. Conclusão
    **Não se trata de um sistema funcional, é apenas um recurso didático educativo.**

#########################################

### 8. APÊNDICE
### Comandos Importantes

- **Instalando o SDK .NET 8.0 (GNU/Linux)**: 
dotnet --version
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0
dotnet --version

- **Criando o Projeto**
Entre na pasta onde será criado o projeto: cd /caminho/para/seu/projeto
Execute o Comando para criar o projeto: dotnet new console -n Biblioteca20 --use-program-main
Adicione o pacote responsável por manipular arquivos JSON: dotnet add package Newtonsoft.Json

### 9. Estrutura de Diretórios
Biblioteca20/
│
├── Biblioteca20.csproj
├── Program.cs
├── appsettings.json
├── README.md
│
├── Data/
│   ├── livros.json
│   ├── clientes.json
│   └── emprestimos.json
│
├── Entities/
│   ├── Livro.cs
│   ├── Cliente.cs
│   ├── Pessoa.cs
│   ├── Funcionario.cs
│   └── Emprestimo.cs
│
├── Interfaces/
│   └── IPessoa.cs
│
└── Services/
    ├── GerenciadorDeArquivo.cs //vou colocar os alunos para fazer. ¬¬
    └── Biblioteca.cs
