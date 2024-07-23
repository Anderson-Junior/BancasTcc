# Gerenciador de Bancas de TCC

## Sobre o Projeto

Este é o projeto de TCC da faculdade, cujo tema é "Gerenciador de Bancas de TCC". O objetivo é controlar bancas de TCC, agendando, controlando temas, turmas, alunos, convites de professores e avaliação dos projetos.

## Funcionalidades

- **Cadastro, atualização, deleção e listagem** de usuários (professor, orientador, coordenador e administrador), instituição, filial, bancas, curso, tema, turma.
- **Envio de convites** aos professores via email para participarem das bancas de TCC, com a possibilidade de aceitarem ou recusarem.
- **Controle de acesso** com base na role do usuário, gerenciando as rotas que cada usuário pode acessar no controller.
- **Sistema de login** utilizando .NET Identity.
- **Cadastro de formulários** utilizados pelos professores para avaliação dos projetos dos alunos nas bancas.
- **Envio de emails** via SMTP.

## Tecnologias Utilizadas

- .NET Core 5
- Razor
- EntityFrameworkCore
- Sistema de login do .NET Identity
- SmtpClient
- SQL Server