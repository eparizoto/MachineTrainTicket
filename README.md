#Train Ticket Machine
====================
You are asked to write code to support the user interface of a train ticket machine.
You will not be writing any actual User Interface code.
But you should develop a search algorithm to help the user entering the name of a station.
The machine has a touchscreen display which works as follows.
As the user types each character of the station’s name on the touchscreen, the display should:
	Update to show all valid choices for the next character 
	List of possible matching stations.
	
The illustration below shows what is needed when ‘D A R T’ has been entered.


User input: D A R T __
 
|   |   |   |   |   |   |
| --- | --- | --- | --- | --- | --- | 
| A | B | C | D | E | DARTFORD  |
| F | G | H | I | J | DARTMOUTH |
| K | L | M | N | O |
| P | Q | R | S | T |
| U | V | W | X | Y |
| Z |   |   |   |   |

Expected Scenarios:

Given a list of stations ‘DARTFORD’, ‘DARTMOUTH’, ‘TOWER HILL’, ‘DERBY’
When input ‘DART’
Then should return:
The characters of ‘F’, ‘M’
The stations ‘DARTFORD’, ‘DARTMOUTH’.

Given a list of stations  ‘LIVERPOOL’, ‘LIVERPOOL LIME STREET’, ‘PADDINGTON’
When input ‘LIVERPOOL’ 
Then should return:
The characters of ‘ ‘
The stations ‘LIVERPOOL’, ‘LIVERPOOL LIME STREET’

Given a list of stations ‘EUSTON’, ‘LONDON BRIDGE’, ‘VICTORIA’ 
When input ‘KINGS CROSS’
Then the application will return: 
no next characters 
no stations
 
Requirements:
Typing a search string will return: 
All stations that start with the search string;
All valid next characters for each matched station;
Runtime speed is very important;
A space is a valid character when returning a list of next characters;
You don’t need to go overboard with your station list in your tests. A small enough list of stations to adequately test each condition will suffice
Not Required:
A fast loading time is not required at start-up, runtime performance takes priority;
This will be run on a dedicated machine designed for the purpose;
The application will be used by a single user at a time. There’s no need to code for concurrency;
No code is required for reading the stations from a data store; 
You may stub the station list or mock a station reader in your tests, whichever you feel represents the best real world solution;


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

