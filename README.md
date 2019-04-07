#Train Ticket Machine
====================

Versões e softwares utilizados
==============================
O projeto foi desenvolvido em C#, .NET 4.5.2 utilizando o Microsoft Visual Studio Community 2015 versão 14.0.25123.00 Update 2.
A documentação do projeto foi feita com o Doxygen versão 1.8.12. 

A estrutura de diretórios do projeto está dividido da seguinte maneira:

1 - Pasta MachineTrainTicket - Projeto com a implementação da solução pedida.
Separei os fontes do projeto MachineTrainTicket em 3 pastas:

- Model => Nesta pasta encontra-se o arquivo MyModel.cs que representa a camada que acessa o BD para buscar as estações disponíveis.

- View => Nesta pasta encontra-se o arquivo MyView.cs que representa a camada de exibição da interface do usuário.
Desenvolvi uma UI simples, apenas exibindo mensagens no prompt de comando, pois o segundo item do exercício deixava explicito a não obrigatoriedade de escrita de uma UI.

- Controller => Nesta pasta encontra-se o mecanismo de busca das estações. Desenvolvi um método que analisa cada letra digitada pelo usuário e já retorna o resultado da busca executada.


2 - MachineTrainTicketTests - Projeto com alguns unit tests.
Nesta pasta encontra-se o projeto com alguns unit tests para testar o algorítmo de busca das estações e os primeiros caractere das próximas estações disponíveis.


3 - Documentation
Nesta pasta encontra-se o seguinte:
- arquivo do exercício proposto: Csharp Development - Train v2.2.docx
- pasta Doxygen:
	Contém a pasta html que possui os arquivos .html do doxygen gerado.
	Arquivo Doxyfile que contém as configurações para a geração da documentação do Doxygen
	Atalho index.html - Atalho onde ao clicar, a documentação do source code é aberta em um browser.
	logo.jpg - arquivo que montei apenas imagens da internet para ilustrar a documentação.


4 - Arquivo MachineTrainTicket.sln
Arquivo de projeto da solução.

5- Pasta Binaries
Nesta pasta encontra-se o binário (executável) de exemplo da implementação da solução (MachineTrainTicket.exe)

